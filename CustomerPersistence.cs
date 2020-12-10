using SoftimRestTask.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftimRestTask
{
    public class CustomerPersistence
    {
        private SqlConnection conn;

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
        public long SaveCustomer(Customer customerToSave)
        {
            String sqlString = "INSERT INTO Customers (VisitDateTime,Age,WasSatisfied,Sex) VALUES ('" + customerToSave.VisitDateTime.ToString("dd.MM.yyyy HH:mm:ss") + "','" + customerToSave.Age + "','" + customerToSave.WasSatisfied + "','" + customerToSave.Sex + "') SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }
    }
}