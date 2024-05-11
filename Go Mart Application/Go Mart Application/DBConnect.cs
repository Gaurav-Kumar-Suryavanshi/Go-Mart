using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Go_Mart_Application
{
    class DBConnect
    {
        private SqlConnection con=new SqlConnection(@"Data Source=DESKTOP-47TN0GF\SQLEXPRESS;Initial Catalog=GoMartDB;Integrated Security=True;Encrypt=False");
        public SqlConnection GetCon()
        {
            return con;
        }
        public void OpenCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
