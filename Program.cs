using System;

namespace DBPerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            entityFrameworkQuerys entityFramework = new entityFrameworkQuerys();
            DapperQuery dapper = new DapperQuery();
            Ado_net adonet = new Ado_net();

            Console.WriteLine("Compiled - entity Frameworktime: {0}", entityFramework.GetOrdersTime_CompiledQuery());
            Console.WriteLine("Raw SQL - entity Framework time: {0}", entityFramework.GetOrderTime_RawQuery());
            Console.WriteLine("ORM - entity Framework time: {0}", entityFramework.GetOrderTime_ORMEntityframework());
            Console.WriteLine("Dapper time: {0}", dapper.GetOrderTime_Dapper());
            Console.WriteLine("ADO.net time: {0}", adonet.GetOrderTime_ADO_net());

        }
    }
}
