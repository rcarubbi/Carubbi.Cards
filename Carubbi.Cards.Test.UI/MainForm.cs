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

        private void RefreshPanel(Panel panel, CardSet cardset)
        {

            SuspendLayout();
            
            panel.SuspendLayout();
            
            panel.Controls.Clear();
            

            foreach (var card in cardset)
            {
                var cardImage = new CardBox { Card = card };
                 
                cardImage.Click += CardImage_Click;
                panel.Controls.Add(cardImage);
              
            }
         
            panel.ResumeLayout();
            ResumeLayout();
            panel.Visible = true;
        }

        private void CardImage_Click(object sender, EventArgs e)
        {
            var selectedCard = ((CardBox)sender).Card;
            _game.TurnCard(selectedCard);
            MessageBox.Show($"Turned Card : {selectedCard.CompleteName}");
        }

        private void _game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_game.Deck):
                    RefreshPanel(DeckPanel, _game.Deck);
                    break;
                case nameof(_game.Hand):
                    RefreshPanel(HandPanel, _game.Hand);
                    break;
                case nameof(_game.GameNumber):
                    GameNumberLabel.Text = _game.GameNumber;
                    break;
                case nameof(_game.State):
                    RefreshPanel(buttonsPanel, _game.State);
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
