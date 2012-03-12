using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    [DataContract]
    public class Server
    {

        private static volatile Server _instance;
        public static Server GetInstance()
        {
            if (_instance == null)
            {
                lock (_instance)
                {
                    if (_instance == null)
                    {
                        _instance = new Server();
                    }
                }
            }
            return _instance;
        }

        [DataMember]
        public List<Room> Rooms { get; private set; }

        [DataMember]
        public List<Player> PlayersConnected { get; private set; }


        private Server()
        {
            Rooms = new List<Room>();
            PlayersConnected = new List<Player>();
        }

        

        public List<Room> ListAvailableRooms()
        {
            List<Room> rooms = (from r in Rooms where r.Seat2 == null || r.Seat1 == null select r).ToList();
            return rooms;
        }

        public Room CreateRoom(string roomName, Player owner)
        {
            Room newRoom = new Room(owner);
            Rooms.Add(newRoom);
            return newRoom;

        }

        public void DeleteRoom(Guid guidRoom)
        {
            List<Room> roomToDelete = (from r in Rooms where r.Id == guidRoom select r).ToList();
            if (roomToDelete.Count > 0)
                Rooms.Remove(roomToDelete[0]);
        }
    }
}
