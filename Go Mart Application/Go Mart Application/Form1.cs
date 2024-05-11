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

namespace Go_Mart_Application
{
    public partial class Form1 : Form
    {
        DBConnect dbCon=new DBConnect();
        public static string loginname, logintype;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 1;
           txtUsername.Text = "Gaurav";
           txtPassword.Text = "1234";

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRole.SelectedIndex > 0)
                {
                    if (txtUsername.Text == string.Empty)
                    {
                        MessageBox.Show("Please Enter Valid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus();
                        return;
                    }
                    if (txtPassword.Text==string.Empty)
                    {
                        MessageBox.Show("Please Enter Valid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        return;
                    }
                    if (cmbRole.SelectedIndex > 0 && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                    {
                        // Login Code 
                        if (cmbRole.Text == "Admin")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 AdminID,Password,FullName from tbAdmin where AdminID=@AdminID and Password=@Password", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@AdminID",txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Success Welcome To Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname=txtUsername.Text;
                                logintype = cmbRole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("InValid Login Please Check Username And Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else if(cmbRole.Text == "Seller")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 SellerName,SellerPass from tblSeller where SellerName=@SellerName and SellerPass=@SellerPass", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@SellerName", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@SellerPass", txtPassword.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Success Welcome To Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname = txtUsername.Text;
                                logintype = cmbRole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("InValid Login Please Check Username And Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter UserName Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clrValue();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please Select Any Role","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    clrValue();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void clrValue()
        {
            cmbRole.SelectedIndex = 0;
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
