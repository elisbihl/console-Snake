using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// GameObjects uppgift är främst att hålla vilka kordinater som ett objekt innehåller och att uppdatera dom.
    /// </summary>
    public abstract class GameObject
    {


        public Position poss;
        
        public GameObject(int x, int y)
        {
            poss.X = x;
            poss.Y = y;
        }
        // TODO
        public virtual void Update() 
        {
            
        }
    }
}
