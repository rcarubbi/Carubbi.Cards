using Carubbi.RobaMonte.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.RobaMonte
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
                case "P1Card":
                    P1CardBox.Card = _game.P1Card;
                    break;
                case "P2Card":
                    P2CardBox.Card = _game.P2Card;
                    break;
                case "P1Score":
                    P1ScoreLabel.Text= _game.P1Score.ToString();
                    break;
                case "P2Score":
                    P2ScoreLabel.Text = _game.P2Score.ToString();
                    break;
                case "GameNumber":
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
                case "Message":
                    logPanel.Controls.Add(new Label{ Text = _game.Message, Width = logPanel.Width-45});
                    break;
            }
        }

        
        private void QuitButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(this, "Are you sure?", "Quit game", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            Environment.Exit(0);
        }

        private void TurnButton_Click(object sender, EventArgs e)
        {
            _game.Turn();
        }
    }
}
