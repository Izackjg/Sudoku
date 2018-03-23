using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class GameForm : Form
    {
        private Board game;

        public GameForm()
        {
            InitializeComponent();

            game = new Board(this, canvas, Difficulty.Easy);
            game.Shuffle();
            

            StartPosition = FormStartPosition.CenterScreen;

            btnDisplayAnswers.Text = "Display";

            AddComboBoxItems();
            cmbDifficulties.SelectedIndex = 0;

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            AdjustSize();
        }

        private void AdjustSize()
        {
            int width = Settings.Rows * (Settings.Size + 1) + 15;
            int wDelta = width - canvas.Width;
            canvas.Width = width;
            Width += wDelta;

            int height = Settings.Cols * (Settings.Size + 1) + 15;
            int hDelta = height - canvas.Height;
            canvas.Height = height;
            Height += hDelta;
        }

        private void btnDisplayAnswers_Click(object sender, EventArgs e)
        {
            //bool isBoardDisplayed = game.IsDisplayed();

            //if (!isBoardDisplayed)
            //{
            //    game.DisplayEmptyHoles();
            //    game.SetDisplayed(true);
            //    isBoardDisplayed = game.IsDisplayed();

            //    btnDisplayAnswers.Text = "Hide";
            //}
            //else if (isBoardDisplayed)
            //{
            //    game.Hide();
            //    game.SetDisplayed(false);
            //    isBoardDisplayed = game.IsDisplayed();

            //    btnDisplayAnswers.Text = "Display";
        }


        private void btnReshuffle_Click(object sender, EventArgs e)
        {
            game.Shuffle();
            game.Dilute();
            //game.GetBoard().Shuffle();
            //game.RefreshBoardAndClearHidden();
            //game.DiluteBoard(Settings.Rows, Settings.Cols);

            foreach (Control c in canvas.Controls)
            {
                if (c.BackColor == Color.Red)
                    c.BackColor = Color.LightGray;
            }
        }

        private void AddComboBoxItems()
        {
            foreach (var item in Enum.GetValues(typeof(Difficulty)))
            {
                cmbDifficulties.Items.Add(item);
            }
        }
    }
}

