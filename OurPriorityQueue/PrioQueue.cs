using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurPriorityQueue
{
    /// <summary>
    /// A Priority Queue with a lower value having a higher priority
    /// </summary>
    /// <typeparam name="TPriority"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class OurPriorityQueue<TPriority, TValue>
        where TPriority : IComparable<TPriority>
    {
        /// <summary> Private class for each cell in the array /// </summary>
        private class Cell
        {
            public TValue Value { get; set; }
            /// <summary>
            /// The priority value for the data, it can be any data type as long as the type it comparable
            /// </summary>
            public TPriority Priority { get; set; }

            public Cell(TPriority aPriority = default, TValue aValue = default)
            {
                Priority = aPriority;
                Value = aValue;
            }
            public override string ToString() => $" {Priority} | {Value}";
        }

        /// <summary> The array where each cell is initially null /// </summary>
        private Cell[] table;

        /// <summary> Keeps track of the number of items /// </summary>
        private int count = 0;

        public OurPriorityQueue(int size = 100)
        {
            if (size < 10)
                size = 10;

            table = new Cell[size];
        }

        public bool IsEmpty() => (count == 0);

        public bool IsFull() => (count == table.Length - 1);

        public void Clear() => count = 0;

        /// <summary>
        /// Peek
        /// Returns the value stored by the root (does not remove) 
        /// </summary>
        /// <returns></returns>
        public TValue Peek()
        {
            if (IsEmpty() == true)
                throw new ApplicationException(
                    "Can't Peek an empty OurPriorityQueue");

            return table[1].Value;
        }

        /// <summary>
        /// Adds a new item using its priority to help place it in the array
        /// </summary>
        /// <param name="aPriority"></param>
        /// <param name="aValue"></param>
        public void Add(TPriority aPriority, TValue aValue)
        {
            if (IsFull()) return;

            // Percolate up
            int hole = ++count;
            for (; hole > 1 && aPriority.CompareTo(table[hole / 2].Priority) < 0; hole /= 2)
            {
                table[hole] = table[hole / 2];
            }
            table[hole] = new Cell(aPriority, aValue);
        }

        /// <summary>
        /// Remove and return the highest priority data
        /// </summary>
        /// <returns></returns>
        public TValue Remove()
        {
            if (IsEmpty() == true)
                throw new ApplicationException(
                    "Can't Remove from an empty OurPriorityQueue");

            // save the data for later
            TValue value = table[1].Value;

            // put the last item in the tree in the root
            table[1] = table[count--];

            // keep moving the lowest child up until we've found the right spot 
            // for the item moved from the last level to the root
            PercolateDown(1);

            return value;
        }

        /// <summary> Percolate Down:
        /// Reposition the hole down until it is 
        /// in the right spot for its priority
        /// </summary>
        /// <param name="hole"></param>
        /// 

        /// <summary>
        // Steps:
        // a. save the hole's cell in a tmp spot
        // b. keep going down the tree until the last level 
        // c. check the right and left child and put lowest one in the child variable
        // d. put lowest child in hole
        /// </summary>
        private void PercolateDown(int hole = 1)
        {
            int child;
            // a.
            Cell pTmp = table[hole];

            // b.
            for (; hole * 2 <= count; hole = child)
            {
                child = hole * 2;   // get right child
                TPriority leftChild = table[child].Priority;
                if (child != count && table[child + 1].Priority.CompareTo(leftChild) < 0)
                    child++;
                // d.
                if (table[child].Priority.CompareTo(pTmp.Priority) < 0)
                {
                    table[hole] = table[child];
                }
                else
                    break;
            }
            // found right spot of hole's original value, put it back into tree
            table[hole] = pTmp;
        }

        /// <summary>
        /// BuildHeap:
        /// Assumes all but last item in array is in correct order
        /// Shifts last item in array into correct location based on priority
        /// </summary>
        public void BuildHeap()
        {
            for (int i = count / 2; i > 0; i--)
            {
                PercolateDown(i);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= count; i++)
            {
                sb.Append(table[i].Value.ToString() + "|");
            }
            return sb.ToString();
        }

        // return string with contents of array in order (e.g. left child, parent, right child)
        public StringBuilder InOrder() => InOrder(1);
        private StringBuilder InOrder(int position)
        {
            StringBuilder str = new StringBuilder();
            if (position <= count)
            {
                str.Append(InOrder(position * 2) + "\t");
                str.Append(table[position].Value.ToString() + "\n ");
                str.Append(InOrder(position * 2 + 1) + "\t");
            }
            return str;
        }
        public void Print() => Console.WriteLine(InOrder());
    }
}



