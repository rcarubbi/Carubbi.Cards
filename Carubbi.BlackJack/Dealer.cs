using System;
using System.Threading;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public class Dealer : Player
    {
        public Dealer()
        {
            Deck = new Deck(10, true);
            CurrentGame = new Game();
        }

        public Game CurrentGame { get; private set; }

        public Deck Deck { get; }

        public event EventHandler playerWins;
        public event EventHandler gameOver;
        public event EventHandler afterGameOver;
        public event EventHandler afterPlayerWins;
        public event EventHandler cardModified;


        public void StartGame(decimal betValue)
        {
            Hand.Clear();
            CurrentGame = new Game(CurrentGame.Player);
            CurrentGame.Player.Bet(betValue, CurrentGame);
            if (CurrentGame.BetValue > 0)
            {
                CurrentGame.BetValue *= 2;
                Deck.Fill(true);
                Deck.Shuffle();
                PickCard(true);
                PickCard(false);
                GiveCard();
                GiveCard();
                if (!CurrentGame.Player.HasBlackJack) return;

                Hand[Hand.Count - 1].Turn();
                if (HasBlackJack)
                    Push();
                else
                    PayBlackJack();
            }
            else
            {
                throw new RuleInfringedException("É necessário fazer sua aprosta");
            }
        }


        public void Push()
        {
            var pushValue = CurrentGame.BetValue / 2;
            CurrentGame.Player.Credits += pushValue;
            DealerWins();
        }

        public void PayBlackJack()
        {
            CurrentGame.Player.Credits += CurrentGame.BetValue * 1.5m;
            playerWins?.Invoke(this, new EventArgs());

            CurrentGame.Player.Hand.Clear();
            Hand.Clear();
            CurrentGame.BetValue = 0;
            afterPlayerWins?.Invoke(this, new EventArgs());
        }

        public void PlayerWins()
        {
            CurrentGame.Player.Credits += CurrentGame.BetValue;
            playerWins?.Invoke(this, new EventArgs());

            CurrentGame.Player.Hand.Clear();
            Hand.Clear();
            CurrentGame.BetValue = 0;
            afterPlayerWins?.Invoke(this, new EventArgs());
        }


        public void DealerWins()
        {
            gameOver?.Invoke(this, new EventArgs());

            CurrentGame.Player.Hand.Clear();
            Hand.Clear();
            CurrentGame.BetValue = 0;
            afterGameOver?.Invoke(this, new EventArgs());
        }

        public void GiveCard()
        {
            var nextCard = Deck.GetTop();
            nextCard.Turn();
            CurrentGame.Player.Hand.PutBottom(nextCard);


            if (!Rules.ValidHand(CurrentGame.Player.Hand)) DealerWins();
        }

        public void PickCard(bool opened)
        {
            var nextCard = Deck.GetTop();
            if (opened)
                nextCard.Turn();
            Hand.PutBottom(nextCard);
        }

        public void TryWin()
        {
            Hand[Hand.Count - 1].Turn();
            if (cardModified != null)
            {
                cardModified(this, new EventArgs());
                Thread.Sleep(200);
            }

            if (HasBlackJack || Rules.CalculateBestPoints(Hand) >= Rules.CalculateBestPoints(CurrentGame.Player.Hand))
            {
                DealerWins();
            }
            else
            {
                if (Rules.ValidHand(Hand))
                    while (true)
                    {
                        PickCard(true);
                        if (cardModified != null)
                        {
                            cardModified(this, new EventArgs());
                            Thread.Sleep(200);
                        }

                        if (!Rules.ValidHand(Hand))
                        {
                            PlayerWins();
                            break;
                        }

                        if (Rules.CalculateBestPoints(Hand) < Rules.CalculateBestPoints(CurrentGame.Player.Hand))
                            continue;

                        DealerWins();
                        break;
                    }
                else
                    PlayerWins();
            }
        }
    }
}