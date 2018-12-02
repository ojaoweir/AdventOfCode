using System;
using System.Collections.Generic;

namespace Dec2
{
    class boxes
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec2\input.txt");            
            int doubleCounter = 0;
            int tripleCounter = 0;
            for (int i = 0; i < input.Length; i = i + 1)
            {
                char[] word =  new char [input[i].Length];
                int[] reoccurance = new int[word.Length];
                for(int j = 0; j < reoccurance.Length; j = j+1)
                {
                    word[j] = input[i][j];
                    reoccurance[j] = 1;
                }
                
                for (int j = 0; j < word.Length - 1; j = j +1)
                {
                    for (int k = j+1; k < word.Length; k = k+1)
                    {
                        if (!word[k].Equals(' '))
                        {
                            if (word[j].Equals(word[k]))
                            {
                                reoccurance[j] = reoccurance[j] + 1;
                                word[k] = ' ';
                            }
                        } 
                    }
                }
                for(int j = 0; j < reoccurance.Length; j = j+1)
                {
                    if(reoccurance[j] == 2)
                    {
                        doubleCounter = doubleCounter + 1;
                        
                        break;
                    }
                }
                for (int j = 0; j < reoccurance.Length; j = j + 1)
                {
                    
                    if (reoccurance[j] == 3)
                    {
                        tripleCounter = tripleCounter + 1;
                        break;
                    }
                }
            }
            
            Console.WriteLine("Svar:");
            Console.WriteLine(tripleCounter * doubleCounter);
        }
    }
}
    
