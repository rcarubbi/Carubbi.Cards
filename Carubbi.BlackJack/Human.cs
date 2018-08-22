using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public class Human : Player
    {
        public Human() : this(1000)
        {
        }

        public Human(decimal startCredits)
        {
            Credits = startCredits;
            Hand = new CardSet();
        }

        public decimal Credits { get; set; }

        public void Bet(decimal betValue, Game game)
        {
            if (Credits >= betValue)
            {
                game.BetValue = betValue;
                Credits -= betValue;
            }
            else
            {
                throw new RuleInfringedException("Você não tem creditos para jogar! Inicie um novo jogo");
            }
        }

        public void OrderCard(Dealer d)
        {
            d.GiveCard();
        }

        public void Stay(Dealer d)
        {
            d.TryWin();
        }
    }
}