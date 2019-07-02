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

        #region Public Methods

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

        public bool IsInBounds(int iRow, int iColumn)
        {
            const bool isOnBoard = true;

            if (iRow < 0 || iRow > rBoardSize - 1)
            {
                return !isOnBoard;
            }
            else if (iColumn < 0 || iColumn > rBoardSize - 1)
            {
                return !isOnBoard;
            }

            return isOnBoard;
        }

        public bool IsNeighborOkay(Move iMove, Move iMoveDirection)
        {
            const bool isOkay = true;
            int desiredRow = iMove.Row + iMoveDirection.Row;
            int desiredColumn = iMove.Column + iMoveDirection.Column;

            if ((iMoveDirection.Row == 0 && iMoveDirection.Column == 0) ||
                !IsInBounds(desiredRow, desiredColumn))
            {
                return !isOkay;
            }

            else if (mBoard[desiredRow, desiredColumn].IsEmpty())
            {
                return !isOkay;
            }

            return isOkay;
        }

        public List<Move> GetPossibleMoves(Player iPlayer)
        {
            Move move = new Move(0, 0);
            List<Move>  possibleMoves = new List<Move>(1);

            for (int i = 0; i < rBoardSize; i++)
            {
                for (int j = 0; j < rBoardSize; j++)
                {
                    move.Row = i;
                    move.Column = j;
                    if (isMoveValid(iPlayer, move) && mBoard[move.Row, move.Column].IsEmpty())
                    {                        
                        possibleMoves.Add(new Move(i, j));
                    }
                }
            }

            return possibleMoves;
        }

        public bool IsAbleToPlay(Player iPlayer)
        {
            const bool isAbleToPlay = true;
            Move move = new Move(0, 0);            

            for (int i = 0; i < rBoardSize; i++)
            {
                for (int j = 0; j < rBoardSize; j++)
                {
                    move.Row = i;
                    move.Column = j;
                    if (isMoveValid(iPlayer, move) && mBoard[move.Row, move.Column].IsEmpty())
                    {
                        return isAbleToPlay;
                    }
                }
            }

            return !isAbleToPlay;
        }

        public bool PlayMove(Player iPlayer, Move iMove)
        {
            bool isMoveSuccessful = false;
            List<Move> possibleMoves = GetPossibleMoves(iPlayer);
            foreach (Move possibleMove in possibleMoves)
            {
                if ((possibleMove.Row == iMove.Row) && (possibleMove.Column == iMove.Column))
                {
                    mBoard[iMove.Row, iMove.Column].Owner = iPlayer;
                    changeBoardByMove(iPlayer, iMove);
                    isMoveSuccessful = true;
                }
            }
            return isMoveSuccessful;
        }      

        #endregion

        #region Private Methods

        private bool isMoveValid(Player iPlayer, Move iMove)
        {
            Square currentSquare;
            bool isValidMoveFound = false;
            Move moveDirection = new Move(0, 0);

            // Check surrounding neighbors
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    moveDirection.Row = i;
                    moveDirection.Column = j;

                    // ignore invalid squares
                    if (!IsNeighborOkay(iMove, moveDirection))
                    {
                        continue;
                    }
                    else
                    {
                        currentSquare = mBoard[iMove.Row + i, iMove.Column + j];
                        if ((iPlayer != currentSquare.Owner) && (isMoveValidInDirection(iPlayer, iMove, moveDirection)))
                        {
                            isValidMoveFound = true;
                            break;
                        }
                    }
                }

                // break outer loop if finished
                if (isValidMoveFound)
                {
                    break;
                }
            }

            return isValidMoveFound;
        }

        private bool isMoveValidInDirection(Player iPlayer, Move iMove, Move iMoveDirection)
        {
            int currentRow = iMove.Row;
            int currentColumn = iMove.Column;
            Square currentSquare = new Square();
            const bool isDirectionOkay = true;
            do
            {
                // Advance in direction
                currentRow += iMoveDirection.Row;
                currentColumn += iMoveDirection.Column;
                currentSquare = mBoard[currentRow, currentColumn];
                if (currentSquare.IsEmpty())
                {
                    break;
                }

                if (iPlayer == currentSquare.Owner)
                {
                    return isDirectionOkay;
                }
            }
            while (iPlayer != currentSquare.Owner && IsInBounds(currentRow + iMoveDirection.Row, currentColumn + iMoveDirection.Column));
            return !isDirectionOkay;
        }

        private void changeBoardByMove(Player iPlayer, Move iMove)
        {
            Square currentSquare, nextSquare;
            Move moveDirection = new Move(0, 0);

            // Check surrounding neighbors
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    moveDirection.Row = i;
                    moveDirection.Column = j;

                    // ignore invalid squares
                    if (!IsNeighborOkay(iMove, moveDirection))
                    {
                        continue;
                    }

                    // ignore already owned squares
                    if (iPlayer == mBoard[iMove.Row + i, iMove.Column + j].Owner)
                    {
                        continue;
                    }

                    if (isMoveValidInDirection(iPlayer, iMove, moveDirection))
                    {
                        int currentRow = iMove.Row, currentColumn = iMove.Column;
                        do
                        {
                            // Advance in direction
                            currentRow += moveDirection.Row;
                            currentColumn += moveDirection.Column;
                            currentSquare = mBoard[currentRow, currentColumn];
                            nextSquare = mBoard[currentRow + moveDirection.Row, currentColumn + moveDirection.Column];
                            mBoard[currentRow, currentColumn].Owner = iPlayer;
                        }
                        while (nextSquare.Owner != iPlayer);
                    }
                }
            }
        }

        #endregion

    }
}
