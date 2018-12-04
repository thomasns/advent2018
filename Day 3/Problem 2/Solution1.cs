/*
 * Advent of Code 2018 
 * Day 3 Problem 2 Solution 1
 * This was my first solution  to the second problem for the 2018 AoC
 * It uses basic rectangle colission to see if the coordinates overlap with any others
 * 
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
            Console.WriteLine(readClaims(inputPath));
            Console.ReadLine();

        }
        static int readClaims(string Path)
        {
            List <int[]> boxes = new List<int[]>(); //Boxes will be stored as int[4] inside a list
            string line;
            StreamReader sr = new StreamReader(Path);
            //Read all the boxes into the list
            while (sr.Peek() >= 0) {
                line = sr.ReadLine();
                //#1 @ 258,327: 19x22
                //splits to pull the coordinates
                string[] parts = line.Split(' ');
                int startX = int.Parse(parts[2].Split(',')[0]);
                int startY = int.Parse(parts[2].Split(',')[1].Split(':')[0]);
                int runX = int.Parse(parts[3].Split('x')[0]);
                int runY = int.Parse(parts[3].Split('x')[1]);
                int[] box = new int[4];
                box[0] = startX; //left most coordinate
                box[1] = startY; //top most coordinate
                box[2] = runX; //width
                box[3] = runY; //height

                boxes.Add(box);
            }

            //If ETSU choses to retroactivly give me an F in algorithms, I understand.
            //nested O(N^2) joy.
            for(int i = 0; i < boxes.Count; i++) { //for each box in the list
                bool col = false; //has a colision occured
                int Axmin, Axmax, Aymin, Aymax; //cordinates of box i
                int Bxmin, Bxmax, Bymin, Bymax; //coordinates of the box we're testing aginst
                Axmin = boxes[i][0]; //left coordinate
                Axmax = boxes[i][0] + boxes[i][2]; //right coordinate
                Aymin = boxes[i][1]; //top coordinate
                Aymax = boxes[i][1] + boxes[i][3]; //bottom coordinate

                for (int j = 0; j < boxes.Count; j++) { //for every other box
                    if (j == i) continue; //skip the box were using as A
                    //check overlap
                    Bxmin = boxes[j][0]; //Same system as above
                    Bxmax = boxes[j][0] + boxes[j][2];
                    Bymin = boxes[j][1];
                    Bymax = boxes[j][1] + boxes[j][3];

                    //check for colissions
                    for (int k = Bxmin; k < Bxmax; k++) {
                        if (k >= Axmin && k <= Axmax) { 
                        for (int l = Bymin; l < Bymax; l++) {
                                if (l >= Aymin && l <= Aymax) {
                                    col = true;
                                }
                            }
                        }
                    }
                }
                if(col == false)return i+1; //if we made it all the way through without a colision, this has to be it
                }
            return -1; //something has went very wrong
            }




    }
}
