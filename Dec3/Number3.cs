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
                start = 1;
                stop = findStop(input, start,' ');
                ID = Int32.Parse(input.Substring(start,stop-1));

                start = stop + 3;
                stop = findStop(input, start,',');
                x = Int32.Parse(input.Substring(start,stop-1));


                start = stop + 1;
                stop = findStop(input, start,':');
                y = Int32.Parse(input.Substring(start,stop-1));

                start = stop + 2;
                stop = findStop(input, start,'x');
                width = Int32.Parse(input.Substring(start,stop-1));

                start = stop + 1;
                stop = input.Length - 1;
                height = Int32.Parse(input.Substring(start,stop-1));
                Console.Write("#");
                Console.Write(ID);
                Console.Write(" ");
                Console.Write(x);
                Console.Write(",");
                Console.Write(y);
                Console.Write(" ");
                Console.Write(width);
                Console.Write("x");
                Console.Write(height);
                Console.WriteLine();
                // Make a general function "splitAt() that has indata what char you should split at instead of findSpace??"
            }
        }

        static int findStop(string text, int start,char match)
        {
            for (int i = start; i < input.Length; i = i + 1)
            {
                if (input[i].Equals(match))
                {
                    return i;
                }
            }
            return null;

        }
    }
}
