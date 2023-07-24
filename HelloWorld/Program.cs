// See https://aka.ms/new-console-template for more information
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

      IDbConnection dbConnection = new SqlConnection(connectionString);

      string sqlCommand = "SELECT GETDATE()";

      DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

      Console.WriteLine(rightNow);

      Computer myComputer = new Computer()
      {
        Motherboard = "Z690",
        HasWifi = true,
        HasLTE = true,
        ReleaseDate = DateTime.Now,
        Price = 943.87m,
        VideoCard = "RTX 2060"
      };

      string sql = @"INSERT INTO TutorialAppSchema.Computer (
        Motherboard,HasWifi,HasLTE,ReleaseDate,Price,VideoCard
       ) VALUES ('" + myComputer.Motherboard
       + "','" + myComputer.HasWifi
       + "','" + myComputer.HasLTE
       + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
       + "','" + myComputer.Price
       + "','" + myComputer.VideoCard
       + "')";

      Console.WriteLine(sql);

      int result = dbConnection.Execute(sql);

      Console.WriteLine(result);

      string sqlSelect = @"SELECT Computer.Motherboard,
        Computer.HasWifi,
        Computer.HasLTE,
        Computer.ReleaseDate,
        Computer.Price,
        Computer.VideoCard
        FROM TutorialAppSchema.Computer";

      IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

      foreach (Computer computer in computers)
      {
        Console.WriteLine("'" + myComputer.Motherboard
         + "','" + myComputer.HasWifi
         + "','" + myComputer.HasLTE
         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
         + "','" + myComputer.Price
         + "','" + myComputer.VideoCard
         + "'"
       );
      }
    }
  }
}