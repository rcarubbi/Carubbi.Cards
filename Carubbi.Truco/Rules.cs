using System;
using Carubbi.Cards;

namespace Carubbi.Truco
{
    internal static class Rules
    {
        public static bool IsManilha(Card c, Card orientadorManilha)
        {
            return c.Value == orientadorManilha.Value + 1;
        }

        public static int ValueOf(Card c, Card orientadorManilha)
        {
            if (IsManilha(c, orientadorManilha))
                return 11;

            switch (c.Value)
            {
                case 3:
                    return 10;
                case 2:
                    return 9;
                case 1:
                    return 8;
                case 13:
                    return 7;
                case 11:
                    return 6;
                case 12:
                    return 5;
                case 7:
                    return 4;
                case 6:
                    return 3;
                case 5:
                    return 2;
                case 4:
                    return 1;
                default:
                    throw new ApplicationException("Invalid Card");
            }
        }
    }
}