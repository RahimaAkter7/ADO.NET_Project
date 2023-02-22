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
    public partial class frmAddStock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BloodBank;Integrated Security=True");
      
        public frmAddStock()
        {
            InitializeComponent();
        }

        private void frmAddStock_Load(object sender, EventArgs e)
        {

            LoadCombo();

            LoadGrid();


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand(" insert into BloodStock values (@id, @unit, @stock, @bg)", con);


            con.Open();
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@unit", txtunit.Text);
            cmd.Parameters.AddWithValue("@stock", (btnyes.Checked) ? btnyes.Text : btnno.Text);
            cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedValue);
           

            cmd.ExecuteNonQuery();
            MessageBox.Show(" Added Successfully");

            con.Close();
            LoadGrid();


        }
        private void LoadCombo()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT BG_ID, BloodGroup_Name FROM  BloodGroup", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbBloodGroup.DisplayMember = "BloodGroup_Name";
            cmbBloodGroup.ValueMember = "BG_ID";
            cmbBloodGroup.DataSource = dt;

            con.Close();
        }

        
        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM BloodStock", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand(" UPDATE Donor SET  Unit_ml=@Unit_ml, Stock=@Stock, BG_ID=@bg WHERE S_ID =@id", con);



            con.Open();
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@Unit_ml", txtunit.Text);
            cmd.Parameters.AddWithValue("@Stock", (btnyes.Checked) ? btnyes.Text : btnno.Text);
            cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedValue);
          
            
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Added Successfully");

            con.Close();
            LoadGrid();




        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {


                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;

                SqlCommand cmd = new SqlCommand("SELECT *FROM BloodStock where S_ID =@id", con);

                
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())



                {

                    txtID.Text = dr.GetInt32(0).ToString();
                    txtunit.Text = dr.GetString(1);

                    if (dr.GetString(dr.GetOrdinal("Stock")) == "Yes")
                    {
                        btnyes.Checked = true;
                    }
                    else if (dr.GetString(dr.GetOrdinal("Stock")) == "no")
                    {
                        btnno.Checked = true;
                    }


                

                    cmbBloodGroup.SelectedValue = dr.GetInt32(dr.GetOrdinal("BG_ID"));

                              
                    }
                con.Close();
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE BloodStock where S_ID =@id", con);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Delete Successfully");
            con.Close();
            LoadGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
