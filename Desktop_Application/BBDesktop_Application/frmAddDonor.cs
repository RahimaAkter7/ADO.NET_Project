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
    public partial class frmAddDonor : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BloodBank;Integrated Security=True");
      
        public frmAddDonor()
        {
            InitializeComponent();
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(" insert into Donor values (@id, @name, @gender, @age, @bg, @unit, @date, @add, @con, @emi,@im)", con);
            
                Image img = Image.FromFile(txtPicturePath.Text);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);


                con.Open();
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", (btnmale.Checked) ? btnmale.Text : btnfemale.Text);
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM  Donor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void frmAddDonor_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGrid();
        }

        private void btnPicUploder_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox1.Image = img;
                txtPicturePath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
