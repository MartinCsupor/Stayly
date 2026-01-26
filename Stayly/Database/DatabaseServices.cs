using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stayly.Database
{
    internal class DatabaseServices
    {
        private static string connectionString;
        private static string table;
        private static string query_parameters;

        public static void DBConnectionCheck(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Sikeres kapcsolodas");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sikertelen kapcsolodas");
                Console.WriteLine(ex);
            }
        }

        public static DataTable getAllData(string connectionString, string table)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand($"SELECT * FROM {table}", connection);

            using var reader = command.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }

        public static int deleteData(string connectionString, string table, string query_parameters)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand($"DELETE FROM {table} WHERE {query_parameters}", connection);

            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }
}