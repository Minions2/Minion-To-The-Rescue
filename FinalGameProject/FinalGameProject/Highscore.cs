using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace FinalGameProject
{
    public partial class Highscore : Form
    {
        SqlCeConnection con;

        public Highscore()
        {
            InitializeComponent();
            con = new SqlCeConnection(@"Data Source=App_Data\Database.sdf");
        }

    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Highscore_Load(object sender, EventArgs e)
        {


            try
            {

                // Create a command object
                SqlCeCommand cmd = new SqlCeCommand("select * from PlayerTable", con);
                con.Open();



                SqlCeDataReader reader = cmd.ExecuteReader();

                List<Character> car = new List<Character>();
                while (reader.Read())
                {
                    Character c = new Character();
                    string User = reader[0].ToString().Trim();
                    string score1 = reader[3].ToString().Trim();
                    string score2 = reader[4].ToString().Trim();
                    string score3 = reader[5].ToString().Trim();
                    c.Username = User;
                    c.ScoreL1 = int.Parse(score1);
                    c.ScoreL2 = int.Parse(score2);
                    c.ScoreL3 = int.Parse(score3);
                    c.Highscore = c.ScoreL1 + c.ScoreL2 + c.ScoreL3;
                    //lbHigh.Items.Add(c);
                    car.Add(c);


                    // lbHigh.Items.Add(result);

                }
                StringBuilder s = new StringBuilder();
                car = car.OrderByDescending(x => x.Highscore).ToList();
                for (int i = 0; i < car.Count; i++)
                {
                    s.Append(String.Format("{0}    -     {1}   -   {2}   -   {3}   =   {4}", car.ElementAt(i).Username, car.ElementAt(i).ScoreL1, car.ElementAt(i).ScoreL2, car.ElementAt(i).ScoreL3, car.ElementAt(i).Highscore));
                    lbHigh.Items.Add(s);
                    s.Clear();
                }


              //  lbHigh.Items.Add(s);
                //Release resources
                reader.Close();
                con.Close();

            }


            catch { }


        }


    }
}