using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-GH3H7IM\SQLEXPRESS";

            string database = "test";
            string username = "sa";
            string password = "228228";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

}