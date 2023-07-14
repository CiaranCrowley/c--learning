// See https://aka.ms/new-console-template for more information
using System;

namespace HelloWorld // Note: actual namespace depends on the project name.
{
  internal class Program
  {

    static void Main(string[] args)
    {
      // Console.WriteLine("Hello World!");

      // sbyte mySbyte = 127;
      // sbyte mySecondSbyte = -128;
      // byte myByte = 255;
      // byte mySecondByte = 0;

      // short myShort = -32_768;
      // ushort myUshort = 65_535;

      // int myInt = 2_147_483_647;
      // int mySecondInt = -2_147_483_648;

      // long myLong = 9_223_372_036_854_775_807;
      // long mySecondLong = -9_223_372_036_854_775_808;

      // float myFloat = 0.751f;
      // float mySecondFloat = 0.75f;
      // double myDouble = 0.751;
      // double mySecondDouble = 0.75d;
      // decimal myDecimal = 0.751m;
      // decimal mySecondDecimal = 0.75m;

      // Console.WriteLine(myFloat - mySecondFloat);
      // Console.WriteLine(myDouble - mySecondDouble);
      // Console.WriteLine(myDecimal - mySecondDecimal);

      // string[] groceryArray = new string[2]; // This is how long the array is

      // groceryArray[0] = "banana";
      // groceryArray[1] = "apple";
      // Console.WriteLine(groceryArray[0]);
      // Console.WriteLine(groceryArray[1]);

      // string[] arr = { "Apple", "Banana" };
      // Console.WriteLine(arr[1]);


      List<string> shoppingList = new List<string>() { "Tomato", "Potato" };

      // Console.WriteLine(shoppingList[0]);
      // Console.WriteLine(shoppingList[1]);

      shoppingList.Add("Chicken");
      // Console.WriteLine(shoppingList[2]);

      IEnumerable<string> shoppingListIEnumerable = shoppingList;

      Console.WriteLine(shoppingListIEnumerable.First());

      string[,] twoDimensionalArray = new string[,] {
        { "Tomato", "Potato" },
        { "Apple", "Banana" }
      };

      Console.WriteLine(twoDimensionalArray[0, 0]);

    }
  }
}