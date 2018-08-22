using System.Collections.Generic;
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

        public CardSet Hand { get; set; }


        public bool HasBlackJack => Rules.IsBlackJack(Hand);

        public List<int> Points => Rules.CalculatePoints(Hand);

        public string PointsInfo
        {
            get
            {
                var stbPoints = new StringBuilder();
                var first = true;
                foreach (var result in Points)
                    if (HasBlackJack)
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

                var minorResult = int.MaxValue;
                if (string.IsNullOrEmpty(stbPoints.ToString()))
                {
                    foreach (var result in Points)
                        if (result < minorResult)
                            minorResult = result;
                    stbPoints.Append(minorResult);
                }

                return stbPoints.ToString();
            }
        }
    }
}