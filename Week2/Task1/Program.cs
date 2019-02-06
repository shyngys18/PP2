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
            string text;
            FileStream fs = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1\input.txt", FileMode.Open,FileAccess.Read);
            StreamReader input = new StreamReader(fs);
            FileStream fs2 = new FileStream(@"C:\Users\Shyngys\Desktop\Week1\Week2\Task1\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter output = new StreamWriter(fs2);




            while ((text = input.ReadLine()) != null) {
                if (palindrome(text) == true)
                {
                    output.WriteLine(text + " " + "Yes");
                }
                else
                {
                    output.WriteLine(text + " " + "No");
                }
            }
            input.Close();
            output.Close();

        }
        static bool palindrome(string text)
        {
            
                if (text == cycle(text))
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
            string textreverse = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {

                textreverse = textreverse + text[i];
            }
            return textreverse;
        }
        }
    }

