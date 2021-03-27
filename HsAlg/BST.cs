using System;
using System.Collections;
using System.Collections.Generic;

namespace HuffmanCode
{
    public class BST<T,V>
    {
        public NodeBST<T,V> root { get; set; }

        private IComparer comparer;

        public BST(IComparer comparer)
        {
            this.comparer = comparer;
        }

        public void Insert(T key, V value)
        {
            if (root == null)
            {
                var newNode = new NodeBST<T,V>(key, value);
                root = newNode;
            }
            else
            {
                Insert(root, key, value);
            }
        }

        public List<(T, string, V)> GetAllSymbol()
        {
            var symbols = new List<(T, string, V)>();
            AddSymbol(root, symbols, "");

            return symbols;
        }

        public V Find(T key)
        {
            return Find(root, key);
        }

        private void AddSymbol(NodeBST<T,V> node, List<(T, string, V)> symbols, string code)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                symbols.Add((node.Key, code, node.Value));

                return;
            }

            if (node.LeftChild != null)
            {
                AddSymbol(node.LeftChild, symbols, code + "0");
            }

            if (node.RightChild != null)
            {
                AddSymbol(node.RightChild, symbols, code + "1");
            }
        }

        private void Insert(NodeBST<T,V> node, T key, V value)
        {
            var compRes = comparer.Compare(node.Key, key);

            if (compRes < 0)
            {
                if (node.RightChild == null)
                {
                    var newNode = new NodeBST<T,V>(key, value);

                    node.RightChild = newNode;
                }
                else
                {
                    Insert(node.RightChild, key, value);
                }
            }
            else if (compRes > 0)
            {
                if (node.LeftChild == null)
                {
                    var newNode = new NodeBST<T,V>(key, value);

                    node.LeftChild = newNode;
                }
                else
                {
                    Insert(node.LeftChild, key, value);
                }
            }
            else
            {
                node.Value = value;
            }
        }

        private V Find(NodeBST<T,V> node, T key)
        {
            if (node == null)
            {
                throw new Exception();
            }

            var compRes = comparer.Compare(node.Key, key);

            if (compRes < 0)
            {
                return Find(node.RightChild, key);
            }

            if (compRes > 0)
            {
                return Find(node.LeftChild, key);
            }

            return node.Value;
        }
    }
}