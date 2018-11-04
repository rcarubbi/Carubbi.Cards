using Carubbi.Cards;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.Cards.WinForms
{
    public partial class CardBox : PictureBox
    {
        public CardBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (DesignMode && BackgroundImage == null)
            {
                BackgroundImage = Resources.Back;
                Width = Resources.Back.Width;
                Height = Resources.Back.Height;
            }
        }


        private Card _card;

        public Card Card
        {
            get => _card;
            set
            {
                _card = value;
                if (_card != null)
                {

                    _card.closed += _card_changed;
                    _card.opened += _card_changed;
                    BackgroundImage = _card.Image;
                    Width = _card.Image.Width;
                    Height = _card.Image.Height;
                    BringToFront();
             
                }
                else
                {
                    BackgroundImage = null;
                    BackColor = Color.Transparent;

                }
                Invalidate();
                 
            }
        }

        private void _card_changed(object sender, EventArgs e)
        {
            if (_card != null)
            {
                BackgroundImage = _card.Image;
                Width = _card.Image.Width;
                Height = _card.Image.Height;
            }
            else
            {
                BackgroundImage = null;
            }
            BringToFront();
            Refresh();
        }
    }
}
