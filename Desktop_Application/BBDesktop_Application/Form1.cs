using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDesktop_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodGroup b = new frmBloodGroup();
            b.Show();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddDonor add = new frmAddDonor();
            add.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddStock st = new frmAddStock();
            st.Show();

        }

        private void updatedeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdateDonor u = new frmUpdateDonor();
            u.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewDonor view = new viewDonor();
            view.Show();
        }

        private void bloodStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStock s = new frmAddStock();
            s.Show();
        }

        private void donorDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonorDetail d = new frmDonorDetail();
            d.Show();
        }
    }
}
