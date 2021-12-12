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
            for (var i = 0; i < Count * 100; i++) PutMiddle(GetRandom());
            OnCardSetChanged(new CardSetChangedEventArgs { Action = CardSetActions.DeckShuffled });
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
            suits.Add(Suit.Hearts);
            suits.Add(Suit.Spades);
            suits.Add(Suit.Diamonds);
            suits.Add(Suit.Clubs);

            foreach (var suit in suits)
                for (var i = 1; i <= 13; i++)
                    Add(new Card(suit, i, _startClosed));

            OnCardSetChanged(new CardSetChangedEventArgs { Action = CardSetActions.DeckFilled });
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
                var randomIndex = _shuffler.Next(0, Count + 1);
                Insert(randomIndex, card);
                OnCardSetChanged(new CardSetChangedEventArgs { Action = CardSetActions.CardAdded, CardIndex = randomIndex, Card = card });
            }
        }

        public Card GetRandom()
        {
            if (!IsEmpty)
            {
                PrepareShuffler(false);
                var randomIndex = _getterShuffler.Next(0, Count);
                var card = this[randomIndex];
                RemoveAt(randomIndex);
                OnCardSetChanged(new CardSetChangedEventArgs { Action = CardSetActions.CardRemoved, CardIndex = randomIndex, Card = card });
                return card;
            }

            return null;
        }
    }
}