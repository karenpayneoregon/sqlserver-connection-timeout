using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerConventional.Classes
{
    public class DataOperations
    {
        
        private static string _connectionString = 
            "Data Source=.\\sqlexpress;Initial Catalog=NorthWind2020;Integrated Security=True";

        public static bool RunWithoutIssues = false;
        private static bool HasException { get; set; }
        public static bool IsSuccessful => HasException == false;
        public static string ExceptionMessage { get; set; }

        public delegate void OnConnectionFinished(string timeSpent);
        public static event OnConnectionFinished ConnectionFinished;

        public static DataTable ReadProducts()
        {
            HasException = false;
            var table = new DataTable();

            _connectionString = RunWithoutIssues ?
                "Data Source=.\\sqlexpressISSUE;Initial Catalog=NorthWind2020;Integrated Security=True" :
                "Data Source=.\\sqlexpress;Initial Catalog=NorthWind2020;Integrated Security=True";

            using (var cn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand() {Connection = cn})
                {
                    cmd.CommandText = SelectStatement();

                    var timer = new Stopwatch();
                    timer.Start();
                    
                    try
                    {
                        cn.Open();
                        table.Load(cmd.ExecuteReader());
                    }
                    catch (Exception e)
                    {
                        HasException = true;
                        ExceptionMessage = e.Message;
                    }

                    timer.Stop();

                    TimeSpan timeTaken = timer.Elapsed;
                    ConnectionFinished?.Invoke(timeTaken.ToString(@"m\:ss\.fff"));

                }
            }

            return table;
        }
        private static string SelectStatement()
        {
            return "SELECT P.ProductID, P.ProductName, P.SupplierID, S.CompanyName, P.CategoryID, " +
                   "C.CategoryName, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, " +
                   "P.ReorderLevel, P.Discontinued, P.DiscontinuedDate " +
                   "FROM  Products AS P INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID " +
                   "INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID";
        }
    }
}
