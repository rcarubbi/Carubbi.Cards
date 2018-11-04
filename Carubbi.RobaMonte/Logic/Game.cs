using Carubbi.Cards;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Carubbi.RobaMonte.Logic
{
    public class Game : INotifyPropertyChanged
    {
        private readonly Deck Deck;

        private bool isP2;

        public Game()
        {
            Deck = new Deck(1, false);

        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private string _gameNumber;

        public string GameNumber
        {
            get => _gameNumber;
            set
            {
                _gameNumber = value;
                OnPropertyChanged();
            }
        }


        private int _p1Score;

        public int P1Score
        {
            get => _p1Score;
            set
            {
                _p1Score = value;
                OnPropertyChanged();
            }
        }

        private int _p2Score;

        public int P2Score
        {
            get => _p2Score;
            set
            {
                _p2Score = value;
                OnPropertyChanged();
            }
        }


        private Card _p1Card;

        public Card P1Card
        {
            get => _p1Card;
            set
            {
                _p1Card = value;
                OnPropertyChanged();
            }
        }

        private Card _p2Card;

        public Card P2Card
        {
            get => _p2Card;
            set
            {
                _p2Card = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void Start()
        {
            Deck.Fill(true);
            Deck.Shuffle(true);
            GameNumber = $"#{Deck.GameNumber}";
            P1Card = null;
            P2Card = null;
            P1Score = 0;
            P2Score = 0;
        }

        public void Turn()
        {
            if (!Deck.IsEmpty)
            {
                if (!isP2)
                {
                    P1Card = Deck.GetTop();
                    P1Score++;
                    CheckSteal(1);
                }
                else
                {
                    P2Card = Deck.GetTop();
                    P2Score++;
                    CheckSteal(2);
                }

                isP2 = !isP2;
            }
            else
            {
                if (P1Score > P2Score)
                {

                    Message = "Jogador 1 (Azul) Venceu!";
                    Start();
                }
                else if (P2Score > P1Score)
                {
                    Message = "Jogador 2 (Vermelho) Venceu!";
                    Start();
                }
                else
                {
                    Message = "Empatou!";
                    Start();
                    Message = $"Adicionado mais um baralho No. {Deck.GameNumber}";
                }
            }
        }

        private void CheckSteal(int player)
        {
            if (P1Card?.Value != P2Card?.Value) return;
            if (player == 1)
            {
                Message = $"Player {player} robou {P2Score} cartas!!!";
                P1Card = P2Card;
                P2Card = null;
                P1Score += P2Score;
                P2Score = 0;
            }
            else
            {
                Message = $"Player {player} robou {P1Score} cartas!!!";
                P2Card = P1Card;
                P1Card = null;
                P2Score += P1Score;
                P1Score = 0;
            }
        }
    }
}
