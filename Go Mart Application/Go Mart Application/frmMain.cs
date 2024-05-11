using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Go_Mart_Application
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(Form1.loginname!= null)
            {
                toolStripStatusLabel2.Text = Form1.loginname;
            }
            if(Form1.logintype!= null && Form1.logintype == "Seller")
            {
                categoryToolStripMenuItem.Enabled=false;
                categoryToolStripMenuItem.ForeColor= Color.Red;
                productToolStripMenuItem.Enabled = false;
                productToolStripMenuItem.ForeColor= Color.Red;
                addUserToolStripMenuItem.Enabled = false;
                addUserToolStripMenuItem.ForeColor = Color.Red;
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategory fcat = new FrmCategory();
            fcat.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abt = new AboutBox1();
            abt.Show();
        }
    }
}
