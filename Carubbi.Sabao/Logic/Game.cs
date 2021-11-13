using Carubbi.Cards;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carubbi.Sabao.Logic
{
    public class Game : INotifyPropertyChanged
    {

        public Game()
        {
            Deck = new Deck();
            GameOver = true;
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

        private Card _deckCard;
        public Card DeckCard
        {
            get { return _deckCard; }
            set
            {
                _deckCard = value;
                OnPropertyChanged();
            }
        }

        private Card _topDiscardCard;
        public Card TopDiscardCard
        {
            get { return _topDiscardCard; }
            set
            {
                _topDiscardCard = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public Player Player1
        {
            get;set;
        }
        public Player Player2
        {
            get;set;
        }

        public void Start()
        {
            GameOver = false;
            Deck.Fill();
            Deck.Shuffle(true);
            DiscardPile = new CardSet();
            Player1 = InitializePlayer(1);
            Player2 = InitializePlayer(2);
            SetupInitialCards();
            GameNumber = $"#{Deck.GameNumber}";
            CurrentPlayer = Player1;
            DeckCard = Deck.GetTop();
            TopDiscardCard = null;
        }

        private Player InitializePlayer(int playerNumber)
        {
            var player = new Player(playerNumber);
            player.PropertyChanged += Player_PropertyChanged;
            return player;
        }

        private void SetupInitialCards()
        {
            bool playerFlag = false;
            var cardPosition = 1;
            for (int i = 0; i < 20; i++)
            {
                var nextCard = Deck.GetTop();
                if (!playerFlag) Player1.SetCard(nextCard, cardPosition);
                else Player2.SetCard(nextCard, cardPosition);
                playerFlag = !playerFlag;
                if (!playerFlag) cardPosition++;
            }

        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is Player)
            {
                OnPropertyChanged($"P{(sender as Player).Number}{e.PropertyName}");
            }
            else
            {
                OnPropertyChanged($"{sender}/{e.PropertyName}");
            }
        }

        public void GetFromDeck()
        {
            DeckCard.Turn();
            CurrentPlayer.HeldCard = DeckCard;
            DeckCard = Deck.GetTop();
        }


        public bool CanDiscard
        {
            get
            {
                return CurrentPlayer?.HeldCard != null && !GameOver;
            }
        }

        public bool CanGetFromDeck
        {
            get
            {
                return CurrentPlayer?.HeldCard == null && DeckCard != null && !GameOver;
            }
        }

        public bool CanGetFromDiscardPile
        {
            get
            {
                return CurrentPlayer?.HeldCard == null && TopDiscardCard != null && !GameOver;
            }
        }

        private bool _gameOver;
        public bool GameOver
        {
            get { return _gameOver; }
            set
            {
                _gameOver = value;
                OnPropertyChanged();
            }
        }

        public void Discard()
        {
            if (TopDiscardCard != null)
            {
                DiscardPile.PutTop(TopDiscardCard);
            }

            TopDiscardCard = CurrentPlayer.HeldCard;
            CurrentPlayer.HeldCard = null;
            EndTurn();
        }

        private void EndTurn()
        {
            if (CurrentPlayer == Player1)
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
        }

        internal void GetFromDiscardPile()
        {
            CurrentPlayer.HeldCard = TopDiscardCard;
            TopDiscardCard = DiscardPile.GetTop();

        }

        internal void SetCard(int positionToChange)
        {
            if (CurrentPlayer.HeldCard == null)
                throw new ApplicationException("Pegue uma carta primeiro");

            Card cardToChange = null;

            switch (positionToChange)
            {
                case 1:
                    cardToChange = CurrentPlayer.C1;
                    break;
                case 2:
                    cardToChange = CurrentPlayer.C2;
                    break;
                case 3:
                    cardToChange = CurrentPlayer.C3;
                    break;
                case 4:
                    cardToChange = CurrentPlayer.C4;
                    break;
                case 5:
                    cardToChange = CurrentPlayer.C5;
                    break;
                case 6:
                    cardToChange = CurrentPlayer.C6;
                    break;
                case 7:
                    cardToChange = CurrentPlayer.C7;
                    break;
                case 8:
                    cardToChange = CurrentPlayer.C8;
                    break;
                case 9:
                    cardToChange = CurrentPlayer.C9;
                    break;
                case 10:
                    cardToChange = CurrentPlayer.C10;
                    break;
            }

            if (!cardToChange.IsClosed || CurrentPlayer.HeldCard.Value != positionToChange)
            {
                throw new ApplicationException("Jogada Inválida, Tente novamente");
            }

            cardToChange.Turn();
            CurrentPlayer.SetCard(CurrentPlayer.HeldCard, positionToChange);
            CurrentPlayer.HeldCard = cardToChange;

            if (CurrentPlayer.Won)
            {
                GameOver = true;
            }

            if (TopDiscardCard?.Value > 10 && DeckCard == null)
            {
                CurrentPlayer = null;
                GameOver = true;
            }
        }


    }


}
