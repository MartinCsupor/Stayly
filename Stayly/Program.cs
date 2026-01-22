using Stayly.Database;
using Stayly.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=stayly;User=root";
    public static DataTable adatok = new DataTable();
    public static List<Szallas> szallasList = new List<Szallas>();
    private static void Main(string[] args)
    {
        DatabaseServices.DBConnectionCheck(connectionString);
        SelectAll(connectionString, "szallas");
        SzallasFeltoltes(adatok);
    }

    private static void SzallasFeltoltes(DataTable adatok)
    {

    }

    private static void SelectAll(string connectionString, string v)
    {
        adatok = DatabaseServices.getAllData(connectionString, "szallas");
    }
}