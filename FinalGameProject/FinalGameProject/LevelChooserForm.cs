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
    public partial class LevelChooserForm : Form
    {
        ProfileForm PForm;
        MainForm MForm;

        public LevelChooserForm(ProfileForm PForm, MainForm MForm)
        {
            InitializeComponent();
            this.PForm = PForm;
            this.MForm = MForm;
        }

        private void btnMargo_Click(object sender, EventArgs e)
        {
            // со кликање на ова копче започнува соодветното ниво
            MainForm GF = new MainForm(this, GameMode.Easy);
            GF.MdiParent = this.MdiParent;
            GF.Show();
            GF.Location = new Point(0, 0);


        }

        private void btnEdith_Click(object sender, EventArgs e)
        {
            // со кликање на ова копче започнува соодветното ниво
            MainForm GF = new MainForm(this, GameMode.Medium);
            GF.MdiParent = this.MdiParent;
            GF.Show();
            GF.Location = new Point(0, 0);

          
        }

        private void btnAgnes_Click(object sender, EventArgs e)
        {
            // со кликање на ова копче започнува соодветното ниво
            MainForm GF = new MainForm(this, GameMode.Hard);
            GF.MdiParent = this.MdiParent;
            GF.Show();
            GF.Location = new Point(0, 0);

        }

        private void LevelChooserForm_Load(object sender, EventArgs e)
        {
            if (MForm == null)
            {
                PForm.Close();
            }
            else {

                MForm.Close();
            }
            
        }

        private void btnEdith_MouseEnter(object sender, EventArgs e)
        {
            btnEdith.ForeColor = Color.White;
        }

        private void btnEdith_MouseLeave(object sender, EventArgs e)
        {
            btnEdith.ForeColor = Color.MediumAquamarine;
        }

        private void btnAgnes_MouseEnter(object sender, EventArgs e)
        {
            btnAgnes.ForeColor = Color.White;
        }

        private void btnAgnes_MouseLeave(object sender, EventArgs e)
        {
            btnAgnes.ForeColor = Color.MediumAquamarine;
        }

        private void btnMargo_MouseEnter(object sender, EventArgs e)
        {
            btnMargo.ForeColor = Color.White;
        }

        private void btnMargo_MouseLeave(object sender, EventArgs e)
        {
            btnMargo.ForeColor = Color.MediumAquamarine;
        }
    }
}
