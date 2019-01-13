using System;

namespace dec8
{
    class node
    {
        static string input;
        static int counter = 5; //input börjar på tecken 5 efter att vi fått roots värden
        int nrChildren;
        int nrMetadata;
        static int end;
        node[] children;
        int[] metadata;
        public node(int nrChildrenIn, int nrMetadataIn)
        {
            nrChildren = nrChildrenIn;
            nrMetadata = nrMetadataIn;
            children = new node[nrChildren];
            metadata = new int[nrMetadata];
            addChildren();
            addMetadata();
        }

        public int calcValue()
        {
            int value = 0;
            if(nrChildren == 0)
            {
                value = sumMetadata();
            } else
            {
                foreach(int m in metadata)
                {
                    if(m != 0 && m-1 < children.Length)
                    {
                        value += children[m - 1].calcValue();
                    }
                }
            }
            return value;
        }

        int sumMetadata()
        {
            int sum = 0;
            foreach (int m in metadata)
            {
                sum += m;
            }
            return sum;

        }

        public int calcTreeSum()
        {
            int sum = 0;
            foreach(node n in children)
            {
                sum += n.calcTreeSum();
            }
            sum += sumMetadata();
            return sum;
        }

        void addChildren()
        {
            int h1;
            int h2;
            int end;
            for (int i = 0; i < children.Length; i++)
            {
                end = findSpace(counter);
                h1 = Int32.Parse(input.Substring(counter,end -counter));
                counter = end+1;
                end = findSpace(counter);
                h2 = Int32.Parse(input.Substring(counter, end-counter));
                counter = end+1;
                //läs h1 och h2 från input med counter
                children[i] = new node(h1, h2);
            }

        }

        int findSpace(int counter)
        {
            for(int i = counter + 1; i < input.Length; i++)
            {
                if(input[i].Equals(' '))
                {
                    return i;
                }
            }
            return input.Length -1;
        }

        void addMetadata()
        {
            int m;
            for (int i = 0; i < metadata.Length; i++)
            {
                end = findSpace(counter);
                m = Int32.Parse(input.Substring(counter, end - counter));
                counter = end + 1;
                metadata[i] = m;
            }

        }

        public static void setInput(string inputIn)
        {
            input = inputIn;
        }
    }

    class makeLikeATree
    {
        public static void Main()
        {
            node.setInput(System.IO.File.ReadAllText(@"E:\Bibliotek\Prog\AdventOfCode\Dec8\input.txt"));
            node root = makeTree();
            int answer1 = root.calcTreeSum();
            Console.Write("Svar1: ");
            Console.WriteLine(answer1);
            int answer2 = root.calcValue();
            Console.Write("Svar2: ");
            Console.WriteLine(answer2);

        }

        static node makeTree()
        {

            return new node(9, 11);
        }
    }
}

//input säger först header, antal barn och sedan metadata. Därefter säger den header på första barnet
// läs här https://www.reddit.com/r/adventofcode/comments/a4aik3/2018_day_8_part_1_what_does_this_mean/