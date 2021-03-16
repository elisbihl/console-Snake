using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Tests
{

    /// <summary>
    /// Jag gjorde alla mina klasser och metoder till public för att kunna göra tester på dom.
    /// Hoppas det här är tillräckligt, hade lite problem med min GameOver metod som ger ett IOExcepetion.
    /// Vet inte riktigt hur jag ska kunna gå runt det.
    /// Det blev lite jobbigt då konstruktorn för min GameWorld behöver många värden som input och att behöva skapa det för alla tester.
    /// </summary>

    [TestClass()]
    public class GameWorldTests
    {

        [TestMethod()]
        public void CreateFoodTest()
        {
            ConsoleRenderer.X = 5;
            ConsoleRenderer.Y = 5;
            Random num = new Random();
            int ranX = num.Next(2, ConsoleRenderer.X);
            int ranY = num.Next(3, ConsoleRenderer.Y);
            Food mat = new Food('@', ranX, ranY);
            Food mat2 = new Food('@', ranX, ranY);
            Assert.IsNotNull(mat);
            Assert.AreNotEqual(mat, mat2);
        } //I det här testet kollar jag så att ett food värde faktiskt skapas.

        //[TestMethod()]

        //public void GameOverTest()
        //{

        //    List<Tail> tailtest1 = new List<Tail>();
        //    Player pTest = new Player(Direction.None, 'P', 0, 0, tailtest1);
        //    Food fTest = new Food('@', 1, 2);

        //    GameWorld WorldTest = new GameWorld(0, pTest, fTest, 2);
        //    ConsoleRenderer rendererTest = new ConsoleRenderer(WorldTest, 80, 36, pTest, fTest);
        //    WorldTest.Collection.Add(pTest);
        //    WorldTest.Collection.Add(fTest);
        //    bool running = false;
        //    Assert.AreEqual(WorldTest.GameOver(running), false);
        //} // Vet inte riktigt vad jag ska skriva för att testa min gameover metod. Jag får en IOException.

        [TestMethod()]
        public void UpdateTest()
        {
            ConsoleRenderer.X = 30;
            ConsoleRenderer.Y = 30;
            List<Tail> tailtest1 = new List<Tail>();
            Player pTest = new Player(Direction.None, 'P', 5, 5, tailtest1);
            Food fTest = new Food('@', 5, 5);
            GameWorld World = new GameWorld(0, pTest, fTest, 3);
              
            Assert.AreEqual(0, World.Collection.Count);
            Assert.IsNotNull(World.Collection);

            World.P.poss.X = 10; World.P.poss.Y = 10;           
            World.Mat.poss.X = 10; World.Mat.poss.Y = 10;
            World.CreateFood();
            
            Assert.AreEqual(1, World.Collection.Count);
        } //I det här testet så kör jag en "AreEqual" innan något är tillagt i Collection och sen igen efter att min metod CreateFood har körts för att se att ett värde har lagts i.
    }
}


