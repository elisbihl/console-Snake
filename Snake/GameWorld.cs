using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// I gameworld klassen så har jag satt så att maten uppdateras på en random plats när den blir upplockad.
    /// Jag har också satt en metod för att man ska förlora liv och placeras i mitten på banan med direction = none om man kör in i en vägg-
    /// eller kör in i sin svans. Om man får slut på liv så skrivs game over ut på skärmen.
    /// </summary>
    public class GameWorld
    {

        public int Liv { get; private set; } //Skapade en public int för hur många liv man har som bestäms i program.
        public int Points { get; private set; }

        public List<GameObject> Collection = new List<GameObject>();

        public Player P { get; private set; }

        public Food Mat { get; private set; }

        public Tail Tail { get; private set; }

        public Food CreateFood()
        {

            if (P.poss.X == Mat.poss.X && P.poss.Y == Mat.poss.Y)
            {
                if (P.Dir == Direction.Right)
                {
                    Tail tail = new Tail('▒', P.poss.X - 1, P.poss.Y);
                    P.Tails.Add(tail);
                }
                if (P.Dir == Direction.Left)
                {
                    Tail tail = new Tail('▒', P.poss.X + 1, P.poss.Y);
                    P.Tails.Add(tail);
                }
                if (P.Dir == Direction.Down)
                {
                    Tail tail = new Tail('▒', P.poss.X, P.poss.Y - 1);
                    P.Tails.Add(tail);
                }
                if (P.Dir == Direction.Up)
                {
                    Tail tail = new Tail('▒', P.poss.X, P.poss.Y + 1);
                    P.Tails.Add(tail);
                }
                Points++;
                Random num = new Random();
                int ranX = num.Next(3, ConsoleRenderer.X - 4);
                int ranY = num.Next(3, ConsoleRenderer.Y - 4);
                Food Mat = new Food('$', ranX, ranY);
                this.Mat = Mat;
                Collection.Add(Mat);
                return Mat;
            }
            return Mat;
        }

        public bool GameOver(bool a)
        {
            if (P.poss.X <= 1 || P.poss.X >= ConsoleRenderer.X - 1 || P.poss.Y <= 1 || P.poss.Y >= ConsoleRenderer.Y - 1) //Om spelaren åker in i en vägg så körs den här if-satsen.
            {
                Liv--; //Spelaren förlorar ett liv.
                P.poss.X = ConsoleRenderer.X / 2; //Spelarens position ändras till mitten av banan.
                P.poss.Y = ConsoleRenderer.Y / 2;
                P.Dir = Direction.None; //Direction sätts till none.
                Console.Clear(); //Används mest för att visa att man förlora ett liv.
                Console.Clear();

            }

            foreach (var item in P.Tails)
            {
                if (item.poss.X == P.poss.X && item.poss.Y == P.poss.Y || P.poss.X <= 1 || P.poss.X >= ConsoleRenderer.X - 1 || P.poss.Y <= 1 || P.poss.Y >= ConsoleRenderer.Y - 1) //Om spelaren åker in i sin egna svans så körs den här if-satsen
                {
                    Liv--;                    //Spelaren förlorar ett liv.
                    P.poss.X = ConsoleRenderer.X / 2;
                    P.poss.Y = ConsoleRenderer.Y / 2; //Positionen sätts till mitten av banan.
                    P.Dir = Direction.None; //Direction sätts till none.
                    Console.Clear(); //Används mest för att visa att man förlora ett liv.
                    Console.Clear();

                }
            }

            if (Liv == 0 || a == false) //Om man förlorar alla liv så blir det game over.
            {
                Console.Clear();
                string gameoverlogo = @"  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                     ░                  ";
                Console.WriteLine(gameoverlogo);
                Console.WriteLine("Du fick: " + Points + " poäng");
                Console.WriteLine("[Press any key]");
                Console.ReadKey();
                
                return false; //Efter gameover skärmen så kommer man tillbaka till huvudmenyn.
            }
            return true;
        }

        public GameWorld(int points, Player p, Food mat, int liv)
        {

            Points = points;
            P = p;
            Mat = mat;
            Liv = liv;
        }

        public void Update()
        {

            foreach (var item in Collection)
            {
                item.Update();              
            }
        }
    }
}
