using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    [Serializable]
    public class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '@';
            location = new Point(15, 1);
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 20);
            location = new Point(x, y);
        }
        public bool FoodWall(int p1, int p2, Wall s)
        {
            foreach (Point p in s.body)
            {
                if (p1 == p.x && p2 == p.y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Serialization(Food food)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bf.Serialize(fs, food);
            fs.Close();
        }
        public Food Deserialization()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Food food = bf.Deserialize(fs) as Food;
            fs.Close();
            return Game.food;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}