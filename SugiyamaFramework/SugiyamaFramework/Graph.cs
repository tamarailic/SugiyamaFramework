using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SugiyamaFramework
{

    public class Graph
    {
        public List<Node> Nodes;

        public Graph(string jsonString)
        {
            Dictionary<string, List<Node>> deserializedJSON = JsonConvert.DeserializeObject<Dictionary<string,List<Node>>>(jsonString);
            this.Nodes = deserializedJSON["stations"];   
        }
    }

    
}
