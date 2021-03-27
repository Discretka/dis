namespace HuffmanCode
{
    public class NodeHeap<T, V>
    {
        public T Key { get; set; }

        public V Value { get; set; }

        public NodeHeap(T key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}