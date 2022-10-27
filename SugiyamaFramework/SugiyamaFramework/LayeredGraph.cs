using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiyamaFramework
{
    class LayeredGraph
    {
        private Graph _graph;
        private int _levelOffsetY = 50;
        private int _levelOffsetX = 50;
        private int _nodeDistanceX = 60;
        private int _nodeDistanceY = 70;
        public LayeredGraph(Graph inputGraph) {
            this._graph = inputGraph;
            Leveling();
            SVGDrawing();
        }


        private void CycleDetection() { }
        private void Leveling() {
            int num = 0;
            foreach (Node node in _graph.Nodes)
            {
                node.Level = num;
                node.PositionX = _levelOffsetX + num * _nodeDistanceX;
                node.PositionY = _levelOffsetY + num * _nodeDistanceY;
                num += 1;
            }
        }
        private void CrossingMinimization() { }
        private void VertexPositioning() { }

        private string NodesDrawing(List<Node> nodes) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Node node in nodes)
            {
                stringBuilder.Append($@"<g>
                                            <circle cx=""{node.PositionX}"" cy=""{node.PositionY}"" r=""20"" stroke=""green"" stroke-width=""4"" fill=""yellow""/>
                                            <text x=""{node.PositionX - 5}"" y=""{node.PositionY + 5}"" fill=""#000000"">{node.Name}</text>
                                        </g>");
            }
            return stringBuilder.ToString();
        }

        //TO DO: incorporate dummies
        private Node CreateDummyNode(string from, string to, int x, int y)
        {
            Node dummyNode = new Node();
            dummyNode.Name = from;
            dummyNode.ForwardConnections = new List<string> { to };
            dummyNode.IsDummy = true;
            dummyNode.PositionX = x;
            dummyNode.PositionY = y;

            return dummyNode;
        }

        private string ConnectionsDrawing(Node node) {
            StringBuilder stringBuilder = new StringBuilder();

            //TO DO: 
            //List<Node> dummies = new List<Node>();

            foreach (Node nodeToConnect in _graph.Nodes)
            {
                if (nodeToConnect.Level > node.Level && node.ForwardConnections.Contains(nodeToConnect.Name))
                {
                    int levelDifference = nodeToConnect.Level - node.Level;
                    for (int i = 0; i < levelDifference - 1; i++)
                    {
                        stringBuilder.Append($@"<polyline points = ""{node.PositionX},{node.PositionY + i * _nodeDistanceY}
                        {node.PositionX},{node.PositionY + (i + 1) * _nodeDistanceY}"" style=""fill:none; stroke:black;stroke-width:3""/> ");
                        //dummies.Add(CreateDummyNode(node.Name, nodeToConnect.Name, node.PositionX, node.PositionY + (i + 1) * _nodeDistanceY));
                    }
                    stringBuilder.Append($@"<polyline points = ""{node.PositionX},{node.PositionY + (levelDifference - 1) * _nodeDistanceY}
                        {nodeToConnect.PositionX},{node.PositionY + levelDifference * _nodeDistanceY}"" style=""fill:none; stroke:black;stroke-width:3""/> ");
                }  
            }

            return stringBuilder.ToString();
        }

        private void SVGDrawing()
        {
            string filePath = "../../results/result.svg";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                StringBuilder stringBuilder = new StringBuilder(@"<?xml version=""1.0"" encoding=""utf-8""?>
<svg version=""1.1"" id=""TamaraIlic"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">");

                foreach (Node node in _graph.Nodes)
                {
                    stringBuilder.Append(ConnectionsDrawing(node));
                }
                stringBuilder.Append(NodesDrawing(_graph.Nodes));
                stringBuilder.Append("</svg>");

                streamWriter.Write(stringBuilder);
            }
        }
    }
}
