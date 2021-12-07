using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_1
{
    public class Scanner
    {
        public void Scan()
        {
            var path = @"C:\Users\K_Nor\source\repos\Advent of Code 2021\Advent of Code 2021\Day 1\Scans.txt";
            List<int> scans = new List<int>();
            FileStream fs = File.OpenRead(path);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    var incoming = Convert.ToInt32(sr.ReadLine());
                    scans.Add(incoming);
                }
            }
            
            Console.WriteLine("Times increased: " + InscreaseDecrease(scans));

            List<int> threescans = new List<int>();

            for (int i = 0; i < scans.Count-2; i++)
            {
                threescans.Add(scans[i] + scans[i + 1] + scans[i + 2]);
            }

            Console.WriteLine("Times increased: " + InscreaseDecrease(threescans));

        }
        public int InscreaseDecrease(List<int> scans)
        {
            int previous = 0;
            int increasecounter = 0;
            foreach (int scan in scans)
            {
                if (previous == 0)
                {
                    //Console.WriteLine(scan + "(N/A)");
                    previous = scan;
                }
                else
                {
                    if (scan > previous)
                    {
                        //Console.WriteLine(scan + "(Increase)");
                        previous = scan;
                        increasecounter++;
                    }
                    else if(scan < previous)
                    {
                        //Console.WriteLine(scan + "(Decrease)");
                        previous = scan;
                    }
                    else
                    {
                        //Console.WriteLine(scan + "(No change)");
                        previous = scan;
                    }
                }
            }
            return increasecounter;
        }
    }
}
