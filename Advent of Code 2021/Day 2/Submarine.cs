using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2021.Day_2
{
     public class Submarine
    {
        int PositionX = 0;
        int PositionY = 0;
        int Aim = 0;

        public void ChangeCommands()
        {
            var path = @"C:\Users\K_Nor\source\repos\Advent-of-Code-2021\Advent of Code 2021\Day 2\Commands.txt";
            FileStream fs = File.OpenRead(path);
            using(StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    var commands = sr.ReadLine().Split(" ");
                    int units = Convert.ToInt32(commands[1]);
                    switch (commands[0])
                    {
                        case "forward":
                            PositionX += units;
                            PositionY += units * Aim;
                            break;
                        case "down":
                            Aim += units;
                            break;
                        case "up":
                            Aim -= units;
                            break;
                    }
                }
            }
            Console.WriteLine("X:" + PositionX + " Y: " + PositionY + " Aim:" + Aim);
            Console.WriteLine("Multiplied: " + (PositionX * PositionY));
        }
        
    }
}
