using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiyamaFramework
{
    public class Node
    {
        public string Name { get; set; }
        public List<string> ForwardConnections { get; set; }
        public int Level;
        public int PositionX = 0;
        public int PositionY = 0;
        public bool IsDummy = false;
    }
}
