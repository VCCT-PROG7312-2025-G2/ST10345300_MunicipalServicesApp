using System.Collections.Generic;

namespace MunicipalServicesAppPoe3.DataStructures
{
    public class Graph
    {
        private readonly Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        public void AddVertex(string vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
                adjacencyList[vertex] = new List<string>();
        }

        public void AddEdge(string from, string to)
        {
            AddVertex(from);
            AddVertex(to);
            adjacencyList[from].Add(to);
        }

        public List<string> GetConnections(string vertex)
        {
            return adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex] : new List<string>();
        }
    }
}
