using System.Collections.Generic;
using Carubbi.Cards;

namespace Carubbi.SlotCard
{
    public class Line
    {
        private List<Card> _cardsToAnalyse;

        public Line()
        {
            Cards = new List<Card>(5);
        }

        public List<Card> Cards { get; }


        public string PriceName { get; private set; }


        public int Result()
        {
            _cardsToAnalyse = Cards;
            var valueComparer = new CardValueComparer();


            _cardsToAnalyse.Sort(valueComparer);

            if (ContainsStraightFlush(_cardsToAnalyse))
            {
                PriceName = "Straight Flush";
                return PayTable.StraightFlush;
            }

            if (ContainsFourOfAKind(_cardsToAnalyse))
            {
                PriceName = "Quadra";
                return PayTable.FourOfAKind;
            }

            if (ContainsStraight(_cardsToAnalyse))
            {
                PriceName = "Straight";
                return PayTable.Straight;
            }

            if (ContainsFullen(_cardsToAnalyse))
            {
                PriceName = "Full House";
                return PayTable.Fullen;
            }

            if (ContainsFlush(_cardsToAnalyse))
            {
                PriceName = "Flush";
                return PayTable.Flush;
            }

            if (ContainsThreeOfAKind(_cardsToAnalyse))
            {
                PriceName = "Trinca";
                return PayTable.ThreeOfAKind;
            }

            if (ContainsTwoPairs(_cardsToAnalyse))
            {
                PriceName = "Dois Pares";
                return PayTable.TwoPairs;
            }

            if (ContainsPair(_cardsToAnalyse))
            {
                PriceName = "Um Par";
                return PayTable.Pair;
            }

            return 0;
        }

        private bool ContainsFullen(List<Card> _cardsToAnalyse)
        {
            var valueOfThree = 0;

            // Search for 3 of a kind
            Card previousCard1 = null;
            Card previousCard2 = null;

            foreach (var c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null)
                    if (c.Value == previousCard1.Value && c.Value == previousCard2.Value)
                        valueOfThree = c.Value;
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            if (valueOfThree > 0)
            {
                Card previousCard = null;

                foreach (var c in Cards)
                {
                    if (previousCard != null)
                        if (c.Value == previousCard.Value)
                            if (c.Value != valueOfThree)
                                return true;
                    previousCard = c;
                }

                return false;
            }

            return false;
        }

        private bool ContainsPair(List<Card> Cards)
        {
            Card previousCard = null;

            foreach (var c in Cards)
            {
                if (previousCard != null)
                    if (c.Value == previousCard.Value)
                        return true;
                previousCard = c;
            }

            return false;
        }

        private bool ContainsTwoPairs(List<Card> Cards)
        {
            Card previousCard = null;
            var countPairs = 0;
            foreach (var c in Cards)
            {
                if (previousCard != null)
                    if (c.Value == previousCard.Value)
                        countPairs++;
                previousCard = c;
            }

            if (countPairs == 2)
                return true;

            return false;
        }

        private bool ContainsThreeOfAKind(List<Card> Cards)
        {
            Card previousCard1 = null;
            Card previousCard2 = null;

            foreach (var c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null)
                    if (c.Value == previousCard1.Value && c.Value == previousCard2.Value)
                        return true;
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            return false;
        }

        private bool ContainsFlush(List<Card> Cards)
        {
            return Cards[0].Suit == Cards[1].Suit &&
                   Cards[0].Suit == Cards[2].Suit &&
                   Cards[0].Suit == Cards[3].Suit &&
                   Cards[0].Suit == Cards[4].Suit;
        }

        private bool ContainsStraight(List<Card> Cards)
        {
            return Cards[0].Value + 1 == Cards[1].Value &&
                   Cards[1].Value + 1 == Cards[2].Value &&
                   Cards[2].Value + 1 == Cards[3].Value &&
                   Cards[3].Value + 1 == Cards[4].Value
                   ||
                   Cards[1].Value + 1 == Cards[2].Value &&
                   Cards[2].Value + 1 == Cards[3].Value &&
                   Cards[3].Value + 1 == Cards[4].Value &&
                   Cards[4].Value == 13 && Cards[0].Value == 1;
        }

        private bool ContainsFourOfAKind(List<Card> Cards)
        {
            Card previousCard1 = null;
            Card previousCard2 = null;
            Card previousCard3 = null;

            foreach (var c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null && previousCard3 != null)
                    if (c.Value == previousCard1.Value &&
                        c.Value == previousCard2.Value &&
                        c.Value == previousCard3.Value)
                        return true;
                previousCard3 = previousCard2;
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            return false;
        }

        private bool ContainsStraightFlush(List<Card> Cards)
        {
            return ContainsFlush(Cards) && ContainsStraight(Cards);
        }
    }
}