using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.Cards
{
    public class CardValueComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            if (x.Value > y.Value)
                return 1;
            else if (y.Value > x.Value)
                return -1;
            else
                return 0;
        }

        #endregion
    }
}
