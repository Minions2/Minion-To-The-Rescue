namespace FinalGameProject
{
    partial class LevelChooserForm
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
            this.btnAgnes = new System.Windows.Forms.Button();
            this.btnEdith = new System.Windows.Forms.Button();
            this.btnMargo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgnes
            // 
            this.btnAgnes.BackColor = System.Drawing.Color.Transparent;
            this.btnAgnes.FlatAppearance.BorderSize = 0;
            this.btnAgnes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgnes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgnes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgnes.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgnes.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnAgnes.Location = new System.Drawing.Point(583, 439);
            this.btnAgnes.Name = "btnAgnes";
            this.btnAgnes.Size = new System.Drawing.Size(228, 87);
            this.btnAgnes.TabIndex = 5;
            this.btnAgnes.Text = "SAVE AGNES";
            this.btnAgnes.UseVisualStyleBackColor = false;
            this.btnAgnes.Click += new System.EventHandler(this.btnAgnes_Click);
            this.btnAgnes.MouseEnter += new System.EventHandler(this.btnAgnes_MouseEnter);
            this.btnAgnes.MouseLeave += new System.EventHandler(this.btnAgnes_MouseLeave);
            // 
            // btnEdith
            // 
            this.btnEdith.BackColor = System.Drawing.Color.Transparent;
            this.btnEdith.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdith.FlatAppearance.BorderSize = 0;
            this.btnEdith.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnEdith.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEdith.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEdith.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdith.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdith.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnEdith.Location = new System.Drawing.Point(540, 97);
            this.btnEdith.Name = "btnEdith";
            this.btnEdith.Size = new System.Drawing.Size(228, 87);
            this.btnEdith.TabIndex = 4;
            this.btnEdith.Text = "SAVE EDITH";
            this.btnEdith.UseVisualStyleBackColor = false;
            this.btnEdith.Click += new System.EventHandler(this.btnEdith_Click);
            this.btnEdith.MouseEnter += new System.EventHandler(this.btnEdith_MouseEnter);
            this.btnEdith.MouseLeave += new System.EventHandler(this.btnEdith_MouseLeave);
            // 
            // btnMargo
            // 
            this.btnMargo.BackColor = System.Drawing.Color.Transparent;
            this.btnMargo.FlatAppearance.BorderSize = 0;
            this.btnMargo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMargo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMargo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMargo.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMargo.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnMargo.Location = new System.Drawing.Point(163, 477);
            this.btnMargo.Name = "btnMargo";
            this.btnMargo.Size = new System.Drawing.Size(228, 87);
            this.btnMargo.TabIndex = 3;
            this.btnMargo.Text = "SAVE MARGO";
            this.btnMargo.UseVisualStyleBackColor = false;
            this.btnMargo.Click += new System.EventHandler(this.btnMargo_Click);
            this.btnMargo.MouseEnter += new System.EventHandler(this.btnMargo_MouseEnter);
            this.btnMargo.MouseLeave += new System.EventHandler(this.btnMargo_MouseLeave);
            // 
            // LevelChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinalGameProject.Properties.Resources.cmode;
            this.ClientSize = new System.Drawing.Size(1052, 590);
            this.Controls.Add(this.btnAgnes);
            this.Controls.Add(this.btnEdith);
            this.Controls.Add(this.btnMargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LevelChooserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelChooserForm";
            this.Load += new System.EventHandler(this.LevelChooserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgnes;
        private System.Windows.Forms.Button btnEdith;
        private System.Windows.Forms.Button btnMargo;
    }
}