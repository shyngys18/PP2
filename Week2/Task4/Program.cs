using System;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //DirectoryInfo path1 = new DirectoryInfo(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task4\source");
           // DirectoryInfo path2 = new DirectoryInfo(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task4\destination");
            string path = "C:\\Users\\Shyngys\\Desktop\\Week1\\Week2\\Task4\\source\\test2.txt";//path for source
            FileStream fs = File.Create(path);//open stream and create file
            fs.Close();//close stream
            string destination = @"C:\Users\Shyngys\Desktop\Week1\Week2\Task4\destination\";//path for destination





            
            File.Copy(path, destination+Path.GetFileName(path));//copy file from source and paste to destination
            File.Delete(path);//delete file from source

        }
        
    }
}
