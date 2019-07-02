using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Board
    {
        private readonly int rBoardSize;
        private Square[,] mBoard;

        public Board(int iBoardSize)
        {
            this.mBoard = new Square[iBoardSize, iBoardSize];
            this.rBoardSize = iBoardSize;
        }

        public int Size { get;}
        public Square[,] MyBoard { get;}

        public void InitializeBoard(Player iPlayer1, Player iPlayer2)
        {
            for (int i = 0; i < rBoardSize; i++)
            {
                for (int j = 0; j < rBoardSize; j++)
                {
                    mBoard[i, j] = new Square();
                }
            }

            int xCenter = (rBoardSize - 1) / 2;
            int yCenter = (rBoardSize - 1) / 2;

            mBoard[xCenter, yCenter] = new Square(iPlayer1);
            mBoard[xCenter, yCenter + 1] = new Square(iPlayer2);
            mBoard[xCenter + 1, yCenter] = new Square(iPlayer2);
            mBoard[xCenter + 1, yCenter + 1] = new Square(iPlayer1);
        }

        public bool IsInBounds(int i_Row, int i_Column)
        {
            const bool isOnBoard = true;

            if (i_Row < 0 || i_Row > rBoardSize - 1)
            {
                return !isOnBoard;
            }
            else if (i_Column < 0 || i_Column > rBoardSize - 1)
            {
                return !isOnBoard;
            }

            return isOnBoard;
        }
    }
}
