namespace BinarySeachTree
{
    public class DFT<T> : Iterator<T>
    {
        private Stack<Node<T>> stack;

        public DFT(Node<T> p)
        {
            stack = new Stack<Node<T>>();
            DFS(p);
        }

        private void DFS(Node<T> p)
        {
            if (p == null)
            {
                return;
            }

            if (p.Left != null)
            {
                DFS(p.Left);
                stack.Push(p.Left);
            }
            
            stack.Push(p);

            if (p.Right != null)
            {
                DFS(p.Right);
                stack.Push(p.Right);
            }
            
        }
        
        public Node<T> Next()
        {
            Node<T> elem = stack.Top();
            
            stack.Pop();

            return elem;
        }

        public bool HasNext()
        {
            return !stack.IsEmpty();
        }
    }
}