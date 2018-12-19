using System;

namespace area
{
    class minCoordinate
    {
        string value;
        int distance;
        public minCoordinate(string valueIn, int distanceIn)
        {
            distance = distanceIn;
            value = valueIn;
        }
        public int getDistance()
        {
            return distance;
        }
        public string getValue()
        {
            return value;
        }
    }
    class mainCoordinate
    {
        int x;
        int y;
        string value;
        int distance;
        public mainCoordinate(int xIn, int yIn, string valueIn, int distanceIn)
        {
            value = valueIn;
            x = xIn;
            y = yIn;
            distance = distanceIn;

        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
        public string getValue(bool big)
        {
            if(big)
            {
                return value;
            }
            char[] temp = new char[2];
            temp[0] = Char.ToLower(value[0]);
            temp[1] = Char.ToLower(value[1]);
            return  temp.ToString();
        }

        public int getDistance()
        {
            return distance;
        }
    }
    class largestArea
    {
        static void Main()
        {
            //get all input, one for each row
            string[] inputs = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec6\input.txt");
            //translate them to mainCoordinates
            mainCoordinate[] coords = inputToCoord(inputs);
            //coord = translate typ
            //Make huge double array
            //place mainCoordinates in the array
            minCoordinate[,] area = calculateArea(coords);
            //for each in array find closest
            //if equal distance to two - it is nothing
            area = fillArea(area, coords);
            //count how many there are of each (so you get the area)
            //count out those that have their value on the border
            printAll(area);
        }

        static void printAll(minCoordinate[,] area)
        {
            Console.WriteLine();
            for( int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(0); j++)
                {
                    Console.Write(area[i, j]);
                }
                Console.WriteLine();
            }
        }

        static minCoordinate[,] fillArea(minCoordinate[,] area, mainCoordinate[] coords)
        {
            int maxX = area.GetLength(0);
            int maxY = area.GetLength(1);
            int startX;
            int startY;
            bool done;
            
            foreach(mainCoordinate c in coords)
            {
                startX = c.getX();
                startY = c.getY();
                done = false;
                for(int i = 1; i < 100000; i++)
                {
                    //search north
                    for (int j = i; j > 0; j++)
                    {
                        done = true;
                        if(startY-j >= 0)
                        {
                            if(startX - (i-j) >= 0)
                            {
                                if (free(area[startX - (i - j), startY - j], i))
                                {
                                    if (equalDistance(area[startX - (i - j), startY - j].getDistance(), i))
                                    {
                                        area[startX - (i - j), startY - j] = new minCoordinate("1", 0);
                                    }
                                    else
                                    {
                                        area[startX - (i - j), startY - j] = new minCoordinate(c.getValue(false), i);
                                        done = false;
                                    }
                                }
                            }
                            if (startX + (i - j) < maxX)
                            {
                                if (free(area[startX - (i - j), startY - j], i))
                                {

                                    if (equalDistance(area[startX - (i - j), startY - j].getDistance(), i))
                                    {
                                        area[startX - (i - j), startY - j] = new minCoordinate("1", 0);
                                    }
                                    else
                                    {
                                        area[startX + (i - j), startY - j] = new minCoordinate(c.getValue(false), i);
                                        done = false;
                                    }
                                }
                            }

                                //out of bonds varför?

                        }
                    }
                    //search west
                    //search south
                    //search east
                    if(done)
                    {
                        break;
                    }

                }
            }
            return area;
        }

        static bool free(minCoordinate mc, int length)
        {
            if(!mc.getValue().Equals('0'))
            {
                if(mc.getDistance() < length)
                {
                    return false;
                }

                if (mc.getValue().Equals('1'))
                {
                    return false;
                }
            }
            return true;
        }

        static bool equalDistance(int num1, int num2)
        {
            if(num1 == num2)
            {
                return true;
            }
            return false;
        }

        static bool noMeet(int[] ways)
        {
            foreach(int i in ways)
            {
                if(i != -1)
                {
                    return false;
                }
            }
            return true;
        }

        static mainCoordinate[] inputToCoord(string[] inputs)
        {
            mainCoordinate[] coords = new mainCoordinate[inputs.Length];
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int x;
            int y;
            int comma;
            int a1 = 0;
            int a2 = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                comma = findComma(inputs[i]);
                x = Int32.Parse(inputs[i].Substring(0, comma));
                y = Int32.Parse(inputs[i].Substring(comma + 1));
                char[] temp = new char[2];
                temp[0] = alphabet[a1];
                temp[1] = alphabet[a2];
                coords[i] = new mainCoordinate(x, y,temp.ToString(),0);
                if (a2 == 25)
                {
                    a1++;
                    a2 = 0;
                } else
                {
                    a2++;
                }
            }
            return coords;
        }
        
        static minCoordinate[,] calculateArea(mainCoordinate[] coords)
        {
            int maxX = 0;
            int maxY = 0;
            minCoordinate[,] area;

            foreach(mainCoordinate coord in coords)
            {
                if (coord.getX() > maxX)
                {
                    maxX = coord.getX();
                }
                if (coord.getY() > maxY)
                {
                    maxY = coord.getY();
                }
            }
            area = new minCoordinate[maxX+1, maxY+1];

            for(int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    area[i,j] = new minCoordinate("0", 0);
                }
            }

            for (int i = 0; i < coords.Length; i++)
            {
                area[coords[i].getX(), coords[i].getY()] = new minCoordinate(coords[i].getValue(true), 0);
            }

            return area;
        }

        static int findComma(string text)
        {
            for(int i = 0; i< text.Length; i++)
            {
                if(text[i].Equals(','))
                {
                    return i; 
                }
            }
            return 0;
        }
    }
}