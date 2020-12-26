namespace BinarySeachTree
{
    public class Node<T>
    {
        public T Item;
        public int Key;
        public int Height;
        public Node<T> Left;
        public Node<T> Right;

        public Node(int k,T value)
        {
            Key = k;
            Left = Right = null;
            Height = 1;
            Item = value;
        }

    }
}