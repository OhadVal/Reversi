using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Move
    {
        private int mRow;
        private int mColumn;

        public Move(int iRow, int iColumn)
        {
            this.mRow = iRow;
            this.mColumn = iColumn;
        }

        public int Row { get; set; }       

        public int Column { get; set; }
    }
}
