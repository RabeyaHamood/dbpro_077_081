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
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;



namespace LMS
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = DB12;Integrated Security = True; MultipleActiveResultSets = True");

        private void Result_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Result Where Id = '"+int.Parse(textBox1.Text)+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            pdfTable.WidthPercentage = 90f;

            int[] firstTablecellWidth = { 20, 25, 25, 30 };
            pdfTable.SetWidths(firstTablecellWidth);

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            int row = dataGridView1.Rows.Count;
            int cell2 = dataGridView1.Rows[1].Cells.Count;
            for (int i = 0; i < row - 1; i++)

            {

                for (int j = 0; j < cell2; j++)
                {


                    if (dataGridView1.Rows[1].Cells[j].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "null";
                    }
                    pdfTable.AddCell(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    this.dataGridView1.Columns[j].Width = 150;
                }
            }

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        pdfTable.AddCell(cell.Value.ToString());
            //    }
            //}


            //Exporting to PDF
            string folderPath = @"G:\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Result.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }



            MessageBox.Show("PDF Generated Successfully");
        }
    }
}
