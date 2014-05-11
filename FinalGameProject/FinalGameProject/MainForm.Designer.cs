namespace FinalGameProject
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.TmrMoving = new System.Windows.Forms.Timer(this.components);
            this.lblPause = new System.Windows.Forms.Label();
            this.lblEMKilled = new System.Windows.Forms.Label();
            this.lblEndWinning = new System.Windows.Forms.Label();
            this.lblNextLevel = new System.Windows.Forms.Label();
            this.pnlWinning = new System.Windows.Forms.Panel();
            this.lblCongrats = new System.Windows.Forms.Label();
            this.TmrPauseBetweenGames = new System.Windows.Forms.Timer(this.components);
            this.lblVector = new System.Windows.Forms.Label();
            this.pnlWinning.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrMoving
            // 
            this.TmrMoving.Interval = 15;
            this.TmrMoving.Tick += new System.EventHandler(this.TmrMoving_Tick);
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.BackColor = System.Drawing.Color.Transparent;
            this.lblPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPause.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPause.ForeColor = System.Drawing.Color.Tomato;
            this.lblPause.Location = new System.Drawing.Point(897, 62);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(134, 46);
            this.lblPause.TabIndex = 1;
            this.lblPause.Text = "PAUSE";
            this.lblPause.Click += new System.EventHandler(this.lblPause_Click);
            this.lblPause.MouseEnter += new System.EventHandler(this.lblPause_MouseEnter);
            this.lblPause.MouseLeave += new System.EventHandler(this.lblPause_MouseLeave);
            // 
            // lblEMKilled
            // 
            this.lblEMKilled.AutoSize = true;
            this.lblEMKilled.BackColor = System.Drawing.Color.Transparent;
            this.lblEMKilled.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMKilled.ForeColor = System.Drawing.Color.Thistle;
            this.lblEMKilled.Location = new System.Drawing.Point(108, 99);
            this.lblEMKilled.Name = "lblEMKilled";
            this.lblEMKilled.Size = new System.Drawing.Size(41, 44);
            this.lblEMKilled.TabIndex = 2;
            this.lblEMKilled.Text = "0";
            // 
            // lblEndWinning
            // 
            this.lblEndWinning.AutoSize = true;
            this.lblEndWinning.BackColor = System.Drawing.Color.Transparent;
            this.lblEndWinning.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndWinning.ForeColor = System.Drawing.Color.Tomato;
            this.lblEndWinning.Location = new System.Drawing.Point(237, 145);
            this.lblEndWinning.Name = "lblEndWinning";
            this.lblEndWinning.Size = new System.Drawing.Size(597, 119);
            this.lblEndWinning.TabIndex = 3;
            this.lblEndWinning.Text = "YOU WON !!";
            this.lblEndWinning.Visible = false;
            this.lblEndWinning.MouseEnter += new System.EventHandler(this.lblEndWinning_MouseEnter);
            this.lblEndWinning.MouseLeave += new System.EventHandler(this.lblEndWinning_MouseLeave);
            // 
            // lblNextLevel
            // 
            this.lblNextLevel.AutoSize = true;
            this.lblNextLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblNextLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextLevel.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNextLevel.Location = new System.Drawing.Point(721, 321);
            this.lblNextLevel.Name = "lblNextLevel";
            this.lblNextLevel.Size = new System.Drawing.Size(177, 36);
            this.lblNextLevel.TabIndex = 4;
            this.lblNextLevel.Text = "NEXT LEVEL";
            this.lblNextLevel.Visible = false;
            this.lblNextLevel.Click += new System.EventHandler(this.lblNextLevel_Click);
            // 
            // pnlWinning
            // 
            this.pnlWinning.BackColor = System.Drawing.Color.LightCyan;
            this.pnlWinning.Controls.Add(this.lblCongrats);
            this.pnlWinning.Controls.Add(this.lblEndWinning);
            this.pnlWinning.Controls.Add(this.lblNextLevel);
            this.pnlWinning.Location = new System.Drawing.Point(0, 0);
            this.pnlWinning.Name = "pnlWinning";
            this.pnlWinning.Size = new System.Drawing.Size(1052, 590);
            this.pnlWinning.TabIndex = 5;
            this.pnlWinning.Visible = false;
            // 
            // lblCongrats
            // 
            this.lblCongrats.AutoSize = true;
            this.lblCongrats.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongrats.ForeColor = System.Drawing.Color.Tomato;
            this.lblCongrats.Location = new System.Drawing.Point(326, 99);
            this.lblCongrats.Name = "lblCongrats";
            this.lblCongrats.Size = new System.Drawing.Size(368, 46);
            this.lblCongrats.TabIndex = 5;
            this.lblCongrats.Text = "CONGRATULATIONS ";
            this.lblCongrats.Visible = false;
            // 
            // TmrPauseBetweenGames
            // 
            this.TmrPauseBetweenGames.Interval = 10000;
            // 
            // lblVector
            // 
            this.lblVector.AutoSize = true;
            this.lblVector.BackColor = System.Drawing.Color.Transparent;
            this.lblVector.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVector.ForeColor = System.Drawing.Color.OldLace;
            this.lblVector.Location = new System.Drawing.Point(13, 155);
            this.lblVector.Name = "lblVector";
            this.lblVector.Size = new System.Drawing.Size(307, 27);
            this.lblVector.TabIndex = 6;
            this.lblVector.Text = "VECTOR DEFEATED  0 TIMES !!";
            this.lblVector.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 590);
            this.Controls.Add(this.pnlWinning);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.lblEMKilled);
            this.Controls.Add(this.lblVector);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.pnlWinning.ResumeLayout(false);
            this.pnlWinning.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TmrMoving;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblEMKilled;
        private System.Windows.Forms.Label lblEndWinning;
        private System.Windows.Forms.Label lblNextLevel;
        private System.Windows.Forms.Panel pnlWinning;
        private System.Windows.Forms.Label lblCongrats;
        private System.Windows.Forms.Timer TmrPauseBetweenGames;
        private System.Windows.Forms.Label lblVector;
    }
}

