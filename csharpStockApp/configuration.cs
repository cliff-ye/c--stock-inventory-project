using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace csharpStockApp
{
    class configuration
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q65C244\SERVER;Initial Catalog=STOCKMANAGEMENTDB;Integrated Security=True");

        public void openCon()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeCon()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public SqlConnection getCon()
        {
            return con;
        }
    }
}
