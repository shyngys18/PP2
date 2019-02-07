﻿using System;
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
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1");
            PrintInfo(dir, 0);
        }
        static void PrintInfo(FileSystemInfo fsi,int k)
        {
            string s = new string(' ', k);
            Console.WriteLine(s + fsi.Name);

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos();
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], k + 3);
                }
            }
        }
    }
}
