using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    [DataContract]
    public class Seat
    {
        [DataMember] public Player Player { get; private set; }

        internal void Take(Player player)
        {
            Player = player;
        }
    }
}