namespace HuffmanCode
{
    public class NodeAVL<T, V>
    {
        public V Item;
        public T Key;
        public int Height;
        public NodeAVL<T, V> Left;
        public NodeAVL<T, V> Right;

        public NodeAVL(T key, V value)
        {
            Key = key;
            Left = Right = null;
            Height = 1;
            Item = value;
        }
    }
}