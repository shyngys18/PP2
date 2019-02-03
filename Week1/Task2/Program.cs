using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        string name;
        string id;
        int year;

        public Student(string name, string id)
        {
            //initializing values
            this.name = name;
            this.id = id;
            this.year = 0;
        }
        public void getName()
        {
            Console.WriteLine("Name: " + name); // print name
        }
        public void getId()
        {
            Console.WriteLine("Id: " + id); // print id
        }
        public void incYear()
        {
            year++; // increase year of study
        }
        public void getYear()
        {
            Console.WriteLine("Year: " + year.ToString()); // print year
        }
        public void PrintInfo()
        { //  print name, id, year in the order.
            getName();
            getId();
            getYear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Shyngys", "18BD110852"); // new student was created, and stored in object s1
            s1.incYear(); // increase an year of s1
            s1.PrintInfo(); // print information about him

            //repeat 2 previous steps
            s1.incYear();
            s1.PrintInfo();
        }
    }
}
