using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Mark
    {
        public int grade;

        public Mark(int a)
        {
            grade = a;
        }
        static string[] letter = { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "F" };
        string getletter()
        {
            if (grade == 100 || grade == 90)
            
        return letter[0];
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
