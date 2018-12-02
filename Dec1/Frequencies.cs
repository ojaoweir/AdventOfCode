using System;

namespace AdventOfCode {
  class SumFrequencies {
    static void Main() {
      //read from file
      //turn into int
      int[] input = readFrequencyInput();

      //add all
      Console.WriteLine(frequency);
      for(int i= 0; i < input.Length; i = i +1) {
        frequency = frequency + input[i];
      }

      Console.WriteLine(frequency);
      //print result
      Console.WriteLine("Press key to continue");
      Console.ReadKey();
    }

    static int[] readFrequencyInput() {
      string[] input = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec1\Input.txt");
      int[] inputInt = new int[input.Length];
      for(int i = 0; i < input.Length; i = i + 1) {
        inputInt[i] = Int32.Parse(input[i]);
      }
      return inputInt;
    }

  }
}
