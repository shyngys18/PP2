using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Task_1
{
    public class cmplex
    { // class for complex numbers
        public int a, b; // complex number variables
        public cmplex() { } // empty constructor because xml serializer requests it
        public cmplex(int a, int b)
        { // constructor for complex  numer
            this.a = a; // initialize values
            this.b = b;
        }
        public void printInfo()
        {
            Console.WriteLine("{0} + {1}i", a, b); // prints complex number in format a + bi
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            restore(); // store or restore
        }
        static void store()
        { // serializer
            cmplex a = new cmplex(3, 7); // create a complx number
            XmlSerializer X = new XmlSerializer(typeof(cmplex)); //create xml serializer
            FileStream output = new FileStream(@"C:\Olymp\C#\PP2\Programming-Principles-2-KBTU\Week 5\Task 1\complex.xml", FileMode.Create, FileAccess.Write);
            //open file stream for writing xml
            X.Serialize(output, a); // serialize contents of complex number a to output file
            output.Close(); // close file for writing
        }
        static void restore()
        { // deserializer
            XmlSerializer X = new XmlSerializer(typeof(cmplex)); // create a serializer
            FileStream reader = new FileStream(@"C:\Olymp\C#\PP2\Programming-Principles-2-KBTU\Week 5\Task 1\complex.xml", FileMode.Open, FileAccess.Read);
            // opens a file for reading xml code
            cmplex a = X.Deserialize(reader) as cmplex; // deseralize .xml as complex number
            a.printInfo(); // print the number
            reader.Close(); // close file with xml code
        }
    }
}