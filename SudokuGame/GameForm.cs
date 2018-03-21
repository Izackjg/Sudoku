using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class GameForm : Form
    {
        private Sudoku game;

        public GameForm()
        {
            InitializeComponent();

            game = new Sudoku(this, board, Difficulty.Easy);
            game.Hide();

            StartPosition = FormStartPosition.CenterScreen;

            btnDisplayAnswers.Text = "Display";

            int hiddenCount = game.GetBoard().CountHidden();
            lblHiddenCount.Text = $"Hidden: {hiddenCount.ToString()}";

            AddComboBoxItems();
            cmbDifficulties.SelectedIndex = 0;

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnDisplayAnswers_Click(object sender, EventArgs e)
        {
            bool isBoardDisplayed = game.IsDisplayed();

            if (!isBoardDisplayed)
            {
                game.DisplayEmptyHoles();
                game.SetDisplayed(true);
                isBoardDisplayed = game.IsDisplayed();

                btnDisplayAnswers.Text = "Hide";
            }
            else if (isBoardDisplayed)
            {
                game.Hide();
                game.SetDisplayed(false);
                isBoardDisplayed = game.IsDisplayed();

                btnDisplayAnswers.Text = "Display";
            }
        }

        private void btnReshuffle_Click(object sender, EventArgs e)
        {
            game.GetBoard().Shuffle();
            game.RefreshBoardAndClearHidden();
            game.DiluteBoard(Settings.Rows, Settings.Cols);
            game.Hide();

            int hiddenCount = game.GetBoard().CountHidden();
            lblHiddenCount.Text = "Hidden: " + hiddenCount.ToString();
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
