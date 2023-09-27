namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; set; }

        public IAbstractBinaryTree<T> LeftChild { get; set; }

        public IAbstractBinaryTree<T> RightChild { get; set; }

        public string AsIndentedPreOrder(int indent = 0)
        {
            StringBuilder sb = new StringBuilder();
            BinaryTree<T> current = this;

            PrintTreeInDepth(sb, current, indent);

            return sb.ToString().TrimEnd();
        }

        public void ForEachInOrder(Action<T> action)
        {
            List<IAbstractBinaryTree<T>> traveresedTreeInOrder = InOrder().ToList();

            traveresedTreeInOrder.ForEach(node => action.Invoke(node.Value));
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            InOrderAlgorithm(this, result);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PostOrderAlgorithm(this, result);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

             PreorderAlgorithm(this, result);

            //Another way
            //result.Add(this);
            //if (this.LeftChild != null)
            //{
            //    result.AddRange(this.LeftChild.PreOrder());
            //}
            //if (this.RightChild != null)
            //{
            //    result.AddRange(this.RightChild.PreOrder());
            //}
            return result;
        }


        private void PreorderAlgorithm(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {
            result.Add(binaryTree);

            if (binaryTree != null)
            {
                if (binaryTree.LeftChild != null)
                {
                    PreorderAlgorithm(binaryTree.LeftChild, result);
                }
                if (binaryTree.RightChild != null)
                {
                    PreorderAlgorithm(binaryTree.RightChild, result);
                }
            }
        }
        private void PostOrderAlgorithm(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {
            if (binaryTree != null)
            {
                if (binaryTree.LeftChild != null)
                {
                    PostOrderAlgorithm(binaryTree.LeftChild, result);
                }
                if (binaryTree.RightChild != null)
                {
                    PostOrderAlgorithm(binaryTree.RightChild, result);
                }
                result.Add(binaryTree);
            }
        }
        private void InOrderAlgorithm(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> result)
        {
            if (binaryTree != null)
            {
                if (binaryTree.LeftChild != null)
                {
                    InOrderAlgorithm(binaryTree.LeftChild, result);
                }

                result.Add(binaryTree);

                if (binaryTree.RightChild != null)
                {
                    InOrderAlgorithm(binaryTree.RightChild, result);
                }
            }
        }

        private void PrintTreeInDepth(StringBuilder sb, IAbstractBinaryTree<T> current, int indent)
        {
            if (current != null)
            {
                sb.Append(' ', indent)
               .AppendLine(current.Value.ToString());
            }

            if (current != null)
            {
                if (current.LeftChild != null)
                {
                    PrintTreeInDepth(sb, current.LeftChild, indent + 2);
                }
                if (current.RightChild != null)
                {
                    PrintTreeInDepth(sb, current.RightChild, indent + 2);
                }
            }
        }
    }
}
