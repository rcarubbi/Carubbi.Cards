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
            Deck.CardSetChanged += Deck_CardSetChanged;
            Hand = new CardSet();
            Hand.CardSetChanged += Hand_CardSetChanged;
        }

        private void Hand_CardSetChanged(object sender, CardSetChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Hand));
        }

        private void Deck_CardSetChanged(object sender, CardSetChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Deck));
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
            Hand.Clear();
            State = GameStates.Started;
        }

        public void TurnCard(Card card)
        {
            card.Turn();
            
        }

        public void Shuffle()
        {
            _deck.Shuffle(true);
            
            GameNumber = $"#{Deck.GameNumber}";
        }

        public void GetFromTop()
        {
            Hand.PutBottom(Deck.GetTop());
            
        }

        public void GetFromBottom()
        {
            Hand.PutBottom(Deck.GetBottom());
         
        }

        public void GetRandom()
        {
            Hand.PutBottom(Deck.GetRandom());
             
         
        }

        public void GetFrom(decimal value)
        {
            Hand.PutBottom(Deck.Get((int)value));
       
        }

        public void PutToTop()
        {
            Deck.PutTop(Hand.GetBottom());
           
        }

        public void PutToBottom()
        {
            Deck.PutBottom(Hand.GetBottom());
          
       
        }

        public void PutToRandom()
        {
            Deck.PutMiddle(Hand.GetBottom());
           
        }


        public void PutTo(decimal value)
        {

            Deck.Set(Hand.GetBottom(), (int) value);
       
        }

       
    }
}
