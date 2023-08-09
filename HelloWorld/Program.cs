// See https://aka.ms/new-console-template for more information
using HelloWorld.Data;
using HelloWorld.Models;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

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

            int result = dapper.ExecuteSqlWithRowCount(sql);

            Console.WriteLine(result);

            string sqlSelect = @"SELECT Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
                FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

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