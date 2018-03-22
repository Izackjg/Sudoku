using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    class Cell
    {
        #region Fields

        private int cellValue;
        private int row;
        private int col;
        private Visibility cellVisibility;

        #endregion

        #region Properties

        public Visibility CellVisibility { get { return cellVisibility; } set { cellVisibility = value; } }
        public bool IsVisible { get { return cellVisibility == Visibility.Visible; } }

        public int CellValue { get { return cellValue; }set { cellValue = value; } }
        public int Row { get { return row; } }
        public int Col { get { return col; } }

        #endregion

        #region Constructors

        public Cell(int cellValue, int row, int col)
        {
            this.cellValue = cellValue;
            this.row = row;
            this.col = col;

            cellVisibility = Visibility.Visible;
        }

        public Cell()
        {
            cellValue = 0;
            row = 0;
            col = 0;

            cellVisibility = Visibility.Visible;
        }



        #endregion
    }
}
