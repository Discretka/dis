namespace RB_Tree
{
    public class Node<T, D>
    {
        public T Key { get; set; }
        public Node<T, D> ChildRight { get; set; }
        public Node<T, D> ChildLeft { get; set; }

        public bool IsRed { get; set; }

        public Node<T, D> Parent { get; set; }

        public D Value { get; set; }

        public Node(T key, D value)
        {
            Key = key;

            Value = value;

            IsRed = true;
        }
    }
}