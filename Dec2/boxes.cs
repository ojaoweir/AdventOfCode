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
            List<string> resultlist = new List<string>();
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
                        if(!resultlist.Contains(input[i]))
                        {
                            resultlist.Add(input[i]);
                        }
                        break;
                    }
                }
                for (int j = 0; j < reoccurance.Length; j = j + 1)
                {
                    
                    if (reoccurance[j] == 3)
                    {
                        tripleCounter = tripleCounter + 1;
                        if (!resultlist.Contains(input[i]))
                        {
                            resultlist.Add(input[i]);
                        }
                        break;
                    }
                }
            }
            
            Console.WriteLine("Svar1:");
            Console.WriteLine(tripleCounter * doubleCounter);
            string[] results = new string[resultlist.Count];
            resultlist.CopyTo(results);
            char[] sharedletters = new char[5];
            for(int i = 0; i < results.Length - 1; i = i+1)
            {
                for(int j = i + 1; j < results.Length; j = j +1)
                {
                    if (same(results[i], results[j]))
                    {
                        int counter = 0;
                        sharedletters = new char[results.Length - 1];
                        for(int k = 0; k < results[i].Length; k = k+1)
                        {
                            if (results[i][k].Equals(results[j][k])) {
                                sharedletters[counter] = results[i][k];
                                counter = counter + 1;
                            }
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Svar2:");
            Console.WriteLine(sharedletters);
        }

        static bool same(string S1, string S2)
        {
            bool deviation = false;
            for(int i = 0; i < S1.Length; i = i+1)
            {
                if(!S1[i].Equals(S2[i]))
                {
                    if(deviation)
                    {
                        return false;
                    } else
                    {
                        deviation = true;
                    }
                }
            }
            return true;
        }
    }
}
    
