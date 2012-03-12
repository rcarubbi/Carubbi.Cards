using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    [DataContract]
    public class Seat
    {
        [DataMember]
        public Player Player { get; private set; }

        internal void Take(Player player)
        {
            this.Player = player;
        }
    }
}
