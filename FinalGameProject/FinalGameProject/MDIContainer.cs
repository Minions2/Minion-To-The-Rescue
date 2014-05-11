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
    public partial class MDIContainer : Form
    {
        

        public MDIContainer()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void MDIContainer_Load(object sender, EventArgs e)
        {
            LogInForm LIForm = new LogInForm(null);
            LIForm.Show();
            LIForm.MdiParent = this;
        }
    }
}
