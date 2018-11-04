using System;
using System.Windows.Forms;
using Carubbi.Cards;

namespace Carubbi.RobaMonte
{
    public partial class frmGame : Form
    {
        private Deck _deck;
        private CardSet _player1;
        private CardSet _player2;

        private bool turn;

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            _deck = new Deck(1, false);
            _player1 = new CardSet();
            _player2 = new CardSet();
            Start();
        }

        private void btnDesce_Click(object sender, EventArgs e)
        {
            if (!_deck.IsEmpty)
            {
                if (turn)
                {
                    Play(picPlayer1, _player1, lblPlacarP1);
                    CheckSteal(_player1, _player2, picPlayer1, lblPlacarP1, picPlayer2, lblPlacarP2);
                }
                else
                {
                    Play(picPlayer2, _player2, lblPlacarP2);
                    CheckSteal(_player2, _player1, picPlayer2, lblPlacarP2, picPlayer1, lblPlacarP1);
                }

                turn = !turn;
            }
            else
            {
                if (_player1.Count > _player2.Count)
                {
                    MessageBox.Show("Jogador 1 (Azul) Venceu!");
                    NewGame();
                }
                else if (_player2.Count > _player1.Count)
                {
                    MessageBox.Show("Jogador 2 (Vermelho) Venceu!");
                    NewGame();
                }
                else
                {
                    MessageBox.Show("Empatou!");
                    Start();
                    MessageBox.Show(string.Format("Adicionado mais um baralho No. {0}", _deck.GameNumber));
                }
            }
        }

        private void Refresh(PictureBox picture, CardSet player, Label placar)
        {
            picture.Image = null;
            if (player.Count > 0)
            {
                picture.Image = player[0].Image;
                picture.Refresh();
            }

            placar.Text = player.Count.ToString();
        }

        private void CheckSteal(CardSet stealer, CardSet stealed, PictureBox pictureStealer, Label placarStealer,
            PictureBox pictureStealed, Label placarStealed)
        {
            if (stealer.Count > 0 && stealed.Count > 0)
                if (stealer[0].Value == stealed[0].Value)
                {
                    MessageBox.Show(string.Format("Robou {0} cartas!!!", stealed.Count));

                    while (!stealed.IsEmpty)
                        stealer.PutTop(stealed.GetBottom());

                    Refresh(pictureStealer, stealer, placarStealer);
                    Refresh(pictureStealed, stealed, placarStealed);
                }
        }

        private void Play(PictureBox picture, CardSet player, Label placar)
        {
            player.PutTop(_deck.GetTop());
            Refresh(picture, player, placar);
        }

        private void NewGame()
        {
            _player1.Clear();
            _player2.Clear();
            Refresh(picPlayer1, _player1, lblPlacarP1);
            Refresh(picPlayer2, _player2, lblPlacarP2);
            Start();
        }

        private void Start()
        {
            _deck.Fill();
            _deck.Shuffle();
        }
    }
}