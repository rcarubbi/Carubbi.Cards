using Carubbi.Cards.Test.UI.Logic;
using Carubbi.Cards.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Carubbi.Cards.Test.UI
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

        private void CardBoxSelected(object sender, CardBox e)
        {
            var selectedCard = e.Card;
            _game.TurnCard(selectedCard);
            MessageBox.Show($"Turned Card : {selectedCard.CompleteName}");
        }

        private void RefreshPanel(Panel panel, GameStates state)
        {
            SuspendLayout();
            panel.SuspendLayout();
            
            foreach(var innerPanel in panel.Controls.OfType<Panel>())
            {
                RefreshPanel(innerPanel, state);
            }

            foreach(var button in panel.Controls.OfType<Button>()){
                button.Enabled = string.IsNullOrEmpty((button.Tag ?? string.Empty).ToString()) || button.Tag.ToString() == state.ToString();
            }

            panel.ResumeLayout();
            ResumeLayout();
            panel.Visible = true;
        }

    

        

        private void _game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_game.GameNumber):
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
                case nameof(_game.State):
                    RefreshPanel(buttonsPanel, _game.State);
                    break;
                case nameof(_game.Deck):
                    DeckPanel.CardSet = _game.Deck;
                    DeckPanel.CardBoxSelected += CardBoxSelected;
                    break;
                case nameof(_game.Hand):
                    HandPanel.CardSet = _game.Hand;
                    HandPanel.CardBoxSelected += CardBoxSelected;
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

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            _game.Shuffle();
            
        }

        private void TopToBottomButton_Click(object sender, EventArgs e)
        {
            _game.GetFromTop();
        }

        private void BottomToBottomButton_Click(object sender, EventArgs e)
        {
            _game.GetFromBottom();
        }

        private void GetRandomButton_Click(object sender, EventArgs e)
        {
            _game.GetRandom();
        }

        private void GetFrom_Click(object sender, EventArgs e)
        {
            _game.GetFrom(GetFromIndexTextBox.Value);
        }
     
        private void PutToTopButton_Click(object sender, EventArgs e)
        {
            _game.PutToTop();
        }

        private void PutToBottomButton_Click(object sender, EventArgs e)
        {
            _game.PutToBottom();
            
        }

        private void PutToRandomButton_Click(object sender, EventArgs e)
        {
            _game.PutToRandom();
        }

        private void PutToButton_Click(object sender, EventArgs e)
        {
            _game.PutTo(PutToIndexTextBox.Value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _game = new Game();
            RefreshPanel(buttonsPanel, _game.State);
            _game.PropertyChanged += _game_PropertyChanged;
        }

       
    }
}
