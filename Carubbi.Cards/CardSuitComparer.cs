using System.Collections.Generic;

namespace Carubbi.Cards
{
    public class CardSuitComparer : IComparer<Card>
    {
        #region IComparer<Card> Members

        public int Compare(Card x, Card y)
        {
            if ((int) x.Naipe > (int) y.Naipe)
                return 1;
            if ((int) y.Naipe > (int) x.Naipe)
                return -1;
            return 0;
        }

        #endregion
    }
}