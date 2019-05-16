using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            comboBox1.Items.Add ("Admin");
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add( "Instructor");
            textBox2.PasswordChar = '*';
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Login where Email ='"+textBox1.Text+"' AND Password = '"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            String cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["UserType"].ToString( )== cmbItemValue)
                    {
                       // MessageBox.Show("You are login as " + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            LMS.Admin A1 = new Admin();
                            this.Show();
                            // this.Hide();
                            A1.ShowDialog();
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            LMS.Student A2 = new Student();
                            this.Show();
                            A2.ShowDialog();
                            
                        }
                        else
                        {
                            LMS.Instructor A3 = new Instructor();
                            this.Show();
                            //this.Hide();
                            A3.ShowDialog();
                        }
                    }
                }
            }
          
           else
            {
                MessageBox.Show("Invalid Email or password");
            }
            conn.Close();
            textBox1.Text = " ";
            textBox2.Text = "";
            comboBox1.Text = ""; 
        }
    }
}
