using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtreme
{
    public class SharpHelper
    {
        private static string connectionString; // Your database connection string goes here

        public static SqlDataAdapter GetSqlDataAdapter(string query)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set. Call SetConnectionString method first.");
            }

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            return adapter;
        }
        public static DataSet GetDataSet(string query)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set. Call SetConnectionString method first.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                return dataSet;
            }
        }
        public static SqlDataReader GetSqlDataReader(string query)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not set. Call SetConnectionString method first.");
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); // Open the connection

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }
        public static DataTable GetFilterData(DataTable dt,string filterQuery)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = filterQuery; // query example = "id = 10"
            return dv.ToTable();
        }
    }
}
