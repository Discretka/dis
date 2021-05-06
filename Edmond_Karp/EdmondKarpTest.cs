using System;
using System.Collections.Generic;
using EdmondKarp;
using EdmondKarp.Tree;
using NUnit.Framework;

namespace EndmondKarpTest
{
    public class Tests
    {
        private AVLTree<string, GraphNode> avlTree;
        
        [SetUp]
        public void Setup()
        {
            var cityS = new GraphNode
            {
                Name = "S",
                Edges = new List<Edge>()
            };

            var cityB = new GraphNode
            {
                Name = "B",
                Edges = new List<Edge>()
            };
            
            var cityA = new GraphNode
            {
                Name = "A",
                Edges = new List<Edge>()
            };

            var T = new GraphNode
            {
                Name = "T",
                Edges = new List<Edge>()
            };

            var sToA = new Edge
            {
                To = cityA,
                Capacity = 5
            };

            var aToS = new Edge
            {
                To = cityS,
                Capacity = 5
            };

            sToA.BackEdge = aToS;

            aToS.BackEdge = sToA;

            var sToB = new Edge
            {
                To = cityB,
                Capacity = 6
            };

            var bToS = new Edge
            {
                To = cityS,
                Capacity = 6
            };

            sToB.BackEdge = bToS;

            bToS.BackEdge = sToB;

            var AToB = new Edge
            {
                To = cityB,
                Capacity = 3
            };

            var bToA = new Edge
            {
                To = cityA,
                Capacity = 3
            };

            AToB.BackEdge = bToA;

            bToA.BackEdge = AToB;

            var ATot = new Edge
            {
                To = T,
                Capacity = 4
            };

            var tToA = new Edge
            {
                To = cityA,
                Capacity = 4
            };

            ATot.BackEdge = tToA;

            tToA.BackEdge = ATot;

            var BTot = new Edge
            {
                To = T,
                Capacity = 5
            };

            var tToB = new Edge
            {
                To = cityB,
                Capacity = 5
            };

            BTot.BackEdge = tToB;

            tToB.BackEdge = BTot;

            cityS.Edges.Add(sToA);

            cityS.Edges.Add(sToB);

            cityA.Edges.Add(AToB);

            cityA.Edges.Add(ATot);

            cityA.Edges.Add(aToS);

            cityB.Edges.Add(BTot);

            cityB.Edges.Add(bToA);

            cityB.Edges.Add(bToS);

            T.Edges.Add(tToA);

            T.Edges.Add(tToB);

            var comparer = new StrComparer();

            avlTree = new AVLTree<string, GraphNode>(comparer);

            avlTree.Insert(cityS.Name, cityS);

            avlTree.Insert(cityA.Name, cityA);

            avlTree.Insert(cityB.Name, cityB);

            avlTree.Insert(T.Name, T);
        }

        [Test]
        public void FileManagerTest_NotExistFile_GetException()
        {
            var incorrectPath = "incorrect";

            var fileManager = new FileManager();

            Assert.Throws<Exception>(() => fileManager.GetAVL(incorrectPath));
        }

        [Test]
        public void GetMaxFlowTest_FourVertex_CorrectMaxFlow()
        {
            var endmondKarp = new EdmondKarp.EdmondKarp();

            var startName = "S";

            var endName = "T";

            var actual = endmondKarp.GetMaxFlow(avlTree, startName, endName);

            var expected = 9;

            Assert.AreEqual(expected, actual);
        }
    }
}