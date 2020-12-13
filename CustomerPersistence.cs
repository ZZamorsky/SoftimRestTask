using SoftimRestTask.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftimRestTask
{
    /// <summary>
    /// Layer for communication with database for Customer
    /// </summary>
    public class CustomerPersistence
    {
        private SqlConnection conn;
        /// <summary>
        /// Provide connection with database
        /// </summary>
        public CustomerPersistence()
        {
            string myConnectionString;
            myConnectionString = "Data Source=pzs5t5imun.database.windows.net;Initial Catalog=AUTO_ETL_META_DB;User ID=softim_recruit;Password=TNeANy5SaFDf;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

            }
            catch
            {
                SqlException ex;
            }
        }
        /// <summary>
        /// Saving List Customers into database
        /// </summary>
        /// <param name="customersToSave"></param>
        public void SaveCustomers(List<Customer> customersToSave)
            
        {
            foreach (Customer customerToSave in customersToSave)
            {
                String sqlString = "INSERT INTO Customers (VisitDateTime,Age,WasSatisfied,Sex) VALUES ('" + customerToSave.VisitDateTime.ToString("yyyy.MM.dd HH:mm:ss") + "','" + customerToSave.Age + "','" + customerToSave.WasSatisfied + "','" + customerToSave.Sex + "')";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Loading Arraylist of all Customers from database
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCustomers()
        {
            ArrayList customersArray = new ArrayList();
            SqlDataReader sqlDataReader = null;
            string sqlString = "SELECT * from Customers";
            SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = sqlDataReader.GetInt32(0);
                customer.VisitDateTime = sqlDataReader.GetDateTime(1);
                customer.Age = sqlDataReader.GetInt32(2);
                customer.WasSatisfied = sqlDataReader.GetBoolean(3);
                customer.Sex = sqlDataReader.GetString(4);
                customersArray.Add(customer);
            }
            return customersArray;
        }
    }
}