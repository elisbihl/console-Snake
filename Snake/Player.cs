using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{/// <summary>
///  Här finns spelarens information.
/// </summary>
    public class Player : GameObject, IRenderable, IMovable
    {
        public char RenderProp { get; set; }
        public Direction Dir { get; set; }

        public List<Tail> Tails = new List<Tail>();


        public Player(Direction direction, char _char, int x, int y, List<Tail> svans) :base(x, y)
        {
            RenderProp = _char;
            Dir = direction;
            Tails = svans;
        }
        public override void Update()
        {
            Tail tail = new Tail(RenderProp, poss.X, poss.Y);
  
            switch (Dir)
            {
                case Direction.Up:
                    if (this.Tails.Count != 0)
                    {
                        this.Tails.RemoveAt(this.Tails.Count - 1);
                        Tail tails = new Tail('▒', poss.X, poss.Y);
                        this.Tails.Insert(0, tails);
                    }
                    poss.Y -= 1;
                    break;
                case Direction.Down:
                    if (this.Tails.Count != 0)
                    {
                        this.Tails.RemoveAt(this.Tails.Count - 1);
                        Tail tails = new Tail('▒', poss.X, poss.Y);
                        this.Tails.Insert(0, tails);
                    }                   
                    poss.Y += 1;
                    break;
                case Direction.Left:

                    if (this.Tails.Count != 0)
                    {
                        this.Tails.RemoveAt(this.Tails.Count - 1);
                        Tail tails = new Tail('▒', poss.X, poss.Y);
                        this.Tails.Insert(0, tails);
                    }
                    poss.X -= 1;
                    break;
                case Direction.Right:
                    if (this.Tails.Count != 0)
                    {
                        this.Tails.RemoveAt(this.Tails.Count - 1);
                        Tail tails = new Tail('▒', poss.X, poss.Y);
                        this.Tails.Insert(0, tails);
                    }
                    poss.X += 1;
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }

    }
}
