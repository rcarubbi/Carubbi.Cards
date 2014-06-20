using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;
namespace Carubbi.Truco
{
    public class Player
    {
        public string Name 
        {
            get;
            private set;
        }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public Hand Hand
        {
            get;
            private set;
        }
         


    }
}
