using System;
using System.Collections.Generic;
using HuffmanCode;
using NUnit.Framework;

namespace HuffmanCodeTest
{
    public class AlgorithmHuffmanTest
    {
        [Test]
        public void GetHuffmanTree_EmptyText_Exception()
        {
            var algo = new AlgorithmHuffman();

            var text = string.Empty;

            Assert.Throws<Exception>(() => algo.GetHuffmanTree(text));
        }

        [Test]
        public void GetHuffmanTree_NotEmptyText_HuffmanTree()
        {
            var algo = new AlgorithmHuffman();

            var text = "I was here last summer.";

            var tree = algo.GetHuffmanTree(text);

            var symbols = tree.GetAllSymbol();

            var expected = new List<(string, string, int)>
            {
                ("r", "000", 2),
                (".", "0010", 1),
                ("w", "0011", 1),
                ("u", "0100", 1),
                ("t", "0101", 1),
                ("l", "0110", 1),
                ("I", "01110", 1),
                ("h", "01111", 1),
                ("e", "100", 3),
                ("s", "101", 3),
                (" ", "110", 4),
                ("m", "1110", 2),
                ("a", "1111", 2),
            };
            
            Assert.IsTrue(AreEqual(symbols,expected));
        }

        private bool AreEqual(List<(string, string, int)> list1, List<(string, string, int)> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (var i = 0; i < list1.Count; i++)
            {
                var flag = false;
                
                for (var j = 0; j < list2.Count; j++)
                {
                    if (list1[i].Item1 == list2[j].Item1)
                    {
                        if (list1[i].Item2 != list2[j].Item2 || list1[i].Item3 != list2[j].Item3)
                        {
                            return false;
                        }

                        flag = true;
                        
                        break;
                    }
                }

                if (!flag)
                {
                    return false;
                }
            }

            return true;
        }
    }
}