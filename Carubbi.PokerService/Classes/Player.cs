using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    public class PlayerNameEqualityComparer : IEqualityComparer<Player>
    {


        #region IEqualityComparer<Player> Members

        public bool Equals(Player x, Player y)
        {
            return (x.Name.ToLower().Trim() == y.Name.ToLower().Trim());
        }

        public int GetHashCode(Player obj)
        {
            return obj.Name.Trim().ToLower().GetHashCode();
        }

        #endregion
    }

    [DataContract]
    public class Player
    {

        public static PlayerNameEqualityComparer PesquisarPorNome = new PlayerNameEqualityComparer();
        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public Int32 Credits { get; set; }

        public Player(string name)
        {
            Name = name;
            Credits = 1000;
        }


    }
}
