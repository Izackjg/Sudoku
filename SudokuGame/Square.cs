using System.Windows.Forms;
using System.Drawing;
using System;

namespace SudokuGame
{
    class Square : Button
    {
        private int size;
        private int row;
        private int col;

        public int SquareSize { get { return Settings.Size; } }
        public int Row { get { return row; } set { row = value; } }
        public int Column { get { return col; } set { col = value; } }

        public Square(int size, int row, int col)
        {
            this.size = size;
            this.row = row;
            this.col = col;

            Size = new Size(size, size);

            this.MouseClick += Square_MouseClick;
        }

        private void Square_MouseClick(object sender, MouseEventArgs e)
        {

        }       
    }
}
