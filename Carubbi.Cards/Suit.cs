using Carubbi.Utils.Localization;

namespace Carubbi.Cards
{
    public enum Suit
    {
        [LocalizedDescription(nameof(Spades), typeof(Resources))]
        Spades,
        [LocalizedDescription(nameof(Diamonds), typeof(Resources))]
        Diamonds,
        [LocalizedDescription(nameof(Hearts), typeof(Resources))]
        Hearts,
        [LocalizedDescription(nameof(Clubs), typeof(Resources))]
        Clubs
    }
}