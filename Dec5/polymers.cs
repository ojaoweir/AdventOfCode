using System;
using System.Collections;

namespace polymers
{
    class polymers
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"E:\Bibliotek\Prog\AdventOfCode\Dec5\input.txt");
            int answerA  = doPartA(text);
            Console.Write("Svar1: ");
            Console.WriteLine(answerA);
            doPartB();

        }

        static int doPartA(string text)
        {
            Stack cStack = new Stack();
            char c;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(' '))
                {
                    break;
                }
                if (cStack.Count == 0)
                {
                    cStack.Push(text[i]);
                }
                else
                {
                    c = (char)cStack.Pop();
                    if (char.ToLower(c).Equals(char.ToLower(text[i])))
                    {
                        if (c.Equals(text[i]))
                        {
                            cStack.Push(c);
                            cStack.Push(text[i]);
                        }
                    }
                    else
                    {
                        cStack.Push(c);
                        cStack.Push(text[i]);


                    }

                }
            }
            char[] cArr2 = new char[cStack.Count];
            for (int j = cStack.Count - 1; j >= 0; j--)
            {
                cArr2[j] = (char)cStack.Pop();
            }
            string text2 = new string(cArr2);
            //Console.WriteLine(text2);
            return text2.Length;
        }

        static void doPartB()
        {
            string cArr = System.IO.File.ReadAllText(@"E:\Bibliotek\Prog\AdventOfCode\Dec5\input.txt");
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int[] lengths = new int[alphabet.Length];
            int[] occurance = new int[alphabet.Length];
            char[] cArr2;
            Stack cStack = new Stack();
            for(int i = 0; i < alphabet.Length; i++)
            {
                cStack = countOut2(cArr, alphabet[i]);
                cArr2 = new char[cStack.Count];
                for (int j = cStack.Count - 1; j >= 0; j--)
                {
                    cArr2[j] = (char)cStack.Pop();
                }
                string text = new string(cArr2);
                //Console.WriteLine(text);
                lengths[i] = doPartA(text);
            }
            Console.Write("Svar2: ");
            Console.Write(findMin(lengths));
            
        }


        static int findMin(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                /*Console.Write(arr[index]);
                Console.Write(": ");
                Console.Write(arr[i]);*/
                if (arr[i] < arr[index])
                {
                    index = i;
                }
                //Console.WriteLine();
            }
            return arr[index];
        }

        static Stack countOut2(string cArr, char letter)
        {
            Stack cStack = new Stack();
            int counter = 0;
            foreach (char c in cArr)
            {
                if (!char.ToLower(c).Equals(letter))
                {
                    cStack.Push(c);
                }
            }
            return cStack;
        }

        static int countOut(char[] cArr, char letter)
        {
            int counter = 0;
            foreach(char c in cArr)
            {
                if (!char.ToLower(c).Equals(letter))
                {
                    //Console.Write(": ");
                    //Console.Write("not remove");
                    counter++;
                }
               // Console.WriteLine();
            }
            return counter;
        }
        
        static int findMax(int[] arr)
        {
            int index = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                /*Console.Write(arr[index]);
                Console.Write(": ");
                Console.Write(arr[i]);*/
                if(arr[i] > arr[index])
                {
                    index = i;
                }
                //Console.WriteLine();
            }
            return index;
        }

        static int findIndexOf(char c, string alphabet)
        {
            for(int i = 0; i < alphabet.Length; i++)
            {
                Console.Write(c);
                Console.Write(": ");
                Console.Write(alphabet[i]);
                Console.WriteLine();
                if (char.ToLower(c).Equals(alphabet[i]))
                {
                    Console.Write("true");
                    Console.WriteLine();
                    return i;
                }
            }
            return 60606060;
        }

    }
}