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
    public partial class RegSubj : Form
    {
        public RegSubj()
        {
            InitializeComponent();
            comboBox1.Items.Add("Mechanics");
            comboBox1.Items.Add("Mechanics");
            comboBox1.Items.Add("DataBase");
            comboBox1.Items.Add("DataBaser");
            comboBox1.Items.Add("Project Management");
            comboBox1.Items.Add("Circuit Analysis");
            comboBox1.Items.Add("Linear Algebra  ");
            comboBox1.Items.Add("Introduction to computing");

            comboBox2.Items.Add("A");
            comboBox2.Items.Add("B");
            comboBox2.Items.Add("C");
            comboBox2.Items.Add("D");

            

            comboBox5.Items.Add("Miss Faiza Bushra");
            comboBox5.Items.Add("Sir Ahmed Anwar");
            comboBox5.Items.Add("Sir Samyan Qayyum");
            comboBox5.Items.Add("Miss Sehar Waqar");
            comboBox5.Items.Add("Dr Maud");

           

        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void RegSubj_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            // cmd.CommandText = "INSERT into Course(CourseTitle, Section , CreditHour , InstructorName , Id) values ('" + comboBox1.Text + "' , '" + comboBox2.Text + "' , '" + textBox1.Text + "' , '" + comboBox5.Text + "' , '" + textBox1.Text + "')";
            cmd.CommandText = "select Course.CourseId ,  Student.Id,  Course.CourseTitle , Course.Section , Course.InstructorName , Course.CreditHour From Course join Student ON Course.Id = Student.Id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT into Course(CourseTitle, Section,InstructorName , CreditHour, Id ) values ('" + comboBox1.Text + "' ,'" + comboBox2.Text + "' , '" + comboBox5.Text + "' , '"+textBox1.Text+"' , '"+textBox2.Text+"' )";
            if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Student is registered");
            }
            else
            {
                MessageBox.Show("Student is not Registered", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cmd.ExecuteNonQuery();
        
        conn.Close();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "";
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String delete = "DELETE FROM Course WHERE CourseId = '" + int.Parse(ID) + "'";
            SqlCommand del = new SqlCommand(delete, conn);
            if (MessageBox.Show("Do You want to Unregister it", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                del.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("You are Unregistered from this Subject");
            }
            else
            {
                MessageBox.Show("You are not Unregistered", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();
            /*textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";*/
            Display_Data();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
