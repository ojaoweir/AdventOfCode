using System;
using System.Collections;

namespace polymers
{
    class polymers
    {
        static void Main()
        {
            string[] inputs = System.IO.File.ReadAllLines(@"E:\Bibliotek\Prog\AdventOfCode\Dec5\input.txt");
            Stack cStack= new Stack();
            char c;
            foreach (string text in inputs)
            {
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
                        Console.Write(char.ToLower(c));
                        Console.WriteLine(char.ToLower(text[i]));
                        if (char.ToLower(c).Equals(char.ToLower(text[i])))
                        {
                            Console.WriteLine("is same");
                            if (c.Equals(text[i]))
                            {
                                Console.Write(c);
                                Console.Write(text[i]);
                                Console.WriteLine(" is saved");
                                cStack.Push(c);
                                cStack.Push(text[i]);
                            }
                            else
                            {
                                Console.Write(c);
                                Console.Write(text[i]);
                                Console.WriteLine(" is removed");
                                if(cStack.Count != 0)
                                {
                                    Console.WriteLine(cStack.Peek());

                                }
                            }
                        }
                        else
                        {
                            Console.Write(c);
                            Console.Write(text[i]);
                            Console.WriteLine(" is saved");
                            cStack.Push(c);
                            cStack.Push(text[i]);


                        }

                    }
                }
            }
            Console.Write("Svar1: ");
            Console.WriteLine(cStack.Count);
        }
    }
}