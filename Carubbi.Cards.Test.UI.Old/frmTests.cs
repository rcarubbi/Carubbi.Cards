using System;
using System.Windows.Forms;

namespace Carubbi.Cards.Test.UI
{
    public partial class frmTests : Form
    {
        private Deck _deck;
        private CardSet _hand;

        public frmTests()
        {
            InitializeComponent();
        }

        private void frmTests_Load(object sender, EventArgs e)
        {
            _deck = new Deck(2, false);
            _hand = new CardSet();
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            Text = "Carubbi.Cards.Test.UI";
            _deck.Fill();
            _hand.Clear();
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void RefreshPanel(Panel panel, CardSet cardset)
        {
            panel.Controls.Clear();
            foreach (var card in cardset)
            {
                var cardImage = new PictureBox();
                cardImage.Height = card.Image.Height;
                cardImage.Width = card.Image.Width;
                cardImage.Image = card.Image;
                cardImage.Tag = card;
                cardImage.Click += cardImage_Click;
               
                panel.Controls.Add(cardImage);
            }
        }

        private void cardImage_Click(object sender, EventArgs e)
        {
            var selectedCard = (Card) ((PictureBox) sender).Tag;
            selectedCard.Turn();
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
            MessageBox.Show(string.Format("Carta virada : {0}", selectedCard.CompleteName));
        }


        private void btnShuffle_Click(object sender, EventArgs e)
        {
            _deck.Shuffle();
            RefreshPanel(pnlCards, _deck);
            Text = string.Format("Game Number # {0}", _deck.GameNumber);
        }

        private void btnGetTop_Click(object sender, EventArgs e)
        {
            _hand.PutBottom(_deck.GetTop());

            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnSobe_Click(object sender, EventArgs e)
        {
            _hand.PutBottom(_deck.GetBottom());

            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnQualquer_Click(object sender, EventArgs e)
        {
            _hand.PutBottom(_deck.GetRandom());
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnDe_Click(object sender, EventArgs e)
        {
            try
            {
                _hand.PutBottom(_deck.Get(Convert.ToInt32(txtDe.Text) - 1));
                RefreshPanel(pnlCards, _deck);
                RefreshPanel(pnlHand, _hand);
            }
            catch
            {
            }
        }

        private void btnCima_Click(object sender, EventArgs e)
        {
            _deck.PutTop(_hand.GetBottom());
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnBaixo_Click(object sender, EventArgs e)
        {
            _deck.PutBottom(_hand.GetBottom());
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnDevolverQualquer_Click(object sender, EventArgs e)
        {
            _deck.PutMiddle(_hand.GetBottom());
            RefreshPanel(pnlCards, _deck);
            RefreshPanel(pnlHand, _hand);
        }

        private void btnEm_Click(object sender, EventArgs e)
        {
            try
            {
                _deck.Set(_hand.GetBottom(), Convert.ToInt32(txtEm.Text) - 1);
                RefreshPanel(pnlCards, _deck);
                RefreshPanel(pnlHand, _hand);
            }
            catch
            {
            }
        }
    }
}