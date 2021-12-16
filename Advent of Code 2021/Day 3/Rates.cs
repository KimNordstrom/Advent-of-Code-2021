using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code_2021.Day_3
{
    public class Rates
    {
        List<string> binStrings = new List<string>();
        List<string> leatlist = new List<string>();
        public int[,] binary = new int[2, 12];
        public int[] most = new int[12];
        public int[] least = new int[12];
        public void ReadFile()
        {
            var path = @"C:\Users\K_Nor\Documents\GitHub\Advent-of-Code-2021\Advent of Code 2021\Day 3\Binarys.txt";
            FileStream fs = File.OpenRead(path);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    binStrings.Add(sr.ReadLine());
                }
            }
        }
        public void DynamicMostLeast()
        {
            leatlist = binStrings;
            for (int i = 0; i < 12; i++)
            {
                binary[0, i] = 0;
                binary[1, i] = 0;
                if (binStrings.Count > 1)
                {
                    for (int j = 0; j < binStrings.Count; j++)
                    {
                        if (binStrings[j][i] == '0')
                        {
                            binary[0, i] += 1;
                        }
                        else if (binStrings[j][i] == '1')
                        {
                            binary[1, i] += 1;
                        }
                    }
                    if (binary[0, i] > binary[1, i])
                    {
                        binStrings = binStrings.FindAll(x => x[i] == '0');
                    }
                    else
                    {
                        binStrings = binStrings.FindAll(x => x[i] == '1');
                    }
                }
                binary[0, i] = 0;
                binary[1, i] = 0;
                if (leatlist.Count > 1)
                {

                    for (int j = 0; j < leatlist.Count; j++)
                    {
                        if (leatlist[j][i] == '0')
                        {
                            binary[0, i] += 1;
                        }
                        else if (leatlist[j][i] == '1')
                        {
                            binary[1, i] += 1;
                        }
                    }
                    if (binary[0, i] <= binary[1, i])
                    {
                        leatlist = leatlist.FindAll(x => x[i] == '0');
                    }
                    else
                    {
                        leatlist = leatlist.FindAll(x => x[i] == '1');
                    }
                }
            }
        }
        public void CountMostLeast()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < binStrings.Count; j++)
                {
                    if (binStrings[j][i] == '0')
                    {
                        binary[0, i] += 1;
                    }
                    else if (binStrings[j][i] == '1')
                    {
                        binary[1, i] += 1;
                    }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (binary[0, i] > binary[1, i])
                {
                    most[i] = 0;
                    least[i] = 1;
                }
                else
                {
                    most[i] = 1;
                    least[i] = 0;
                }
            }
        }
        public void PrintResults()
        {
            double gamma = 0;
            double epsilon = 0;
            double oxygen = 0;
            double scrubber = 0;
            int value = 2048;
            for (int i = 0; i < 12; i++)
            {
                gamma += most[i] * value;
                epsilon += least[i] * value;
                value /= 2;
            }
            oxygen = Convert.ToInt32(binStrings[0], 2);
            scrubber = Convert.ToInt32(leatlist[0], 2);
            Console.WriteLine("Gamma: " + gamma);
            Console.WriteLine("Epsilon: " + epsilon);
            Console.WriteLine("Power consumption: " + (gamma * epsilon));
            Console.WriteLine("Oxygen: " + oxygen);
            Console.WriteLine("Scrubber: " + scrubber);
            Console.WriteLine("Life support rating: " + (oxygen * scrubber));

        }
    }
}
