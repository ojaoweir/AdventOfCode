using System;

namespace polymers
{
    class polymers
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"E:\Bibliotek\Prog\AdventOfCode\Dec5\input.txt");
            for (int i = 1; i < text.Length; i++)
            {
                if (char.ToLower(text[i - 1]).Equals(char.ToLower(text[i])))
                {
                    if (text[i - 1].Equals(text[i]))
                    {
                        Console.Write(text[i-1]);
                    }
                } else
                {
                    Console.Write();

                }
            }
        }
    }
}