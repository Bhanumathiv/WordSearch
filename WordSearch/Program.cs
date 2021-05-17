using System;
using System.Data;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
           {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[]
        {

            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };
        static Boolean checkBoundaries(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Grid.GetLength(0) || j >= Grid.GetLength(1))
                return false;
            else
                return true;
        }

        private static void findMatch(int k, int l, int kDiff, int lDiff, string curWord)
        {
            string compareString = "";
            int a = k; int b = l;
            for (int i = 0; i < curWord.Length; i++)
            {
                if (checkBoundaries(a, b) && Grid[a, b] == curWord[i])
                {
                    compareString += curWord[i];
                    a += kDiff;
                    b += lDiff;
                }
                if (!curWord.StartsWith(compareString))
                    return;
            }
            if (curWord == compareString)
                Console.WriteLine("Match found for " + curWord + ". Starts at [" + l + ", " + k + "] and Ends at [" + (b - lDiff) + "," + (a - kDiff) + "]");

        }

        private static void FindWords()
        {

            for (int i = 0; i < Words.Length; i++)
            {
                string curWord = Words[i];



                for (int k = 0; k < Grid.GetLength(0); k++)
                {
                    for (int l = 0; l < Grid.GetLength(1); l++)
                    {
                        if (curWord[0] == Grid[k, l])
                        {
                            int kDiff = 0;
                            int lDiff = 0;
                            if (checkBoundaries(k + 1, l))
                            {
                                kDiff = 1;
                                lDiff = 0;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k - 1, l))
                            {
                                kDiff = -1;
                                lDiff = 0;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k, l + 1))
                            {
                                kDiff = 0; lDiff = 1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k, l - 1))
                            {
                                kDiff = 0; lDiff = -1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k + 1, l + 1))
                            {
                                kDiff = 1;
                                lDiff = 1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k - 1, l - 1))
                            {
                                kDiff = -1;
                                lDiff = -1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k + 1, l - 1))
                            {
                                kDiff = 1;
                                lDiff = -1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                            if (checkBoundaries(k - 1, l + 1))
                            {
                                kDiff = -1;
                                lDiff = 1;
                                findMatch(k, l, kDiff, lDiff, curWord);
                            }
                        }
                    }
                }


                //Find each of the words in the grid, outputting the start and end location of
                //each word, e.g.
                //PUPPY found at (10,7) to (10, 3) 
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Word Search");

            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }


            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

       


    }
}


