using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public class Game
    {
        
        private Human _p1;
       

        public Human Player
        {
            get
            {
                return _p1;
            }
        }




        public Game()
        {

            _p1 = new Human();
        }

       

        public Game(Human player)
        {

            _p1 = player;
        }

     


        public decimal BetValue
        {
            get;
            set;
        }

    }
}
