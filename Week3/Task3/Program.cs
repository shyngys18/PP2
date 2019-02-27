using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string ab = "";
            string ba = "";
            
            string b = Console.ReadLine();
            string a = "";
            for(int i = b.Length-1; i >=0; i--)
            {
                a = a + b[i];
            }
            string[] dirs = Directory.GetFiles(@"C:\Users\Shyngys\Desktop\test1", "b"*);
            string[] dirs2 = Directory.GetDirectories(@"C:\Users\Shyngys\Desktop\test1", "b*");
            string[] filePaths = Directory.GetFiles(@"C:\Users\Shyngys\Desktop\test1", "*.*",
                                         SearchOption.AllDirectories);
            foreach(string x in dirs)
            {
                 ab = x;

            }
            foreach (string x1 in dirs2)
            {
                 ba = x1;
            }
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Shyngys\Desktop\test1");
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                Console.WriteLine(dir.Name+ab+ba);
            }


        }
    }
}
