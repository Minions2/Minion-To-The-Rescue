using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Media;
using System.IO;
using System.Reflection;

namespace FinalGameProject
{
    /// <summary>
    /// почетна форма (логирање и пристап за регистрација).
    /// </summary>
    public partial class LogInForm : Form
    {
        ProfileForm PForm;

        // database
         SqlCeConnection con;
         SqlCeCommand cmd = new SqlCeCommand();
         SqlCeDataReader rdr;
         SqlCeParameter picture;

        // intro music
         SoundPlayer happy = new SoundPlayer(Properties.Resources.Happy);
         public static String Username ;

        public LogInForm(ProfileForm PForm)
        {
            InitializeComponent();
            this.PForm = PForm;
            con = new SqlCeConnection(@"Data Source=App_Data\Database.sdf");
            picture = new SqlCeParameter("@picture", SqlDbType.Image);
            cmd.Connection = con;
            happy.PlayLooping();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            if (PForm != null)
            {
                PForm.Close();    
            }

        }


        bool flag;
        /// <summary>
        /// логирање доколку играчот има постоечки акаунт + база на податоци.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIn_Click(object sender, EventArgs e)
        {

            string userName = tbUsername.Text;
            Username = tbUsername.Text;
            string password = tbPass.Text;

            if (tbUsername.Text == "" && tbPass.Text == "")
            {
                MessageBox.Show("Enter username or password");
                flag = true;
            }
            else
            {

                string query = "SELECT * FROM PlayerTable WHERE username = '" + userName + "'";
                cmd = new SqlCeCommand(query, con);

                con.Open();
                try
                {
                    rdr = cmd.ExecuteReader();
                    rdr.Read();


                    string probaUser = rdr[0].ToString().Trim();
                    string probaPass = rdr[1].ToString().Trim();

                    con.Close();
                    //погрешна лозинка
                    if (userName.Equals(probaUser.ToString()) && !password.Equals(probaPass.ToString()))
                    {
                        MessageBox.Show("The password is incorrect.");
                        tbPass.Select(0, tbPass.Text.Length);
                    }

                     // се е во ред.
                    else
                    {
                        ProfileForm PF = new ProfileForm(this, null);
                        PF.MdiParent = this.MdiParent;
                        PF.Show();
                        PF.Location = new Point(0, 0);


                    }
                }
                catch
                {
                    if (!flag)
                    {
                        MessageBox.Show("The user name or password is incorrect.");
                    }
                    tbUsername.Select(0, tbUsername.Text.Length);

                }
            }
        }

        /// <summary>
        /// основање на нов профил од играчот.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm su = new SignUpForm();
            su.ShowDialog();
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string userName = tbUsername.Text;
                Username = tbUsername.Text;
                string password = tbPass.Text;

                if (tbUsername.Text == "" && tbPass.Text == "")
                {
                    MessageBox.Show("Enter username or password");
                    flag = true;
                }

                string query = "SELECT * FROM PlayerTable WHERE username = '" + userName + "'";
                cmd = new SqlCeCommand(query, con);

                con.Open();
                try
                {
                    rdr = cmd.ExecuteReader();
                    rdr.Read();


                    string probaUser = rdr[0].ToString().Trim();
                    string probaPass = rdr[1].ToString().Trim();

                    con.Close();
                    //погрешна лозинка
                    if (userName.Equals(probaUser.ToString()) && !password.Equals(probaPass.ToString()))
                    {
                        MessageBox.Show("The password is incorrect.");
                        tbPass.Select(0, tbPass.Text.Length);
                    }

                     // се е во ред.
                    else
                    {
                        ProfileForm PF = new ProfileForm(this, null);
                        PF.MdiParent = this.MdiParent;
                        PF.Show();
                        PF.Location = new Point(0, 0);


                    }
                }
                catch
                {
                    if (!flag)
                    {
                        MessageBox.Show("The user name or password is incorrect.");
                    }
                    tbUsername.Select(0, tbUsername.Text.Length);

                }
            }
        }

    }
}
