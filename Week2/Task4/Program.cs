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
            string path = "C:\\Users\\Shyngys\\Desktop\\Week1\\Week2\\Task4\\source\\test.txt";
            FileStream fs = File.Create(path);
            fs.Close();
            string destination = @"C:\Users\Shyngys\Desktop\Week1\Week2\Task4\destination\";





            
            File.Copy(path, destination + Path.GetFileName(path));
            File.Delete(path);

        }
        
    }
}
