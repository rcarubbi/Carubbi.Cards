using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Carubbi.Cards
{
    public class Deck : CardSet
    {
        public Deck()
            : this(1)
        {

        }

        public Deck(int numberOfDecks)
            : this(numberOfDecks, true)
        {

        }

        private bool _startClosed;
        private int _numberOfDecks;

        public Deck(int numberOfDecks, bool startClosed)
        {
            _seeder = new Random();
            _startClosed = startClosed;
            _numberOfDecks = numberOfDecks;

            for (int i = 0; i < _numberOfDecks; i++)
                Fill(false);
        }

        private Random _seeder;
        private Random _shuffler;
        private Random _getterShuffler; 

        private int _gameNumber;
        public int GameNumber
        {
            get
            {
                return _gameNumber;
            }
        }

        public void Shuffle()
        {
            this.Shuffle(true);
        }

        public void Shuffle(bool reseed)
        {
            PrepareShuffler(reseed);
            for (int i = 0; i < this.Count*100; i++)
            {
                PutMiddle(GetRamdom());
            }
        }

        public void Fill()
        {
            Fill(true);
        }

        public void Fill(bool clearBefore)
        {
            if (clearBefore)
                this.Clear();

            List<Suit> suits = new List<Suit>();
            suits.Add(Suit.Copas);
            suits.Add(Suit.Espadas);
            suits.Add(Suit.Ouros);
            suits.Add(Suit.Paus);

            foreach (Suit suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                    this.Add(new Card(suit, i, _startClosed));
            }

        }

        private void PrepareShuffler(bool reseed)
        {
            if (_shuffler == null || reseed)
            {
                _shuffler = null;
                _gameNumber = _seeder.Next();
                _shuffler = new Random(_gameNumber);
                Thread.Sleep(10);
                _getterShuffler = new Random();
            }
        }

        public void PutMiddle(Card card)
        {
            if (card != null)
            {
                PrepareShuffler(false);
                int ramdomIndex = _shuffler.Next(0, this.Count + 1);
                this.Insert(ramdomIndex, card);
            }
        }

        public Card GetRamdom()
        {
            if (!IsEmpty)
            {
                PrepareShuffler(false);
                int ramdomIndex = _getterShuffler.Next(0, this.Count);
                Card card = this[ramdomIndex];
                this.RemoveAt(ramdomIndex);
                return card;
            }
            else
                return null;
        }

    }
}
