namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = children.ToList() ?? new List<Tree<T>>();
            foreach (Tree<T> child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }
        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();

            Dfs(this, sb, 0);

            return sb.ToString().TrimEnd();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            List<T> result = new List<T>();

            FindNodesDfs(result, this, (tree) => tree.children.Count > 0 && tree.Parent != null);

            return result;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            List<T> result = new List<T>();

            FindNodesDfs(result, this, (tree) => tree.children.Count == 0);

            return result;
        }

        public T GetDeepestKey()
        {
            List<Tree<T>> result = new List<Tree<T>>();
            GetAllLeafElements(this, result);

            int maxDepth = int.MinValue;
            Tree<T> deepestTree = null;
            foreach (Tree<T> leaf in result)
            {
                int depth = FindDepth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestTree = leaf;
                }
            }
            return deepestTree.Key;
        }


        public IEnumerable<T> GetLongestPath()
        {
            List<Tree<T>> leafs = new List<Tree<T>>();
            Stack<T> path = new Stack<T>();
            GetAllLeafElements(this, leafs);

            int maxDepth = int.MinValue;

            foreach (Tree<T> leaf in leafs)
            {
                int currentDepth = FindDepth(leaf);
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    path.Clear();
                    CreatePath(leaf, path);
                }
            }
            return path.ToArray();

        }
        private int FindDepth(Tree<T> leaf)
        {
            int counter = 0;
            while (leaf.Parent != null)
            {
                leaf = leaf.Parent;
                counter++;
            }
            return counter;
        }
        private void CreatePath(Tree<T> leaf, Stack<T> path)
        {
            while (leaf != null)
            {
                path.Push(leaf.Key);
                leaf = leaf.Parent;
            }
        }
        private void Dfs(Tree<T> tree, StringBuilder sb, int depth)
        {
            sb.Append(' ', depth)
                .AppendLine(tree.Key.ToString());

            foreach (Tree<T> child in tree.Children)
            {
                Dfs(child, sb, depth + 2);
            }
        }
        private void FindNodesDfs(List<T> result, Tree<T> tree, Predicate<Tree<T>> predicate)
        {
            if (predicate.Invoke(tree))
            {
                result.Add(tree.Key);
            }
            foreach (Tree<T> child in tree.Children)
            {
                FindNodesDfs(result, child, predicate);
            }
        }
        private void GetAllLeafElements(Tree<T> tree, List<Tree<T>> result)
        {
            if (tree.children.Count == 0)
            {
                result.Add(tree);
            }
            foreach (Tree<T> child in tree.children)
            {
                GetAllLeafElements(child, result);
            }
        }

    }
}
