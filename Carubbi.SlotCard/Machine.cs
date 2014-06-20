using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;
using System.Threading;

namespace Carubbi.SlotCard
{
    public class Machine
    {
        public event EventHandler OnCreditsAltered;
        public event EventHandler OnSpin;
        public event EventHandler OnPlay;
        public event PriceHandler OnPayPrice;

        public List<Roullete> Roulletes { get; private set; }

        protected int _credits;

        public int Credits
        {
            get
            {
                return _credits;
            }
            set
            {
                _credits = value;
                if (OnCreditsAltered != null)
                    OnCreditsAltered(this, EventArgs.Empty);

            }
        }


        public string Mode
        {

            get
            {
                return _payer.IsInDeliverMode ?
                    string.Format("Devolução ({0})", _payer.GamesInDeliverMode) :
                    string.Format("Coleta ({0})", _payer.GamesInCollectMode);
            }
        }

        


        public Machine()
        {
            Roulletes = new List<Roullete>(5);
            for (int i = 0; i < Roulletes.Capacity; i++)
                Roulletes.Add(new Roullete());
            
            Random randomTime = new Random();
            Thread.Sleep(randomTime.Next(0, 100));
            _deck1 = new Deck(1, true);
            Thread.Sleep(randomTime.Next(0, 100));
            _deck2 = new Deck(1, true);
            Thread.Sleep(randomTime.Next(0, 100));
            _deck3 = new Deck(1, true);

            _payer = new Payer();
            _payer.OnPayPrice += new PriceHandler(_payer_OnPayPrice);
            PercentGain = 80;
            TotalCoinsReceived = 10000;

        }

        void _payer_OnPayPrice(object sender, PriceEventArgs e)
        {
            if (OnPayPrice != null)
                OnPayPrice(this, e);
        }

        public int LinesEnableds { get; private set; }

        public int CoinsCollecteds { get; private set; }



        public int TotalGamesPlayeds { get; private set; }

        public int TotalCoinsReceived { get; private set; }
        public int TotalCoinsReturneds { get; private set; }

        public int CoinsInGame { get; private set; }

        public decimal PercentGain { get; set; }

        private Deck _deck1;
        private Deck _deck2;
        private Deck _deck3;

        private Payer _payer;

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

            foreach (Roullete r in Roulletes)
                r.Spin(_deck1, _deck2, _deck3);
            if (OnSpin != null)
            {
                OnSpin(this, EventArgs.Empty);
            }

        }

        public List<Line> ReadLines(List<Roullete> roulletes)
        {
            List<Line> linesToRead = new List<Line>(LinesEnableds);

            if (LinesEnableds >= 1)
            {
                Line l = new Line();
                l.Cards.Add(roulletes[0].Slot2);
                l.Cards.Add(roulletes[1].Slot2);
                l.Cards.Add(roulletes[2].Slot2);
                l.Cards.Add(roulletes[3].Slot2);
                l.Cards.Add(roulletes[4].Slot2);
                linesToRead.Add(l);
            }

            if (LinesEnableds >= 2)
            {
                Line l = new Line();
                l.Cards.Add(roulletes[0].Slot1);
                l.Cards.Add(roulletes[1].Slot1);
                l.Cards.Add(roulletes[2].Slot1);
                l.Cards.Add(roulletes[3].Slot1);
                l.Cards.Add(roulletes[4].Slot1);
                linesToRead.Add(l);
            }

            if (LinesEnableds >= 3)
            {
                Line l = new Line();
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
            this.Credits -= CoinsInGame;
            TotalCoinsReceived += CoinsInGame;
            TotalGamesPlayeds++;

            CoinsCollecteds = 0;
            List<Line> lines = new List<Line>(LinesEnableds);
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
            return this.Credits / linesCount;
        }
    }
}
