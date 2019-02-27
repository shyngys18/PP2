using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    public class Complex
    {
        public double a;
        public double b;

        public Complex(double a1, double b1)
        {
            a = a1;
            b = b1;
        }
        public Complex()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {        //Serialize
            Complex complex = new Complex(2, 3);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            using (FileStream fs = new FileStream("complex.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                xs.Serialize(fs, complex);
            }
            //Deserialize
            using (FileStream fs = new FileStream("complex.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                Complex complex2 = xs.Deserialize(fs) as Complex;
                Console.WriteLine("{0}+{1}*i", complex2.a, complex2.b);//okay
            }
        }
    }
}
