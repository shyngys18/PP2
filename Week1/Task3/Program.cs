using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// reading the array size
            int[] a = new int[n];//creater array
            for (int i = 0; i < n; i++)//reading the array integers
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for(int i = 0; i < n; i++)
            {
                Console.Write(a[i].ToString() + " " + a[i].ToString() + " ");//convert a[i] to string twice and spaces between them
            }


        }
    }
}
