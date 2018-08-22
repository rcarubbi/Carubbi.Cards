using System.Collections.Generic;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public static class Rules
    {
        public static bool ValidHand(CardSet hand)
        {
            if (CalculateBestPoints(hand) > 21) return false;
            return true;
        }


        public static bool IsBlackJack(CardSet hand)
        {
            var hasAce = false;
            var hasTen = false;
            var countCards = 0;
            foreach (var c in hand)
                if (!c.IsClosed)
                {
                    if (ValueOf(c) == 11)
                        hasAce = true;
                    if (ValueOf(c) == 10)
                        hasTen = true;
                    countCards++;
                }

            if (hasAce && hasTen && countCards == 2)
                return true;
            return false;
        }

        public static int CountAces(CardSet hand)
        {
            var countAces = 0;
            foreach (var c in hand)
                if (ValueOf(c) == 11 && !c.IsClosed)
                    countAces++;

            return countAces;
        }

        public static List<int> CalculatePoints(CardSet hand)
        {
            var results = new List<int>();
            for (var i = 0; i <= CountAces(hand); i++)
                results.Add(CalculateAcesValues(i, hand));
            return results;
        }

        public static int CalculateAcesValues(int acesToChange, CardSet hand)
        {
            var total = 0;
            foreach (var c in hand)
                if (!c.IsClosed)
                {
                    var cardValue = ValueOf(c);
                    var changedValue = 0;
                    if (ValueOf(c) == 11 && acesToChange > 0)
                    {
                        changedValue = 1;
                        acesToChange--;
                    }
                    else
                    {
                        changedValue = cardValue;
                    }

                    total += changedValue;
                }

            return total;
        }


        public static int CalculateBestPoints(CardSet hand)
        {
            var results = CalculatePoints(hand);

            var bestResult = -1;
            var minorResult = int.MaxValue;
            foreach (var result in results)
                if (result > bestResult && result <= 21)
                    bestResult = result;
            if (bestResult < 0)
            {
                foreach (var result in results)
                    if (result < minorResult)
                        minorResult = result;
                bestResult = minorResult;
            }

            return bestResult;
        }

        public static int ValueOf(Card c)
        {
            if (c.Value >= 10)
                return 10;
            if (c.Value > 1)
                return c.Value;
            return 11;
        }
    }
}