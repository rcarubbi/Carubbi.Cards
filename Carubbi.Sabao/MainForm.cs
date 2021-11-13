using Carubbi.Cards.WinForms;
using Carubbi.Sabao.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.Sabao
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Game _game;


        private void StartButton_Click(object sender, EventArgs e)
        {

            _game.Start();
        }

        private void _game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SuspendLayout();

            RefreshButtons();

            switch (e.PropertyName)
            {
                case "TopDiscardCard":
                    DiscardCardBox.Card = _game.TopDiscardCard;
                    break;
                case "P1HeldCard":
                case "P2HeldCard":
                    HeldCard.Card = _game.CurrentPlayer?.HeldCard;
                    break;
                case "DeckCard":
                    DeckCardBox.Card = _game.DeckCard;
                    break;
                case "GameNumber":
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
                case "GameOver":
                    if (_game.GameOver && _game.CurrentPlayer != null)
                    {
                        NotificationLabel.Text = $"Jogador {_game.CurrentPlayer.Number} venceu!";
                        MessageBox.Show(NotificationLabel.Text);
                    }
                    else if (_game.GameOver && _game.CurrentPlayer == null)
                    {
                        NotificationLabel.Text = "Empate";
                        MessageBox.Show(NotificationLabel.Text);
                    }
                    break;
                case "P1C1":
                    P1C1.Card = _game.Player1.C1;
                    break;
                case "P1C2":
                    P1C2.Card = _game.Player1.C2;
                    break;
                case "P1C3":
                    P1C3.Card = _game.Player1.C3;
                    break;
                case "P1C4":
                    P1C4.Card = _game.Player1.C4;
                    break;
                case "P1C5":
                    P1C5.Card = _game.Player1.C5;
                    break;
                case "P1C6":
                    P1C6.Card = _game.Player1.C6;
                    break;
                case "P1C7":
                    P1C7.Card = _game.Player1.C7;
                    break;
                case "P1C8":
                    P1C8.Card = _game.Player1.C8;
                    break;
                case "P1C9":
                    P1C9.Card = _game.Player1.C9;
                    break;
                case "P1C10":
                    P1C10.Card = _game.Player1.C10;
                    break;
                case "P2C1":
                    P2C1.Card = _game.Player2.C1;
                    break;
                case "P2C2":
                    P2C2.Card = _game.Player2.C2;
                    break;
                case "P2C3":
                    P2C3.Card = _game.Player2.C3;
                    break;
                case "P2C4":
                    P2C4.Card = _game.Player2.C4;
                    break;
                case "P2C5":
                    P2C5.Card = _game.Player2.C5;
                    break;
                case "P2C6":
                    P2C6.Card = _game.Player2.C6;
                    break;
                case "P2C7":
                    P2C7.Card = _game.Player2.C7;
                    break;
                case "P2C8":
                    P2C8.Card = _game.Player2.C8;
                    break;
                case "P2C9":
                    P2C9.Card = _game.Player2.C9;
                    break;
                case "P2C10":
                    P2C10.Card = _game.Player2.C10;
                    break;
                case "CurrentPlayer":
                    NotificationLabel.Text = $"Jogador {_game.CurrentPlayer.Number}, é sua vez de jogar";
                    HeldCard.Card = _game.CurrentPlayer?.HeldCard;
                    break;
                
            }


            ResumeLayout();
        }

        private void RefreshButtons()
        {
            DiscardButton.Enabled = _game.CanDiscard;
            GetFromDeckButton.Enabled = _game.CanGetFromDeck;
            GetFromDiscardPileButton.Enabled = _game.CanGetFromDiscardPile;

            P1C1.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C2.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C3.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C4.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C5.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C6.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C7.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C8.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C9.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;
            P1C10.Enabled = _game.CurrentPlayer?.Number == 1 && !_game.GameOver;

            P2C1.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C2.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C3.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C4.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C5.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C6.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C7.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C8.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C9.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            P2C10.Enabled = _game.CurrentPlayer?.Number == 2 && !_game.GameOver;
            DeckCardBox.Enabled = _game.CanGetFromDeck;
            DiscardCardBox.Enabled = _game.CanGetFromDiscardPile;
            HeldCard.Enabled = _game.CanDiscard;
            StartButton.Enabled = _game.GameOver;
        }

        private void DeckCardBox_Click(object sender, EventArgs e)
        {
            _game.GetFromDeck();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(this, "Are you sure?", "Quit game", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            Environment.Exit(0);
        }

        private void DiscardButton_Click(object sender, EventArgs e)
        {
            _game.Discard();
        }

        private void GetFromDeckButton_Click(object sender, EventArgs e)
        {
            _game.GetFromDeck();
        }

        private void GetFromDiscardPileButton_Click(object sender, EventArgs e)
        {
            _game.GetFromDiscardPile();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            try
            {
                var cardPosition = int.Parse((sender as CardBox).Tag.ToString());
                _game.SetCard(cardPosition);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _game = new Game();
            _game.PropertyChanged += _game_PropertyChanged;
            RefreshButtons();
        }

        private void DiscardCardBox_Click(object sender, EventArgs e)
        {
            _game.GetFromDiscardPile();
        }

        private void HeldCard_Click(object sender, EventArgs e)
        {
            _game.Discard();
        }
    }
}
