using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class FormGameSettings : Form
    {
        private const bool mPlayVSComputer = true;
        private int mboardSize = 6;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void buttonBoardSizeClick(object sender, EventArgs e)
        {
            changeBoardSize();
            this.buttonBoardSize.Text = $"Board Size: {mboardSize} x {mboardSize} (Click to Increase)";
        }

        private void changeBoardSize()
        {
            if (mboardSize == 12)
            {
                mboardSize = 6;
            }
            else
            {
                mboardSize += 2;
            }
        }       

        private void buttonAgainstFriendClick(object sender, EventArgs e)
        {
            if(checkInput())
            {
                Play(!mPlayVSComputer);
            }
            else
            {
                MessageBox.Show("There's something wrong with the usernames", "Message", MessageBoxButtons.OK);
            }

        }

        private void buttonAgainstComputerClick(object sender, EventArgs e)
        {
            if (checkInput())
            {
                Play(mPlayVSComputer);
            }
            else
            {
                MessageBox.Show("There's something wrong with the user names", "Message", MessageBoxButtons.OK);
            }
        }
        
        private bool checkInput()
        {
            string player1 = firstPlayerTextBox.Text;
            string player2 = secondPlayerTextBox.Text;
            const bool isOkay = true;

            if(player1 == "" || player2 == "")
            {
                return !isOkay;
            }
            else if(player1 == player2)
            {
                return !isOkay;
            }
            return isOkay;
        }

        private void Play(bool iIsVSComputer)
        {
            string player1 = firstPlayerTextBox.Text;
            string player2 = secondPlayerTextBox.Text;
            this.Hide();
            FormGame formGame = new FormGame(mboardSize, iIsVSComputer, player1, player2);
            formGame.ShowDialog();
            this.Close();
        }
    }
}
