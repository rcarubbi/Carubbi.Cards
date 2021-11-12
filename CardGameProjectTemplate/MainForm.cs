using CardGameProjectTemplate.Logic;
using System;
using System.Windows.Forms;

namespace CardGameProjectTemplate
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
            switch (e.PropertyName)
            {
                case "DiscardCard":
                    DiscardCardBox.Card = _game.DiscardCard;
                    break;
                case "DeckCard":
                    DeckCardBox.Card = _game.DeckCard;
                    break;
                case "GameNumber":
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
            }
        }

        private void DeckCardBox_Click(object sender, EventArgs e)
        {
            _game?.Discard();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(this, "Are you sure?", "Quit game", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _game = new Logic.Game();
            _game.PropertyChanged += _game_PropertyChanged;
        }
    }
}
