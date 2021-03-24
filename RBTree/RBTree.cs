using System;
using System.Collections.Generic;

namespace RB_Tree
{
    public class RbTree<T, V>
    {
        private Node<T, V> root;

        private StringComparator comparator;
        
        public int Count { get; set; }

        public RbTree(StringComparator comparator)
        {
            this.comparator = comparator;
        }

        public void Delete(T key)
        {
            var node = Find(root, key);

            if (!IsNodeExist(node, key))
            {
                throw new Exception("element with the same key is not found");
            }

            Count--;

            if (!IsLeftChildExist(node) && !IsRightChildExist(node))
            {
                DeleteWhenZeroChild(node);

                return;
            }

            Node<T, V> nextNode = null;

            if (!IsLeftChildExist(node) || !IsRightChildExist(node))
            {
                DeleteWhenOneChild(node);
            }
            else
            {
                DeleteWhenTwoChild(node, ref nextNode);
            }

            if (nextNode != null && nextNode != node)
            {
                node.IsRed = nextNode.IsRed;

                node.Key = nextNode.Key;
            }

            if (IsBlack(nextNode))
            {
                FixDelete(nextNode);
            }
        }

        public void Clear()
        {
            root = null;

            Count = 0;
        }

        public List<T> GetKeys()
        {
            var keys = new List<T>();

            AddKey(root, keys);

            return keys;
        }

        public List<V> GetValues()
        {
            var values = new List<V>();

            AddValue(root, values);

            return values;
        }

        public void Print()
        {
            var output = ToString();

            Console.WriteLine(output);
        }
        
        public void Insert(T key, V value)
        {
            Count++;

            var newNode = new Node<T, V>(key, value);

            if (root == null)
            {
                newNode.IsRed = false;

                root = newNode;

                return;
            }

            var parent = Find(root, newNode.Key);

            newNode.Parent = parent;

            AddChild(parent,newNode, comparator);

            FixInsert(newNode);
        }

        public override string ToString()
        {
            var keys = GetKeys();

            var values = GetValues();

            var output = "";

            for (var i = 0; i < Count; i++)
            {
                output += $"key = {keys[i]} value = {values[i]}\n";
            }

            return output;
        }
        
        public V Find(T key)
        {
            var node = Find(root, key);

            if (!IsNodeExist(node, key))
            {
                throw new Exception("element with the same key is not found");
            }

            return node.Value;
        }

        private void DeleteWhenZeroChild(Node<T, V> node)
        {
            if (IsRoot(node))
            {
                root = null;
            }
            else
            {
                if (IsLeftChild(node))
                {
                    node.Parent.ChildLeft = null;
                }
                else
                {
                    node.Parent.ChildRight = null;
                }
            }
        }

        private void DeleteWhenOneChild(Node<T, V> node)
        {
            if (IsRoot(node))
            {
                root = node.ChildLeft ?? node.ChildRight;

                return;
            }

            if (!IsLeftChildExist(node))
            {
                if (IsLeftChild(node))
                {
                    node.Parent.ChildLeft = node.ChildLeft;
                }
                else
                {
                    node.Parent.ChildRight = node.ChildLeft;
                }
            }
            else
            {
                if (IsLeftChild(node))
                {
                    node.Parent.ChildLeft = node.ChildRight;
                }
                else
                {
                    node.Parent.ChildRight = node.ChildRight;
                }
            }
        }

        private bool IsRoot(Node<T, V> node)
        {
            return node == root;
        }

        private void DeleteWhenTwoChild(Node<T, V> node, ref Node<T, V> nextNode)
        {
            nextNode = NextNode(node);

            if (!IsRightChildExist(node))
            {
                nextNode.ChildRight.Parent = nextNode.Parent;
            }

            if (IsRoot(nextNode))
            {
                root = nextNode.ChildRight;
            }
            else
            {
                var parent = nextNode.Parent;

                if (IsLeftChild(nextNode))
                {
                    parent.ChildLeft = nextNode.ChildRight;
                }
                else
                {
                    parent.ChildRight = nextNode.ChildRight;
                }
            }
        }

        private void AddKey(Node<T, V> node, List<T> keys)
        {
            if (node == null)
            {
                return;
            }

            AddKey(node.ChildLeft, keys);

            keys.Add(node.Key);

            AddKey(node.ChildRight, keys);
        }

        private void AddValue(Node<T, V> node, List<V> values)
        {
            if (node == null)
            {
                return;
            }

            AddValue(node.ChildLeft, values);

            values.Add(node.Value);

            AddValue(node.ChildRight, values);
        }

        private void FixDelete(Node<T, V> node)
        {
            while (IsBlack(node) && !IsRoot(node))
            {
                if (IsLeftChild(node))
                {
                    var brother = GetBrother(node);

                    if (brother == null)
                    {
                        break;
                    }

                    if (!IsBlack(brother))
                    {
                        brother.IsRed = false;

                        node.Parent.IsRed = true;

                        LeftRotate(node.Parent);
                    }

                    if (IsLeftChildBlack(brother) && IsRightChildBlack(brother))
                    {
                        brother.IsRed = true;
                    }
                    else
                    {
                        if (IsRightChildBlack(brother))
                        {
                            brother.ChildLeft.IsRed = false;

                            brother.IsRed = true;

                            RightRotate(brother);
                        }

                        brother.IsRed = node.Parent.IsRed;

                        node.Parent.IsRed = false;

                        brother.ChildRight.IsRed = false;

                        LeftRotate(node.Parent);

                        node = root;
                    }
                }
                else
                {
                    var brother = GetBrother(node);

                    if (brother == null)
                    {
                        break;
                    }

                    if (!IsBlack(brother))
                    {
                        brother.IsRed = false;

                        node.Parent.IsRed = true;

                        RightRotate(node.Parent);
                    }

                    if (IsLeftChildBlack(brother) && IsRightChildBlack(brother))
                    {
                        brother.IsRed = true;
                    }
                    else
                    {
                        if (IsLeftChildBlack(brother))
                        {
                            brother.ChildRight.IsRed = false;

                            brother.IsRed = true;

                            LeftRotate(brother);
                        }

                        brother = node.Parent;

                        node.Parent.IsRed = false;

                        brother.ChildLeft.IsRed = false;

                        RightRotate(node.Parent);

                        node = root;
                    }
                }
            }

            node.IsRed = false;

            root.IsRed = false;
        }

        private void FixInsert(Node<T, V> newNode)
        {
            var parent = newNode.Parent;

            while (!IsBlack(parent))
            {
                var parentOfParent = parent.Parent;

                if (IsLeftChild(parent))
                {
                    var uncle = parentOfParent.ChildRight;

                    if (uncle != null)
                    {
                        if (!IsBlack(uncle))
                        {
                            parent.IsRed = false;

                            uncle.IsRed = false;

                            parentOfParent.IsRed = true;

                            newNode = parentOfParent;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (IsRightChild(newNode))
                        {
                            newNode = parent;

                            LeftRotate(newNode);
                        }

                        parent.IsRed = false;

                        parentOfParent.IsRed = true;

                        RightRotate(parentOfParent);
                    }
                }
                else
                {
                    var uncle = parentOfParent.ChildLeft;

                    if (uncle != null)
                    {
                        if (!IsBlack(uncle))
                        {
                            parent.IsRed = false;

                            uncle.IsRed = false;

                            parentOfParent.IsRed = true;

                            newNode = parentOfParent;
                        }
                    }
                    else
                    {
                        if (IsLeftChild(newNode))
                        {
                            newNode = parent;

                            RightRotate(newNode);
                        }

                        parent.IsRed = false;

                        parentOfParent.IsRed = true;

                        LeftRotate(parentOfParent);
                    }
                }
            }

            root.IsRed = false;
        }

        private void LeftRotate(Node<T, V> node)
        {
            var isRoot = IsRoot(node);

            var pivot = node.ChildRight;

            pivot.Parent = node.Parent;

            if (node.Parent != null)
            {
                if (IsLeftChild(node))
                {
                    node.Parent.ChildLeft = pivot;
                }
                else
                {
                    node.Parent.ChildRight = pivot;
                }
            }

            node.ChildRight = pivot.ChildLeft;

            if (IsLeftChildExist(pivot))
            {
                pivot.ChildLeft.Parent = node;
            }

            node.Parent = pivot;

            pivot.ChildLeft = node;

            if (isRoot)
            {
                root = pivot;
            }
        }
        
        private bool IsLeftChildExist<T, V>(Node<T, V> node)
        {
            return node?.ChildLeft != null;
        }

        private bool IsRightChildExist<T, V>(Node<T, V> node)
        {
            return node?.ChildRight != null;
        }

        private bool IsLeftChild<T, V>(Node<T, V> node)
        {
            if (node.Parent == null)
            {
                return false;
            }

            return node.Parent.ChildLeft == node;
        }

        private bool IsRightChild<T, V>(Node<T, V> node)
        {
            if (node.Parent == null)
            {
                return false;
            }

            return node.Parent.ChildRight == node;
        }

        private Node<T, V> NextNode<T, V>(Node<T, V> node)
        {
            var child = node.ChildRight;

            while (child.ChildLeft != null)
            {
                child = child.ChildLeft;
            }

            return child;
        }

        private bool IsBlack<T, V>(Node<T, V> node)
        {
            if (node == null)
            {
                return false;
            }

            return node.IsRed == false;
        }

        private Node<T, V> GetBrother<T, V>(Node<T, V> node)
        {
            if (IsLeftChild(node))
            {
                return node.Parent.ChildRight;
            }

            if (IsRightChild(node))
            {
                return node.Parent.ChildLeft;
            }

            return null;
        }

        private bool IsLeftChildBlack<T, V>(Node<T, V> node)
        {
            return IsBlack(node.ChildLeft);
        }

        private bool IsRightChildBlack<T, V>(Node<T, V> node)
        {
            return IsBlack(node.ChildRight);
        }

        private void AddChild<T, V>(Node<T, V> parent, Node<T, V> child, StringComparator comparer)
        {
            var compRes = comparer.compare(parent.Key, child.Key);

            if (compRes < 0)
            {
                parent.ChildRight = child;
            }
            else
            {
                parent.ChildLeft = child;
            }
        }

        private void RightRotate(Node<T, V> node)
        {
            var isRoot = IsRoot(node);

            var pivot = node.ChildLeft;

            pivot.Parent = node.Parent;

            if (node.Parent != null)
            {
                if (IsLeftChild(node))
                {
                    node.Parent.ChildLeft = pivot;
                }
                else
                {
                    node.Parent.ChildRight = pivot;
                }
            }

            node.ChildLeft = pivot.ChildRight;

            if (IsRightChildExist(pivot))
            {
                pivot.ChildRight.Parent = node;
            }

            node.Parent = pivot;

            pivot.ChildRight = node;

            if (isRoot)
            {
                root = pivot;
            }
        }

        private Node<T, V> Find(Node<T, V> current, T key)
        {
            var compRes = comparator.compare(current.Key, key);

            return compRes switch
            {
                -1 => current.ChildRight == null ? current : Find(current.ChildRight, key),
                0 => current,
                1 => current.ChildLeft == null ? current : Find(current.ChildLeft, key)
            };
        }

        private bool IsNodeExist(Node<T, V> node, T key)
        {
            return node != null && comparator.compare(node.Key, key) == 0;
        }
    }
}