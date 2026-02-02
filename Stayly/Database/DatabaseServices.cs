using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
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
        
        public static string szallasFeltoltes(string connectionString, string hostName, string propertyName, string location, double price, double rating, string checkIn, string checkOut, int elerheto)
        {

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO szallas (hostName, popertyName, location, price, rating, checkInTime, checkOutTime, elerhetoseg) " +
                       "VALUES (@host, @name, @loc, @price, @rating, @checkIn, @checkOut, @ava)";

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@host", hostName);
            command.Parameters.AddWithValue("@name", propertyName);
            command.Parameters.AddWithValue("@loc", location);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@rating", rating);
            command.Parameters.AddWithValue("@checkIn", checkIn);
            command.Parameters.AddWithValue("@checkOut", checkOut);
            command.Parameters.AddWithValue("@ava", elerheto); 
            
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return "Szállás sikeresen felvéve az adatbázisba!";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Nem sikerült a beszúrás!";
            }
        }
    }
}