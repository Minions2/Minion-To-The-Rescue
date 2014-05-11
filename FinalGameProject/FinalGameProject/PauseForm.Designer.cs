namespace FinalGameProject
{
    partial class PauseForm
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
            this.lblQuit = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblResume = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuit
            // 
            this.lblQuit.BackColor = System.Drawing.Color.Transparent;
            this.lblQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuit.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuit.ForeColor = System.Drawing.Color.Gold;
            this.lblQuit.Location = new System.Drawing.Point(12, 131);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(188, 54);
            this.lblQuit.TabIndex = 13;
            this.lblQuit.Text = "QUIT";
            this.lblQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuit.Click += new System.EventHandler(this.lblQuit_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.Gold;
            this.lblMenu.Location = new System.Drawing.Point(12, 63);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(188, 54);
            this.lblMenu.TabIndex = 12;
            this.lblMenu.Text = "MENU";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // lblResume
            // 
            this.lblResume.BackColor = System.Drawing.Color.Transparent;
            this.lblResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResume.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResume.ForeColor = System.Drawing.Color.Gold;
            this.lblResume.Location = new System.Drawing.Point(12, 9);
            this.lblResume.Name = "lblResume";
            this.lblResume.Size = new System.Drawing.Size(188, 54);
            this.lblResume.TabIndex = 10;
            this.lblResume.Text = "RESUME";
            this.lblResume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResume.Click += new System.EventHandler(this.lblResume_Click);
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinalGameProject.Properties.Resources.pause11;
            this.ClientSize = new System.Drawing.Size(560, 444);
            this.Controls.Add(this.lblQuit);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.lblResume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQuit;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblResume;
    }
}