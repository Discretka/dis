namespace HuffmanCode
{
    public class NodeBST<T, V>
    {
        public NodeBST<T, V> LeftChild { get; set; }

        public NodeBST<T, V> RightChild { get; set; }

        public T Key { get; set; }

        public V Value { get; set; }

        public NodeBST(T key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}