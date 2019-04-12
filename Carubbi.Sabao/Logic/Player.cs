using Carubbi.Cards;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carubbi.Sabao.Logic
{
    public class Player : INotifyPropertyChanged
    {
        private Card _heldCard;

        public Card HeldCard
        {
            get => _heldCard;
            set
            {
                _heldCard = value;
                OnPropertyChanged();
            }
        }

        public Player(CardSet deck)
        {
            InitializeCards(deck);
        }

        private void InitializeCards(CardSet deck)
        {
            C1 = deck.GetTop();
            C2 = deck.GetTop();
            C3 = deck.GetTop();
            C4 = deck.GetTop();
            C5 = deck.GetTop();
            C6 = deck.GetTop();
            C7 = deck.GetTop();
            C8 = deck.GetTop();
            C9 = deck.GetTop();
            C10 = deck.GetTop();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Card _c1;

        public Card C1
        {
            get => _c1;
            set
            {
                _c1 = value;
                OnPropertyChanged();
            }
        }

        private Card _c2;

        public Card C2
        {
            get => _c2;
            set
            {
                _c2 = value;
                OnPropertyChanged();
            }
        }

        private Card _c3;

        public Card C3
        {
            get => _c3;
            set
            {
                _c3 = value;
                OnPropertyChanged();
            }
        }

        private Card _c4;

        public Card C4
        {
            get => _c4;
            set
            {
                _c4 = value;
                OnPropertyChanged();
            }
        }

        private Card _c5;

        public Card C5
        {
            get => _c5;
            set
            {
                _c5 = value;
                OnPropertyChanged();
            }
        }

        private Card _c6;

        public Card C6
        {
            get => _c6;
            set
            {
                _c6 = value;
                OnPropertyChanged();
            }
        }

        private Card _c7;

        public Card C7
        {
            get => _c7;
            set
            {
                _c7 = value;
                OnPropertyChanged();
            }
        }

        private Card _c8;

        public Card C8
        {
            get => _c8;
            set
            {
                _c8 = value;
                OnPropertyChanged();
            }
        }

        private Card _c9;

        public Card C9
        {
            get => _c9;
            set
            {
                _c9 = value;
                OnPropertyChanged();
            }
        }

        private Card _c10;

        public Card C10
        {
            get => _c10;
            set
            {
                _c10 = value;
                OnPropertyChanged();
            }
        }
    }
}
