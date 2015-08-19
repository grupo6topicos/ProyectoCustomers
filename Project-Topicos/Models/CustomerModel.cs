using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Model
{
    public class CustomerModel : DBCon 
    {
        public int CustomerID { get; set; }
        public String FistName { get; set; }
        public String LastName { get; set; }
        public String PersonType { get; set; }
        public String StoreName { get; set; }
        public int AddressID { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String Country { get; set; }


        public DataTable ListCustomer()
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query =  "SELECT c.[CustomerID],c.[FistName],c.[LastName],a.[AddressID],a.[Address1],a.[City],a.[Province],a.[Country] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID  ";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListCustomer_Country(String Country)
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query = "SELECT c.[CustomerID],c.[FistName],c.[LastName],a.[AddressID],a.[Address1],a.[City],a.[Province],a.[Country] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID WHERE a.[Country] = @Country";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.Parameters.AddWithValue("@Country", Country);
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListCustomer_Province(String Province)
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query = "SELECT c.[CustomerID],c.[FistName],c.[LastName],a.[AddressID],a.[Address1],a.[City],a.[Province],a.[Country] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID WHERE a.[Province] = @Province ";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.Parameters.AddWithValue("@Province", Province);
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListCustomer_City(String City)
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query = "SELECT c.[CustomerID],c.[FistName],c.[LastName],a.[AddressID],a.[Address1],a.[City],a.[Province],a.[Country] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID WHERE a.[City] = @City ";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.Parameters.AddWithValue("@City", City);
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListCountries()
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query =  "SELECT DISTINCT a.[Country] "+
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID "+
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID" ;
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListProvinces()
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query = "SELECT DISTINCT a.[Province] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }

        public DataTable ListCities()
        {
            DataTable dt_Customers = new DataTable();
            SqlDataReader reader = null;
            try
            {
                String query =  "SELECT DISTINCT a.[City] " +
                                "FROM [dbo_Customers].[dbo].[CustomerAddress] cs LEFT JOIN [dbo_Customers].[dbo].[Customers] c ON cs.CustomerID = c.CustomerID " +
                                "LEFT JOIN [dbo_Customers].[dbo].[Address] a ON cs.AddressID = a.AddressID";
                System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand(query, this.GetObjConexion());
                sqlcmd.CommandType = CommandType.Text;
                this.Open();
                reader = sqlcmd.ExecuteReader();
                dt_Customers.Load(reader);
                return dt_Customers;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                reader = null;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                this.Close();
            }
        }
    }
}
