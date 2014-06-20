using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.Truco
{
    public class TrucoDeck : Deck
    {
        public TrucoDeck(TrucoDeckType type)
            : base()
        {
            PrepareTrucoDeck(type);

             

        }

        private void PrepareTrucoDeck(TrucoDeckType type)
        {
            IEnumerable<Card> invalidCards;
            if (type == TrucoDeckType.Short)
                invalidCards = this.Where(c => new int[] { 4, 5, 6, 7, 8, 9, 10 }.Contains(c.Value));
            else
                invalidCards = this.Where(c => new int[] { 8, 9, 10 }.Contains(c.Value));

            IEnumerable<Card> validCards = this.Except(invalidCards);
            this.Clear();
            this.AddRange(validCards);
        }


        public new void Fill(bool clearBefore)
        { 
            
        }
    }
}
