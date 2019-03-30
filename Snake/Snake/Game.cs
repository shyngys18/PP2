using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Game
    {

        public static Snake snake;
        public static Food food;
        public static Wall wall;
        public static bool GameOver;
        public static int direction;
        public static int speed;
        public static bool FoodWall;
        public static int level = 1;
        public static int score = 0;

        public static void Init(int score)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 25);
            FoodWall = true;
            GameOver = false;
            direction = 1;
            speed = 150;

            snake = new Snake();
            food = new Food();
            wall = new Wall();

        }

        public static void Draw()
        {
            //Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Your Score: " + score);
        }

        // serialize objects (Save function)
        // desiralize objects (Resume function)
    }
}