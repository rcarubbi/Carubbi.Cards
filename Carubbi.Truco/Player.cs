namespace Carubbi.Truco
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public string Name { get; }

        public Hand Hand { get; }
    }
}