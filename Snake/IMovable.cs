using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Ger ut värdet för vilken direction spelaren har. 
    /// Det är bara player klassen som behöver implementera det här interfacet.
    /// </summary>
    public interface IMovable
    {
        Direction Dir { get; set; }
    }
}
