using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuGame
{
    static class GraphicMethods
    {

        public static void MakeCombobox(Form parent)
        {
            ComboBox cb = new ComboBox();
            cb.Location = new Point(150, 150);
            cb.Size = new Size(70, 70);
            parent.Controls.Add(cb);

            for (int i = 0; i < 10; i++)
            {
                cb.Items.Add(i.ToString());
            }
        }
    }
}
