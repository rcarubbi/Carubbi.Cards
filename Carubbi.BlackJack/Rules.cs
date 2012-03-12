using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public static class Rules
    {

        public static bool ValidHand(CardSet hand)
        {
            if (CalculateBestPoints(hand) > 21)
            {
                return false;
            }
            return true;
        }



        public static bool IsBlackJack(CardSet hand)
        {
            bool hasAce = false;
            bool hasTen = false;
            int countCards = 0;
            foreach (Card c in hand)
            {
                if (!c.IsClosed)
                {
                    if (Rules.ValueOf(c) == 11)
                        hasAce = true;
                    if (Rules.ValueOf(c) == 10)
                        hasTen = true;
                    countCards++;
                }
            }
            if (hasAce && hasTen && countCards == 2)
                return true;
            else
                return false;
        }

        public static int CountAces(CardSet hand)
        {
            int countAces = 0;
            foreach (Card c in hand)
                if (Rules.ValueOf(c) == 11 && !c.IsClosed)
                    countAces++;

            return countAces;
        }

        public static List<int> CalculatePoints(CardSet hand)
        {
            List<int> results = new List<int>();
            for (int i = 0; i <= CountAces(hand); i++)
                results.Add(CalculateAcesValues(i, hand));
            return results;
        }

        public static int CalculateAcesValues(int acesToChange, CardSet hand)
        { 
            int total = 0;
            foreach (Card c in hand)
            {
                if (!c.IsClosed)
                {
                    int cardValue = ValueOf(c);
                    int changedValue = 0;
                    if (Rules.ValueOf(c) == 11 && acesToChange > 0)
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
            }
            return total;
        
        }

    

        public static int CalculateBestPoints(CardSet hand)
        {
            List<int> results = CalculatePoints(hand);

            int bestResult = -1;
            int minorResult = int.MaxValue;
            foreach (int result in results)
            {
                if (result > bestResult && result <= 21)
                    bestResult = result;
            }
            if (bestResult < 0)
            {
                foreach (int result in results)
                {
                    if (result < minorResult)
                        minorResult = result;
                }
                bestResult = minorResult;
            }
            return bestResult;
        
        }

        public static int ValueOf(Card c)
        {
            if (c.Value >= 10)
            {
                return 10;
            }
            else if (c.Value > 1)
            {
                return c.Value;
            }
            else
            {
                return 11;
            }

        }


    }
}
