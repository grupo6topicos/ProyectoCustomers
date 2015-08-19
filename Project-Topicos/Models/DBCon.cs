using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Model
{
    public class DBCon
    {
        private static SqlConnection sqlConn;
        System.Data.SqlClient.SqlConnection Conn;


        protected DBCon()
        {
            Conn = new System.Data.SqlClient.SqlConnection(@"Data Source=131.190.73.250\I_TRADE;Initial Catalog=dbo_Customers;Persist Security Info=True;User ID=sa;Password=lacost");
        }

        protected System.Data.SqlClient.SqlConnection GetObjConexion()
        {
            return this.Conn;
        }

        public static SqlConnection getInstance()
        {
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection();
            }
            return sqlConn;
        }

        protected Boolean Open()
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                    Conn.Open();

                if (Conn.State == System.Data.ConnectionState.Open)
                    return true;
                else
                    return false;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        protected Boolean Close()
        {
            try
            {

                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();
                if (Conn.State == System.Data.ConnectionState.Closed)
                    return true;
                else
                    return false;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
