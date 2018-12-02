using System;
namespace Frequiencies {
  class frequiencies {
    static void Main() {
      //read from file
      string[] input = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec1\Input.txt");
      int[] inputInt = new int[input.Length];
      int frequency = 0;
      for(int i = 0; i < input.Length; i = i + 1) {
      }

      //turn into int
      for(int i = 0; i < input.Length; i = i + 1) {
        inputInt[i] = Int32.Parse(input[i]);
      }

      //add all

      Console.WriteLine(frequency);
      for(int i= 0; i < inputInt.Length; i = i +1) {
        frequency = frequency + inputInt[i];
      }

      Console.WriteLine(frequency);
      //print result
      Console.WriteLine("Press key to continue");
      Console.ReadKey();
    }
  }
}
