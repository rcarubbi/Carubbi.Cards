using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Dispatcher;

namespace Carubbi.PokerServices
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class RoomManagerServiceImplementation : RoomManagerServiceContract
    {
        Server _server = null;

        public event EventHandler PlayerConnect;
        public event EventHandler PlayerJoinRoom;

        public RoomManagerServiceImplementation()
        {
            _server = Server.GetInstance();
        }


        #region RoomManagerServiceContract Members

        public Server Connect(Player p)
        {
            if (!_server.PlayersConnected.Contains(p, Player.PesquisarPorNome))
            {
                _server.PlayersConnected.Add(p);
                return _server;
            }
            else
            {
                FaultException ex = new FaultException("Já existe um usuário conectado com este login");
                throw ex;
            }

            
        }

        public Room CreateRoom(Server server, string roomName, Player owner)
        {
            return server.CreateRoom(roomName, owner);
        }

        public bool DeleteRoom(Server server, Guid guidRoom)
        {
            try
            {
                server.DeleteRoom(guidRoom);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Room> ListAvailableRooms(Server server)
        {
            return server.ListAvailableRooms();
        }

        public List<Seat> ListEmptySeats(Room room)
        {
            return room.ListEmptySeats();
        }

        public bool Join(Room room, Seat seat, Player player)
        {
            try
            {
                room.Join(seat, player);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

    }
}
