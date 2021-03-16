using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Här är svans-objektets klass.
    /// </summary>
    public class Tail : GameObject, IRenderable
    {
        public char RenderProp { get; set; }

        public Tail(char tail, int x, int y) :base(x, y)
        {
            RenderProp = tail;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
