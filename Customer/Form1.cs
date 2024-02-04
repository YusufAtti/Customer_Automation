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


namespace Customer
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-HP2NA5H\SQLEXPRESS;Initial Catalog=CustomerAutomation;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.customerAutomationDataSet.Customer);
            ShowData();
            dataGridView1.ClearSelection();
            txtid.Text = "0";
        }

        private void ShowData()
        {

            try {
                string show = "SELECT MusteriID, Ad, Soyad, AylikGelir, KrediyeUygunMu, Sehir FROM Customer";
                SqlDataAdapter dataadapter = new SqlDataAdapter(show, connect);
                DataTable dt = new DataTable();
                dataadapter.Fill(dt);


                if(dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show("Hata!! KOD: 4001");
            }

            finally
            {
                if (connect != null)
                    connect.Close();
            }

         }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
            txtsalary.Text = dataGridView1.Rows[secilensatir].Cells[3].Value.ToString();
            txtcredit.Text = dataGridView1.Rows[secilensatir].Cells[4].Value.ToString();
            txtcity.Text = dataGridView1.Rows[secilensatir].Cells[5].Value.ToString();
        }
    }
}
