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
    public partial class Fee : Form
    {
        public Fee()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Fee ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") || textBox4.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }
            else
            {



                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("INSERT INTO Fee Values((Select Id From Student WHERE Id ='" + textBox1.Text + "'), @FeeStatus , @TotalFees , @Fine)");
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@FeeStatus", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalFees", textBox3.Text);
                cmd.Parameters.AddWithValue("@Fine", textBox4.Text);
                /* SqlCommand scmd = new SqlCommand("insert into [Group] (CreatedOn)values(@CreatedOn); SELECT SCOPE_IDENTITY()", conn);
                 scmd.Parameters.AddWithValue("@CreatedOn", textBox1.Text);

                 int Id = Convert.ToInt32(scmd.ExecuteScalar());

                 SqlCommand scmd2 = new SqlCommand("insert into Evaluation (Name , TotalMarks , TotalWeightage)values(@Name , @TotalMarks , @TotalWeightage); SELECT SCOPE_IDENTITY()", conn);
                 scmd2.Parameters.AddWithValue("@Name", textBox1.Text);
                 scmd2.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
                 scmd2.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);


                 int Id1 = Convert.ToInt32(scmd.ExecuteScalar());

                 SqlCommand scmd1 = new SqlCommand("insert into  GroupEvaluation (GroupId,EvaluationId,ObtainedMarks , EvaluationDate) VALUES(@GroupId,@EvaluationId , @ObtainedMarks,@EvaluationDate)", conn);
                 scmd1.Parameters.AddWithValue("@GroupId", item.Text);
                 scmd1.Parameters.AddWithValue("@qauntity", qauntity.Text);
                 scmd1.Parameters.AddWithValue("@custId", custId);
                 scmd1.ExecuteNonQuery(); */
                //cmd.CommandText = "INSERT into GroupEvaluation(GroupId ,EvaluationId ,  ObtainedMarks, EvaluationDate ) values ('" + int.Parse(ID) + "','" + int.Parse(ID1) + "','" + textBox1.Text + "' , '" +DateTime.Parse( textBox2.Text) + "')  ";
                // cmd.CommandText = "INSERT into GroupEvaluation(GroupId ,EvaluationId ,  ObtainedMarks, EvaluationDate ) values ('" + int.Parse(ID) + "','" + int.Parse(ID1) + "','" + textBox1.Text + "' , '" + DateTime.Parse(textBox2.Text) + "')  ";

                if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted");
                }
                else
                {
                    MessageBox.Show("Data is not inserted", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";




            Display_Data();
            conn.Close();
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else
            {


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Fee set TotalFees = '" + this.textBox3.Text + "' , Fine = '" + this.textBox4.Text + "' , FeeStatus = '" + this.textBox2.Text + "'  where Id = '" + this.textBox1.Text + "' ";
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
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Display_Data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM Fee WHERE Id = '" + int.Parse(ID) + "'";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Display_Data();
        }

        private void Fee_Load(object sender, EventArgs e)
        {

        }
    }
}
