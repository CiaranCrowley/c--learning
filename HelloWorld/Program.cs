// See https://aka.ms/new-console-template for more information
using System;
using HelloWorld.Models;

namespace HelloWorld // Note: actual namespace depends on the project name.
{


  internal class Program
  {
    static void Main(string[] args)
    {
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
