/*
 * Advent of Code 2018 
 * Day 3 Problem 1 
 * Nothing fancy, just uses an array to store how many times each cell is claimed from the input
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
            int[,] claimed = new int[1000, 1000]; //claimed will tally how many times a particular square is claimed
            Console.WriteLine(readClaims(inputPath, claimed));
            Console.ReadLine();

        }
        static int readClaims(string Path, int[,] claims)
        {
            string line;
            int total = 0; //total of inchs overlapped
            StreamReader sr = new StreamReader(Path);
            while (sr.Peek() >= 0) {
                line = sr.ReadLine();
                //#1 @ 258,327: 19x22
                
                //some messy splits to get the 4 useful coordinates
                string[]  parts = line.Split(' ');
                int startX = int.Parse(parts[2].Split(',')[0]);
                int startY = int.Parse(parts[2].Split(',')[1].Split(':')[0]);
                int runX = int.Parse(parts[3].Split('x')[0]);
                int runY = int.Parse(parts[3].Split('x')[1]);

                for(int i = 0; i < runX; i ++) { 
                    for(int j = 0; j < runY; j++) {
                        claims[startX + i, startY +j]++;
                        if (claims[startX + i,startY+ j] == 2) //only count the first time an overlap occurs
                            total++;
                    }
                }

            }
            return total;


        }

    }
}
