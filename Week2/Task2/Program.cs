using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader input = new StreamReader(fs);//open stream for read
            FileStream fs2 = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter output = new StreamWriter(fs2);//open stream for write
            string s;//create a string
            while ((s = input.ReadLine()) != null)//reading until text is not empty
            {
                if (IsPrime(int.Parse(s)) == true)//if number is prime write to the output.txt
                {
                    output.WriteLine(s);
                }
            }
            input.Close();//close input stream
            output.Close();//close output stream
        }
        static bool IsPrime(int s)//checking for prime 
        {
            if (s == 1)
                return false;
            for (int i = 2; i * i <= s; i++)
                if (s % i == 0)
                    return false;
            return true;
        }
    }
}
