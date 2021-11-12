using System;
using System.Drawing;
using Carubbi.Extensions;
namespace Carubbi.Cards
{
    public class Card
    {
        private Bitmap _image;


        private string _name;

        public Card(Suit suit, int value, bool startClosed)
        {
            Suit = suit;
            Value = value;
            IsClosed = startClosed;
        }

        public Suit Suit { get; }

        public int Value { get; }

        public bool IsClosed { get; private set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = CheckName();
                return _name;
            }
        }

        public Bitmap Image
        {
            get
            {
                if (IsClosed)
                    _image = Resources.Back;
                else
                    _image = CheckImage();
                return _image;
            }
        }

        public string CompleteName => string.Format(Resources.FullNamePattern, Name, Suit.Text());

        public event EventHandler opened;
        public event EventHandler closed;


        public void Turn()
        {
            if (IsClosed)
                Open();
            else
                Close();
        }


        public void Open()
        {
            IsClosed = false;
            if (opened != null)
                opened(this, new EventArgs());
        }

        public void Close()
        {
            IsClosed = true;
            if (closed != null)
                closed(this, new EventArgs());
        }

        private string CheckName()
        {
            var name = string.Empty;
            switch (Value)
            {
                case 1:
                    name = Resources.Ace;
                    break;
                case 2:
                    name = Resources.Two;
                    break;
                case 3:
                    name = Resources.Three;
                    break;
                case 4:
                    name = Resources.Four;
                    break;
                case 5:
                    name = Resources.Five;
                    break;
                case 6:
                    name = Resources.Six;
                    break;
                case 7:
                    name = Resources.Seven;
                    break;
                case 8:
                    name = Resources.Eight;
                    break;
                case 9:
                    name = Resources.Nine;
                    break;
                case 10:
                    name = Resources.Ten;
                    break;
                case 11:
                    name = Resources.Jack;
                    break;
                case 12:
                    name = Resources.Queen;
                    break;
                case 13:
                    name = Resources.King;
                    break;
            }

            return name;
        }

        private Bitmap CheckImage()
        {
            switch (Suit)
            {
                case Suit.Hearts:
                    switch (Value)
                    {
                        case 1:
                            return Resources.H01;
                        case 2:
                            return Resources.H02;
                        case 3:
                            return Resources.H03;
                        case 4:
                            return Resources.H04;
                        case 5:
                            return Resources.H05;
                        case 6:
                            return Resources.H06;
                        case 7:
                            return Resources.H07;
                        case 8:
                            return Resources.H08;
                        case 9:
                            return Resources.H09;
                        case 10:
                            return Resources.H10;
                        case 11:
                            return Resources.H11;
                        case 12:
                            return Resources.H12;
                        case 13:
                            return Resources.H13;
                        default:
                            return null;
                    }
                case Suit.Spades:
                    switch (Value)
                    {
                        case 1:
                            return Resources.S01;
                        case 2:
                            return Resources.S02;
                        case 3:
                            return Resources.S03;
                        case 4:
                            return Resources.S04;
                        case 5:
                            return Resources.S05;
                        case 6:
                            return Resources.S06;
                        case 7:
                            return Resources.S07;
                        case 8:
                            return Resources.S08;
                        case 9:
                            return Resources.S09;
                        case 10:
                            return Resources.S10;
                        case 11:
                            return Resources.S11;
                        case 12:
                            return Resources.S12;
                        case 13:
                            return Resources.S13;
                        default:
                            return null;
                    }
                case Suit.Diamonds:
                    switch (Value)
                    {
                        case 1:
                            return Resources.D01;
                        case 2:
                            return Resources.D02;
                        case 3:
                            return Resources.D03;
                        case 4:
                            return Resources.D04;
                        case 5:
                            return Resources.D05;
                        case 6:
                            return Resources.D06;
                        case 7:
                            return Resources.D07;
                        case 8:
                            return Resources.D08;
                        case 9:
                            return Resources.D09;
                        case 10:
                            return Resources.D10;
                        case 11:
                            return Resources.D11;
                        case 12:
                            return Resources.D12;
                        case 13:
                            return Resources.D13;
                        default:
                            return null;
                    }
                case Suit.Clubs:
                    switch (Value)
                    {
                        case 1:
                            return Resources.C01;
                        case 2:
                            return Resources.C02;
                        case 3:
                            return Resources.C03;
                        case 4:
                            return Resources.C04;
                        case 5:
                            return Resources.C05;
                        case 6:
                            return Resources.C06;
                        case 7:
                            return Resources.C07;
                        case 8:
                            return Resources.C08;
                        case 9:
                            return Resources.C09;
                        case 10:
                            return Resources.C10;
                        case 11:
                            return Resources.C11;
                        case 12:
                            return Resources.C12;
                        case 13:
                            return Resources.C13;
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
    }
}