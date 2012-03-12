using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carubbi.Cards;

namespace Carubbi.BlackJack
{
    public class Dealer : Player
    {
        private Game _game;

        public event EventHandler playerWins;
        public event EventHandler gameOver;
        public event EventHandler afterGameOver;
        public event EventHandler afterPlayerWins;
        public event EventHandler cardModified;
        public Dealer()
            : base()
        {
            _deck = new Deck(10, true);
            _game = new Game();

        }

        public Game CurrentGame
        {
            get
            {
                return _game;
            }
        }


        public void StartGame(decimal betValue)
        {
            Hand.Clear();
            _game = new Game(_game.Player);
            _game.Player.Bet(betValue, this.CurrentGame);
            if (_game.BetValue > 0)
            {

                _game.BetValue *= 2;
                Deck.Fill(true);
                Deck.Shuffle();
                PickCard(true);
                PickCard(false);
                GiveCard();
                GiveCard();
                if (_game.Player.HasBlackJack)
                {
                    Hand[Hand.Count - 1].Turn();
                    if (this.HasBlackJack)
                        Push();
                    else
                        PayBlackJack();
                }

            }
            else
                throw new RuleInfringedException("É necessário fazer sua aprosta");

        }


        public void Push()
        {
            decimal pushValue = _game.BetValue / 2;
            _game.Player.Credits += pushValue;
            DealerWins();
        }

        public void PayBlackJack()
        {
            _game.Player.Credits += (_game.BetValue * 1.5m);
            if (playerWins != null)
                playerWins(this, new EventArgs());

            _game.Player.Hand.Clear();
            Hand.Clear();
            _game.BetValue = 0;
            if (afterPlayerWins != null)
                afterPlayerWins(this, new EventArgs());
        }

        public void PlayerWins()
        {
            _game.Player.Credits += _game.BetValue;
            if (playerWins != null)
                playerWins(this, new EventArgs());

            _game.Player.Hand.Clear();
            Hand.Clear();
            _game.BetValue = 0;
            if (afterPlayerWins != null)
                afterPlayerWins(this, new EventArgs());
        }


        public void DealerWins()
        {
            if (gameOver != null)
                gameOver(this, new EventArgs());

            _game.Player.Hand.Clear();
            Hand.Clear();
            _game.BetValue = 0;
            if (afterGameOver != null)
                afterGameOver(this, new EventArgs());

        }

        private Deck _deck;
        public Deck Deck
        {
            get
            {
                return _deck;
            }

        }

        public void GiveCard()
        {
            Card nextCard = Deck.GetTop();
            nextCard.Turn();
            _game.Player.Hand.PutBottom(nextCard);


            if (!Rules.ValidHand(_game.Player.Hand))
            {
                DealerWins();
            }
        }

        public void PickCard(bool opened)
        {
            Card nextCard = Deck.GetTop();
            if (opened)
                nextCard.Turn();
            this.Hand.PutBottom(nextCard);

        }

        public void TryWin()
        {
            Hand[Hand.Count - 1].Turn();
            if (cardModified != null)
            {
                cardModified(this, new EventArgs());
                System.Threading.Thread.Sleep(200);
            }
            if (this.HasBlackJack || Rules.CalculateBestPoints(Hand) >= Rules.CalculateBestPoints(CurrentGame.Player.Hand))
                DealerWins();
            else
            {

                if (Rules.ValidHand(Hand))
                {

                    while (true)
                    {
                        PickCard(true);
                        if (cardModified != null)
                        {
                            cardModified(this, new EventArgs());
                            System.Threading.Thread.Sleep(200);
                        }
                        if (!Rules.ValidHand(Hand))
                        {
                            PlayerWins();
                            break;
                        }
                        else if (Rules.CalculateBestPoints(Hand) >= Rules.CalculateBestPoints(CurrentGame.Player.Hand))
                        {
                            DealerWins();
                            break;
                        }
                    }

                }
                else
                {
                    PlayerWins();
                }
            }

        }
    }
}
