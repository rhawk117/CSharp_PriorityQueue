using System;
using System.Collections.Generic;
using static System.Console;


namespace OurPriorityQueue
{
    public static class PriorityHelper
    {
        // returns the example we did in class 
        public static OurPriorityQueue<int, int> InClassExample()
        {
            OurPriorityQueue<int, int> pQ = new OurPriorityQueue<int, int>(20);
            pQ.Add(5, 5);
            pQ.Add(12, 12);
            pQ.Add(9, 9);
            pQ.Add(14, 14);
            pQ.Add(20, 20);
            pQ.Add(52, 52);
            pQ.Add(11, 11);
            pQ.Add(55, 55);
            pQ.Add(50, 50);
            pQ.Add(23, 23);
            pQ.Add(40, 40);
            pQ.Add(19, 19);
            return pQ;
        }
        public static void fullView(OurPriorityQueue<int, int> pQ)
        {
            WriteLine(pQ); // by arr order 
            pQ.PrintTree(); // tree view
        }

        // insanely useful for visualization 
        public static void PQViewer(OurPriorityQueue<int, int> pQ)
        {
            if (pQ.IsEmpty())
            {
                WriteLine("The Priority Queue is empty...");
                return;
            }

            while (true)
            {
                WriteLine(@"
                [ Press the corresponding key to display the Queue ]
                    [ or 'q' or 'esc' to exit ]
                        
                        [ Options ]
                    a). Array View - View PQ 'table' array
                    o). 'In Order' View - View PQ in Order
                    t). Tree View - PQ as a Tree
                    q). exit / go back
                ");
                ConsoleKeyInfo input = ReadKey();
                Clear();
                if (input.KeyChar != 'q')
                {
                    WriteLine($"| Count => {pQ.Count} |");
                    handleKeys(pQ, input);
                }
                else
                {
                    break;
                }
            }

        }
        private static void handleKeys(OurPriorityQueue<int, int> pQ, ConsoleKeyInfo input)
        {
            if (input.KeyChar == 'a')
            {
                WriteLine(pQ);
            }
            else if (input.KeyChar == 'o')
            {
                pQ.Print();
            }
            else if (input.KeyChar == 't')
            {
                pQ.PrintTree();
            }
            WriteLine("[ Press enter to continue ]");
            ReadLine();
        }

        // part 1 of HW9
        private static OurPriorityQueue<int, int> Part1a()
        {
            // Inserting 85, 25, 41, and 29.
            OurPriorityQueue<int, int> PriorQ = new OurPriorityQueue<int, int>(20);
            PriorQ.Add(85, 85);

            WriteLine("Insert => 25");
            PriorQ.Add(25, 25);
            fullView(PriorQ);

            ReadLine();
            WriteLine("Insert => 41");

            PriorQ.Add(41, 41);
            fullView(PriorQ);
            ReadLine();

            WriteLine("Insert => 29");
            PriorQ.Add(29, 29);
            WriteLine(PriorQ);
            ReadLine();
            WriteLine("A. => B.");

            return PriorQ;
        }

        private static OurPriorityQueue<int, int> Part1b(OurPriorityQueue<int, int> PriorQ)
        {
            // Then Insert => 28, 16
            ReadLine();
            PriorQ.Add(28, 28);
            fullView(PriorQ);
            ReadLine();

            PriorQ.Add(16, 16);
            fullView(PriorQ);
            ReadLine();

            WriteLine("B. => C.");
            return PriorQ;

        }

        private static void Part1c(OurPriorityQueue<int, int> PriorQ)
        {
            // Then do a remove
            ReadLine();
            WriteLine("Pre-Remove");
            fullView(PriorQ);

            PriorQ.Remove();

            WriteLine("Post-Remove");
            fullView(PriorQ);
        }

        // bruh this is so extra (rank 2 things)
        public static void Part1()
        {
            var pQ = Part1a();
            pQ = Part1b(pQ);
            Part1c(pQ);
        }



    }
}
