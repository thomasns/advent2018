/*
 * Advent of Code 2018 
 * Day 2 Problem 2 
 * The goal here is to find two strings from the input that differ by only one character,
 * Then return the string formed by removing that one.
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
            List<string> strs = new List<string>(); //The list that will contain all the strings
            
            //We only compare the strings to ones already read in, rather than reading them all in first. 
            //Still O(N^2) but kinda nicer
            StreamReader sr = new StreamReader(@"C:\input2.txt");
            while (sr.Peek() >= 0) {
               string line = sr.ReadLine(); 
                for(int i = 0; i < strs.Count(); i++) { //compare aginst all the strings already read
                    int dc = diffcount(line, strs[i]); //heper function to cound the differences between strings
                    if(dc == 1) { //input specifies only one pair with a single difference this is it
                        Console.WriteLine(remdiff(line, strs[i])); //print the string without the different character
                        Console.ReadLine();
                    }
                }
                    strs.Add(line); //after checking aginst all the other strings, add this one to the list
                }


               

            Console.ReadLine();
        }

        /// <summary>
        /// Finds the number of different characters between two strings
        /// </summary>
        /// <param name="a">String a</param>
        /// <param name="b">String b</param>
        /// <returns>Either 0, 1 or 2, for speed sake if 2 is hit, we terminate early</returns>
        static int diffcount(string a, string b)
        {
            char[] ca = a.ToCharArray();
            char[] cb = b.ToCharArray(); //char arrays make more sense at midnight

            int count = 0; 
            for (int i = 0; i < a.Count(); i++) {
                if (ca[i] != cb[i]) {
                    count++;
                    if (count > 1)
                        return 2; //We're looking specfically for one with just 1 difference, don't waste time looking for more
                }
            }
            return count;
        }

        /// <summary>
        /// Forms a string of the identical characters from two strings
        /// </summary>
        /// <param name="a">String a</param>
        /// <param name="b">String b</param>
        /// <returns>A string. if input was AABA and ABBA would return ABA</returns>
        static string remdiff(string a, string b)
        {
            char[] ca = a.ToCharArray();
            char[] cb = b.ToCharArray();

            //pretty simple, iterate over each character, if they're the same, add to the output, otherwise, skip
            string strOut = "";
            for(int i = 0; i < ca.Count(); i++) {
                if (ca[i] == cb[i])
                    strOut += ca[i];
                    
            }
            return strOut;
        }
    }
}
