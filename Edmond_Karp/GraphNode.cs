using System.Collections.Generic;

namespace EdmondKarp
{
    public class GraphNode
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }
    }
}