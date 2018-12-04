/*
 * Advent of Code 2018 
 * Day 3 Problem 2 Solution 2
 * 
 * A few minutes after finally getting the correct answer to the second solution, 
 * I realized I had completly dropped the ball, I could have recycled most of Solution 1 and saved time. 
 * With my particular input, this ran in about 1/4th the time of my first attempt
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AdventD3
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputPath = @"C:\input3.txt";
            int[,] claimed = new int[1000, 1000];
            readClaims(inputPath, claimed);
            Console.ReadLine();

        }
        static void readClaims(string Path, int[,] claims)
        {
            string line;
            StreamReader sr = new StreamReader(Path);

            //Same setup as the problem 1 solution, but we don't need to keep track with the total overlaps
            while (sr.Peek() >= 0) {
                line = sr.ReadLine();
                //#1 @ 258,327: 19x22
                string[] parts = line.Split(' ');
                int startX = int.Parse(parts[2].Split(',')[0]);
                int startY = int.Parse(parts[2].Split(',')[1].Split(':')[0]);
                int runX = int.Parse(parts[3].Split('x')[0]);
                int runY = int.Parse(parts[3].Split('x')[1]);
                for (int i = 0; i < runX; i++) {
                    for (int j = 0; j < runY; j++) {
                        claims[startX + i, startY + j]++;
                    }
                }

            }
            sr.Close();
            sr = new StreamReader(Path); //reopen the input 

            //So this should be a O(N) with a much smaller O(N^2) inside. Yay
            while (sr.Peek() >= 0) {
                line = sr.ReadLine();
                //#1 @ 258,327: 19x22
                bool overlap = false;
                
                //break the line into useable coordinates
                string[] parts = line.Split(' ');
                int startX = int.Parse(parts[2].Split(',')[0]);
                int startY = int.Parse(parts[2].Split(',')[1].Split(':')[0]);
                int runX = int.Parse(parts[3].Split('x')[0]);
                int runY = int.Parse(parts[3].Split('x')[1]);
                //We already have a array of how many times a certain cell is claimed, 
                //so just go cell by cell, if they're all 1 that means this box is the only one claiming them. 
                //Stop as soon as we find one > 1
                for (int i = 0; i < runX; i++) {
                    for (int j = 0; j < runY; j++) {
                        if (claims[startX + i, startY + j] != 1) {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap) break;
                    if (overlap == false && i == runX-1) Console.WriteLine(line); //Report output here
                }

            }

        }
    }
}
