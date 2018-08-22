using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Carubbi.PokerServices
{
    public class PlayerNameEqualityComparer : IEqualityComparer<Player>
    {
        #region IEqualityComparer<Player> Members

        public bool Equals(Player x, Player y)
        {
            return x.Name.ToLower().Trim() == y.Name.ToLower().Trim();
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

        public Player(string name)
        {
            Name = name;
            Credits = 1000;
        }

        [DataMember] public string Name { get; set; }

        [DataMember] public int Credits { get; set; }
    }
}