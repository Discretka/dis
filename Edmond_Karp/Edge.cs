namespace EdmondKarp
{
    public class Edge
    {
        public GraphNode To { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }
        public Edge BackEdge { get; set; }
    }
}