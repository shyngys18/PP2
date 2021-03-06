﻿using System;
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
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Wall()
        {
            sign = '#';
            color = ConsoleColor.Magenta;
            body = new List<Point>();
            LoadLevel(1);
        }

        public void LoadLevel(int level)
        {

            body.Clear();

            string fileName = string.Format(@"C:\Users\Shyngys\Desktop\Week1/level1.txt", level); FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            int row = 0;
            string line = "";
            while (row < 20)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                        body.Add(new Point(col, row));
                }
                row++;
            }
        }
        public void Serialization(Wall wall)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bf.Serialize(fs, wall);
            fs.Close();
        }
        public Wall Deserialization()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Wall wall = bf.Deserialize(fs) as Wall;
            fs.Close();
            return wall;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}