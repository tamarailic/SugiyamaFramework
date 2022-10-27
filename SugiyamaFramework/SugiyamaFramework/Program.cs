using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiyamaFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText($"../../resources/graph1.json");
            Graph graph = new Graph(data);
            LayeredGraph lG = new LayeredGraph(graph);

        }

    }
}
