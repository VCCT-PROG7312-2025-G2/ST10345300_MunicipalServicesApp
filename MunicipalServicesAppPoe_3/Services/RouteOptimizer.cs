using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesAppPoe_3.Services

{
    /// <summary>
    /// RouteOptimizer implements Kruskal's Minimum Spanning Tree (MST) algorithm.
    /// It determines the most efficient set of municipal service routes between multiple areas
    /// with the lowest total cost (e.g., distance, time, or maintenance expense).
    /// </summary>
    public class RouteOptimizer
    {
        /// <summary>
        /// Represents a connection (edge) between two areas.
        /// </summary>
        public class Edge
        {
            public int Source { get; set; }
            public int Destination { get; set; }
            public int Weight { get; set; } // Cost or distance between areas
        }

        /// <summary>
        /// Executes Kruskal's MST algorithm.
        /// </summary>
        /// <param name="edges">A list of edges connecting nodes.</param>
        /// <param name="vertices">Total number of unique nodes (areas).</param>
        /// <returns>A list of edges that form the Minimum Spanning Tree.</returns>
        public static List<Edge> KruskalMST(List<Edge> edges, int vertices)
        {
            // Sort edges by ascending weight
            edges = edges.OrderBy(e => e.Weight).ToList();

            // Initialize each vertex as its own parent
            int[] parent = Enumerable.Range(0, vertices).ToArray();
            List<Edge> result = new List<Edge>();

            // Helper functions: Find and Union
            int Find(int i)
            {
                if (parent[i] == i) return i;
                return parent[i] = Find(parent[i]);
            }

            void Union(int x, int y)
            {
                int xroot = Find(x);
                int yroot = Find(y);
                parent[yroot] = xroot;
            }

            // Iterate through all sorted edges
            foreach (var edge in edges)
            {
                int x = Find(edge.Source);
                int y = Find(edge.Destination);

                // If including this edge doesn’t cause a cycle, include it in the result
                if (x != y)
                {
                    result.Add(edge);
                    Union(x, y);
                }
            }

            return result;
        }

        /// <summary>
        /// Utility function to print a readable MST summary string.
        /// </summary>
        public static string GenerateMstReport(List<Edge> mst)
        {
            if (mst == null || mst.Count == 0)
                return "No optimal routes found.";

            int totalCost = mst.Sum(e => e.Weight);
            string report = "🧭 Municipal Route Optimization Report\n\n";

            foreach (var e in mst)
                report += $"• Area {e.Source} ↔ Area {e.Destination} | Cost: {e.Weight}\n";

            report += $"\nTotal Minimum Cost: {totalCost}";
            return report;
        }
    }
}
