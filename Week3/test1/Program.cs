
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        string name;
        public Program(string a)
        {
            
            FileStream fs = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader input = new StreamReader(fs);//open stream for read
            FileStream fs2 = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter output = new StreamWriter(fs2);//open stream for write
            string b = Console.ReadLine();
            string str = b, str1 = "";

            foreach (char t in str)
                str1 += t.ToString()
                    .FirstOrDefault(s => s.ToString().ToLower() != "a" &&
                                         s.ToString().ToLower() != "y" &&
                                         s.ToString().ToLower() != "o" &&
                                         s.ToString().ToLower() != "i" &&
                                         s.ToString().ToLower() != "y" &&
                                         s.ToString().ToLower() != "o" &&
                                         s.ToString().ToLower() != "e");
            str = str1;
            output.WriteLine(str1);
            input.Close();
            output.Close();


        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader input = new StreamReader(fs);//open stream for read
            FileStream fs2 = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task2\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter output = new StreamWriter(fs2);//open stream for write
            string b = Console.ReadLine();
            string str = b, str1 = "";

            foreach (char t in str)
                str1 += t.ToString()
                    .FirstOrDefault(s => s.ToString().ToLower() != "a" &&
                                         s.ToString().ToLower() != "y" &&
                                         s.ToString().ToLower() != "o" &&
                                         s.ToString().ToLower() != "i" &&
                                         s.ToString().ToLower() != "y" &&
                                         s.ToString().ToLower() != "o" &&
                                         s.ToString().ToLower() != "e"); 
            str = str1;
            output.WriteLine(str1);
            input.Close();
            output.Close();


        }
    }
}
