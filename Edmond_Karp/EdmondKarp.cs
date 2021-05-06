using System;
using System.Collections.Generic;
using EdmondKarp.Tree;

namespace EdmondKarp
{
    public class EdmondKarp
    {
        public int GetMaxFlow(AVLTree<string, GraphNode> avlTree, string start, string end)
        {
            AVLTree<string, GraphNode> pathTree;
            var maxFlow = 0;
            while ((pathTree = BFS(avlTree, start, end)) != null)
            {
                var flow = GetFlow(pathTree, end);
                maxFlow += flow;
                UpdateNetwork(flow, pathTree, end);
            }
            return maxFlow;
        }
        private void UpdateNetwork(int maxFlow, AVLTree<string, GraphNode> pathTree, string end)
        {
            var currentName = end;
            GraphNode currentNode;
            while ((currentNode = pathTree.Find(currentName)) != null)
            {
                var edge = GetEdgeByToName(currentNode, currentName);
                edge.Size += maxFlow;
                edge.BackEdge.Size -= maxFlow;
                currentName = currentNode.Name;
            }
        }
        private int GetFlow(AVLTree<string, GraphNode> pathTree, string end)
        {
            var currentName = end;
            var maxFlow = int.MaxValue;
            GraphNode currentNode;
            while ((currentNode = pathTree.Find(currentName)) != null)
            {
                var edge = GetEdgeByToName(currentNode, currentName);
                maxFlow = Math.Min(edge.Capacity - edge.Size, maxFlow);
                currentName = currentNode.Name;
            }
            return maxFlow;
        }
        private Edge GetEdgeByToName(GraphNode node, string toName)
        {
            foreach (var edge in node.Edges)
            {
                var to = edge.To;
                if (to.Name == toName)
                {
                    return edge;
                }
            }
            return null;
        }
        private AVLTree<string, GraphNode> BFS(AVLTree<string, GraphNode> avlTree, string start, string end)
        {
            var visitTree = new AVLTree<string, bool>(new StrComparer());
            visitTree.Insert(start, true);
            var pathTree = new AVLTree<string, GraphNode>(new StrComparer());
            pathTree.Insert(start, null);
            var queue = new Queue<GraphNode>();
            var startNode = avlTree.Find(start);
            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var edge in currentNode.Edges)
                {
                    if (edge.Capacity != edge.Size)
                    {
                        var to = edge.To;
                        
                        try
                        {
                            visitTree.Find(to.Name);
                        }
                        catch
                        {
                            visitTree.Insert(to.Name, true);
                            pathTree.Insert(to.Name, currentNode);
                            queue.Enqueue(to);
                        }
                    }
                }
            }
            try
            {
                pathTree.Find(end);
                return pathTree;
            }
            catch
            {
                return null;
            }
        }
    }
}