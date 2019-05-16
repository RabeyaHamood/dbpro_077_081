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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LMS.RegSubj f3 = new RegSubj();
            this.Show();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LMS.Result f4 = new Result();
            this.Show();
            f4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LMS.viewFee f5 = new viewFee();
            this.Show();
            f5.ShowDialog();
        }
    }
}
