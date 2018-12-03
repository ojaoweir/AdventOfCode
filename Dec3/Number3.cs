using System;

namespace overlaps
{
    class square
    {
        int x;
        int y;
        int width;
        int height;
        int ID;

        public square(int IDIn, int xIn, int yIn, int widthIn, int heightIn)
        {
            ID = IDIn;
            x = xIn;
            y = yIn;
            width = widthIn;
            height = heightIn;
        }
        
    }

    class overlapping
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec3\input.txt");
            convertToSquare(input);
        }

        static void convertToSquare(string[] inputs)
        {
            foreach(string input in inputs)
            {
                int space = findSpace(input, 1);
                int x;
                int y;
                int width;
                int height;
                int ID;
                

                ID = Int32.Parse(input.Substring(1, (space - 1)));
                Console.WriteLine(ID);

            }
        }

        static int findSpace(string text, int start)
        {
            for (int i = start; i < input.Length; i = i + 1)
            {
                if (input[i].Equals(' '))
                {
                    return i;
                }
            }
            return null;

        }

    }
}
