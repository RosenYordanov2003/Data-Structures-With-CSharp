namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; }
        }
        private Node root;
        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }
        //Create a copy for searched node
        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }
            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            List<T> result = this.InOrder(this.root).ToList();

            result.ForEach(x => action.Invoke(x));
        }

        public void Insert(T element)
        {
            this.root = Insert(element, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            //To remove duplicate values
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }
            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
           Node node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }
            return new BinarySearchTree<T>(node);
        }

        private IEnumerable<T> InOrder(Node tree)
        {
            List<T> result = new List<T>();

            if (tree != null)
            {
                if (tree.Left != null)
                {
                    result.AddRange(InOrder(tree.Left));
                }
                result.Add(tree.Value);
                if (tree.Right != null)
                {
                    result.AddRange(InOrder(tree.Right));
                }
            }
            return result;
        }
        private Node FindNode(T element)
        {
            Node current = this.root;
            while (current != null)
            {
                if (element.CompareTo(current.Value) == 0)
                {
                    return current;
                }
                else if (element.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return null;
        }
    }
}
