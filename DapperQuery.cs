using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Diagnostics;
using System.Linq;

namespace DBPerformanceTests
{
    class DapperQuery
    {
        public string GetOrderTime_Dapper()
        {
            var connstring = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;";

            Stopwatch time = new Stopwatch();
            time.Start();

            using(SqlConnection connection = new SqlConnection(connstring))
            {
                var output = connection.Query<OrderDetails>("select * from [Order Details]").ToList();
            }
            time.Stop();
            return Convert.ToString(time.Elapsed);
        }


    }
        public class OrderDetails
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public float UnitPrice { get; set; }
            public int Quantity { get; set; }
            public float Discount { get; set; }
        }
}
