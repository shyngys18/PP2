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
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1");//open directory of destination
            PrintInfo(dir, 0);//printing file tree
        }
        static void PrintInfo(FileSystemInfo fsi,int k)
        {
            string s = new string(' ', k);//create string with 2 parameters
            Console.WriteLine(s + fsi.Name);//printing files

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos();
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], k + 3);//printing directories
                }
            }
        }
    }
}
