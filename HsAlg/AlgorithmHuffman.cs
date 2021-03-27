using System;
using System.Collections;
using System.Collections.Generic;

namespace HuffmanCode
{
    public class AlgorithmHuffman
    {
        public BST<string, int> GetHuffmanTree(string text)
        {
            if (text == string.Empty)
            {
                throw new Exception("empty text entered");
            }

            var frequency = GetFrequency(text);
            var heap = CreateHeap(frequency);
            var codeTree = Algo(heap);
            return codeTree;
        }

        private BST<string, int> Algo(Heap<int, BST<string, int>> heap)
        {
            IComparer comparer = new StrComparer();

            while (heap.Size > 1)
            {
                var bst1 = heap.ExtractMin();
                var bst2 = heap.ExtractMin();
                var newBst = new BST<string, int>(comparer);
                var key = bst1.root.Key + bst2.root.Key;
                var value = bst1.root.Value + bst2.root.Value;
                var nodeBst = new NodeBST<string, int>(key, value);

                nodeBst.LeftChild = bst1.root;
                nodeBst.RightChild = bst2.root;
                newBst.root = nodeBst;
                heap.Insert(nodeBst.Value, newBst);
            }

            return heap.GetMin();
        }

        private Heap<int, BST<string, int>> CreateHeap(List<(char, int)> frequency)
        {
            IComparer intComparer = new IntComparer();

            IComparer strComparer = new StrComparer();

            var heap = new Heap<int, BST<string, int>>(intComparer);

            for (var i = 0; i < frequency.Count; i++)
            {
                var bst = new BST<string, int>(strComparer);

                bst.Insert(frequency[i].Item1.ToString(), frequency[i].Item2);
                heap.Insert(frequency[i].Item2, bst);
            }

            return heap;
        }

        private List<(char, int)> GetFrequency(string text)
        {
            IComparer comparer = new CharComparer();

            var tree = new AVLTree<char, int>(comparer);
            for (var i = 0; i < text.Length; i++)
            {
                try
                {
                    var count = tree.Find(text[i]);

                    count++;

                    tree.Insert(text[i], count);
                }
                catch
                {
                    tree.Insert(text[i], 1);
                }
            }

            return tree.GetNodes();
        }
    }
}