using System.Collections.Generic;

namespace Carubbi.Cards
{
    public class CardValueComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            if (x.Value > y.Value)
                return 1;
            if (y.Value > x.Value)
                return -1;
            return 0;
        }

        #endregion
    }
}