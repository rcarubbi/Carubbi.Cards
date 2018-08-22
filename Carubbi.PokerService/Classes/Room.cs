using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    [DataContract]
    public class Room
    {
        public Room(Player owner)
        {
            Owner = owner;
            Seat1.Take(owner);
            Id = new Guid();
        }

        public Seat Seat1 { get; private set; }
        public Seat Seat2 { get; private set; }
        public Player Owner { get; }
        public Guid Id { get; }

        public List<Seat> ListEmptySeats()
        {
            var seats = new List<Seat>();
            seats.Add(Seat1);
            seats.Add(Seat2);

            var emptySeats = (from s in seats where s.Player == null select s).ToList();

            return emptySeats;
        }

        public void Join(Seat seat, Player player)
        {
            seat.Take(player);
        }
    }
}