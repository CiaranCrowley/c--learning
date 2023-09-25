// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    private static void Main(string[] args)
    {

      IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

      DataContextDapper dapper = new DataContextDapper(config);

      // string sql = @"INSERT INTO TutorialAppSchema.Computer (
      //           Motherboard,HasWifi,HasLTE,ReleaseDate,Price,VideoCard
      //           ) VALUES ('" + myComputer.Motherboard
      //     + "','" + myComputer.HasWifi
      //     + "','" + myComputer.HasLTE
      //     + "','" + myComputer.ReleaseDate
      //     + "','" + myComputer.Price
      //     + "','" + myComputer.VideoCard
      //     + "')\n";

      // File.WriteAllText(@"C:\Users\ciara\Documents\C Sharp\CSharp_Learning\HelloWorld\log.txt", "\n" + sql + "\n");

      // using StreamWriter openFile = new(@"C:\Users\ciara\Documents\C Sharp\CSharp_Learning\HelloWorld\log.txt", append: true);

      // openFile.WriteLine("\n" + sql + "\n");

      // openFile.Close();

      string computersJson = File.ReadAllText("Computers.json");

      // Console.WriteLine(computersJson);

      JsonSerializerOptions options = new JsonSerializerOptions()
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };

      // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
      IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);
      IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

      if (computersNewtonSoft != null)
      {
        foreach (Computer computer in computersNewtonSoft)
        {
          Console.WriteLine(computer.Motherboard);

          string sql = @"INSERT INTO TutorialAppSchema.Computer (
                    Motherboard,HasWifi,HasLTE,ReleaseDate,Price,VideoCard
                    ) VALUES ('" + EscapeSingleQuotes(computer.Motherboard)
              + "','" + computer.HasWifi
              + "','" + computer.HasLTE
              + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd")
              + "','" + computer.Price.ToString("0.00")
              + "','" + EscapeSingleQuotes(computer.VideoCard)
              + "')\n";

          dapper.ExecuteSql(sql);
        }
      }

      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };

      string computersCopyNewtonSoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

      File.WriteAllText("computersCopyNewtonSoft.txt", computersCopyNewtonSoft);

      string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

      File.WriteAllText("computersCopySystem.txt", computersCopySystem);

    }

    static string EscapeSingleQuotes(string input)
    {
      string output = input.Replace("'", "''");

      return output;
    }
  }
}