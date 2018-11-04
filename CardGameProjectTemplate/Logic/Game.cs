using Carubbi.Cards;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CardGameProjectTemplate.Logic
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

        private Deck Deck { get; }
        private CardSet DiscardPile { get; set; }

        public void Discard()
        {
            if (Deck.IsEmpty)
            {
                return;
            }

            DiscardCard = Deck.GetTop();
            DeckCard = Deck.FirstOrDefault();
            DiscardCard.Turn();
            DiscardPile.Add(DiscardCard);
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

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void Start()
        {
            Deck.Shuffle(true);
            DiscardPile = new CardSet();
            DiscardCard = null;
            DeckCard = Deck.First();
            GameNumber = $"#{Deck.GameNumber}";
        }
    }
}
