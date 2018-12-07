using System;
using System.Text;
using System.Collections.Generic;

namespace naptime
{
    class guard
    {
        List<sleep> sleeps;
        public int ID;
        public int totalSleep;
        public int[] sleepiestTime = new int[2];
        public guard(int IDin)
        {
            ID = IDin;
            sleeps = new List<sleep>();
            totalSleep = 0;
            sleepiestTime[0] =0;
            sleepiestTime[1] = 0;
        }

        public int calcSleepMinute()
        {
            int[] min = new int[60];
            for(int i = 0; i < min.Length; i++)
            {
                foreach(sleep s in sleeps)
                {
                    if(s.start <= i)
                    {
                        if(s.stop > i)
                        {
                            min[i]++;
                        }
                    }
                }
            }
            return findMax(min);
        }

        public void calcTotalSleepTime()
        {
            totalSleep = 0;
            foreach(sleep s in sleeps)
            {
                totalSleep = totalSleep + s.minAsleep;
            }
        }

        public void addSleep(sleep s)
        {
            sleeps.Add(s);
            totalSleep = totalSleep + s.minAsleep;
        }

        public void timeAsleepOnSleepiest()
        {
            sleepiestTime[0] = calcSleepiestTime();
            sleepiestTime[1] = calcTimeAsleepOn(sleepiestTime[0]);
        }

        public int calcTimeAsleepOn(int time)
        {
            int times = 0;
            foreach (sleep s in sleeps)
            {
                Console.WriteLine();
                Console.Write(time);
                Console.Write(' ');
                Console.Write(s.start);
                Console.Write(' ');
                Console.Write(s.stop);
                Console.Write(' ');
                if (time >= s.start && time < s.stop)
                {
                    Console.Write("true");
                    times++;
                }
            }
            return times;
        }

        public int calcSleepiestTime()
        {
            int[] mins = new int[60];
            for (int i = 0; i < 60; i++)
            {
                foreach (sleep s in sleeps)
                {
                    if(i >= s.start && i < s.stop)
                    {
                        mins[i]++;
                    }
                }
            }
            return findMax(mins);
        }

        public int findMax(int[] arr)
        {
            int index = 0;
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i]>arr[index])
                {
                    index = i;
                }
            }
            return index;
        }

    }
    class sleep
    {
        public int start;
        string date;
        public int stop;
        public int minAsleep= 0;
        public sleep(string dateIn, int startIn, int stopIn)
        {
            date = dateIn;
            start = startIn;
            stop = stopIn;
            minAsleep = stop - start;
        }

    }

    class whensleep
    {
        static void Main()
        {
            string[] read = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec4\input.txt");
            string[] inputs = doTheSort(read);
            int guardId = 0;
            bool asleep = false;
            List<guard> guards = new List<guard>();
            guard sleeper = new guard(0);
            string oldDate = "";
            int startTime = 0;
            int stopTime = 0;
            foreach (string input in inputs)
            {
                string date = input.Substring(1, 10);
                if (!date.Equals(oldDate))
                {
                    if (asleep)
                    {
                        sleeper.addSleep(new sleep(oldDate, startTime, 59));
                        asleep = false;
                    }
                    startTime = 0;
                    oldDate = date;

                }
                int stopPos;
                switch (input[19])
                {
                    case 'G':
                        stopPos = getStopPos(input);
                        guardId = Int32.Parse(input.Substring(26, stopPos - 26));
                        sleeper = findGuard(guards, guardId);
                        break;
                    case 'w':
                        stopTime = getTime(input);
                        sleeper.addSleep(new sleep(date, startTime, stopTime));
                        asleep = false;
                        break;
                    case 'f':
                        startTime = getTime(input);
                        asleep = true;
                        break;
                }
            }
            foreach (guard g in guards)
            {
                g.calcTotalSleepTime();
            }


            foreach (guard g in guards)
            {
                if (g.totalSleep > sleeper.totalSleep)
                {
                    sleeper = g;

                }
            }
            Console.Write("Guard: ");
            Console.WriteLine(sleeper.ID);
            int sleepmin = sleeper.calcSleepiestTime();
            Console.Write("Sleepiest minute: ");
            Console.WriteLine(sleepmin);
            Console.Write("svar1: ");
            Console.WriteLine(sleeper.ID * sleepmin);
            Console.WriteLine();

            /*foreach (guard g in guards)
            {
                g.timeAsleepOnSleepiest();
            }


            foreach (guard g in guards)
            {
                if (g.sleepiestTime[0] > sleeper.sleepiestTime[0])
                {
                    sleeper = g;

                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Guard: ");
            Console.WriteLine(sleeper.ID);
            Console.Write("most slept min: ");
            Console.WriteLine(sleeper.sleepiestTime[0]);
            Console.Write("svar2: ");
            Console.Write(sleeper.ID * sleeper.sleepiestTime[0]);

            */

            doTaskB(guards);
        }
        //Of all guards, which guard is most frequently asleep on the same minute?
        static void doTaskB(List<guard> guardsList)
        {
            int[] min = new int[guardsList.Count];
            guard[] guards = guardsList.ToArray();
            for(int i = 0; i < min.Length; i++)
            {
                min[i] = guards[i].calcSleepMinute();
            }
            int index = 0;
            for(int i = 0; i < min.Length; i++)
            {
                if(min[i] > min[index])
                {
                    index = i;
                }

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Guard: ");
            Console.WriteLine(guards[index].ID);
            Console.Write("most slept min: ");
            Console.WriteLine(min[index]);
            Console.Write("svar2: ");
            Console.Write(guards[index].ID * min[index]);
        }

        static int getTime(string text)
        {
            return Int32.Parse(text.Substring(15, 2));
        }

        static guard findGuard(List<guard> guards,int guardId)
        {
            foreach (guard gua in guards)
            {
                if (gua.ID == guardId)
                {
                    return gua;
                }
            }
            guard g = new guard(guardId);
            guards.Add(g);
            return g;
        }

        static int getStopPos(string text)
        {
            for (int i = 26; i < text.Length; i = i + 1)
            {
                if (text[i].Equals(' '))
                {
                    return i;
                }
            }
            return 606060606;

        }

        static string[] doTheSort(string[] texts)
        {
            for(int i = 1; i < texts.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if(!isFirst(texts[j],texts[j-1]))
                    {
                        break;
                    } else
                    {
                        string temp = texts[j - 1];
                        texts[j - 1] = texts[j];
                        texts[j] = temp;
                    }
                }
            }
            return texts;
        }

        static bool isFirst(string s1, string s2)
        {
            //datum mindre
            int valS1 = Int32.Parse(s1.Substring(1, 4));
            int valS2 = Int32.Parse(s2.Substring(1, 4));          
            if(valS1 == valS2)
            {
                valS1 = Int32.Parse(s1.Substring(6, 2));
                valS2 = Int32.Parse(s2.Substring(6, 2));
                if(valS1 == valS2)
                {
                    valS1 = Int32.Parse(s1.Substring(9, 2));
                    valS2 = Int32.Parse(s2.Substring(9, 2));
                    if(valS1 == valS2)
                    {
                        valS1 = Int32.Parse(s1.Substring(12, 2));
                        valS2 = Int32.Parse(s2.Substring(12, 2));
                        if (valS1 == valS2)
                        {
                            valS1 = Int32.Parse(s1.Substring(15, 2));
                            valS2 = Int32.Parse(s2.Substring(15, 2));
                            if (valS1 < valS2)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            if (valS1 > valS2)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if(valS1 < valS2)
                        {
                            return true;
                        }
                    }

                } else
                {
                    if (valS1 < valS2) {
                        return true;
                    }
                }
            } else
            {
                if(valS1 < valS2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
