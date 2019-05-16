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
    public partial class RegisterStudent : Form
    {
        public RegisterStudent()
        {
            InitializeComponent();
            comboBox1.Items.Add("Computer Science");
            comboBox1.Items.Add("Computer Engineering");
            comboBox1.Items.Add("Electrical Engineering");
            comboBox1.Items.Add("Mechanical Engineering");
            comboBox1.Items.Add("Civil Engineering");

            comboBox2.Items.Add("2015");
            comboBox2.Items.Add("2016");
            comboBox2.Items.Add("2017");
            comboBox2.Items.Add("2018");

            comboBox3.Items.Add("A");
            comboBox3.Items.Add("B");
            comboBox3.Items.Add("C");
            comboBox3.Items.Add("D");


        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");


        private void RegisterStudent_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""|| textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }

            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }



            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT into Student(FIrstName, LastName , Email , Password , RePassword , [Roll No] , Address , [Mobile No] , Department , Session , Section) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "' , '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "')";
                if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Student is registered");
                }
                else
                {
                    MessageBox.Show("Student is not Registered", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Student set  FirstName = '" + this.textBox1.Text + "' , LastName = '" + this.textBox2.Text + "' , Email= '" + this.textBox3.Text + "' , Password= '" + this.textBox4.Text + "' , Repassword= '" + this.textBox5.Text + "', [Roll No]= '" + this.textBox6.Text + "', Address= '" + this.textBox7.Text + "', [Mobile No]= '" + this.textBox8.Text + "' , Department= '" + this.comboBox1.Text + "', Session= '" + this.comboBox2.Text + "', Section= '" + this.comboBox3.Text + "' where FirstName = '" + this.textBox1.Text + "'";
            if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("DATA IS Updated");
            }
            else
            {
                MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();
        
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            Display_Data();
    }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String delete = "DELETE FROM Student WHERE Id = '" + int.Parse(ID) + "'";
            SqlCommand del = new SqlCommand(delete, conn);
            if (MessageBox.Show("Do You want to delete it", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                del.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Student is deleted");
            }
            else
            {
                MessageBox.Show("Row not deleted", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();
            /*textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";*/
            Display_Data();
        }
    }
}
