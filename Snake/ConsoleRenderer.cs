using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{

    /// <summary>
    /// I ConsoleRenderer bestäms var och i vilken ordning allt ska skrivas ut i konsolen.
    /// ConsoleRenderer behöver få reda på vilka objekt som finns som mat och spelare.
    /// Här sätts också hur stor spelvärlden ska vara.
    /// </summary>
    public class ConsoleRenderer
    {

        public static int X { get; set; }
        public static int Y { get; set; }
        private Player P { get; set; }


        private Food Mat { get; set; }


        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld, int x, int y, Player p, Food mat)
        {
            X = x;
            Y = y;
            // TODO Konfigurera Console-fönstret enligt världens storlek
            Console.SetWindowSize(X, Y);
            Console.SetBufferSize(X + 1, Y + 1);
            world = gameWorld;
            P = p;
            Mat = mat;
        }

        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(4, 0);
            Console.Write("Points: " + world.Points); //Här skriver den ut hur många poäng spelaren har samlat
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(P.poss.X, P.poss.Y);
            Console.CursorVisible = false;
            Console.Write(P.RenderProp); // Här skrivs spelaren ut.

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X - 15, 0);
            Console.Write("Lives: " + world.Liv); //Här visar den hur många liv spelaren har kvar.
            Console.CursorVisible = false;


            foreach (var item in P.Tails) //Här skrivs alla delar för svansen ut.
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(item.poss.X, item.poss.Y);
                Console.Write(item.RenderProp);
            }
            // TODO Rendera spelvärlden (och poängräkningen)

            Mat = world.CreateFood(); //Här körs metoden ifrån GameWorld för att på slumpmässig kordinat skapa en ny mat.
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(Mat.poss.X, Mat.poss.Y);
            Console.CursorVisible = false;
            Console.Write(Mat.RenderProp);          //Här skrivs maten ut.

            for (int i = 0; i < X; i++) // Här skapas väggarna runt om banan för sidled.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write('█');
                Console.SetCursorPosition(i, Y - 1);
                Console.Write('█');
            }
            for (int i = 1; i < Y; i++) // Här skapas väggarna uppifrån och ner.
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(0, i);
                Console.Write('█');
                Console.SetCursorPosition(X - 1, i);
                Console.Write('█');
                Console.SetCursorPosition(1, i);
                Console.Write('█');
                Console.SetCursorPosition(X - 2, i);
                Console.Write('█');
            }
        }

        public void RenderBlank()
        {
            Console.SetCursorPosition(P.poss.X, P.poss.Y);
            Console.WriteLine(' ');
            Console.SetCursorPosition(Mat.poss.X, Mat.poss.Y);
            Console.Write(' ');

            foreach (var item in P.Tails)
            {
                Console.SetCursorPosition(item.poss.X, item.poss.Y);
                Console.WriteLine(' ');
            }

        }
    }
}
