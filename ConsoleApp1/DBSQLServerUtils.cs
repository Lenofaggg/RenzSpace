using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Tutorial.SqlConn
{
    class DBSQLServerUtils
    {

        public static SqlConnection
        GetDBConnection(string datasource, string database, string username, string password)
        {

            //Data Source = DESKTOP - GH3H7IM\SQLEXPRESS;
            //Initial Catalog = test;
            //Persist Security Info = True;
            //User ID = sa;
            //Password = 228228;


            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }


    }
}