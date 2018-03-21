using System.Windows.Forms;

namespace SudokuGame
{
    class Square : Button
    {
        private int size;
        private int row;
        private int col;

        public Square(int size, int row, int col) : base()
        {
            this.size = size;
            this.row = row;
            this.col = col;

            Height = size;
            Width = size;
        }

        public Square() : base()
        {
            this.size = 0;
            this.row = 0;
            this.col = 0;
        }

        public void SetRow(int row) { this.row = row; }
        public void SetCol(int col) { this.col = col; }

        public int GetSize() { return size; }
        public int GetRow() { return row; }
        public int GetCol() { return col; }
    }
}
