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
    public partial class InstrForm : Form
    {
        public InstrForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("A");
            comboBox1.Items.Add("A-");
            comboBox1.Items.Add("B+");
            comboBox1.Items.Add("B");
            comboBox1.Items.Add("B-");
            comboBox1.Items.Add("C+");
            comboBox1.Items.Add("C");
            comboBox1.Items.Add("C-");
            comboBox1.Items.Add("D+");
            comboBox1.Items.Add("D");
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void InstrForm_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Result ";
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
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("INSERT INTO Result Values((Select Id From Student WHERE Id ='" + textBox1.Text + "'),(Select CourseId From Course where CourseId = '" + textBox2.Text + "'), @ObtainedMarks,@Grade)");
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@CourseId", textBox2.Text);
            cmd.Parameters.AddWithValue("@ObtainedMarks", textBox3.Text);
            cmd.Parameters.AddWithValue("@Grade", comboBox1.Text);



            if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
            }
            else
            {
                MessageBox.Show("Data is not inserted", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            Display_Data();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Result set ObtainedMarks = '" + this.textBox3.Text + "' , Grade = '" + this.comboBox1.Text + "'  where Id = '" + this.textBox1.Text + "' AND  CourseId = '" + this.textBox2.Text + "' ";
            if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("DATA IS Updated");
            }
            else
            {
                MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            cmd.ExecuteNonQuery();
        
        conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";

            Display_Data();
    }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM Result WHERE Id = '" + int.Parse(ID) + "'";
            SqlCommand del = new SqlCommand(delete, conn);
            if (MessageBox.Show("Do You want to delete it", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                del.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("DATA IS DELETED");
            }
            else
            {
                MessageBox.Show("Row not deleted", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            conn.Close();

            Display_Data();
        }
    }
}
