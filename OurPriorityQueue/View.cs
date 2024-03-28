using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace OurPriorityQueue
{
    public class View
    {
        private OurPriorityQueue<int, int> queue;

        public View(OurPriorityQueue<int, int> queue)
        {
            this.queue = queue;
        }

        private void add(int val) => queue.Add(val, val);

        public void Add()
        {
            WriteLine($"[ Current PQ Size = {queue.Count}]");
            WriteLine("[ Enter an integer to add or 'q' to go back ]");
            string input = ReadLine(); int val;
            if (input == "q")
            {
                return;
            }
            else if (!int.TryParse(input, out val))
            {
                WriteLine("[ Specify an integer value or enter 'q' to go back. ]");
                Add();
            }
            WriteLine($"[ Adding => {val} ]");
            add(val);
            viewChanges();
            enterToContinue();
        }

        private void viewChanges()
        {
            WriteLine("[ RESULT ]\n");
            WriteLine($"*** Table *** \n{queue}\n*** Tree View *** \n");
            queue.PrintTree();
        }
        private void enterToContinue() { WriteLine("[ Press enter to continue ]"); ReadLine(); }

        private void remove() => queue.Remove();

        public void Remove()
        {
            if (queue.Count > 0)
            {
                WriteLine($"[ Removing first item in Queue ({queue.Peek()})]");
                remove();
                viewChanges();
                enterToContinue();
            }
        }

        public void Views()
        {
            if (queue.IsEmpty())
            {
                WriteLine("[ Queue is empty nothing to view ]");
            }
            bool active = true;
            while (active)
            {
                WriteLine(@"
                [ Press the corresponding key to display the Queue ]
                    [ or 'q' or 'esc' to exit ]
                        
                        [ Options ]
                    a). Array View - View PQ 'table' array
                    o). 'In Order' View - View PQ in Order
                    t). Tree View - PQ as a Tree
                
                ");
                char input = ReadKey().KeyChar;

                if (input != 'q')
                {
                    hndleViews(input);
                }
                else
                {
                    active = false;
                }
            }
        }

        public void hndleViews(char k)
        {
            switch (k)
            {
                case 'a':
                    WriteLine(queue);
                    break;

                case 'o':
                    queue.Print();
                    break;

                case 't':
                    queue.PrintTree();
                    break;
            }
            enterToContinue();


        }
        public void MainMenu()
        {
            WriteLine(@"
                 [ Enter the corresponding key with desired action ]
                
                    a. Add
                    r. Remove
                    v. View 
                    q. quit
                ");

            char input = ReadKey().KeyChar;

            if (input != 'q') hndleMenu(input);
        }
        private void hndleMenu(char k)
        {
            switch (k)
            {
                case 'r':
                    Remove();
                    break;
                case 'a':
                    Add();
                    break;
                case 'v':
                    Views();
                    break;
            }
            MainMenu();
        }





    }
}
