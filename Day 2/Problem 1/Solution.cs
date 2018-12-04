/*
 * Advent of Code 2018 
 * Day 2 Problem 1 
 * Forms a basic checksum from a list of strings 
 * Basically the product of the count of strings with atleast two duplicate characters and the count of strings with atleast 3 duplicate characters
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent3
{
    class Program
    {
        static void Main(string[] args)
        {
            int tripCount = 0;
            int dupeCount = 0;

            StreamReader sr = new StreamReader(@"C:\input2.txt");
            //Read the file sequentially, no need to store anything other than the counts
            while (sr.Peek() >= 0) {
                string line = sr.ReadLine();
                char[] ca = line.ToCharArray();
                bool dupeFound = false;
                bool tripFound = false;
                for (int i = 0; i < ca.Count(); i++) {
                    if (!dupeFound) {  //only count the first duplicate
                        if (count(ca[i], line) == 2) {
                            dupeFound = true;
                            dupeCount++;
                        }

                    }
                    if (!tripFound) { //only count the first triplicate
                        if (count(ca[i], line) == 3) {
                            tripFound = true;
                            tripCount++;
                        }

                    }
                }



            }
            Console.WriteLine(tripCount * dupeCount); //form and report the checksum
            Console.ReadLine();
        }

        /// <summary>
        /// Finds the count of a particular character in a string
        /// </summary>
        /// <param name="c">the character to search for</param>
        /// <param name="str">the string to search</param>
        /// <returns>The number of times c is found in str</returns>
        static int count(char c, string str)
        {
            char[] ca = str.ToCharArray();
            int times = 0;
            for (int i = 0; i < ca.Count(); i++) {
                if (ca[i] == c)
                    times++;
            }
            return times;
        }
    }
}