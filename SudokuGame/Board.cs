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

        private Random random = new Random();

        private const int TIMES = 10000;

        private Difficulty diff;

        private int lower;
        private int[,] gameBoard;
        private int[,] hiddenGameBoard;

        #endregion

        #region Constructor

        public Board()
        {
            gameBoard = new int[Settings.Rows, Settings.Cols];
            hiddenGameBoard = new int[Settings.Rows, Settings.Cols];
            CreateSolvedBoard();
            CopyOriginalToHidden();
        }

        public Board(Difficulty diff)
        {
            this.diff = diff;
            if (diff == Difficulty.Easy)
                lower = Settings.EasyLower;
            else if (diff == Difficulty.Medium)
                lower = Settings.MediumLower;
            else
                lower = Settings.HardLower;

            gameBoard = new int[Settings.Rows, Settings.Cols];
            hiddenGameBoard = new int[Settings.Rows, Settings.Cols];
            CreateSolvedBoard();
            CopyOriginalToHidden();
        }
        #endregion

        #region Shuffle Methods

        public void WrongShuffle()
        {
            WrongShuffle(TIMES, TIMES, TIMES);
        }

        private void WrongShuffle(int timesRows, int timesCols, int timesBoth)
        {
            for (int i = 0; i < timesRows; i++)
            {
                SwitchRows(random.Next(0, 9), random.Next(0, 9));
            }

            for (int i = 0; i < timesCols; i++)
            {
                SwitchCols(random.Next(0, 9), random.Next(0, 9));
            }

            for (int i = 0; i < timesBoth; i++)
            {
                SwitchRows(random.Next(0, 9), random.Next(0, 9));
                SwitchCols(random.Next(0, 9), random.Next(0, 9));
            }
        }

        public void Shuffle()
        {
            Shuffle(TIMES, TIMES, TIMES);
        }

        private void Shuffle(int timesRows, int timesCols, int timesBoth)
        {
            int s;
            int shuffleOne;
            int shuffleTwo;

            for (int i = 0; i < timesRows; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchRows(shuffleOne, shuffleTwo);
            }

            for (int i = 0; i < timesCols; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchCols(shuffleOne, shuffleTwo);
            }

            for (int i = 0; i < timesBoth; i++)
            {
                s = random.Next(3);
                shuffleOne = s * 3 + random.Next(3);
                shuffleTwo = s * 3 + random.Next(3);
                SwitchRows(shuffleOne, shuffleTwo);
                SwitchCols(shuffleOne, shuffleTwo);
            }
        }

        #endregion

        #region Public Methods

        public void SetEmpty(int row, int col)
        {
            SetRowEmpty(row);
            SetColEmpty(col);
        }

        private void SetRowEmpty(int row)
        {
            for (int i = 0; i < Settings.Cols; i++)
            {
                int times = random.Next(1, lower + 1);
                for (int j = 0; j < times; j++)
                {
                    hiddenGameBoard[i, row] = Settings.SetThreshold;
                    row = random.Next(Settings.Rows);
                }
            }
        }

        private void SetColEmpty(int col)
        {
            for (int i = 0; i < Settings.Rows; i++)
            {
                int times = random.Next(1, lower + 1);
                for (int j = 0; j < times; j++)
                {
                    hiddenGameBoard[col, i] = Settings.SetThreshold;
                    col = random.Next(Settings.Cols);
                }
            }
        }

        public int CountHidden()
        {
            int count = 0;

            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Cols; j++)
                {
                    if (hiddenGameBoard[i, j] < Settings.HiddenThreshold)
                        count++;
                }
            }

            return count;
        }

        public bool IsValid()
        {
            bool valid = false;

            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Cols; j++)
                {
                    valid = CheckRow(i) && CheckColumn(j) && CheckBlock();

                    if (!valid)
                        return false;

                }
            }

            return true;
        }

        #endregion

        #region Private Methods

        private void CreateSolvedBoard()
        {
            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Cols; j++)
                {
                    gameBoard[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }
        }

        private void CopyOriginalToHidden()
        {
            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Cols; j++)
                {
                    hiddenGameBoard[i, j] = gameBoard[i, j];
                }
            }
        }

        private void SwitchRows(int row1, int row2)
        {
            for (int i = 0; i < Settings.Cols; i++)
            {
                int temp = gameBoard[row1, i];
                gameBoard[row1, i] = gameBoard[row2, i];
                gameBoard[row2, i] = temp;
            }
        }

        private void SwitchCols(int col1, int col2)
        {
            for (int i = 0; i < Settings.Rows; i++)
            {
                int temp = gameBoard[i, col1];
                gameBoard[i, col1] = gameBoard[i, col2];
                gameBoard[i, col2] = temp;
            }
        }

        private bool CheckRow(int row)
        {
            bool[] rowNums = new bool[9];
            //List<int> rowNums = new List<int>();

            for (int i = 0; i < Settings.Cols; i++)
            {
                if (rowNums[gameBoard[row, i] - 1])
                    return false;
                rowNums[gameBoard[row, i] - 1] = true;
                //if (rowNums.Contains(gameBoard[row, i]))
                //    return false;
                //rowNums.Add(gameBoard[row, i]);
            }

            return true;
        }

        private bool CheckColumn(int col)
        {
            bool[] colNums = new bool[9];
            //List<int> colNums = new List<int>();

            for (int i = 0; i < Settings.Rows; i++)
            {
                if (colNums[gameBoard[i, col] - 1])
                    return false;
                colNums[gameBoard[i, col] - 1] = true;
                //if (colNums.Contains(gameBoard[i, col]))
                //    return false;
                //colNums.Add(gameBoard[i, col]);
            }

            return true;
        }

        private bool CheckBlock()
        {
            bool[] blockNums = new bool[9]; // 0 -> 9 (value has to be value - 1).
            for (int i = 0; i < Settings.Rows; i++)
            {
                for (int j = 0; j < Settings.Cols; j++)
                {
                    for (int k = i; k < 3 + i; k++)
                    {
                        for (int l = j; l < 3 + j; l++)
                        {
                            int current = gameBoard[i, j];
                            blockNums[current - 1] = true;
                        }
                    }
                }
            }

            foreach (var boolVal in blockNums)
            {
                if (!boolVal)
                    return false;
            }
            return true;
        }

        private bool ContainsAllNums(List<int> numbers)
        {
            for (int i = 1; i < 10; i++)
            {
                if (!numbers.Contains(i))
                    return false;
            }

            return true;
        }

        #endregion

        #region Get/Set

        public void SetGameBoard(int[,] gameBoard) { this.gameBoard = gameBoard; }
        public void SetHiddenGameBoard(int[,] hiddenGameBoard) { this.hiddenGameBoard = hiddenGameBoard; }

        public int[,] GetGameBoard() { return gameBoard; }
        public int[,] GetHiddenGameBoard() { return hiddenGameBoard; }

        #endregion
    }
}
