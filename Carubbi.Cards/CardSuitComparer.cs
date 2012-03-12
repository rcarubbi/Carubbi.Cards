using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.Cards
{
    public class CardSuitComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            if ((int)x.Naipe > (int)y.Naipe)
                return 1;
            else if ((int)y.Naipe > (int)x.Naipe)
                return -1;
            else
                return 0;
        }

        #endregion
    }
}
