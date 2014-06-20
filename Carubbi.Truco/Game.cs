using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.Truco
{
    public class Game
    {


        public TrucoDeck Deck
        {
            get;
            private set;
        }

        public Player P1
        {
            get;
            private set;
        }
        
        public Player P2
        {
            get;
            private set;
        }
        
        public Player P3
        {
            get;
            private set;

        }
        
        public Player P4
        {
            get;
            private set;
        }


        public Game(Player p1, Player p2, TrucoDeckType gameType)
        {
            P1 = p1;
            P2 = p2;
            Deck = new TrucoDeck(gameType);
        }

        public Game(Player p1, Player p2, Player p3, Player p4, TrucoDeckType gameType)
            : this(p1, p2, gameType)
        {
            P3 = p3;
            P4 = p4;
        }

        public void StartHand()
        {
            Deck.Fill(true);
            Deck.Shuffle(true);
            for (int i = 1; i <= 3; i++)
            {
                GiveCard(P1, i);
                GiveCard(P2, i);

                if (P3 != null)
                {
                    GiveCard(P3, i);
                    GiveCard(P4, i);
                }
            }
        }

        private void GiveCard(Player p, int cardNumber)
        {
            switch (cardNumber)
            { 
                case 1:
                    p.Hand.Card1 = Deck.GetTop();
                    break;
                case 2:
                    p.Hand.Card2 = Deck.GetTop();
                    break;
                case 3:
                    p.Hand.Card3 = Deck.GetTop();
                    break;
            }
        }

       


    }
}
