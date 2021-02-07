using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DBPerformanceTests
{
    class Ado_net
    {
        public string GetOrderTime_ADO_net()
        {
            var connstring = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;";
            string query = "select * from [Order Details]";
            Stopwatch time = new Stopwatch();
            time.Start();

            using(SqlConnection connection = new SqlConnection(connstring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            time.Stop();
            return Convert.ToString(time.Elapsed);
        }
    }
}
