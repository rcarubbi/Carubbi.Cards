using System;

namespace Carubbi.Cards
{
    public class CardSetChangedEventArgs : EventArgs
    {
        public int CardIndex { get; set; }

        public Card Card { get; set; }

        public CardSetActions Action { get; set; }
    }
}

