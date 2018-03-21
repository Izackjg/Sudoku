using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    static class HelperMethods
    {
        // These are extension methods.
        public static T[] GetRow<T>(this T[,] input, int row) where T : IComparable
        {
            int rows = input.GetLength(0);
            int cols = input.GetLength(1);

            if (row >= rows)
                throw new IndexOutOfRangeException("Row Index out of Range.");

            T[] requestedRow = new T[cols];

            for (int i = 0; i < cols; i++)
            {
                requestedRow[i] = input[row, i];
            }

            return requestedRow;

        }

        public static T[] GetCol<T>(this T[,] input, int col) where T : IComparable
        {
            int rows = input.GetLength(0);
            int cols = input.GetLength(1);

            if (col >= cols)
                throw new IndexOutOfRangeException("Column Index out of Range.");

            T[] requestedCol = new T[rows];

            for (int i = 0; i < rows; i++)
            {
                requestedCol[i] = input[i, col];
            }

            return requestedCol;
        }
    }
}
