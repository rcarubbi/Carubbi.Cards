using System.Collections.Generic;
using System.Linq;
using Carubbi.Cards;

namespace Carubbi.Truco
{
    public class TrucoDeck : Deck
    {
        public TrucoDeck(TrucoDeckType type)
        {
            PrepareTrucoDeck(type);
        }

        private void PrepareTrucoDeck(TrucoDeckType type)
        {
            IEnumerable<Card> invalidCards;
            if (type == TrucoDeckType.Short)
                invalidCards = this.Where(c => new[] {4, 5, 6, 7, 8, 9, 10}.Contains(c.Value));
            else
                invalidCards = this.Where(c => new[] {8, 9, 10}.Contains(c.Value));

            var validCards = this.Except(invalidCards);
            Clear();
            AddRange(validCards);
        }


        public new void Fill(bool clearBefore)
        {
        }
    }
}