using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDesktop_Application
{
    public partial class frmUpdateDonor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BloodBank;Integrated Security=True");
      

        public frmUpdateDonor()
        {
            InitializeComponent();
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

            //Load cmbTutorId
            //SqlDataAdapter sda2 = new SqlDataAdapter("select ID,Name,Gender, Age,BG_ID,Unit_ml,Date,Address,ContactNo,Email,Photo ", con);
            //DataTable dt2 = new DataTable();
            //sda2.Fill(dt2);
            //txtID.DisplayMember = "ID,";
            //txtID.ValueMember = "Name,";
            //txtID.DataSource = dt2;

            con.Close();

        }
        private void loadGrid()
        {


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM  Donor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();



        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(" UPDATE Donor SET Name=@name, Gender=@gender, Age=@age, BG_ID=@bg, Unit_ml=@unit, Date=@date, Address=@add, ContactNo=@con, Email=@emi,Photo=@im WHERE id=@id", con);

            Image img = Image.FromFile(txtPicturePath.Text);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);


            con.Open();
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@gender", (rbtnmale.Checked) ? rbtnmale.Text : rbtnfemale.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedValue);
            cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@add", txtAddress.Text);
            cmd.Parameters.AddWithValue("@con", txtContact.Text);
            cmd.Parameters.AddWithValue("@emi", txtEmail.Text);
            cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.VarBinary) { Value = ms.ToArray() });

            cmd.ExecuteNonQuery();
            MessageBox.Show(" Added Successfully");

            con.Close();
            loadGrid();
        }

        //private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.CommandText = " select ID,Name,Gender, Age,BG_ID,Unit_ml,Date,Address,ContactNo,Email,Photo WHERE ID=@i";
        //    cmd.Parameters.AddWithValue("@i", cmbId.SelectedValue);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        txtName.Text = dr.GetString(1);


        //        if (dr.GetString(2).ToString() == rbtnMale.Text)
        //        {
        //            rbtnMale.Checked = true;
        //        }
        //        if (dr.GetString(2) == rbtnFemale.Text)
        //        {
        //            rbtnFemale.Checked = true;
        //        }

        //        txtAge.Text = dr.GetString(3);
        //        cmbBloodGroup.SelectedValue = dr.GetInt32(4);
        //        txtUnit.Text = dr.GetString(5);
        //        dateTimePicker1.Value =dr.GetDateTime(6).Date;
        //        txtAddress.Text = dr.GetString(7);
        //        txtContact.Text = dr.GetString(8);
        //        txtEmail.Text = dr.GetString(9);
        //        pictureBox1.Image = Image.FromStream(dr.GetStream(10));

        //    }
        //    con.Close();
        //}
        
        private void btnPicUploder_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox1.Image = img;
                txtPicturePath.Text = openFileDialog1.FileName;
                
            }
        }

        

        //private void btnDelete_Click(object sender, EventArgs e)
        //{

        //    SqlCommand cmd = new SqlCommand(" DELETE FROM Donor WHERE ID = @i", con);
        //    cmd.Parameters.AddWithValue("@i", cmbId.SelectedValue);
        //    con.Open();

        //    if (cmd.ExecuteNonQuery() > 0)
        //    {
        //        MessageBox.Show(" Delete Successfully");

        //    }
        //    con.Close();
        //    //    /*loadcombo();*/
        //}
        private void frmUpdateDonor_Load(object sender, EventArgs e)
        {
            LoadCombo();
            loadGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count>0)
            {


                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;

               SqlCommand cmd= new SqlCommand("Select * from Donor where ID=@id",con);

                cmd.Parameters.AddWithValue("@id",id);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                        
                
                 
               {

                    txtID.Text = dr.GetInt32(0).ToString();
                    txtName.Text = dr.GetString(1);

                    if(dr.GetString(dr.GetOrdinal("Gender")) == "Male")
                    {
                        rbtnmale.Checked = true;
                    }
                    else if(dr.GetString(dr.GetOrdinal("Gender")) == "Female")
                    {
                        rbtnfemale.Checked = true;
                    }


                    txtAge.Text = dr.GetInt32(3).ToString();


                    cmbBloodGroup.SelectedValue = dr.GetInt32(dr.GetOrdinal("BG_ID"));


                    txtUnit.Text = dr.GetString(5);
                    dateTimePicker1.Value = dr.GetDateTime(6).Date;
                    txtAddress.Text = dr.GetString(7);
                    txtContact.Text = dr.GetString(8);
                    txtEmail.Text = dr.GetString(9);
                    pictureBox1.Image = Image.FromStream(dr.GetStream(10));


                }
                con.Close();
            }
            
            
            


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Donor WHERE ID=@id", con);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Delete Successfully");
            con.Close();
            loadGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
