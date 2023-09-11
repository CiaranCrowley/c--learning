// See https://aka.ms/new-console-template for more information
using HelloWorld.Models;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,HasWifi,HasLTE,ReleaseDate,Price,VideoCard
                ) VALUES ('" + myComputer.Motherboard
                + "','" + myComputer.HasWifi
                + "','" + myComputer.HasLTE
                + "','" + myComputer.ReleaseDate
                + "','" + myComputer.Price
                + "','" + myComputer.VideoCard
                + "')\n";

            File.WriteAllText(@"C:\Users\ciara\Documents\C Sharp\CSharp_Learning\HelloWorld\log.txt", "\n" + sql + "\n");

            using StreamWriter openFile = new(@"C:\Users\ciara\Documents\C Sharp\CSharp_Learning\HelloWorld\log.txt", append: true);

            openFile.WriteLine("\n" + sql + "\n");

            openFile.Close();

            string fileText = File.ReadAllText("log.txt");

            Console.WriteLine(fileText);
        }
    }
}