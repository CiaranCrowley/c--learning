// See https://aka.ms/new-console-template for more information
using System;

namespace HelloWorld // Note: actual namespace depends on the project name.
{

  public class Computer
  {
    // private string _motherboard;
    public string Motherboard { get; set; } = "";
    public int CPUCores { get; set; }
    public bool hasWifi { get; set; }
    public bool hasLTE { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; } = "";
  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Computer myComputer = new Computer()
      {
        Motherboard = "Z690",
        hasWifi = true,
        hasLTE = true,
        ReleaseDate = DateTime.Now,
        Price = 943.87m,
        VideoCard = "RTX 2060"
      };
      Console.WriteLine(myComputer.Motherboard);

    }

  }
}
