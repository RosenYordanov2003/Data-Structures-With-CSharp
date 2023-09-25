namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            Queue<List<int>> paths = new Queue<List<int>>();

            List<Tree<int>> leafs = new List<Tree<int>>();
            FindLeafs(this, leafs);

            foreach (Tree<int> leaf in leafs)
            {
                CreatePath(leaf, paths, sum);
            }
            return paths;
        }
        //BFS
        public IEnumerable<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(this);
            List<Tree<int>> result = new List<Tree<int>>();

            while (queue.Any())
            {
                Tree<int> currrentRoot = queue.Dequeue();
                if ((currrentRoot.Children.Sum(x => x.Key) + currrentRoot.Key) == sum)
                {
                    result.Add(currrentRoot);
                }
                foreach (Tree<int> child in currrentRoot.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        private void FindLeafs(Tree<int> tree, List<Tree<int>> leafs)
        {
            if (tree.Children.Count == 0)
            {
                leafs.Add(tree);
            }
            foreach (Tree<int> child in tree.Children)
            {
                FindLeafs(child, leafs);
            }
        }
        private void CreatePath(Tree<int> leaf, Queue<List<int>> path, int sum)
        {
            List<int> trees = new List<int>();
            while (leaf != null)
            {
                trees.Add(leaf.Key);
                leaf = leaf.Parent;
            }
            if (trees.Sum(x => x) == sum)
            {
                trees.Reverse();
                path.Enqueue(trees);
            }
        }
    }
}
