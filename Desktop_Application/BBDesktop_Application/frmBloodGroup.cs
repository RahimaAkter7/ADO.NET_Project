using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDesktop_Application
{
    public partial class frmBloodGroup : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BloodBank;Integrated Security=True");
        public frmBloodGroup()
        {
            InitializeComponent();
        }

       
        private void frmBloodGroup_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select BG_ID, BloodGroup_Name from  BloodGroup", con);

            {
                con.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(" insert into  BloodGroup values (@ID, @BG)", con);
            
                con.Open();
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@BG", txtBloodGroupName.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show(" Added Successfully");

                con.Close();
                LoadGrid();

           
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
