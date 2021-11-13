using Carubbi.Cards;
using System;
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

        public Player(int playerNumber)
        {
            Number = playerNumber;
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

        public int Number { get; private set; }
        public bool Won { get
            {
                return !C1.IsClosed && C1.Value == 1
                    && !C2.IsClosed && C2.Value == 2
                    && !C3.IsClosed && C3.Value == 3
                    && !C4.IsClosed && C4.Value == 4
                    && !C5.IsClosed && C5.Value == 5
                    && !C6.IsClosed && C6.Value == 6
                    && !C7.IsClosed && C7.Value == 7
                    && !C8.IsClosed && C8.Value == 8
                    && !C9.IsClosed && C9.Value == 9
                    && !C10.IsClosed && C10.Value == 10;
            }
        }

        internal void SetCard(Card nextCard, int cardPosition)
        {

            switch (cardPosition)
            {
                case 1:
                    C1 = nextCard;
                    break;
                case 2:
                    C2 = nextCard;
                    break;
                case 3:
                    C3 = nextCard;
                    break;
                case 4:
                    C4 = nextCard;
                    break;
                case 5:
                    C5 = nextCard;
                    break;
                case 6:
                    C6 = nextCard;
                    break;
                case 7:
                    C7 = nextCard;
                    break;
                case 8:
                    C8 = nextCard;
                    break;
                case 9:
                    C9 = nextCard;
                    break;
                case 10:
                    C10 = nextCard;
                    break;
            }
        }

        internal bool IsValid(int value)
        {
            switch (value)
            {
                case 1:
                    return C1.IsClosed;
                case 2:
                    return C2.IsClosed;
                case 3:
                    return C3.IsClosed;
                case 4:
                    return C4.IsClosed;
                case 5:
                    return C5.IsClosed;
                case 6:
                    return C6.IsClosed;
                case 7:
                    return C7.IsClosed;
                case 8:
                    return C8.IsClosed;
                case 9:
                    return C9.IsClosed;
                case 10:
                    return C10.IsClosed;
                default:
                    return false;
            }
        }
    }
}
