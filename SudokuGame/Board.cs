using System;
using System.Windows.Forms;

namespace SudokuGame
{
    class Board
    {
        #region Fields

        private Form parent;
        private PictureBox canvas;

        private static Random random = new Random();
        private const int Times = 10000;

        private Cell[,] cells;
        private Difficulty boardDifficulty;

        private int lower;
        private int rows;
        private int cols;

        #endregion

        #region Properties

        public Cell this[int row, int col]
        {
            get
            {
                if (row >= rows || col >= cols)
                    throw new IndexOutOfRangeException();
                return cells[row, col];
            }
            set
            {
                if (row >= rows || col >= cols)
                    throw new IndexOutOfRangeException();
                cells[row, col] = value;
            }
        }

        public Difficulty Difficulty { get { return boardDifficulty; } }
        public int Lower { get { return lower; } }
        public int Rows { get { return rows; } }
        public int Columns { get { return cols; } }

        #endregion

        #region Constructors

        public Board(Form parent, PictureBox canvas, Difficulty boardDifficulty)
        {
            this.parent = parent;
            this.canvas = canvas;
            this.boardDifficulty = boardDifficulty;
            lower = CalculateLower(boardDifficulty);

            rows = Settings.Rows;
            cols = Settings.Cols;
            cells = new Cell[rows, cols];

            CreateSolved();
        }
        
        #endregion

        #region Public Methods

        public void Shuffle()
        {
            int s;
            int shuffleOne;
            int shuffleTwo;

            for (int i = 0; i < Times; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchRows(shuffleOne, shuffleTwo);
            }

            for (int i = 0; i < Times; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchCols(shuffleOne, shuffleTwo);
            }

            for (int i = 0; i < Times; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchRows(shuffleOne, shuffleTwo);
                SwitchCols(shuffleOne, shuffleTwo);
            }
        }

        public void Dilute(int rows, int cols)
        {

        }

        #endregion

        #region Private Methods

        private void CreateSolved()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value = (i * 3 + 9 / 3 + j) % 9 + 1;
                    cells[i, j] = new Cell(value, i, j);
                }
            }
        }

        private int CalculateLower(Difficulty diff)
        {
            switch (diff)
            {
                case Difficulty.Easy:
                    return Settings.EasyLower;
                case Difficulty.Medium:
                    return Settings.MediumLower;
                case Difficulty.Hard:
                    return Settings.HardLower;
                default:
                    return -1;
            }
        }
        
        private void SwitchRows(int row1, int row2)
        {
            for (int i = 0; i < Settings.Cols; i++)
            {
                int temp = cells[row1, i].CellValue;
                cells[row1, i].CellValue = cells[row2, i].CellValue;
                cells[row2, i].CellValue = temp;
            }
        }

        private void SwitchCols(int col1, int col2)
        {
            for (int i = 0; i < Settings.Rows; i++)
            {
                int temp = cells[i, col1].CellValue;
                cells[i, col1].CellValue = cells[i, col2].CellValue;
                cells[i, col2].CellValue = temp;
            }
        }

        #endregion
    }
}
