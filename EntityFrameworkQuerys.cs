using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DBPerformanceTests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DBPerformanceTests
{
    class entityFrameworkQuerys
    {
        private readonly NorthwindContext _connection;

        public string GetOrdersTime_CompiledQuery()
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            var items = EF.CompileQuery((NorthwindContext db) =>
                (db.OrderDetails));

            time.Stop();
            return Convert.ToString(time.Elapsed);
            
        }
        public string GetOrderTime_RawQuery()
        {
            NorthwindContext _connection = new NorthwindContext();
            Stopwatch time = new Stopwatch();
            time.Start();

            var items = _connection.OrderDetails.FromSqlRaw("select * from [Order Details]").ToList();

            time.Stop();

            return Convert.ToString(time.Elapsed);

        }
        public string GetOrderTime_ORMEntityframework()
        {
            NorthwindContext _connection = new NorthwindContext();
            Stopwatch time = new Stopwatch();
            time.Start();

            var items = _connection.OrderDetails.ToList();
            time.Stop();

            return Convert.ToString(time.Elapsed);

        }



    }
}
