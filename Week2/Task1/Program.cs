using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;//created a string
            FileStream fs = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1\input.txt", FileMode.Open,FileAccess.Read);
            StreamReader input = new StreamReader(fs);//open stream for reading
            FileStream fs2 = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter output = new StreamWriter(fs2);//open stream for writing




            while ((text = input.ReadLine()) != null)
            {//reading an string from all lines, while the line is not empty
                if (palindrome(text) == true)
                {
                    output.WriteLine(text + " " + "Yes");//printing is a palindrome or not
                }
                else
                {
                    output.WriteLine(text + " " + "No");
                }
            }
            input.Close();//close input stream
            output.Close();//close output stream

        }
        static bool palindrome(string text)
        {
            
                if (text == cycle(text))//if origin text==reverse text so its a palindrome
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        public static string cycle(string text)
        {
            string textreverse = "";  //create a string
            for (int i = text.Length - 1; i >= 0; i--)//iterating over string from back
            {

                textreverse = textreverse + text[i];//adding the LETTER TO MASSIV
            }
            return textreverse;//return reverse word
        }
        }
    }

