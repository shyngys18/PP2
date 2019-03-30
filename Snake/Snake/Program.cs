using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {

        public static void MoveSnake()
        {
            while (!Game.GameOver)
            {
                switch (Game.direction)
                {
                    case 1:
                        Game.snake.Move(1, 0);
                        break;
                    case 2:
                        Game.snake.Move(-1, 0);
                        break;
                    case 3:
                        Game.snake.Move(0, 1);
                        break;
                    case 4:
                        Game.snake.Move(0, -1);
                        break;
                }
                if (!Game.snake.Collision(Game.wall) || !Game.snake.ObstacleSnake(Game.snake))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over");
                    Game.GameOver = true;

                    break;

                }

                while (Game.food.FoodWall(Game.food.location.x, Game.food.location.y, Game.wall))
                {
                    Game.food.SetRandomPosition();
                }

                if (Game.snake.body.Count() % 4 == 0)
                {
                    Game.wall.body.Clear();
                    Game.snake.body.Clear();
                    Console.Clear();
                    Game.level = Game.level + 1;
                    Game.snake.body.Add(new Point(3, 1));
                    Game.snake.body.Add(new Point(2, 1));
                    Game.snake.body.Add(new Point(1, 1));
                    Game.wall.LoadLevel(Game.level);
                    Game.direction = 1;
                    if (Game.level == 5)
                    {
                        Game.level = 0;
                    }
                }



                Game.Draw();
                Thread.Sleep(Game.speed);

            }
        }



        static void Main(string[] args)
        {
            int a = 0;
            int score = 0;
            Game.Init(score);
            Thread t = new Thread(MoveSnake);

            t.Start();
            while (!Game.GameOver)
            {

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.direction = 4;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.direction = 3;
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.direction = 2;
                        break;
                    case ConsoleKey.RightArrow:
                        Game.direction = 1;
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.F1:

                        Game.snake.Serialization(Game.snake);
                        Game.wall.Serialization(Game.wall);

                        break;
                    case ConsoleKey.F2:
                        Game.GameOver = false;
                        Console.Clear();
                        Game.snake = Game.snake.Deserialization();
                        Game.wall.Deserialization();
                        break;
                }



                //Checking for collision with obstacles



            }
            Console.Clear();
            Console.WriteLine("Game Over");




        }
    }
}