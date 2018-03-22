using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    class Board
    {
        #region Fields

        public static Random random = new Random();

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

        public Board(Difficulty boardDifficulty)
        {
            this.boardDifficulty = boardDifficulty;
            lower = CalculateLower(boardDifficulty);

            rows = Settings.Rows;
            cols = Settings.Cols;
            cells = new Cell[rows, cols];

            CreateSolved();
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

        #endregion

    }
}
