namespace UserInterface
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonAgainstFriend = new System.Windows.Forms.Button();
            this.buttonAgainstComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerTextBox
            // 
            this.firstPlayerTextBox.Location = new System.Drawing.Point(223, 32);
            this.firstPlayerTextBox.Name = "firstPlayerTextBox";
            this.firstPlayerTextBox.Size = new System.Drawing.Size(136, 22);
            this.firstPlayerTextBox.TabIndex = 0;
            this.firstPlayerTextBox.Text = "Goku";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second Player Name:";
            // 
            // secondPlayerTextBox
            // 
            this.secondPlayerTextBox.Location = new System.Drawing.Point(223, 70);
            this.secondPlayerTextBox.Name = "secondPlayerTextBox";
            this.secondPlayerTextBox.Size = new System.Drawing.Size(136, 22);
            this.secondPlayerTextBox.TabIndex = 3;
            this.secondPlayerTextBox.Text = "Vegeta";
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Location = new System.Drawing.Point(26, 137);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(333, 99);
            this.buttonBoardSize.TabIndex = 4;
            this.buttonBoardSize.Text = "Board Size: 6 x 6 (Click to Increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSizeClick);
            // 
            // buttonAgainstFriend
            // 
            this.buttonAgainstFriend.Location = new System.Drawing.Point(223, 286);
            this.buttonAgainstFriend.Name = "buttonAgainstFriend";
            this.buttonAgainstFriend.Size = new System.Drawing.Size(156, 79);
            this.buttonAgainstFriend.TabIndex = 5;
            this.buttonAgainstFriend.Text = "Play Against Your Friend";
            this.buttonAgainstFriend.UseVisualStyleBackColor = true;
            this.buttonAgainstFriend.Click += new System.EventHandler(this.buttonAgainstFriendClick);
            // 
            // buttonAgainstComputer
            // 
            this.buttonAgainstComputer.Location = new System.Drawing.Point(12, 286);
            this.buttonAgainstComputer.Name = "buttonAgainstComputer";
            this.buttonAgainstComputer.Size = new System.Drawing.Size(156, 79);
            this.buttonAgainstComputer.TabIndex = 6;
            this.buttonAgainstComputer.Text = "Play Against the Computer";
            this.buttonAgainstComputer.UseVisualStyleBackColor = true;
            this.buttonAgainstComputer.Click += new System.EventHandler(this.buttonAgainstComputerClick);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 391);
            this.Controls.Add(this.buttonAgainstComputer);
            this.Controls.Add(this.buttonAgainstFriend);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.secondPlayerTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstPlayerTextBox);
            this.Name = "FormGameSettings";
            this.Text = "Reversi - Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox firstPlayerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox secondPlayerTextBox;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonAgainstFriend;
        private System.Windows.Forms.Button buttonAgainstComputer;
    }
}