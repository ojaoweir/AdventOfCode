using System;
using System.Collections.Generic;

namespace AdventOfCode {
  class FindDoubleFrequencies {
            static void Main() {
            int[] input = readFrequencyInput();
            List<int> frequencies = new List<int>();
            int frequency = 0;
            Boolean run = true;
            int counter = 0;
            do
            {
                frequency = frequency + input[counter];
                Console.WriteLine(frequency);
                if(frequencies.Contains(frequency))
                {
                    run = false;
                } else
                {
                    counter = (counter + 1) % input.Length;
                    frequencies.Add(frequency);

                }
            } while (run);

            Console.WriteLine(frequency);
            Console.WriteLine("Press button to continue");
            Console.ReadKey();

    }
   static int[] readFrequencyInput()
        {
            string[] input = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec1\Input.txt");
            int[] inputInt = new int[input.Length];
            for (int i = 0; i < input.Length; i = i + 1)
            {
                inputInt[i] = Int32.Parse(input[i]);
            }
            return inputInt;
   }

    }
}
