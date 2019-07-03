using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game
    {
        #region Data Memebers
        private readonly Player mPlayer1;
        private Player mPlayer2;
        private bool mIsVSComputer;
        private Board mBoard;
        private int mNumOfMovesPlayed;
        private eCurrentPlayer mCurrentPlayer;
        #endregion        

        #region Properties
        public Player Player1 { get => mPlayer1;}
        public Player Player2 { get => mPlayer2;}
        public bool IsVSComputer { get => mIsVSComputer;}
        public Board GameBoard { get => mBoard; }
        public int NumOfMovesPlayed { get => mNumOfMovesPlayed; set => mNumOfMovesPlayed = value; }
        public Player CurrentPlayer
        {
            get
            {
                if (mCurrentPlayer == eCurrentPlayer.Player1)
                {
                    return mPlayer1;
                }
                else
                {
                    return mPlayer2;
                }
            }
        }
        #endregion

        public Game(Player iPlayer1, Player iPlayer2, bool iIsVSComputer, Board iBoard)
        {
            this.mPlayer1 = iPlayer1;
            this.mPlayer2 = iPlayer2;
            this.mIsVSComputer = iIsVSComputer;
            this.mBoard = iBoard;
            this.mNumOfMovesPlayed = 0;
            this.mCurrentPlayer = eCurrentPlayer.Player1;
        }

        #region Public Methods
        public void PlayTurn(Player iPlayer, Move iMoveToPlay)
        {
            mBoard.PlayMove(iPlayer, iMoveToPlay);            
            mNumOfMovesPlayed++;
        }

        public void PlayComputerTurn(Player iComputer)
        {            
            Move moveToPlay = getComputerMove(iComputer);
            mBoard.PlayMove(iComputer, moveToPlay);
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

        public void StartNewGame()
        {
            mNumOfMovesPlayed = 0;
            mCurrentPlayer = eCurrentPlayer.Player1;
            mBoard.InitializeBoard(mPlayer1, mPlayer2);
        }

        public void ChangePlayer()
        {
            if (mCurrentPlayer == eCurrentPlayer.Player1)
            {
                mCurrentPlayer = eCurrentPlayer.Player2;
            }
            else
            {
                mCurrentPlayer = eCurrentPlayer.Player1;
            }
        }

        public Player GetPlayer(eCurrentPlayer iPlayer)
        {
            if (iPlayer == eCurrentPlayer.Player1)
            {
                return mPlayer1;
            }
            else
            {
                return mPlayer2;
            }
        }

        public Player GetOtherPlayer(eCurrentPlayer iPlayer)
        {
            if (iPlayer == eCurrentPlayer.Player1)
            {
                return mPlayer2;
            }
            else
            {
                return mPlayer1;
            }
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


