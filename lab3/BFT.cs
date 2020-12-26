namespace BinarySeachTree
{
    public class BFT<T>:Iterator<T>
    {
        private Queue<Node<T>> queue;

        public BFT(Node<T> p)
        {
            queue = new Queue<Node<T>>();
            BFS(p);
        }

        private void BFS(Node<T> p)
        {
            if (p == null)
            {
                return;
            }

            if (p.Left != null)
            {
                BFS(p.Left);
                queue.Push(p.Left);
            }
            
            queue.Push(p);

            if (p.Right != null)
            {
                BFS(p.Right);
                queue.Push(p.Right);
            }
        }
        public bool HasNext()
        {
            return !queue.IsEmpty();
        }
        public Node<T> Next()
        {
            Node<T> elem = queue.Front();
            queue.Pop();
            return elem;
        }
    }
}