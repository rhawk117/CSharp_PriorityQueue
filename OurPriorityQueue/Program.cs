using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace OurPriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CTOR SIGNATURE => <TPriority, TValue>(int size = 100)

            // PriorityHelper.Part1();

            // var pQ = testCase();
            // edgeCases(pQ);



            var pQ = testCase();
            pQ.PrintTree();
            WriteLine("[ 31 to 30 => (false) since it's parent (8) is still less than 30 and no changes occur ]");
            WriteLine($"Result = {pQ.IncreasePriority(31, 30)}");
            ReadLine();
            WriteLine("Still works??");
            edgeCases(pQ);
        }

        static void edgeCases(OurPriorityQueue<int, int> pQ)
        {
            Dictionary<int, int> map = new Dictionary<int, int>
            {
                {31, 4 }, // true 
                {69, 1 }, // false, funny number isn't in it
                {17, 1 }, // true, 17s priority should be 1 & root 
                {26, 2 }, // true 
            };

            foreach (KeyValuePair<int, int> test in map)
            {
                var key = test.Key;
                var value = test.Value;
                WriteLine($"Changing the priority of {key} to {value}");
                pQ.PrintTree();
                WriteLine($"Result => {pQ.IncreasePriority(key, value)}");
                pQ.PrintTree();
                WriteLine("\nenter\n");
                ReadLine();
            }
        }

        // generating the example priority queue given in instructions
        static OurPriorityQueue<int, int> testCase()
        {
            OurPriorityQueue<int, int> pQ = new OurPriorityQueue<int, int>(20);
            int[] items = {
                8, 31, 10, 40, 45, 26, 17
            };

            for (int i = 0; i < items.Length; i++)
            {
                pQ.Add(items[i], items[i]);
            }

            return pQ;
        }







    }
}
