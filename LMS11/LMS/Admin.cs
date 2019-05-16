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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LMS.RegisterStudent f1 = new RegisterStudent();
            this.Show();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LMS.RegisterInst f2 = new RegisterInst();
            this.Show();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LMS.Fee f3 = new Fee();
            this.Show();
            f3.ShowDialog();
        }
    }
}
