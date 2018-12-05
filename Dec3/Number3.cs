using System;
using System.Text;

namespace overlaps
{
    class square
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int ID;

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
            square[] sqs = convertToSquare(input);            
            int[] max = findMax(sqs);
            int[,] sheet = new int[max[0],max[1]];
            sheet = setSheet(sqs, sheet);
            Console.Write("Svar1: ");
            Console.WriteLine(calculateOverlaps(sheet));
            Console.Write("Svar2: ");
            Console.Write(findOKsquare(sheet,sqs));
        }

        static int findOKsquare(int[,] sheet, square[] sqs)
        {
            foreach(square sq in sqs)
            {
                if (OKsquare(sheet,sq))
                {

                    return sq.ID;
                }
            }
            return 6755555;
        }

        static bool OKsquare(int[,] sheet, square sq)
        {
            for (int i = sq.x; i < sq.width + sq.x; i = i + 1)
            {
                for (int j = sq.y; j < sq.height + sq.y; j = j + 1)
                {
                    if (sheet[i, j] == 2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static int calculateOverlaps(int[,] sheet)
        {
            int overlaps = 0;
            foreach(int sh in sheet)
            {
                if(sh == 2)
                {
                    overlaps = overlaps + 1;
                }
            }
            return overlaps;
        }

        static int[] findMax(square[] sqs)
        {
            int[] coord = { 0, 0 };
            Console.WriteLine(coord[0]);
            Console.WriteLine(coord[1]);
            foreach (square sq in sqs)
            {
                int reachX = sq.x + sq.width;
                int reachY = sq.y + sq.height;
                if (reachX > coord[0])
                {
                    coord[0] = reachX;
                }
                if (reachY > coord[1])
                {
                    coord[1] = reachY;
                }
            }
            Console.WriteLine(coord[0]);
            Console.WriteLine(coord[1]);

            return coord;
        }

        static int[,] setSheet(square[] sqs, int[,] sheet)
        {
            foreach(square sq in sqs)
            {
                for(int i = sq.x; i < sq.width+sq.x; i= i+1)
                {
                    for(int j = sq.y; j < sq.height+sq.y; j = j+1)
                    {
                        if(sheet[i,j] == 0)
                        {
                            sheet[i,j] = 1;
                        } else if (sheet[i,j] == 1)
                        {
                            sheet[i,j] = 2;
                        }
                    }
                }
            }
            return sheet;
        }

        static square[] convertToSquare(string[] inputs)
        {
            square[] inputSq = new square[inputs.Length];
            foreach(string input in inputs)
            {
                int start = 1;
                int x;
                int y;
                int width;
                int height;
                int ID;
                int stop;
                start = 1;
                stop = findStop(input, start,' ');
                ID = Int32.Parse(input.Substring(start,stop-start));

                start = stop + 3;
                stop = findStop(input, start,',');
                x = Int32.Parse(input.Substring(start,stop-start));


                start = stop + 1;
                stop = findStop(input, start,':');
                y = Int32.Parse(input.Substring(start,stop-start));

                start = stop + 2;
                stop = findStop(input, start,'x');
                width = Int32.Parse(input.Substring(start, stop - start));
                
                start = stop + 1;
                stop = input.Length;
                height = Int32.Parse(input.Substring(start, stop - start));
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
                inputSq[(ID-1)] = new square(ID, x, y, width, height);
            }
            return inputSq;
        }

        static int findStop(string text, int start,char match)
        {
            for (int i = start; i < text.Length; i = i + 1)
            {
                if (text[i].Equals(match))
                {
                    return i;
                }
            }
            return 606060606;

        }
    }
}
