using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Ett interface som delar ut värdet för karaktären till objekt till alla de olika klasserna som implementerar det här interfacet.
    /// </summary>
    public interface IRenderable
    {
        public char RenderProp
        {
            get; set;
        }
    }
}
