using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruh
{
    class Init
    {
        static void Main(string[] args)
        {
            Program program = new Program(10, 10, 5, 5);
            while (true)
            {
                program.GameLogic(Console.ReadKey());
            }
        }

    }
    class Program
    {
        public int[] Player = new int[2];
        public List<Wall> Walls = new List<Wall>();
        public int AreaWidth;
        public int AreaHeight;
        public Program(int Width = 10, int Height = 10, int PlayerX = 5, int PlayerY = 5)
        {
            AreaWidth = Width;
            AreaHeight = Height;
            Player[0] = PlayerX;
            Player[1] = PlayerY;
            Walls = GetWallData();
        }
        public void GameLogic(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.W)
            {
                if (Player[1] - 1 >= 0 ^ CheckIfWall(Player[0], Player[1] - 1) == true) { Player[1]--; }
            } else if (input.Key == ConsoleKey.S)
            {
                if (Player[1] + 1 < AreaHeight ^ CheckIfWall(Player[0], Player[1] + 1)) { Player[1]++; }
            }
            else if (input.Key == ConsoleKey.A)
            {
                if (Player[0] - 1 >= 0 ^ CheckIfWall(Player[0] - 1, Player[1])) { Player[0]--; }
            } else if (input.Key == ConsoleKey.D)
            {
                if (Player[0] + 1 < AreaWidth ^ CheckIfWall(Player[0] + 1, Player[1])) { Player[0]++; }
            }
            Draw(AreaWidth, AreaHeight, Player[0], Player[1]);
        }
        public void Draw(int w, int h, int xPos = 5, int yPos = 5)
        {
            Console.SetCursorPosition(0, 0);
            int y = 0;
            while (y < h)
            {
                Console.WriteLine("");
                int x = 0;
                while (x < w)
                {
                    if (xPos == x && yPos == y)
                        { Console.Write("@"); }
                    else if (CheckIfWall(x,y))
                    {
                        Console.Write('▓');
                    }
                    else{ Console.Write('▒'); }
                    x++;
                }
                y++;
            }
        }
        public bool CheckIfWall(int x, int y)
        {
            bool result = false;
            foreach (Wall wall in Walls)
            {
                if (wall.x == x && wall.y == y)
                {
                    result = true;
                    break;
                }
                else {result = false; }
            }
            return result;
        }
public List<Wall> GetWallData()
        {
            int counter = 0;
            string line;
            List<string> WallsData = new List<string>();
            List<Wall> Walls = new List<Wall>();
            System.IO.StreamReader file =
    new System.IO.StreamReader("Walls.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                WallsData.Add(line);
                counter++;
            }
            foreach (string WallData in WallsData)
            {
                string[] xy = WallData.Split(",".ToCharArray());
                Wall NewWall = new Wall(Convert.ToInt32(xy[1]) - 1, Convert.ToInt32(xy[0]) - 1);
                Walls.Add(NewWall);
            }
            return Walls;
        }
    }

    public struct Wall
    {
        public int x;
        public int y;

        public Wall(int Xpos,int Ypos)
        {
            x = Xpos;
            y = Ypos;
        }
    }
}
