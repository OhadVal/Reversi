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

        public int Row
        {
            get
            {
                return mRow;
            }

            set
            {
                mRow = value;
            }
        }

        public int Column
        {
            get
            {
                return mColumn;
            }

            set
            {
                mColumn = value;
            }
        }


        public static Move operator +(Move iMove, Move iOtherMove)
        {
            return new Move(iMove.Row + iOtherMove.Row, iMove.Column + iOtherMove.Column);
        }
    }
}
