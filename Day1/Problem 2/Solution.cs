/*
 * Advent of Code 2018 
 * Day 1 Problem 2 
 * Given a list of positive and negative numbers, sequentialy add them, and find the first result that occurs twice 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> results = new List<int>(); //Stores all the results found so far
            List<int> additions = new List<int>(); //Stores each value from the input to add to the list

            int total = 0; //current result
            StreamReader sr = new StreamReader(@"C:\input.txt");

            //only read the list once, store each value as the next node in a linked list
            //also runs the first cycle of additions
            while (sr.Peek() >= 0) {
                int b; 
                b = int.Parse(sr.ReadLine()); //convert string to int
                total += b;
                additions.Add(b);
                if (results.Contains(total)) { //check for a duplicate
                    Console.WriteLine("Dupe found at: " + total);
                    break;
                }
                results.Add(total);
            }

            //loop through the list until we find a duplicate
            bool found = false;
            while(found != true) {
                for(int i = 0; i < additions.Count;i++) {
                    total += additions[i];
                    if (results.Contains(total)) {
                        Console.WriteLine("Dupe found at: " + total);
                        Console.ReadLine();
                        found = true;
                        break;
                    }
                results.Add(total);
                }

            }


        }
    }
}
