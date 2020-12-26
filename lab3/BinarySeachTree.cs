namespace BinarySeachTree
{
    public class BinarySeachTree<T>
    {

        private Node<T> root;

        public Node<T> GetRoot()
        {
            return root;
        }

        public BinarySeachTree()
        {
            root = null;
        }
        
        private int Height<T>(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private int BFactor<T>(Node<T> node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        private void FixHeight<T>(Node<T> node)
        {
            int hl = Height(node.Left);
            int hr = Height(node.Right);
            node.Height = (hl > hr ? hl : hr) + 1;
        }

        private Node<T> RotateRight<T>(Node<T> p)
        {
            Node<T> q = p.Left;
            p.Left = q.Right;
            q.Right = p;
            FixHeight(p);
            FixHeight(q);
            return q;
        }

        private Node<T> RotateLeft<T>(Node<T> q)
        {
            Node<T> p = q.Right;
            q.Right = p.Left;
            p.Left = q;
            FixHeight(q);
            FixHeight(p);
            return p;
        }

        private Node<T> Balance<T>(Node<T> p)
        {
            FixHeight(p);
            if (BFactor(p) == 2)
            {
                if (BFactor(p.Right) < 0)
                {
                    p.Right = RotateRight(p.Right);
                }
                return RotateLeft(p);
            }

            if (BFactor(p) == -2)
            {
                if (BFactor(p.Left) > 0)
                {
                    p.Left = RotateLeft(p.Left);
                }

                return RotateRight(p);
            }

            return p;
        }

        private Node<T> Insert<T>(Node<T> p, int key,T value)
        {
            if (p == null)
            {
                return new Node<T>(key,value);
            }

            if (key < p.Key)
            {
                p.Left = Insert(p.Left, key,value);
            }
            else
            {
                p.Right = Insert(p.Right, key,value);
            }

            return Balance(p);
        }

        public void Insert(int key,T value)
        {
            root = Insert(root, key,value);
        }

        private Node<T> FindMin<T>(Node<T> p)
        {
            return p.Left != null ? FindMin(p.Left) : p;
        }

        private Node<T> RemoveMin<T>(Node<T> p)
        {
            if (p.Left == null)
            {
                return p.Right;
            }

            p.Left = RemoveMin(p.Left);

            return Balance(p);
        }

        private Node<T> Remove<T>(Node<T> p, int key)
        {
            if (p == null)
            {
                return null;
            }

            if (key < p.Key)
            {
                p.Left = Remove(p.Left, key);
            }
            else if (key > p.Key)
            {
                p.Right = Remove(p.Right, key);
            }
            else
            {
                Node<T> l = p.Left;
                Node<T> r = p.Right;
                if (r == null)
                {
                    return l;
                }

                Node<T> min = FindMin(r);
                min.Right = RemoveMin(r);
                min.Left = l;
                return Balance(min);
            }

            return Balance(p);
        }

        public void Remove(int key)
        {
            root = Remove(root, key);
        }

        private T Contains<T>(Node<T> p, int key)
        {
            if (p == null)
            {
                return default(T);
            }

            if (key < p.Key)
            {
                return Contains(p.Left, key);
            }

            if (key > p.Key)
            {
                return Contains(p.Right, key);
            }

            return p.Item;
        }

        public T Contains(int key)
        {
            return Contains(root, key);
        }

    }
}