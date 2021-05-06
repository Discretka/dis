using System;
using System.Collections.Generic;
using System.IO;
using EdmondKarp.Tree;

namespace EdmondKarp
{
    public class FileManager
    {
        public AVLTree<string, GraphNode> GetAVL(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("The file does not exist");
            }

            var avlTree = new AVLTree<string, GraphNode>(new StrComparer());

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    AddCity(line, avlTree);
                }
            }

            return avlTree;
        }

        private void AddCity(string line, AVLTree<string, GraphNode> avlTree)
        {
            var parameters = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3)
            {
                throw new Exception("Incorrect data format");
            }

            var weight = parameters[2];
            var capacity = int.Parse(weight);
            var cityName1 = parameters[0];
            var cityName2 = parameters[1];

            GraphNode city1, city2;

            try
            {
                city1 = avlTree.Find(cityName1);
            }
            catch
            {
                city1 = new GraphNode()
                {
                    Name = cityName1,
                    Edges = new List<Edge>()
                };

                avlTree.Insert(cityName1, city1);
            }

            try
            {
                city2 = avlTree.Find(cityName2);
            }
            catch
            {
                city2 = new GraphNode()
                {
                    Name = cityName2,
                    Edges = new List<Edge>()
                };

                avlTree.Insert(cityName2, city2);
            }

            var city1ToCity2 = new Edge
            {
                Capacity = capacity,
                To = city2
            };

            var city2ToCity1 = new Edge
            {
                Capacity = capacity,
                To = city1
            };

            city2ToCity1.BackEdge = city1ToCity2;
            city1ToCity2.BackEdge = city2ToCity1;
            city1.Edges.Add(city1ToCity2);
            city2.Edges.Add(city2ToCity1);
        }
    }
}