using System;
using System.Collections;

namespace HuffmanCode
{
    public class Heap<T,V>
    {
        private const int capacity = 300;

        public int Size { get; private set; }

        private NodeHeap<T,V>[] nodes;

        private IComparer comparer;

        public Heap(IComparer comparer)
        {
            this.comparer = comparer;

            nodes = new NodeHeap<T,V>[capacity];
            Size = 0;
        }

        public V GetMin()
        {
            if (Size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return nodes[1].Value;
        }

        public void Insert(T key, V value)
        {
            if (Size == capacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            var newNode = new NodeHeap<T,V>(key, value);
            Size++;
            nodes[Size] = newNode;
            SiftUp(Size);
        }

        public V ExtractMin()
        {
            var value = nodes[1].Value;
            nodes[1] = nodes[Size];
            Size--;
            SiftDown(1);

            return value;
        }

        private void SiftDown(int index)
        {
            var minIndex = index;
            var leftChild = LeftChild(index);

            if (leftChild <= Size && comparer.Compare(nodes[leftChild].Key, nodes[minIndex].Key) < 0)
            {
                minIndex = leftChild;
            }

            var rightChild = RightChild(index);

            if (rightChild <= Size &&
                comparer.Compare(nodes[rightChild].Key, nodes[minIndex].Key) < 0)
            {
                minIndex = rightChild;
            }

            if (minIndex != index)
            {
                Swap(nodes[minIndex], nodes[index]);
                SiftDown(minIndex);
            }
        }

        private void SiftUp(int index)
        {
            while (index > 1 && comparer.Compare(nodes[index].Key, nodes[Parent(index)].Key) < 0)
            {
                Swap(nodes[index], nodes[Parent(index)]);
                index = Parent(index);
            }
        }


        private void Swap(NodeHeap<T,V> node1, NodeHeap<T,V> node2)
        {
            var temp = new NodeHeap<T,V>(node1.Key, node1.Value);
            node1.Key = node2.Key;
            node1.Value = node2.Value;
            node2.Key = temp.Key;
            node2.Value = temp.Value;
        }

        private int Parent(int index)
        {
            return index / 2;
        }

        private int LeftChild(int index)
        {
            return 2 * index;
        }

        private int RightChild(int index)
        {
            return 2 * index + 1;
        }
    }
}