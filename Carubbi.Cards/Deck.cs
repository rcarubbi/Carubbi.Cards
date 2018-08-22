using System;
using System.Collections.Generic;
using System.Threading;

namespace Carubbi.Cards
{
    public class Deck : CardSet
    {
        private Random _getterShuffler;
        private readonly int _numberOfDecks;

        private readonly Random _seeder;
        private Random _shuffler;

        private readonly bool _startClosed;

        public Deck()
            : this(1)
        {
        }

        public Deck(int numberOfDecks)
            : this(numberOfDecks, true)
        {
        }

        public Deck(int numberOfDecks, bool startClosed)
        {
            _seeder = new Random();
            _startClosed = startClosed;
            _numberOfDecks = numberOfDecks;

            for (var i = 0; i < _numberOfDecks; i++)
                Fill(false);
        }

        public int GameNumber { get; private set; }

        public void Shuffle()
        {
            Shuffle(true);
        }

        public void Shuffle(bool reseed)
        {
            PrepareShuffler(reseed);
            for (var i = 0; i < Count * 100; i++) PutMiddle(GetRamdom());
        }

        public void Fill()
        {
            Fill(true);
        }

        public void Fill(bool clearBefore)
        {
            if (clearBefore)
                Clear();

            var suits = new List<Suit>();
            suits.Add(Suit.Copas);
            suits.Add(Suit.Espadas);
            suits.Add(Suit.Ouros);
            suits.Add(Suit.Paus);

            foreach (var suit in suits)
                for (var i = 1; i <= 13; i++)
                    Add(new Card(suit, i, _startClosed));
        }

        private void PrepareShuffler(bool reseed)
        {
            if (_shuffler == null || reseed)
            {
                _shuffler = null;
                GameNumber = _seeder.Next();
                _shuffler = new Random(GameNumber);
                Thread.Sleep(10);
                _getterShuffler = new Random();
            }
        }

        public void PutMiddle(Card card)
        {
            if (card != null)
            {
                PrepareShuffler(false);
                var ramdomIndex = _shuffler.Next(0, Count + 1);
                Insert(ramdomIndex, card);
            }
        }

        public Card GetRamdom()
        {
            if (!IsEmpty)
            {
                PrepareShuffler(false);
                var ramdomIndex = _getterShuffler.Next(0, Count);
                var card = this[ramdomIndex];
                RemoveAt(ramdomIndex);
                return card;
            }

            return null;
        }
    }
}