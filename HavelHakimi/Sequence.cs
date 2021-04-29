using System;
using System.Collections.Generic;
using System.Text;

namespace HavelHakimi
{
    class Sequence
    {
        private List<int> seq;

        public Sequence(int[] newseq)
        {
            seq = new List<int>(newseq);
        }

        public override string ToString()
        {
            string message = "[";

            foreach (int answer in seq)
            {
                message += answer.ToString() + ", ";
            }

            if (seq.Count == 0)
            {
                return message + "]";
            }
            else
            {
                // remove the trailing ', ' and return
                return message.Substring(0, message.Length - 2) + "]";
            }
        }

        /// <summary>
        /// Get the sequence as an array.
        /// </summary>
        /// <returns>int[] seq</returns>
        public int[] Get()
        {
            return seq.ToArray();
        }

        /// <summary>
        /// Loops until the sequence no longer contains any instances of 0.
        /// </summary>
        public void RemoveZeroes()
        {
            bool containsZero = true;

            while (containsZero)
            {
                containsZero = seq.Remove(0);
            }
        }

        /// <summary>
        /// Sorts the sequence in descending order.
        /// </summary>
        public void SortDescending()
        {
            Sorter s = new Sorter();
            seq.Sort(s);

            // reverse the order
            seq.Reverse();
        }

        /// <summary>
        /// Checks if the given number n is greater than the size of the sequence.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>true if n is greater than the size of the sequence, and false if n is less than or equal to the size of the sequence.</returns>
        public bool LengthCheck(int n)
        {
            if (n > seq.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Subtracts 1 from the first n answers in the sequence. Assumes n is greater than 0 and no greater than the size of the sequence.
        /// </summary>
        /// <param name="n"></param>
        public void FrontElimination(int n)
        {
            for (int i = 0; i < n; i++)
            {
                seq[i]--;
            }
        }

        public int RemoveFirst()
        {
            int first = seq[0];
            seq.RemoveAt(0);
            return first;
        }

        public bool IsEmpty()
        {
            if (seq.Count == 0)
            {
                return true;
            }
            return false;
        }
    }

    class Sorter : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

            return x.CompareTo(y);
        }
    }
}
