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
    public partial class RegisterInst : Form
    {
        public RegisterInst()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void RegisterInst_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Instructor ";
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )

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

                cmd.CommandText = "INSERT into Instructor(FirstName, LastName , Email , Password , RePassword) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "')";
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
          
            Display_Data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String delete = "DELETE FROM Instructor WHERE Id = '" + int.Parse(ID) + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Instructor set  FirstName = '" + this.textBox1.Text + "' , LastName = '" + this.textBox2.Text + "' , Email= '" + this.textBox3.Text + "' , Password= '" + this.textBox4.Text + "' , Repassword= '" + this.textBox5.Text + "' where FirstName = '" + this.textBox1.Text + "'";
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
        
            Display_Data();
        }
    }
}
