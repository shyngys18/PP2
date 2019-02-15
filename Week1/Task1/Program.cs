using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // reading the array size 
            int[] a = new int[n]; // create an array with n elements
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine()); // reading the ith elements of the array
            }
            List<int> pr = new List<int>(); // created a list to store prime numbers
            for (int i = 0; i < n; i++)
            { // iterating through the array
                if (isPrime(a[i])) // a[i] is prime
                    pr.Add(a[i]); // add a[i] to the back of pr
            }
            Console.WriteLine(pr.Count); // print the size of prime numbers subset
            foreach(var x in pr) // print primes
                Console.Write(x.ToString() + " "); // convert integers to the strings and print them with spaces
        }
        static bool isPrime(int x)
        {
            if (x == 1) // corner case
                return false;
            for (int i = 2; i * i <= x; i++) // iterating over possible divisiors <= sqrt(x)
                if (x % i == 0) // x divides i
                    return false;
            // no divisors were found
            return true;
        }
    }
}
