using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LMS.Login f1 = new LMS.Login();
            this.Show();
            f1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LMS.ContactUs f2 = new LMS.ContactUs();
            this.Show();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LMS.AboutUs f3 = new LMS.AboutUs();
            this.Show();
            f3.ShowDialog();
        }
    }
}
