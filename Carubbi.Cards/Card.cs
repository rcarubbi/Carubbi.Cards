using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Carubbi.Cards
{
    public class Card
    {

        public Card(Suit naipe, int value, bool startClosed)
        {
            _naipe = naipe;
            _value = value;
            _isClosed = startClosed;

        }

        public event EventHandler opened;
        public event EventHandler closed;


        public void Turn()
        {
            if (_isClosed)
                Open();
            else
                Close();
        }

        private Suit _naipe;
        public Suit Naipe
        {
            get
            {
                return _naipe;
            }

        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }

        }

        private bool _isClosed;
        public bool IsClosed
        {
            get
            {
                return _isClosed;
            }
        }


        public void Open()
        {
            _isClosed = false;
            if (opened != null)
                opened(this, new EventArgs());
        }

        public void Close()
        {
            _isClosed = true;
            if (closed != null)
                closed(this, new EventArgs());
        }


        private string _name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = CheckName();
                return _name;
            }

        }

        private Bitmap _image;
        public Bitmap Image
        {
            get
            {

                if (_isClosed)
                {
                    _image = Resources.Back;
                }
                else
                {
                    _image = CheckImage();
                }
                return _image;
            }

        }

        public string CompleteName
        {
            get
            {
                return string.Format("{0} de {1}", Name, Naipe);
            }
        }

        private string CheckName()
        {
            string name = string.Empty;
            switch (Value)
            {
                case 1:
                    name = "ás";
                    break;
                case 2:
                    name = "dois";
                    break;
                case 3:
                    name = "três";
                    break;
                case 4:
                    name = "quatro";
                    break;
                case 5:
                    name = "cinco";
                    break;
                case 6:
                    name = "seis";
                    break;
                case 7:
                    name = "sete";
                    break;
                case 8:
                    name = "oito";
                    break;
                case 9:
                    name = "nove";
                    break;
                case 10:
                    name = "dez";
                    break;
                case 11:
                    name = "valete";
                    break;
                case 12:
                    name = "dama";
                    break;
                case 13:
                    name = "rei";
                    break;
            }

            return name;

        }

        private Bitmap CheckImage()
        {
            switch (Naipe)
            {
                case Suit.Copas:
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
                case Suit.Espadas:
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
                case Suit.Ouros:
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
                case Suit.Paus:
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
