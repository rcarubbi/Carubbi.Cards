using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Carubbi.Cards;

namespace Carubbi.SlotCard.UI
{
    public partial class frmGame : Form
    {
        private readonly Machine _machine;

        public frmGame()
        {
            InitializeComponent();
            _machine = new Machine();
            ConfigureMachine();
        }

        public int LinesEnableds
        {
            get
            {
                var qtLinesEnableds = 0;
                if (pnlLine1.Enabled)
                    qtLinesEnableds++;
                if (pnlLine2.Enabled)
                    qtLinesEnableds++;
                if (pnlLine3.Enabled)
                    qtLinesEnableds++;

                return qtLinesEnableds;
            }
        }

        private void ConfigureMachine()
        {
            _machine.OnCreditsAltered += _machine_CreditsAltered;
            _machine.OnSpin += _machine_OnSpin;
            _machine.OnPlay += _machine_OnPlay;
            _machine.OnPayPrice += _machine_OnPayPrice;
        }

        private void _machine_OnPayPrice(object sender, PriceEventArgs e)
        {
            switch (e.LineNumber)
            {
                case 1:
                    lblGainLine2.Text = e.PriceValue.ToString();
                    lblPriceName2.Text = e.PriceName;
                    break;
                case 2:
                    lblGainLine1.Text = e.PriceValue.ToString();
                    lblPriceName1.Text = e.PriceName;
                    break;
                case 3:
                    lblGainLine3.Text = e.PriceValue.ToString();
                    lblPriceName3.Text = e.PriceName;
                    break;
            }
        }

        private void _machine_OnPlay(object sender, EventArgs e)
        {
            lblTotalGamesValue.Text = _machine.TotalGamesPlayeds.ToString();
            lblCoinsCollectedValue.Text = _machine.TotalCoinsReceived.ToString();
            lblCoinsReturnValue.Text = _machine.TotalCoinsReturneds.ToString();
            lblPercentReturnValue.Text =
                (Convert.ToDecimal(_machine.TotalCoinsReturneds) / Convert.ToDecimal(_machine.TotalCoinsReceived) * 100)
                .ToString();
            lblMode.Text = _machine.Mode;
        }

        private void _machine_OnSpin(object sender, EventArgs e)
        {
            var roulleteNumber = 1;
            foreach (var r in _machine.Roulletes) RefreshRoullete(r, roulleteNumber++);
            Application.DoEvents();
        }

        private void RefreshRoullete(Roullete r, int roulleteNumber)
        {
            switch (roulleteNumber)
            {
                case 1:
                    LoadCard(pbSlot11, r.Slot1);
                    LoadCard(pbSlot21, r.Slot2);
                    LoadCard(pbSlot31, r.Slot3);
                    break;
                case 2:
                    LoadCard(pbSlot12, r.Slot1);
                    LoadCard(pbSlot22, r.Slot2);
                    LoadCard(pbSlot32, r.Slot3);
                    break;
                case 3:
                    LoadCard(pbSlot13, r.Slot1);
                    LoadCard(pbSlot23, r.Slot2);
                    LoadCard(pbSlot33, r.Slot3);
                    break;
                case 4:
                    LoadCard(pbSlot14, r.Slot1);
                    LoadCard(pbSlot24, r.Slot2);
                    LoadCard(pbSlot34, r.Slot3);
                    break;
                case 5:
                    LoadCard(pbSlot15, r.Slot1);
                    LoadCard(pbSlot25, r.Slot2);
                    LoadCard(pbSlot35, r.Slot3);
                    break;
            }
        }

        private void LoadCard(PictureBox pic, Card c)
        {
            c.Turn();
            pic.Width = c.Image.Width;
            pic.Height = c.Image.Height;
            pic.Image = c.Image;
            pic.BringToFront();
            pic.Refresh();
        }

        private void _machine_CreditsAltered(object sender, EventArgs e)
        {
            lblCredits.Text = _machine.Credits.ToString();
        }

        private void EnableLine(Panel line)
        {
            line.Enabled = true;
            line.BackColor = Color.Black;
        }

        private void DisableLine(Panel line)
        {
            line.Enabled = false;
            line.BackColor = Color.Gray;
        }

        private void btn1Line_Click(object sender, EventArgs e)
        {
            var maxPossible = _machine.CheckCreditsToPlayLines(1);
            EnableLine(pnlLine2);
            DisableLine(pnlLine1);
            DisableLine(pnlLine3);
            btn1Line.Enabled = false;
            btn2Lines.Enabled =
                btn3Lines.Enabled = true;

            if (maxPossible <= 0)
                GameOver();
        }

        private void btn2Lines_Click(object sender, EventArgs e)
        {
            var maxPossible = _machine.CheckCreditsToPlayLines(2);

            EnableLine(pnlLine1);
            EnableLine(pnlLine2);
            DisableLine(pnlLine3);
            btn2Lines.Enabled = false;
            btn1Line.Enabled =
                btn3Lines.Enabled = true;

            if (maxPossible <= 0)
                btn1Line_Click(this, EventArgs.Empty);
        }

        private void btn3Lines_Click(object sender, EventArgs e)
        {
            var maxPossible = _machine.CheckCreditsToPlayLines(3);

            EnableLine(pnlLine1);
            EnableLine(pnlLine2);
            EnableLine(pnlLine3);
            btn3Lines.Enabled = false;
            btn1Line.Enabled =
                btn2Lines.Enabled = true;

            if (maxPossible <= 0)
                btn2Lines_Click(this, EventArgs.Empty);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            PrepareNewGame();
            RefreshBetPanels(0);
        }

        private void PrepareNewGame()
        {
            _machine.Credits = 1000;
            btn1Line_Click(this, EventArgs.Empty);
            EnableBetButtons(true);
            btnNewGame.Enabled = false;
        }


        private void GameOver()
        {
            _machine.Credits = 0;
            btnNewGame.Enabled = true;
            DisableLine(pnlLine1);
            DisableLine(pnlLine2);
            DisableLine(pnlLine3);
            EnableBetButtons(false);
            DisableAllLineButtons();
#if !DEBUG
            MessageBox.Show("Insira mais créditos");
#endif
        }

        private void EnableBetButtons(bool p)
        {
            btnBet1.Enabled =
                btnBet3.Enabled =
                    btnBetMax.Enabled = p;
        }

        private void DisableAllLineButtons()
        {
            btn1Line.Enabled =
                btn2Lines.Enabled =
                    btn3Lines.Enabled = false;
        }

        private void RefreshBetPanels(int value)
        {
            lblGainLine1.Text =
                lblGainLine2.Text =
                    lblGainLine3.Text =
                        lblPriceName1.Text =
                            lblPriceName2.Text =
                                lblPriceName3.Text = string.Empty;


            lblBetLine1.Text =
                lblBetLine2.Text =
                    lblBetLine3.Text = string.Empty;
            if (value > 0)
            {
                if (pnlLine1.Enabled)
                    lblBetLine1.Text = value.ToString();
                if (pnlLine2.Enabled)
                    lblBetLine2.Text = value.ToString();
                if (pnlLine3.Enabled)
                    lblBetLine3.Text = value.ToString();
            }
        }

        private void btnBet1_Click(object sender, EventArgs e)
        {
            var creditsRemain = _machine.CheckCreditsToPlayLines(LinesEnableds);
            if (creditsRemain >= 1)
            {
                RefreshBetPanels(1);
                _machine.Play(1, LinesEnableds);
            }
            else
            {
                GameOver();
            }
        }

        private void btnBet3_Click(object sender, EventArgs e)
        {
            var creditsRemain = _machine.CheckCreditsToPlayLines(LinesEnableds);
            if (creditsRemain >= 3)
            {
                RefreshBetPanels(3);
                _machine.Play(3, LinesEnableds);
            }
            else
            {
                btnBet1_Click(this, EventArgs.Empty);
            }
        }

        private void btnBetMax_Click(object sender, EventArgs e)
        {
            var creditsRemain = _machine.CheckCreditsToPlayLines(LinesEnableds);
            if (creditsRemain >= 5)
            {
                RefreshBetPanels(5);
                _machine.Play(5, LinesEnableds);
            }
            else
            {
                btnBet3_Click(this, EventArgs.Empty);
            }
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            _machine.PercentGain = Convert.ToDecimal(txtPercentReturn.Text);
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
#if DEBUG
            while (true)
                BeginPlay();
#endif
        }

        private void BeginPlay()
        {
            var sw = new StreamWriter(@"C:\Documents and Settings\Raphael\My Documents\Testes\result.txt", true);
            btnNewGame_Click(this, EventArgs.Empty);
            btn3Lines_Click(this, EventArgs.Empty);
            var countGames = 0;
            var record = 0;
            while (_machine.Credits > 0)
            {
                btnBetMax_Click(this, EventArgs.Empty);
                if (_machine.Credits > record) record = _machine.Credits;
                countGames++;
            }

            sw.WriteLine("{0} - Jogos {1}, Maximo obtido {2}", DateTime.Now, countGames, record);
            sw.Close();
            sw.Dispose();
        }
    }
}