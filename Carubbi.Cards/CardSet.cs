using System.Collections.Generic;

namespace Carubbi.Cards
{
    public class CardSet : List<Card>
    {
        public bool IsEmpty => Count == 0;

        public Card Get(int cardIndex)
        {
            if (!IsEmpty)
            {
                var card = this[cardIndex];
                RemoveAt(cardIndex);
                return card;
            }

            return null;
        }

        public void Set(Card card, int cardIndex)
        {
            if (card != null)
                Insert(cardIndex, card);
        }

        public Card GetTop()
        {
            if (!IsEmpty)
            {
                var card = this[0];
                RemoveAt(0);
                return card;
            }

            return null;
        }

        public Card GetBottom()
        {
            if (!IsEmpty)
            {
                var card = this[Count - 1];
                RemoveAt(Count - 1);
                return card;
            }

            return null;
        }

        public void PutTop(Card card)
        {
            if (card != null)
                Insert(0, card);
        }

        public void PutBottom(Card card)
        {
            if (card != null)
                Add(card);
        }
    }
}