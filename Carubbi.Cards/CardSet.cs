using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.Cards
{
    public class CardSet : List<Card>
    {
        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public Card Get(int cardIndex)
        {
            if (!IsEmpty)
            {
                Card card = this[cardIndex];
                this.RemoveAt(cardIndex);
                return card;
            }
            else
                return null;
        }

        public void Set(Card card, int cardIndex)
        {
            if (card != null)
                this.Insert(cardIndex, card);
        }

        public Card GetTop()
        {
            if (!IsEmpty)
            {
                Card card = this[0];
                this.RemoveAt(0);
                return card;
            }
            else
            {
                return null;
            }
        }

        public Card GetBottom()
        {
            if (!IsEmpty)
            {
                Card card = this[this.Count - 1];
                this.RemoveAt(this.Count - 1);
                return card;
            }
            else
                return null;

        }

        public void PutTop(Card card)
        {
            if (card != null)
                this.Insert(0, card);
        }
        public void PutBottom(Card card)
        {
            if (card != null)
                this.Add(card);
        }
    }
}
