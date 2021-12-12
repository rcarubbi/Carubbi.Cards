using System;
using System.Collections.Generic;

namespace Carubbi.Cards
{
    public class CardSet : List<Card>
    {

        public event EventHandler<CardSetChangedEventArgs> CardSetChanged;

        public bool IsEmpty => Count == 0;

        public Card Get(int cardIndex)
        {
            if (!IsEmpty)
            {
                var card = this[cardIndex];
                RemoveAt(cardIndex);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardRemoved });
                return card;
            }

         
            return null;
        }

        public void Set(Card card, int cardIndex)
        {
            if (card != null)
            {
                Insert(cardIndex, card);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardAdded });
            }
        }

        public Card GetTop()
        {
            if (!IsEmpty)
            {
                var cardIndex = 0;
                var card = this[cardIndex];
                RemoveAt(cardIndex);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardRemoved });
                return card;
            }

            return null;
        }

        public Card GetBottom()
        {
            if (!IsEmpty)
            {
                var cardIndex = Count - 1;
                var card = this[cardIndex];
                RemoveAt(cardIndex);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardRemoved });
                return card;
            }

            return null;
        }

        public void PutTop(Card card)
        {
            if (card != null)
            {
                var cardIndex = 0;
                Insert(cardIndex, card);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardAdded });
            }
        }

        public void PutBottom(Card card)
        {
            if (card != null)
            {
                var cardIndex = Count;
                Add(card);
                OnCardSetChanged(new CardSetChangedEventArgs { Card = card, CardIndex = cardIndex, Action = CardSetActions.CardAdded });
            }
        }

        protected virtual void OnCardSetChanged(CardSetChangedEventArgs e)
        {
            CardSetChanged?.Invoke(this, e);
        }
    }
}