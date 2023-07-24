// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld // Note: actual namespace depends on the project name.
{


  internal class Program
  {
    static void Main(string[] args)
    {

      string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

      IDbConnection dbConnection = new SqlConnection(connectionString);

      string sqlCommand = "SELECT GETDATE()";

      DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

      Console.Write(rightNow);

      Computer myComputer = new Computer()
      {
        Motherboard = "Z690",
        HasWifi = true,
        HasLTE = true,
        ReleaseDate = DateTime.Now,
        Price = 943.87m,
        VideoCard = "RTX 2060"
      };
      Console.WriteLine(myComputer.Motherboard);

    }

  }
}
