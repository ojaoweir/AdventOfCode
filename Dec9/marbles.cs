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
            clockwise.setClockwise() = newMarble;
            return newMarble;
        }
    }

    class dec9
    {
        public static void Main()
        {
            int maxValue = 71843;
            int nrPlayers = 468;
            int players = new int[nrPlayers];
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
                    //lägg till score till player
                }
            }
        }
    }
}