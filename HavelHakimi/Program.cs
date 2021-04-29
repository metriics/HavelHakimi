using System;
using System.Collections.Generic;

namespace HavelHakimi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] sequences =
            {
                new int[]{ 5, 3, 0, 2, 6, 2, 0, 7, 2, 5 },
                new int[]{ 4, 2, 0, 1, 5, 0 },
                new int[]{ 3, 1, 2, 3, 1, 0 },
                new int[]{ 16, 9, 9, 15, 9, 7, 9, 11, 17, 11, 4, 9, 12, 14, 14, 12, 17, 0, 3, 16 }, // this breaks the code
                new int[]{ 14, 10, 17, 13, 4, 8, 6, 7, 13, 13, 17, 18, 8, 17, 2, 14, 6, 4, 7, 12 }, // this breaks the code
                new int[]{ 15, 18, 6, 13, 12, 4, 4, 14, 1, 6, 18, 2, 6, 16, 0, 9, 10, 7, 12, 3 },
                new int[]{ 6, 0, 10, 10, 10, 5, 8, 3, 0, 14, 16, 2, 13, 1, 2, 13, 6, 15, 5, 1 },
                new int[]{ 2, 2, 0 },
                new int[]{ 3, 2, 1 },
                new int[]{ 1, 1 },
                new int[]{ 1 },
                new int[]{ }
            };

            for (int i = 0; i < sequences.Length; i++)
            {
                Sequence currentSequence = new Sequence(sequences[i]);
                Console.WriteLine(currentSequence.ToString() + $" => {HavelHakimi(currentSequence)}");
            }
        }

        public static bool HavelHakimi(Sequence seq)
        {
            // Havel-Hakimi algorithm
            seq.RemoveZeroes();

            // make sure the sequence is not empty
            if (seq.IsEmpty())
            {
                return true;
            }

            // sort the sequence in descending order
            seq.SortDescending();

            // remove first answer from seqeunce
            int n = seq.RemoveFirst();

            // make sure n is not greater than the new length of the sequence
            if (seq.LengthCheck(n))
            {
                return false;
            }

            // subtract 1 from the first n elements
            seq.FrontElimination(n);

            // recursion! :0 
            return HavelHakimi(seq);
        }
    }
}
