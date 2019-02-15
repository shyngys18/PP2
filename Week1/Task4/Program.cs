using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // reading n
            for (int i = 1; i <= n; i++)
            { // iterarting over rows
                for (int j = 1; j <= i; j++)
                { // iterating over columns
                    Console.Write("[*]"); // printing a block
                }
                Console.WriteLine(); // moving to the next line(row) in console

            }
        }
    }
}
