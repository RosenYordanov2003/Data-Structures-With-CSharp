namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children;
        private Tree<T> parent;
        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> tree = FindSubTreeByKey(parentKey);

            if (tree is null)
            {
                throw new ArgumentNullException();
            }
            tree.children.Add(child);
            child.parent = tree;
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                Tree<T> currentTree = queue.Dequeue();
                result.Add(currentTree.value);
                foreach (Tree<T> child in currentTree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            List<T> result = new List<T>();

            Dfs(this, result);


            //Stack<T> result = new Stack<T>();
            //Stack<Tree<T>> stack = new Stack<Tree<T>>();
            //stack.Push(this);

            //while (stack.Any())
            //{
            //    Tree<T> currentTree = stack.Pop();
            //    result.Push(currentTree.value);
            //    foreach (Tree<T> child in currentTree.children)
            //    {
            //        stack.Push(child);
            //    }
            //}
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> childTree = FindSubTreeByKey(nodeKey);
            if (childTree is null)
            {
                throw new ArgumentNullException();
            }
            if (childTree.parent == null)
            {
                throw new ArgumentException();
            }
            Tree<T> parentTree = childTree.parent;
            parentTree.children.Remove(childTree);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstTree = FindSubTreeByKey(firstKey);
            Tree<T> secondTree = FindSubTreeByKey(secondKey);

            if (firstTree is null || secondTree is null)
            {
                throw new ArgumentNullException();
            }
            if (firstTree.parent is null || secondTree.parent is null)
            {
                throw new ArgumentException();
            }

            Tree<T> firstParent = firstTree.parent;
            Tree<T> secondParent = secondTree.parent;


            int firstTreeIndex = firstParent.children.IndexOf(firstTree);
            int secondTreeIndex = secondParent.children.IndexOf(secondTree);

            firstParent.children[firstTreeIndex] = secondTree;
            secondParent.children[secondTreeIndex] = firstTree;

        }

        private Tree<T> FindSubTreeByKey(T key)
        {
            // We will find it with BFS Algorithm

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                Tree<T> currentTree = queue.Dequeue();

                if (currentTree.value.Equals(key))
                {
                    return currentTree;
                }
                foreach (Tree<T> child in currentTree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }
        private void Dfs(Tree<T> tree, ICollection<T> list)
        {
            foreach (Tree<T> child in tree.children)
            {
                Dfs(child, list);
            }
            list.Add(tree.value);
        }
    }
}
