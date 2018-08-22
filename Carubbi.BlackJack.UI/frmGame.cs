using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.BlackJack.UI
{
    public partial class frmGame : Form
    {
        private Dealer _dealer;

        public frmGame()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame.Enabled = false;
            EnableBetControls(true);
            _dealer = new Dealer();
            _dealer.playerWins += _dealer_playerWins;
            _dealer.afterPlayerWins += _dealer_afterPlayerWins;
            _dealer.afterGameOver += _dealer_afterGameOver;
            _dealer.gameOver += _dealer_gameOver;
            _dealer.cardModified += _dealer_cardModified;
            lblCredits.Text = _dealer.CurrentGame.Player.Credits.ToString("c");
            ClearPanel(pnlDealerHand);
            ClearPanel(pnlPlayerHand);
        }

        private void _dealer_cardModified(object sender, EventArgs e)
        {
            RefreshScreen();
            Application.DoEvents();
        }

        private void _dealer_afterGameOver(object sender, EventArgs e)
        {
            ClearPanel(pnlPlayerHand);
            ClearPanel(pnlDealerHand);
            RefreshScreen();
        }

        private void _dealer_afterPlayerWins(object sender, EventArgs e)
        {
            ClearPanel(pnlPlayerHand);
            ClearPanel(pnlDealerHand);
            RefreshScreen();
        }

        private void _dealer_gameOver(object sender, EventArgs e)
        {
            RefreshScreen();
            MessageBox.Show("Game Over");

            EnableCardControls(false);
            EnableBetControls(true);
        }

        private void _dealer_playerWins(object sender, EventArgs e)
        {
            RefreshScreen();
            MessageBox.Show("Você venceu!!");
            EnableCardControls(false);
            EnableBetControls(true);
            ClearPanel(pnlPlayerHand);
            ClearPanel(pnlDealerHand);
        }

        private void EnableCardControls(bool enable)
        {
            btnOrder.Enabled =
                btnStay.Enabled = enable;
        }

        private void EnableBetControls(bool enable)
        {
            btnBet.Enabled =
                betValue.Enabled = enable;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            try
            {
                EnableBetControls(false);

                _dealer.StartGame(betValue.Value);
                Text = string.Format("Carubbi's Blackjack - Game Number #{0}", _dealer.Deck.GameNumber);

                EnableCardControls(true);
                RefreshScreen();
            }
            catch (RuleInfringedException ex)
            {
                MessageBox.Show(ex.Message);
                EnableBetControls(true);
                EnableCardControls(false);
                btnNewGame.Enabled = true;
            }
        }

        private void RefreshCredits()
        {
            lblCredits.Text = _dealer.CurrentGame.Player.Credits.ToString("C");
        }

        private void RefreshPlayerPoints()
        {
            lblPlayerPoints.Text = _dealer.CurrentGame.Player.PointsInfo;
        }

        private void RefreshDealerPoints()
        {
            lblDealerPoints.Text = _dealer.PointsInfo;
        }

        private void RefreshBetValue()
        {
            lblBetGame.Text = _dealer.CurrentGame.BetValue.ToString("C");
        }

        private void RefreshScreen()
        {
            RefreshPanel(pnlDealerHand, _dealer);
            RefreshPanel(pnlPlayerHand, _dealer.CurrentGame.Player);
            RefreshCredits();
            RefreshBetValue();
            RefreshPlayerPoints();
            RefreshDealerPoints();
        }

        private void ClearPanel(Panel pnlHand)
        {
            foreach (Control c in pnlHand.Controls)
            {
                ((PictureBox) c).BackColor = Color.Transparent;
                ((PictureBox) c).Image = null;
                ((PictureBox) c).Refresh();
            }
        }

        private void RefreshPanel(Panel pnlHand, Player p)
        {
            var indexCard = 1;
            foreach (var c in p.Hand)
            {
                var pic = (PictureBox) pnlHand.Controls.Find(string.Concat(GetBaseName(pnlHand), indexCard), false)[0];
                pic.Width = c.Image.Width;
                pic.Height = c.Image.Height;
                pic.Image = c.Image;
                pic.BringToFront();
                pic.Refresh();

                indexCard++;
            }
        }

        private string GetBaseName(Panel pnlHand)
        {
            var pictureBaseName = string.Empty;
            if (pnlHand.Name.ToLower().Contains("dealer"))
                pictureBaseName = "dealerCard";
            else
                pictureBaseName = "playerCard";

            return pictureBaseName;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            _dealer.CurrentGame.Player.OrderCard(_dealer);
            RefreshScreen();
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            _dealer.CurrentGame.Player.Stay(_dealer);
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
        }

        private void betValue_ValueChanged(object sender, EventArgs e)
        {
            if (betValue.Value > _dealer.CurrentGame.Player.Credits)
                betValue.Value = _dealer.CurrentGame.Player.Credits;
        }
    }
}