using Carubbi.Cards;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carubbi.Sabao.Logic
{
    public class Game : INotifyPropertyChanged
    {

        public Game()
        {
            Deck = new Deck();
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

        private Player _currentPlayer;

        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                OnPropertyChanged();
            }
        }

        private Deck Deck { get; }
        private CardSet DiscardPile { get; set; }

        public void TurnCard()
        {
            if (!DeckCard.IsClosed) return;
            DeckCard?.Turn();
            OnPropertyChanged("DeckCard");
            DeckCardValid = IsValid(DeckCard);
        }

        private static bool IsValid(Card card)
        {
            return card.Value < 11;
        }

        private bool _deckCardValid;

        public bool DeckCardValid
        {
            get => _deckCardValid;
            set
            {
                _deckCardValid = value;
                OnPropertyChanged();
            }
        }


        public void Discard(Card currentCard = null)
        {

            if (currentCard == null && Deck.IsEmpty)
            {
                return;
            }

            DiscardCard = currentCard ?? DeckCard;

            if (currentCard == null)
            {
                DeckCard = Deck.GetTop();
            }

            DiscardPile.Add(DiscardCard);
            PlayerTurn = PlayerTurn == 1 ? 2 : 1;
        }


        private Card _discardCard;

        public Card DiscardCard
        {
            get => _discardCard;
            set
            {
                _discardCard = value;
                OnPropertyChanged();
            }
        }

        private Card _deckCard;

        public Card DeckCard
        {
            get => _deckCard;
            set
            {
                _deckCard = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void Start()
        {
            Deck.Shuffle(true);
            DiscardPile = new CardSet();
            DiscardCard = null;
            Player1 = new Player(Deck);
            Player1.PropertyChanged += Player_PropertyChanged;

            Player2 = new Player(Deck);
            Player2.PropertyChanged += Player_PropertyChanged;

            DeckCard = Deck.GetTop();
            GameNumber = $"#{Deck.GameNumber}";
            PlayerTurn = 1;
            DeckCardValid = false;
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged($"{sender}/{e.PropertyName}");
        }

        public void GetFromDeck()
        {

            Card currentCard = DeckCard;
            do
            {
                var property = GetType().GetProperty($"P{PlayerTurn}C{currentCard.Value}");
                var nextCard = (Card)property.GetValue(this);


                if (nextCard.IsClosed)
                {
                    property.SetValue(this, currentCard);
                    nextCard.Turn();
                    currentCard = nextCard;
                }
                else
                {
                    currentCard = nextCard;
                    break;
                }
            } while (IsValid(currentCard));



            Discard(currentCard);

            DeckCard = Deck.GetTop();
        }
    }


}
