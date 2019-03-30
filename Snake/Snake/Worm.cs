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
    public class Snake
    {

        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Snake()
        {
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>();

            body.Add(new Point(12, 1));
            body.Add(new Point(11, 1));
        }

        public void Move(int dx, int dy)
        {
            Point lastPoint = body[body.Count - 1];
            Console.SetCursorPosition(lastPoint.x, lastPoint.y);
            Console.Write(' ');


            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            CollisionWithWall();

            if (Eat())
            {
                Game.score += 200;
                if (body.Count % 4 == 0 && Game.speed >= 30)
                {
                    Game.speed -= 30;
                }
                Game.food.SetRandomPosition();

            }

        }

        public void CollisionWithWall()
        {
            if (body[0].x > 69)
                body[0].x = 0;
            if (body[0].x < 0)
                body[0].x = 69;
            if (body[0].y > 19)
                body[0].y = 0;
            if (body[0].y < 0)
                body[0].y = 19;
        }



        public bool Eat()
        {
            if (body[0].x == Game.food.location.x
                && body[0].y == Game.food.location.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }


            return false;
        }

        public bool Collision(Wall wall)
        {
            for (int i = 0; i < wall.body.Count; i++)
                if (body[0].x == wall.body[i].x && body[0].y == wall.body[i].y)
                {
                    return false;
                }
            return true;
        }
        public bool ObstacleSnake(Snake snake)
        {
            for (int i = 1; i < snake.body.Count; i++)
            {
                if (snake.body[0].x == snake.body[i].x && snake.body[0].y == snake.body[i].y)
                {
                    return false;
                }
            }
            return true;
        }

        public void Serialization(Snake snake)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bf.Serialize(fs, Game.snake);
            fs.Close();
        }
        public Snake Deserialization()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("SaveWall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Snake snake = bf.Deserialize(fs) as Snake;
            fs.Close();
            return snake;
        }

        public void Draw()
        {

            for (int i = 0; i < body.Count; i++)
            {
                /*if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = color;*/
                Console.ForegroundColor = (i == 0) ? ConsoleColor.Red : color;
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }

            /*          int index = 0;
                        foreach (Point p in body)
                        {
                            if (index == 0)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = color;
                            Console.SetCursorPosition(p.x, p.y);
                            Console.Write(sign);
                            index++;
                        }*/
        }
    }
}