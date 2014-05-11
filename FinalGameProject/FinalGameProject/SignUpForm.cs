using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.Media;
using FinalGameProject.Properties;


namespace FinalGameProject
{
    public partial class SignUpForm : Form
    {
        SqlCeConnection con;
        SqlCeCommand cmd=new SqlCeCommand();
        SqlCeDataReader rdr;
        private bool exist;
        Image img;

        public SignUpForm()
        {
            InitializeComponent();
            con = new SqlCeConnection(@"Data Source=App_Data\Database.sdf");
            cmd.Connection = con;
        }

        //ErrorProvider
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (txtUserName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtUserName, "This information is required.");
            }

            string s = txtUserName.Text.Trim();
            if (s.Contains(" "))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUserName, "Username should not contain any special characters, symbols or spaces.");
            }
         
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    char letter = s[i];
                    if (!Char.IsLetterOrDigit(letter))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtUserName, "Username should not contain any special characters, symbols or spaces.");
                    }

                }
            }

        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {

            if (txtPass.Text.Length < 6)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPass, "Password must be longer than 6 characters");
            }
            else
                errorProvider.SetError(txtPass, null);
        }

        private void txtUserName_Validated(object sender, EventArgs e)
        {

            errorProvider.SetError(txtUserName, null);
        }


        private void txtPass_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtPass, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
               if (txtUserName.Text.Length != 0 && txtPass.Text.Length != 0)
            {
                string userName = txtUserName.Text;
                string password = txtPass.Text;
                //int poeni = 0;
                cmd.CommandText= "SELECT * FROM PlayerTable WHERE username = '" + userName + "'";
                //cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    string proba = rdr[0].ToString();
                    exist = true;
                }
                catch
                {
                    exist = false;
                }

                con.Close();

                if (!exist)
                {
                    MemoryStream ms=new MemoryStream();
                    img = Resources.hi;
                    img.Save(ms, img.RawFormat);
                    byte[] a = ms.GetBuffer();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@picture", a);
                    int score1 = 0;
                    int score2 = 0;
                    int score3 = 0;
                    cmd.CommandText = "INSERT INTO PlayerTable(username,password,picture,scoreL1,scoreL2,scoreL3) VALUES('" + userName + "','" + password + "',@picture," + score1 + "," + score2 + "," + score3 + ")";
                   
                    //cmd = new SqlCommand(query1, con);
                    con.Open();
                    try
                    {
                        int broj=cmd.ExecuteNonQuery();
                        if (broj > 0)
                        {
                            MessageBox.Show("You have successfully registered!");
                            
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again!");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("You have successfully registered!");

                    }
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Someone already has that username!");
                    txtUserName.Focus();
                    txtUserName.Select(0, txtUserName.Text.Length);
                    
                }
            }

            if (txtUserName.Text.Length == 0)
            {
                errorProvider.SetError(txtUserName, "This information is required.");
                errorProvider.SetError(txtPass, null);
            }
            else if (txtUserName.Text.Length != 0 && txtPass.Text.Length == 0)
            {
                errorProvider.SetError(txtPass, "This information is required");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

       
        



    }
}
