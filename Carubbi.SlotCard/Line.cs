using Carubbi.Cards;
using System.Collections.Generic;
namespace Carubbi.SlotCard
{
    public class Line
    {
        public List<Card> Cards { get; private set; }
        private List<Card> _cardsToAnalyse;


        public string PriceName { get; private set; }


        public int Result()
        {
            _cardsToAnalyse = Cards;
            CardValueComparer valueComparer = new CardValueComparer();


            _cardsToAnalyse.Sort(valueComparer);

            if (ContainsStraightFlush(_cardsToAnalyse))
            {
                PriceName = "Straight Flush";
                return PayTable.StraightFlush;
            }
            else if (ContainsFourOfAKind(_cardsToAnalyse))
            {
                PriceName = "Quadra";
                return PayTable.FourOfAKind;
            }
            else if (ContainsStraight(_cardsToAnalyse))
            {
                PriceName = "Straight";
                return PayTable.Straight;
            }
            else if (ContainsFullen(_cardsToAnalyse))
            {
                PriceName = "Full House";
                return PayTable.Fullen;
            }
            else if (ContainsFlush(_cardsToAnalyse))
            {
                PriceName = "Flush";
                return PayTable.Flush;
            }
            else if (ContainsThreeOfAKind(_cardsToAnalyse))
            {
                PriceName = "Trinca";
                return PayTable.ThreeOfAKind;
            }
            else if (ContainsTwoPairs(_cardsToAnalyse))
            {
                PriceName = "Dois Pares";
                return PayTable.TwoPairs;
            }
            else if (ContainsPair(_cardsToAnalyse))
            {
                PriceName = "Um Par";
                return PayTable.Pair;
            }
            else
                return 0;

        }

        private bool ContainsFullen(List<Card> _cardsToAnalyse)
        {
            int valueOfThree = 0;

            // Search for 3 of a kind
            Card previousCard1 = null;
            Card previousCard2 = null;

            foreach (Card c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null)
                {
                    if (c.Value == previousCard1.Value && c.Value == previousCard2.Value)
                    {
                        valueOfThree = c.Value;
                    }
                }
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            if (valueOfThree > 0)
            {
                Card previousCard = null;

                foreach (Card c in Cards)
                {
                    if (previousCard != null)
                    {
                        if (c.Value == previousCard.Value)
                        {
                            if (c.Value != valueOfThree)
                                return true;
                        }
                    }
                    previousCard = c;
                }
                return false;
            }
            else
                return false;
        }

        private bool ContainsPair(List<Card> Cards)
        {

            Card previousCard = null;

            foreach (Card c in Cards)
            {
                if (previousCard != null)
                {
                    if (c.Value == previousCard.Value)
                        return true;
                }
                previousCard = c;
            }
            return false;
        }

        private bool ContainsTwoPairs(List<Card> Cards)
        {
            Card previousCard = null;
            int countPairs = 0;
            foreach (Card c in Cards)
            {
                if (previousCard != null)
                {
                    if (c.Value == previousCard.Value)
                        countPairs++;
                }
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

            foreach (Card c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null)
                {
                    if (c.Value == previousCard1.Value && c.Value == previousCard2.Value)
                        return true;
                }
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            return false;
        }

        private bool ContainsFlush(List<Card> Cards)
        {
            return (Cards[0].Naipe == Cards[1].Naipe &&
                Cards[0].Naipe == Cards[2].Naipe &&
                Cards[0].Naipe == Cards[3].Naipe &&
                Cards[0].Naipe == Cards[4].Naipe);

        }

        private bool ContainsStraight(List<Card> Cards)
        {
            return (Cards[0].Value + 1 == Cards[1].Value &&
               Cards[1].Value + 1 == Cards[2].Value &&
               Cards[2].Value + 1 == Cards[3].Value &&
               Cards[3].Value + 1 == Cards[4].Value)
               ||
               (
               Cards[1].Value + 1 == Cards[2].Value &&
               Cards[2].Value + 1 == Cards[3].Value &&
               Cards[3].Value + 1 == Cards[4].Value &&
               Cards[4].Value == 13 && Cards[0].Value == 1
               );
        }

        private bool ContainsFourOfAKind(List<Card> Cards)
        {
            Card previousCard1 = null;
            Card previousCard2 = null;
            Card previousCard3 = null;

            foreach (Card c in Cards)
            {
                if (previousCard1 != null && previousCard2 != null && previousCard3 != null)
                {
                    if (c.Value == previousCard1.Value &&
                        c.Value == previousCard2.Value &&
                        c.Value == previousCard3.Value)
                        return true;
                }
                previousCard3 = previousCard2;
                previousCard2 = previousCard1;
                previousCard1 = c;
            }

            return false;
        }

        private bool ContainsStraightFlush(List<Card> Cards)
        {
            return (ContainsFlush(Cards) && ContainsStraight(Cards));
        }

        public Line()
        {
            Cards = new List<Card>(5);
        }
    }
}
