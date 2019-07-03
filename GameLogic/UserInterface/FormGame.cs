using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace UserInterface
{
    public partial class FormGame : Form
    {
        private const string kTitle = "Reversi";
        private ReversiButton[,] mbuttonGameBoard;
        private Game mGame;        
        private int mButtonSize = 50;
        private eCurrentPlayer mCurrentPlayer;
        private List<ReversiButton> mCurrentClickableButtons = new List<ReversiButton>();

        public FormGame(int iBoardSize, bool iIsVSComputer, string iPlayer1Name, string iPlayer2Name)
        {            
            mGame = new Game(new Player(iPlayer1Name), new Player(iPlayer2Name), iIsVSComputer, new Board(iBoardSize));
            mCurrentPlayer = eCurrentPlayer.Player1;
            InitializeComponentCustom(iBoardSize);
        }

        private void InitializeComponentCustom(int iBoardSize)
        {
            // FormGame
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Size = new Size((mButtonSize * (iBoardSize + 1)) + 16, (mButtonSize * (iBoardSize + 1)) + 39);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = $"{kTitle} - {mGame.CurrentPlayer.Name}'s turn";

            mGame.StartNewGame();
            mGame.GameBoard.IsAbleToPlay(mGame.CurrentPlayer);
            mbuttonGameBoard = new ReversiButton[iBoardSize, iBoardSize];

            for (int i = 0; i < iBoardSize; i++)
            {
                for (int j = 0; j < iBoardSize; j++)
                {
                    mbuttonGameBoard[i, j] = new ReversiButton(i, j, mButtonSize);
                    mbuttonGameBoard[i, j].Location = new Point((mButtonSize / 2) + (i * mButtonSize), (mButtonSize / 2) + (j * mButtonSize));
                    mbuttonGameBoard[i, j].Enabled = false;

                    updateButtonBackgroundImage(i, j);
                    this.Controls.Add(mbuttonGameBoard[i, j]);
                }
            }

            updatePossibleMoves();
        }

        private void updateButtonBackgroundImage(int iRow, int iCol)
        {
            if (!mGame.GameBoard[new Move(iRow, iCol)].IsEmpty())
            {
                if (mGame.GameBoard[new Move(iRow, iCol)].Owner == mGame.GetPlayer(eCurrentPlayer.Player1))
                {
                    mbuttonGameBoard[iRow, iCol].BackgroundImage = UserInterface.Properties.Resources.goku;
                }
                else if (mGame.GameBoard[new Move(iRow, iCol)].Owner == mGame.GetPlayer(eCurrentPlayer.Player2))
                {
                    mbuttonGameBoard[iRow, iCol].BackgroundImage = UserInterface.Properties.Resources.vegeta;
                }
            }
            else
            {
                mbuttonGameBoard[iRow, iCol].BackgroundImage = null;
            }
        }

        private void updatePossibleMoves()
        {
            if (mGame.GameBoard.IsAbleToPlay(mGame.CurrentPlayer))
            {
                foreach (Move move in mGame.GameBoard.GetPossibleMoves(mGame.CurrentPlayer))
                {
                    mbuttonGameBoard[move.Row, move.Column].Enabled = true;
                    mbuttonGameBoard[move.Row, move.Column].BackColor = Color.Green;
                    mbuttonGameBoard[move.Row, move.Column].Click += new EventHandler(buttonClicked);
                    mCurrentClickableButtons.Add(mbuttonGameBoard[move.Row, move.Column]);
                }
            }
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            ReversiButton currentButton = (ReversiButton)sender;
            mGame.PlayTurn(mGame.CurrentPlayer, new Move(currentButton.Row, currentButton.Col));
            EndTurn();
        }

        private void EndTurn()
        {
            mCurrentPlayer = ChangePlayer();
            mGame.ChangePlayer();
            refreshBoard();
            if(mGame.IsGameOver())
            {
                GameOver();
            }

            // Plays the computer's turn if it's vs computer.
            if(mGame.CurrentPlayer == mGame.Player2 && mGame.IsVSComputer)
            {
                wait(800);
                mGame.PlayComputerTurn(mGame.CurrentPlayer);
                EndTurn();
            }
        }

        private void GameOver()
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to play again?", kTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                newGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private eCurrentPlayer ChangePlayer()
        {
            if(mCurrentPlayer == eCurrentPlayer.Player1)
            {
                return eCurrentPlayer.Player2;
            }
            else
            {
                return eCurrentPlayer.Player1;
            }
        }

        private void newGame()
        {
            mGame.StartNewGame();            
            updatePossibleMoves();
            refreshBoard();
        }

        private void refreshBoard()
        {
            resetClickableButtons();
            for (int i = 0; i < mGame.GameBoard.Size; i++)
            {
                for (int j = 0; j < mGame.GameBoard.Size; j++)
                {
                    mbuttonGameBoard[i, j].BackColor = DefaultBackColor;
                    mbuttonGameBoard[i, j].UseVisualStyleBackColor = true;
                    mbuttonGameBoard[i, j].Enabled = false;
                    updateButtonBackgroundImage(i, j);
                }
            }

            updatePossibleMoves();
            this.Text = $"{kTitle} - {mGame.CurrentPlayer.Name}'s Turn";
        }

        private void resetClickableButtons()
        {
            int amountOfItemsToRemove = mCurrentClickableButtons.Count - 1;
            for (int i = amountOfItemsToRemove; i >= 0; i--)
            {
                mCurrentClickableButtons[i].Click -= new EventHandler(buttonClicked);
                mCurrentClickableButtons.Remove(mCurrentClickableButtons[i]);
            }
        }      

        /// <summary>
        /// This function is pausing the program for x seconds.
        /// </summary>
        /// <param name="x"></param>
        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            //start wait timer
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //stop wait timer
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
