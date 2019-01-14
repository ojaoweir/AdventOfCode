using System;

namespace marbles
{
    class marble
    {
        marble clockwise;
        marble counterClockwise;
        int value;

        public marble()
        {
        }

        public void write(int current)
        {
            if(value != current)
            {
                Console.Write(value);
                Console.Write(" ");
            } else
            {
                Console.Write("(");
                Console.Write(value);
                Console.Write(")");
                Console.Write(" ");

            }
            if(clockwise.getValue() != 0)
            {
                clockwise.write(current);
            }
        }

        public void initiate(marble clockwiseIn, marble counterClockwiseIn, int valueIn)
        {
            setClockwise(clockwiseIn);
            setCounterClockwise(counterClockwiseIn);
            value = valueIn;
        }

        public int getValue()
        {
            return value;
        }

        public marble getClockwise()
        {
            return clockwise;
        }

        public marble getCounterClockwise()
        {
            return counterClockwise;
        }

        public void setClockwise(marble clockwiseIn)
        {
            clockwise = clockwiseIn;
        }

        public void setCounterClockwise(marble counterClockwiseIn)
        {
            counterClockwise = counterClockwiseIn;
        }

        public marble addNewAsCurrent(int valueIn)
        {
            marble newMarble = new marble();
            newMarble.initiate(clockwise.getClockwise(), clockwise, valueIn);
            clockwise.setClockwise(newMarble);
            return newMarble;
        }

        public marble remove(int time)
        {
            //Console.WriteLine();
           // Console.Write(value);
            if (time == 0)
            {
                clockwise.setCounterClockwise(counterClockwise);
                counterClockwise.setClockwise(clockwise);
                return this;
            }
            else
            {
                return counterClockwise.remove(time - 1);
            }
        }
    }

    class dec9
    {
        public static void Main()
        {
            int maxValue = 7184300;
            int nrPlayers = 468;
            long[] players = new long[nrPlayers];
            int playercounter = 0;
            marble current = new marble();
            marble zero = current;
            current.initiate(current, current, 0);
            current.getClockwise().setCounterClockwise(current);
            for(int i = 1; i <= maxValue; i++)
            {
                if(i % 23 != 0)
                {
                    current = current.addNewAsCurrent(i);
                    current.getClockwise().setCounterClockwise(current);
                } else
                {
                    players[playercounter] += i; //lägg till score till player
                    current = current.remove(7);
                    players[playercounter] += current.getValue();
                    current = current.getClockwise();
                }
                playercounter = (playercounter +1) % nrPlayers;
                //zero.write(current.getValue());
                //Console.WriteLine();
            }
            long answer1 = players[findMaxPlayer(players)];
            Console.Write("Svar1: ");
            Console.WriteLine(answer1);
        }

        static int findMaxPlayer(long[] players)
        {
            int leader = 0;
            for(int i = 0; i < players.Length; i++)
            {
                if(players[i] > players[leader])
                {
                    leader = i;
                }
            }
            return leader;
        }
    }
}