using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalGameProject
{
    public partial class PauseForm : Form
    {


        MainForm MForm;

        public PauseForm(MainForm MForm)
        {
            InitializeComponent();
            this.MForm = MForm;
        }

      


        private void lblResume_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            ProfileForm pf = new ProfileForm(null, this);
            pf.MdiParent = MForm.MdiParent;
            pf.Show();
            pf.Location = new Point(0, 0);
            MForm.Close();
        }

        private void lblQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit the game ? ", " Quit the game ", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                MForm.MdiParent.Close();
            }
        }

       


    }
}
