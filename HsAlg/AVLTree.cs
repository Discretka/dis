using System;
using System.Collections;
using System.Collections.Generic;

namespace HuffmanCode
{
    public class AVLTree<T,V>
    {
        private NodeAVL<T,V> root;

        private IComparer comparer;

        public int Count { get; private set; }

        public AVLTree(IComparer comparer)
        {
            this.comparer = comparer;
        }

        public List<(T,V)> GetNodes()
        {
            var nodes = new List<(T,V)>();
            AddNode(root, nodes);

            return nodes;
        }


        public List<V> GetItems()
        {
            var items = new List<V>();
            AddItem(root, items);

            return items;
        }

        public V Find(T key)
        {
            return Find(root, key);
        }


        public void Insert(T key, V value)
        {
            root = Insert<T,V>(root, key, value);
            Count++;
        }


        private void AddNode(NodeAVL<T,V> node, List<(T,V)> nodes)
        {
            if (node == null)
            {
                return;
            }

            AddNode(node.Left, nodes);

            nodes.Add((node.Key, node.Item));

            AddNode(node.Right, nodes);
        }


        private void AddItem(NodeAVL<T,V> node, List<V> items)
        {
            if (node == null)
            {
                return;
            }

            AddItem(node.Left, items);
            items.Add(node.Item);
            AddItem(node.Right, items);
        }

        private int Height<T,V>(NodeAVL<T,V> node)
        {
            return node?.Height ?? 0;
        }

        private int BFactor<T, V>(NodeAVL<T, V> node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        private void FixHeight<T, V>(NodeAVL<T, V> node)
        {
            var heightLeft = Height(node.Left);
            var heightRight = Height(node.Right);
            node.Height = (heightLeft > heightRight ? heightLeft : heightRight) + 1;
        }

        private NodeAVL<T,V> RotateRight<T,V>(NodeAVL<T,V> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            FixHeight(node);
            FixHeight(left);
            return left;
        }

        private NodeAVL<T,V> RotateLeft<T,V>(NodeAVL<T,V> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            FixHeight(node);
            FixHeight(right);
            return right;
        }

        private NodeAVL<T,V> Balance<T,V>(NodeAVL<T,V> node)
        {
            FixHeight(node);
            if (BFactor(node) == 2)
            {
                if (BFactor(node.Right) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            if (BFactor(node) == -2)
            {
                if (BFactor(node.Left) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }

            return node;
        }

        private NodeAVL<T, V> Insert<T, V>(NodeAVL<T, V> node, T key, V value)
        {
            if (node == null)
            {
                return new NodeAVL<T, V>(key, value);
            }

            if (comparer.Compare(key, node.Key) < 0)
            {
                node.Left = Insert(node.Left, key, value);
            }
            else if (comparer.Compare(key, node.Key) > 0)
            {
                node.Right = Insert(node.Right, key, value);
            }
            else
            {
                node.Item = value;
            }

            return Balance(node);
        }

        private V Find<T, V>(NodeAVL<T, V> node, T key)
        {
            if (node == null)
            {
                throw new Exception("Not found item with same key");
            }

            var compRes = comparer.Compare(node.Key, key);
            if (compRes < 0)
            {
                return Find(node.Right, key);
            }

            if (compRes > 0)
            {
                return Find(node.Left, key);
            }

            return node.Item;
        }
    }
}