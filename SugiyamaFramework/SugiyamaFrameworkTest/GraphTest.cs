using NUnit.Framework;
using SugiyamaFramework;
using System.IO;

namespace SugiyamaFrameworkTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingGraph()
        {
            string jsonString = File.ReadAllText($"../../../resources/graphTest.json");
            var graph = new Graph(jsonString);
            Assert.IsNotNull(graph);
        }

        
    }
}