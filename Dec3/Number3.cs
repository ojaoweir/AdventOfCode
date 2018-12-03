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
                int start = 1;
                int space = findSpace(input, start);
                string coord;
                int x;
                int y;
                int width;
                int height;
                int ID;
                int stop;

                ID = Int32.Parse(input.Substring(start, (space - 1)));
                start = space + 3;
                space = findSpace(input,start);
                Console.WriteLine(ID);
                coord = input.Substring(start,space-1);
                for(int i = 0; i < coord.Length; i = i+1) {
                  if(input[i].Equal(',')) {
                    stop = i;
                    break;
                  }
                }
                x = Int32.Parse(coord.Substring(start,(stop-1)));
                y = Int32.Parse(coord.Substring(stop+1,space-1));

                Console.WriteLine(x);
                Console.WriteLine(y);
                // Make a general function "splitAt() that has indata what char you should split at instead of findSpace??"
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
