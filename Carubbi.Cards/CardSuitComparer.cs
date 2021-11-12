using System.Collections.Generic;

namespace Carubbi.Cards
{
    public class CardSuitComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            if ((int) x.Suit > (int) y.Suit)
                return 1;
            if ((int) y.Suit > (int) x.Suit)
                return -1;
            return 0;
        }

        #endregion
    }
}