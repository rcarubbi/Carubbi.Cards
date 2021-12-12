using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.Cards.WinForms
{
    public partial class CardSetPanel : Panel
    {
        public CardSetPanel()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
        }

        public int CardPadding { get; set; }
         
        private CardSet _cardSet;

        public CardSet CardSet
        {
            get => _cardSet;
            set
            {
                _cardSet = value;
                if (_cardSet != null)
                {
                    _cardSet = value;
                    _cardSet.CardSetChanged += _cardSet_CardSetChanged;
                }
                SuspendLayout();
                RefreshPanel();
                Invalidate();
                ResumeLayout();
            }
        }

        private void _cardSet_CardSetChanged(object sender, CardSetChangedEventArgs e)
        {
            SuspendLayout();
            switch (e.Action)
            {
                case CardSetActions.CardAdded:
                    
                    var left = CalculateLeft(e.CardIndex);
                    MoveRemainingCardBoxesRight(e.CardIndex);
                    var cardBox = new CardBox { Card = e.Card, Left = left };
                    cardBox.Click += CardBox_Click;
                    Controls.Add(cardBox);
                    Controls.SetChildIndex(cardBox, e.CardIndex);
                    break;
                case CardSetActions.CardRemoved:
                    MoveRemainingCardBoxesLeft(e.CardIndex);
                    Controls.RemoveAt(e.CardIndex);
                    break;
                default:
                    break;
            }
            Invalidate();
            Refresh();
            ResumeLayout();
        }

     

        private void MoveRemainingCardBoxesRight(int cardIndex)
        {
            if (cardIndex < Controls.Count)
            {
                for (int i = cardIndex; i < Controls.Count - 1; i++)
                {
                    Controls[i].Left = Controls[i + 1].Left;
                }
                Controls[Controls.Count - 1].Left = CalculateLeft(Controls.Count - 1);
            }
        }

        private void MoveRemainingCardBoxesLeft(int cardIndex)
        {
            if (cardIndex < Controls.Count-1)
            {
                for (int i = Controls.Count - 1; i > cardIndex; i--)
                {
                    Controls[i].Left = Controls[i - 1].Left;
                }
            }
        }

        private int CalculateLeft(int cardIndex)
        {
            return cardIndex > 0 
                ? Controls[cardIndex - 1].Left + Controls[cardIndex - 1].Width + CardPadding
                : 0;
        }

        private void RefreshPanel()
        {
            if (_cardSet == null) return;
            Controls.Clear();
            var index = 0;
            foreach(var card in _cardSet)
            {
                var left = CalculateLeft(index++);
                var cardBox = new CardBox { Card = card, Left = left};
                cardBox.Click += CardBox_Click;
                Controls.Add(cardBox);
            }
        }


        public event EventHandler<CardBox> CardBoxSelected;

        private void CardBox_Click(object sender, EventArgs e)
        {
            CardBoxSelected?.Invoke(this, (sender as CardBox));
        }
    }
}
