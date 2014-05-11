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
    public partial class ProfileForm : Form
    {
        LogInForm LIForm;
        PauseForm PForm;

        // database
        SqlCeConnection con;
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeParameter picture;
        String Username;

        public ProfileForm(LogInForm LIForm, PauseForm PForm)
        {
            InitializeComponent();
            this.LIForm = LIForm;
            this.PForm = PForm;
            this.Username = LogInForm.Username;
            lblHi.Text = "BELLO \n" + Username;
            con = new SqlCeConnection(@"Data Source=App_Data\Database.sdf");
            picture = new SqlCeParameter("@picture", SqlDbType.Image);
            cmd.Connection = con;

        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (LIForm != null || PForm != null)
            {
                if (LIForm == null)
                {
                    PForm.Close();
                }
                else if (PForm == null)
                {
                    LIForm.Close();
                }
            }

            // стави ја сликата на профилот.

            con.Open();
            cmd.CommandText = "SELECT picture FROM PlayerTable WHERE username = '" + Username + "'";
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            SqlCeCommandBuilder cmb = new SqlCeCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);

            pictureBox.Image = Image.FromStream(ms);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            ms.Close();
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogInForm LF = new LogInForm(this);
            LF.MdiParent = this.MdiParent;
            LF.Show();
            LF.Location = new Point(0, 0);
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            LevelChooserForm LCF = new LevelChooserForm(this, null);
            LCF.MdiParent = this.MdiParent;
            LCF.Show();
            LCF.Location = new Point(0, 0);
        }


        /// <summary>
        /// аплаудирање на слика на профилот на играчот.
        /// </summary>
        bool flag1;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // избери слика.
            try
            {
                OpenFileDialog fileChooser = new OpenFileDialog();
                fileChooser.Filter = "image files (*.jpg|*.jpg|All files(*.*)|*.*";
                fileChooser.InitialDirectory = "C:\\Users\\Public\\Pictures\\Sample Pictures";
                fileChooser.Title = "Select Image For Upload";
                if (fileChooser.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(fileChooser.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    flag1 = true;
                }
            }
            catch { }

            //socuvaj ja vo bazata

            if (flag1)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                byte[] a = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", a);
                cmd.CommandText = "UPDATE PlayerTable Set picture=@picture where username=@username";
                con.Open();
                cmd.Parameters.Add(new SqlCeParameter("@username", Username));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void btnInstuctions_Click(object sender, EventArgs e)
        {
            Instructions Instructions = new Instructions();
            Instructions.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            lblAU1.Visible = true;
            lblAU2.Visible = true;
            lblAU3.Visible = true;
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            Highscore hs = new Highscore();
            hs.Show();
        }
    }
}
