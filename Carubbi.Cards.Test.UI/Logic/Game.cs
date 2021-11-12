using System;
using Carubbi.Cards;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Carubbi.Cards.Test.UI.Logic
{
    public class Game : INotifyPropertyChanged
    {

        public Game()
        {
            Deck = new Deck(2, false);
            Hand = new CardSet();
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

        private GameStates _state;
        public GameStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        private CardSet _hand;

        public CardSet Hand
        {
            get => _hand;
            set
            {
                _hand = value;
                OnPropertyChanged();
            }
        }

        private Deck _deck;

        public Deck Deck
        {
            get => _deck;
            set
            {
                _deck = value;
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
           
            Deck.Fill();
            Deck = Deck;

            Hand.Clear();
            Hand = Hand;
            State = GameStates.Started;
        }

        public void TurnCard(Card card)
        {
            card.Turn();
            Deck = Deck;
            Hand = Hand;
        }

        public void Shuffle()
        {
            _deck.Shuffle(true);
            Deck = Deck;
            Hand = Hand;
            GameNumber = $"#{Deck.GameNumber}";
        }

        public void GetFromTop()
        {
            Hand.PutBottom(Deck.GetTop());
            Deck = Deck;
            Hand = Hand;
        }

        public void GetFromBottom()
        {
            Hand.PutBottom(Deck.GetBottom());
            Deck = Deck;
            Hand = Hand;
        }

        public void GetRandom()
        {
            Hand.PutBottom(Deck.GetRandom());
            Deck = Deck;
            Hand = Hand;
        }

        public void GetFrom(decimal value)
        {
            Hand.PutBottom(Deck.Get((int)value));
            Deck = Deck;
            Hand = Hand;
        }

        public void PutToTop()
        {
            Deck.PutTop(Hand.GetBottom());
            Deck = Deck;
            Hand = Hand;
        }

        public void PutToBottom()
        {
            Deck.PutBottom(Hand.GetBottom());
            Deck = Deck;
            Hand = Hand;
        }

        public void PutToRandom()
        {
            Deck.PutMiddle(Hand.GetBottom());
            Deck = Deck;
            Hand = Hand;
        }


        public void PutTo(decimal value)
        {

            Deck.Set(Hand.GetBottom(), (int) value);
            Deck = Deck;
            Hand = Hand;
        }
    }
}
