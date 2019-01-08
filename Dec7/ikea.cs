using System;
using System.Collections.Generic;

namespace dec7
{
    class step
    {
        List<step> pred;
        List<step> succ;
        char c;
        bool pushed;
        public step(char cIn)
        {
            pred = new List<step>();
            c = cIn;
            succ = new List<step>();
            pushed = false;
        }

        public void push()
        {
            pushed = true;
        }

        public bool getPushed()
        {
            return pushed;
        }

        public void addSucc(step succIn)
        {
            succ.Add(succIn);
        }

        public List<step> getSucc()
        {
            return succ;
        }

        public void addPred(step predIn)
        {
            pred.Add(predIn);
        }

        public List<step> getPred()
        {
            return pred;
        }

        public char getC()
        {
            return c;
        }

        public void sortSucc()
        {
            succ.Sort(compareSteps);
        }

        public void sortPred()
        {
            pred.Sort(compareSteps);
            pred.Reverse();
        }

        private static int compareSteps(step left, step right)
        {
            return left.getC().CompareTo(right.getC());
        }
    }
    class ikea
    {
        static void Main()
        {
            //ta in indata som array av par [a,b] ==> a krävs för b
            char[,] input = getInput();
            //spara varje steg som en char med referenser fram och bak.
            //lägg in de i random ordning
            //en referens start
            //sista blir null
            //sortera enligt input glöm inte att de ska vara i alfabetsordning!
            step root = makeTree(input);
            //Denna nedan som inte funkar som den ska
            printOrder(root);
        }

        static void printPred(step root)
        {
            Console.Write(root.getC());
            Console.Write(": ");
            foreach(step s in root.getPred())
            {
                Console.Write(s.getC());
            }
            Console.WriteLine();
            foreach (step s in root.getPred())
            {
                printPred(s);
            }
        }

        static void printOrder(step root)
        {
            List<step> order = new List<step>();
            root.push();
            Stack<step> orderStack = makeOrder(root, order);
            while(orderStack.Count != 0)
            {
                Console.Write(orderStack.Pop().getC());
            }
            Console.Write(root.getC());
        }

        static Stack<step> makeOrder(step root, List<step> order)
        {
            foreach (step s in root.getPred())
            {
                if (!s.getPushed())
                {
                    order.Add(s);
                    s.push();
                    Console.Write(s.getC());
                    Console.WriteLine(" added");
                }
            }
            if(order.Count != 0)
            {
                order.Sort(compareSteps);
                step top = order[0];
                Console.Write(top.getC());
                Console.WriteLine(" pushed");
                order.Remove(top);
                Stack<step> orderStack = makeOrder(top, order);
                orderStack.Push(top);
                return orderStack;
            }
            return new Stack<step>();
        }
        private static int compareSteps(step left, step right)
        {
            return left.getC().CompareTo(right.getC());
        }

        static void printSucc(step inStep)
        {
            foreach(step s in inStep.getSucc())
            {
                Console.Write(s.getC());
            }
            foreach (step s in inStep.getSucc())
            {
                printSucc(s);
            }
        }

        static step makeTree(char [,] input)
        {
            List<char> allStepChars = addAllStepChars(input);
            step[] allSteps = addAllSteps(allStepChars);
            step root = sortSteps(allSteps, input);
            return root;
        }

        static step sortSteps(step[] steps, char[,] input)
        {
            step pred;
            step succ;
            step root;
            for(int i = 0; i < input.GetLength(0); i++)
            {
                pred = find(steps, input[i, 0]);
                succ = find(steps, input[i, 1]);
                pred.addSucc(succ);
                succ.addPred(pred);
            }

            foreach(step s in steps)
            {
                s.sortPred();
            }
            root = findLastStep(steps);
            return root;
        }

        static step findLastStep(step[] steps)
        {
            foreach(step s in steps)
            {
                if(s.getSucc().Count == 0)
                {
                    return s;
                }
            }
            return steps[0];
        }

        static step find(step[] steps, char c)
        {
            foreach(step s in steps)
            {
                if(s.getC().Equals(c))
                {
                    return s;
                }
            }
            return steps[0];
        }

        static step[] addAllSteps(List<char> allStepChars)
        {
            step[] steps = new step[allStepChars.Count];
            for(int i = 0; i< steps.Length; i++)
            {
                steps[i] = new step(allStepChars[i]);
            }
            return steps;
        }

        static List<char> addAllStepChars(char[,] input)
        {
            List<char> allStepChars = new List<char>();
            foreach (char c in input)
            {
                if (!allStepChars.Contains(c))
                {
                    allStepChars.Add(c);
                }
            }
            return allStepChars;

        }

        static char[,] getInput()
        {
            string[] inputs = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec7\input.txt");
            char[,] input = new char[inputs.Length, 2]; //första termen är vilket par i arrayen, andra termen är position i paret

            for (int i = 0; i < inputs.Length; i++)
            {
                input[i, 0] = inputs[i][5];
                input[i, 1] = inputs[i][36];
            }

            return input;
        }
    }
}