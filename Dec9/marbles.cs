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

        public int remove(int time)
        {
            if (time == 0)
            {
                clockwise.setCounterClockwise(counterClockwise);
                counterClockwise.setClockwise(clockwise);
                return value;
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
            int maxValue = 1618;
            int nrPlayers = 10;
            int[] players = new int[nrPlayers];
            int playercounter = 0;
            marble current = new marble();
            current.initiate(current, current, 0);
            for(int i = 1; i <= maxValue; i++)
            {
                if(i % 23 != 0)
                {
                    current = current.addNewAsCurrent(i);
                } else
                {
                    players[playercounter] += i; //lägg till score till player
                    players[playercounter] += current.remove(7);
                }
                playercounter = (playercounter +1) % nrPlayers;
                Console.WriteLine(playercounter);
            }
            int answer1 = players[findMaxPlayer(players)];
            Console.Write("Svar1: ");
            Console.WriteLine(answer1);
        }

        static int findMaxPlayer(int[] players)
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