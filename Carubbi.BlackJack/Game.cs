namespace Carubbi.BlackJack
{
    public class Game
    {
        public Game()
        {
            Player = new Human();
        }


        public Game(Human player)
        {
            Player = player;
        }


        public Human Player { get; }


        public decimal BetValue { get; set; }
    }
}