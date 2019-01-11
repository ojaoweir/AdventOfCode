using System;

namespace dec8
{
    class node
    {
        static string input;
        static int counter = 5; //input börjar på tecken 5 efter att vi fått roots värden
        int nrChildren;
        int nrMetadata;
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

        void addChildren()
        {
            int h1;
            int h2;
            for (int i = 0; i < children.Length; i++)
            {
                h1 = 0;
                h2 = 0;
                //läs h1 och h2 från input med counter
                children[i] = new node(h1, h2);
            }

        }

        void addMetadata()
        {
            int m;
            for (int i = 0; i < metadata.Length; i++)
            {
                //läs m från input med counter
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
        }

        static node makeTree()
        {

            return new node(9, 11);
        }
    }
}

//input säger först header, antal barn och sedan metadata. Därefter säger den header på första barnet
// läs här https://www.reddit.com/r/adventofcode/comments/a4aik3/2018_day_8_part_1_what_does_this_mean/