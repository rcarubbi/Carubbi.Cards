using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public abstract class Player
    {
        public Player()
        {
            Hand = new CardSet();
        }

        public CardSet Hand
        {
            get;
            set;
        }


        public bool HasBlackJack
        {
            get
            {
                return Rules.IsBlackJack(Hand);
            }
        
        }

        public List<int> Points
        {
            get
            {
                return Rules.CalculatePoints(Hand);

            }


        }

        public string PointsInfo
        {
            get
            {
                StringBuilder stbPoints = new StringBuilder();
                bool first = true;
                foreach (int result in Points)
                {
                    if (this.HasBlackJack)
                    {
                        return "BJ";
                    }
                    else
                    {
                        if (result <= 21)
                        {
                            if (first)
                                stbPoints.Append(result);
                            else
                                stbPoints.AppendFormat("/{0}", result);


                            first = false;
                        }
                    }
                }

                int minorResult = int.MaxValue;
                if (string.IsNullOrEmpty(stbPoints.ToString()))
                {
                    foreach (int result in Points)
                    {
                        if (result < minorResult)
                            minorResult = result;
                    }
                    stbPoints.Append(minorResult);
                }

                return stbPoints.ToString();
            }


        }





    }
}
