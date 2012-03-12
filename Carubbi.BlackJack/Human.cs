using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public class Human : Player
    {
        public Decimal Credits
        {
            get;
            set;
        }


        public Human() : this(1000)
        { 
        
        }

        public Human(Decimal startCredits)
        {
            Credits = startCredits;
            Hand = new CardSet();
           
        }

        public void Bet(Decimal betValue, Game game)
        {
            if (Credits >= betValue)
            {
                game.BetValue = betValue;
                Credits -= betValue;
            }
            else
                throw new RuleInfringedException("Você não tem creditos para jogar! Inicie um novo jogo");

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
