using System;
using System.Collections.Generic;
using System.Threading;
using Carubbi.Cards;

namespace Carubbi.SlotCard
{
    public class Machine
    {
        protected int _credits;

        private readonly Deck _deck1;
        private readonly Deck _deck2;
        private readonly Deck _deck3;

        private readonly Payer _payer;


        public Machine()
        {
            Roulletes = new List<Roullete>(5);
            for (var i = 0; i < Roulletes.Capacity; i++)
                Roulletes.Add(new Roullete());

            var randomTime = new Random();
            Thread.Sleep(randomTime.Next(0, 100));
            _deck1 = new Deck(1, true);
            Thread.Sleep(randomTime.Next(0, 100));
            _deck2 = new Deck(1, true);
            Thread.Sleep(randomTime.Next(0, 100));
            _deck3 = new Deck(1, true);

            _payer = new Payer();
            _payer.OnPayPrice += _payer_OnPayPrice;
            PercentGain = 80;
            TotalCoinsReceived = 10000;
        }

        public List<Roullete> Roulletes { get; }

        public int Credits
        {
            get => _credits;
            set
            {
                _credits = value;
                if (OnCreditsAltered != null)
                    OnCreditsAltered(this, EventArgs.Empty);
            }
        }


        public string Mode => _payer.IsInDeliverMode
            ? string.Format("Devolução ({0})", _payer.GamesInDeliverMode)
            : string.Format("Coleta ({0})", _payer.GamesInCollectMode);

        public int LinesEnableds { get; private set; }

        public int CoinsCollecteds { get; private set; }


        public int TotalGamesPlayeds { get; private set; }

        public int TotalCoinsReceived { get; private set; }
        public int TotalCoinsReturneds { get; private set; }

        public int CoinsInGame { get; private set; }

        public decimal PercentGain { get; set; }
        public event EventHandler OnCreditsAltered;
        public event EventHandler OnSpin;
        public event EventHandler OnPlay;
        public event PriceHandler OnPayPrice;

        private void _payer_OnPayPrice(object sender, PriceEventArgs e)
        {
            if (OnPayPrice != null)
                OnPayPrice(this, e);
        }

        private void ResetDeck(Deck deck)
        {
            deck.Fill();
            deck.Shuffle(false);
        }

        private void Spin()
        {
            ResetDeck(_deck1);
            ResetDeck(_deck2);
            ResetDeck(_deck3);

            foreach (var r in Roulletes)
                r.Spin(_deck1, _deck2, _deck3);
            if (OnSpin != null) OnSpin(this, EventArgs.Empty);
        }

        public List<Line> ReadLines(List<Roullete> roulletes)
        {
            var linesToRead = new List<Line>(LinesEnableds);

            if (LinesEnableds >= 1)
            {
                var l = new Line();
                l.Cards.Add(roulletes[0].Slot2);
                l.Cards.Add(roulletes[1].Slot2);
                l.Cards.Add(roulletes[2].Slot2);
                l.Cards.Add(roulletes[3].Slot2);
                l.Cards.Add(roulletes[4].Slot2);
                linesToRead.Add(l);
            }

            if (LinesEnableds >= 2)
            {
                var l = new Line();
                l.Cards.Add(roulletes[0].Slot1);
                l.Cards.Add(roulletes[1].Slot1);
                l.Cards.Add(roulletes[2].Slot1);
                l.Cards.Add(roulletes[3].Slot1);
                l.Cards.Add(roulletes[4].Slot1);
                linesToRead.Add(l);
            }

            if (LinesEnableds >= 3)
            {
                var l = new Line();
                l.Cards.Add(roulletes[0].Slot3);
                l.Cards.Add(roulletes[1].Slot3);
                l.Cards.Add(roulletes[2].Slot3);
                l.Cards.Add(roulletes[3].Slot3);
                l.Cards.Add(roulletes[4].Slot3);
                linesToRead.Add(l);
            }

            return linesToRead;
        }

        public void Play(int coinsPerLine, int linesEnableds)
        {
            LinesEnableds = linesEnableds;
            CoinsInGame = coinsPerLine * linesEnableds;
            Credits -= CoinsInGame;
            TotalCoinsReceived += CoinsInGame;
            TotalGamesPlayeds++;

            CoinsCollecteds = 0;
            var lines = new List<Line>(LinesEnableds);
            do
            {
                Spin();
                lines = ReadLines(Roulletes);
            } while (!_payer.ValidPay(lines, coinsPerLine, TotalCoinsReceived, TotalCoinsReturneds, PercentGain));

            CoinsCollecteds = _payer.Pay(lines, coinsPerLine);


            Credits += CoinsCollecteds;
            TotalCoinsReturneds += CoinsCollecteds;

            if (OnPlay != null)
                OnPlay(this, EventArgs.Empty);
        }


        public int CheckCreditsToPlayLines(int linesCount)
        {
            return Credits / linesCount;
        }
    }
}