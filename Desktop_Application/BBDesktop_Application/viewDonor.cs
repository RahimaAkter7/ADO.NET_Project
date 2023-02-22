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
    public partial class viewDonor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BBMS;Integrated Security=True");
        public viewDonor()
        {
            InitializeComponent();
        }

        private void viewDonor_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Donor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //cmbBloodGroup.DataSource = dt;
            //cmbBloodGroup.DisplayMember = "Blood_Group_Name";
            //cmbBloodGroup.ValueMember = "Blood_ID";
            dataGridView1.DataSource = dt;
            con.Close();


        }
    }
}
