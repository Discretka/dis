namespace BinarySeachTree
{
    public interface Iterator<T>
    {
        public Node<T> Next();

        public bool HasNext();
    }
}