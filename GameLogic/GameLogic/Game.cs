using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Game
    {
        #region Data Memebers
        private readonly Player mPlayer1;
        private Player mPlayer2;
        private bool mIsVSComputer;
        private Board mBoard;
        private int mNumOfMovesPlayed;
        #endregion

        #region Properties
        public Player Player1 { get => mPlayer1;}
        public Player Player2 { get => mPlayer2;}
        public bool IsVSComputer { get => mIsVSComputer;}
        public Board GameBoard { get => mBoard; }
        public int NumOfMovesPlayed { get => mNumOfMovesPlayed; set => mNumOfMovesPlayed = value; }
        #endregion

        public Game(Player iPlayer1, Player iPlayer2, bool iIsVSComputer, Board iBoard)
        {
            this.mPlayer1 = iPlayer1;
            this.mPlayer2 = iPlayer2;
            this.mIsVSComputer = iIsVSComputer;
            this.mBoard = iBoard;
            this.mNumOfMovesPlayed = 0;
        }

        #region Public Methods
        public void PlayTurn(Player ioPlayer, Move iMoveToPlay)
        {
            mBoard.PlayMove(ioPlayer, iMoveToPlay);            
            mNumOfMovesPlayed++;
        }

        public void PlayComputerTurn(Player ioComputer)
        {
            Move moveToPlay = getComputerMove(ioComputer);
            mBoard.PlayMove(ioComputer, moveToPlay);
            mNumOfMovesPlayed++;
        }

        public bool IsGameOver()
        {
            const bool isGameOver = true;
            int boardSize = mBoard.Size * mBoard.Size;

            if (mNumOfMovesPlayed >= boardSize)
            {
                return isGameOver;
            }
            else
            {
                if (!mBoard.IsAbleToPlay(mPlayer1) && !mBoard.IsAbleToPlay(mPlayer2))
                {
                    return isGameOver;
                }
            }
            return !isGameOver;
        }
        #endregion

        #region Private Methods
        private Move getComputerMove(Player iPlayer)
        {
            List<Move> possibleMoves = mBoard.GetPossibleMoves(iPlayer);
            Random random = new Random();
            int randomMove = random.Next(0, possibleMoves.Count);
            return possibleMoves[randomMove];
        }

        #endregion
    }
}
