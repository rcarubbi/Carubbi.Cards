using Carubbi.Cards;

namespace Carubbi.SlotCard
{
    public class Roullete
    {
        public Card Slot1 { get; private set; }
        public Card Slot2 { get; private set; }
        public Card Slot3 { get; private set; }

        public void Spin(Deck deckToSpin1, Deck deckToSpin2, Deck deckToSpin3)
        {
            Slot1 = deckToSpin1.GetTop();
            Slot2 = deckToSpin2.GetTop();
            Slot3 = deckToSpin3.GetTop();
        }
    }
}