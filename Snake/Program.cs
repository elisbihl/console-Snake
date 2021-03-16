using System;
using System.Threading;
using System.Collections.Generic;

namespace Snake
    
{
    /// <summary>
    /// Huvudprogrammet för hela spelet. Här ger man spelaren, maten etc. huvudvärden.
    /// Här finns main-loopen som ser till att hela spelet körs.
    /// För att i alla fall försöka ge mig på ett VG så skapade jag en svans och en väggar.
    /// </summary>
    public enum Direction { Up, Down, Left, Right, None }; // Enums för vart spelaren ska åka.
    public struct Position // Struct för position för spelare, mat etc.
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it as uppercase, otherwise returns '\0'.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        public static void Loop()
        {
            List<Tail> svans = new List<Tail>();
            int liv = 3; // Hur många liv spelaren har. Behöver igentligen inte deklareras till en variabel men jag gjorde det ändå.
            Player P = new Player(Direction.None, '█', 40, 18, svans); //Här skapas spelaren som sätts med en start "Direction", 
            //vilken karaktär den ska visas som och vilka kordinater den startar på.
            Food Mat = new Food('$', 10, 23);  //Här skapas den första maten, den sätts med en karaktär och två fasta kordinater.
                                               // Initialisera spelet

            int j = 0;
            int frameRate = 5; // Hur fort spelet ska gå.
            GameWorld world = new GameWorld(0, P, Mat, liv); // Här skapas världen, som laddas in med spelare mat och liv.
            ConsoleRenderer renderer = new ConsoleRenderer(world, 80 ,36, P, Mat); //Här körs renderen med all information den behöver.

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            // ...

            world.Collection.Add(P);
            world.Collection.Add(Mat); // Här läggs mat och spelare till i listan som ligger i gameworld.

            // Huvudloopen
            bool running = true;
            while (running)
            {              
                if (world.Points > j) //Kollar om poäng går upp och ökar frameraten(hastigheten på spelet) utefter det.
                {                   
                    frameRate++;
                    j++;
                }              
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;
                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {                  
                    case ConsoleKey.Q:
                        running = false;
                        break;
                    case ConsoleKey.UpArrow:
                            if (P.Dir == Direction.Down)
                            {
                                break;
                            }
                            else
                            {
                                P.Dir = Direction.Up;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            if (P.Dir == Direction.Up)
                            {
                                break;
                            }
                            else { P.Dir = Direction.Down;
                                break;
                            }
                        
                    case ConsoleKey.LeftArrow:
                            if (P.Dir == Direction.Right)
                            {
                                break;
                            }
                            else
                            {
                                P.Dir = Direction.Left;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            if (P.Dir == Direction.Left)
                            {
                                break;
                            }
                            else
                            {
                                P.Dir = Direction.Right;
                                break;
                            }
                        // TODO Lägg till logik för andra knapptryckningar
                        // ...
                }                              
                // Uppdatera världen och rendera om
                renderer.RenderBlank();

                world.Update();
                renderer.Render();
                running = world.GameOver(running);
                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv

                    Thread.Sleep((int)frameTime);
                }
            }
        }

        public static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                string logo = @"███████ ███    ██ ███████      ██ ██   ██ 
██      ████   ██ ██           ██ ██  ██  
███████ ██ ██  ██ █████        ██ █████   
     ██ ██  ██ ██ ██      ██   ██ ██  ██  
███████ ██   ████ ███████  █████  ██   ██ 
                                          
                                         ";
                Console.ForegroundColor = ConsoleColor.Red; //Här är min huvudmeny, inte något speciellt.
                Console.WriteLine(logo);
                Console.WriteLine("[1] Play a game of Snejk");
                Console.WriteLine("[I] How to play.");
                Console.WriteLine("[Q] Quit");
                string menu = Console.ReadLine();
                switch (menu.ToUpper())
                {
                    case "1":
                        Console.Clear();
                        Loop();
                        break;
                    case "I":
                        Console.Clear();
                        Console.WriteLine("* Use the arrowkeys to move the snake.");
                        Console.WriteLine("* You've got three lives.");
                        Console.WriteLine("* If you hit a wall you lose one life.");
                        Console.WriteLine("* If you hit your tail you lose one life.");
                        Console.WriteLine("* If you lose all of your lives you are dead. Game Over.");
                        Console.WriteLine("* Press [Q] at any time to exit to the main menu.");
                        Console.WriteLine("  [PRESS ANY KEY]");
                        Console.ReadKey();
                        break;
                    case "Q":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Pick one of the options above!");
                        Console.ReadKey();
                        break;
                }
                // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            }
        }
    }
}
