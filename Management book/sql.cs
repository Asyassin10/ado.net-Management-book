using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Management_book
{
    class sql
    {
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection con = new SqlConnection();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        public void connecter()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=DESKTOP-1JHKSTN\SQLEXPRESS;Initial Catalog=BOOK;Integrated Security=True";

                con.Open();

            }
        }
        public void deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
