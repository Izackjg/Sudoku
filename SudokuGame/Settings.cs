using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    static class Settings
    {
        #region Thresholds

        public const int SetThreshold = -1;
        public const int HiddenThreshold = 0;

        #endregion

        #region Lower

        public const int HardLower = 4;

        public const int MediumLower = 3;

        public const int EasyLower = 0;

        #endregion

        #region Size

        public const int Size = 55;
        public const int FontSize = 22;

        #endregion

        #region Dimensions

        public const int Rows = 9;
        public const int Cols = 9;
        public const int BlockDimensionRow = Rows / 3;
        public const int BlockDimensionCol = Cols / 3;

        #endregion
    }
}
