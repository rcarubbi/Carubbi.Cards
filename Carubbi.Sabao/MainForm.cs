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
            _game = new Game();
            _game.PropertyChanged += _game_PropertyChanged;
            _game.Start();
        }

        private void _game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DiscardCard":
                    DiscardCardBox.Card = _game.DiscardCard;
                    break;
                case "DeckCardValid":
                    GetFromDeckButton.Visible = _game.DeckCardValid;
                    break;
                case "DeckCard":
                    DeckCardBox.Card = _game.DeckCard;
                    var visible = !_game.DeckCard?.IsClosed;
                    DiscardButton.Visible = visible.HasValue && visible.Value;
                    break;
                case "GameNumber":
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
                case "PlayerTurn":
                    if (_game.PlayerTurn == 1)
                    {
                        P1InnerPanel.BorderStyle= BorderStyle.Fixed3D;
                        P2InnerPanel.BorderStyle = BorderStyle.None;

                    }
                    else
                    {
                        P2InnerPanel.BorderStyle = BorderStyle.Fixed3D;
                        P1InnerPanel.BorderStyle = BorderStyle.None;
                    }

                    break;
                case "P1C1":
                    P1C1.Card = _game.P1C1;
                    break;
                case "P1C2":
                    P1C2.Card = _game.P1C2;
                    break;
                case "P1C3":
                    P1C3.Card = _game.P1C3;
                    break;
                case "P1C4":
                    P1C4.Card = _game.P1C4;
                    break;
                case "P1C5":
                    P1C5.Card = _game.P1C5;
                    break;
                case "P1C6":
                    P1C6.Card = _game.P1C6;
                    break;
                case "P1C7":
                    P1C7.Card = _game.P1C7;
                    break;
                case "P1C8":
                    P1C8.Card = _game.P1C8;
                    break;
                case "P1C9":
                    P1C9.Card = _game.P1C9;
                    break;
                case "P1C10":
                    P1C10.Card = _game.P1C10;
                    break;
                case "P2C1":
                    P2C1.Card = _game.P2C1;
                    break;
                case "P2C2":
                    P2C2.Card = _game.P2C2;
                    break;
                case "P2C3":
                    P2C3.Card = _game.P2C3;
                    break;
                case "P2C4":
                    P2C4.Card = _game.P2C4;
                    break;
                case "P2C5":
                    P2C5.Card = _game.P2C5;
                    break;
                case "P2C6":
                    P2C6.Card = _game.P2C6;
                    break;
                case "P2C7":
                    P2C7.Card = _game.P2C7;
                    break;
                case "P2C8":
                    P2C8.Card = _game.P2C8;
                    break;
                case "P2C9":
                    P2C9.Card = _game.P2C9;
                    break;
                case "P2C10":
                    P2C10.Card = _game.P2C10;
                    break;
            }
        }

        private void DeckCardBox_Click(object sender, EventArgs e)
        {
            _game?.TurnCard();
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
            _game?.Discard();
        }

        private void GetFromDeckButton_Click(object sender, EventArgs e)
        {
            _game.GetFromDeck();
        }
    }
}
