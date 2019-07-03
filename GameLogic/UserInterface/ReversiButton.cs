using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public class ReversiButton : Button
    {
        private int mRow;
        private int mCol;

        public ReversiButton(int iRow, int iCol, int iSize)
        {
            this.mRow = iRow;
            this.mCol = iCol;
            this.Size = new Size(iSize, iSize);
        }

        public int Col { get => mCol; set => mCol = value; }
        public int Row { get => mRow; set => mRow = value; }
    }
}
