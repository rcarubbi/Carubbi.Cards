using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Carubbi.PokerServices
{
    [ServiceContract]
    public interface RoomManagerServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Server Connect(Player p);

        [OperationContract]
        Room CreateRoom(Server server, string roomName, Player owner);

        [OperationContract]
        bool DeleteRoom(Server server, Guid guidRoom);

        [OperationContract]
        List<Room> ListAvailableRooms(Server server);

        [OperationContract]
        List<Seat> ListEmptySeats(Room room);

        [OperationContract]
        bool Join(Room room, Seat seat, Player player);
    }
}