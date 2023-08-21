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
            DataContextEF entityFramework = new DataContextEF();

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                CPUCores = 16,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

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

            string sqlSelect = @"SELECT Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
                FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach (Computer computer in computers)
            {
                Console.WriteLine("'" + +computer.ComputerId
                 + "','" + computer.Motherboard
                 + "','" + computer.HasWifi
                 + "','" + computer.HasLTE
                 + "','" + computer.ReleaseDate.ToString("yyyy-MM-dd")
                 + "','" + computer.Price
                 + "','" + computer.VideoCard
                 + "'"
               );
            }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if (computersEf != null)
            {
                foreach (Computer computer in computersEf)
                {
                    Console.WriteLine("'" + computer.ComputerId
                     + "','" + computer.Motherboard
                     + "','" + computer.HasWifi
                     + "','" + computer.HasLTE
                     + "','" + computer.ReleaseDate.ToString("yyyy-MM-dd")
                     + "','" + computer.Price
                     + "','" + computer.VideoCard
                     + "'"
                   );
                }
            }
        }
    }
}