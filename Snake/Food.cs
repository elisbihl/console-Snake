using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Här är grunden för food objektet. 
    /// Alltså håller i och delar ut värdet för karaktär och kordinat till klasser food ärvs ifrån.
    /// </summary>
    public class Food : GameObject, IRenderable
    {

        public char RenderProp { get; set; }
        public Food(char food, int x, int y) :base(x, y)
        {
            RenderProp = food;

        }
       
    }
}
