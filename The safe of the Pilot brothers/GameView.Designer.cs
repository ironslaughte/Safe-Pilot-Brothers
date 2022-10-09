namespace The_safe_of_the_Pilot_brothers
{
    partial class GameView
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
            this.restartButton = new System.Windows.Forms.Button();
            this.rebootButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // restartButton
            // 
            this.restartButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.restartButton.Location = new System.Drawing.Point(144, 15);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(87, 48);
            this.restartButton.TabIndex = 0;
            this.restartButton.Text = "Начать заново";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // rebootButton
            // 
            this.rebootButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rebootButton.Location = new System.Drawing.Point(47, 15);
            this.rebootButton.Name = "rebootButton";
            this.rebootButton.Size = new System.Drawing.Size(91, 48);
            this.rebootButton.TabIndex = 1;
            this.rebootButton.Text = "Ввести новое значение размера сейфа";
            this.rebootButton.UseVisualStyleBackColor = true;
            this.rebootButton.Click += new System.EventHandler(this.RebootButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startButton.Location = new System.Drawing.Point(237, 15);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(86, 48);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Game
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(357, 91);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.rebootButton);
            this.Controls.Add(this.restartButton);
            this.Name = "Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button rebootButton;
        private System.Windows.Forms.Button startButton;
    }
}