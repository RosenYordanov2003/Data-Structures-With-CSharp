namespace Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            //IntegerTreeFactory factory = new IntegerTreeFactory();
            //IntegerTree tree = factory.CreateTreeFromStrings(new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" });
            //Console.WriteLine("Paths from leaf to root with given sum");
            //Console.WriteLine(string.Join(Environment.NewLine, tree.GetPathsWithGivenSum(27).Select(p => string.Join(" ", p))));

            //List<Tree<int>> result = tree.GetSubtreesWithGivenSum(43).ToList();
            //Console.WriteLine("Subtrees with given sum");
            //foreach (Tree<int> treeRooth in result)
            //{
            //    Console.Write($"{treeRooth.Key} ");
            //    foreach (Tree<int> child in treeRooth.Children)
            //    {
            //        Console.Write($"{child.Key} ");
            //    }
            //    Console.WriteLine();
            //}
            int counter = 0;
            int n = 3;
            FactorielCompexity(n, ref counter);
            Console.WriteLine(counter);
        }
        private static void FactorielCompexity(int n, ref int counter)
        {
            if (n == 0)
            {
                Console.WriteLine("You have finished");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                counter++;
                FactorielCompexity(n - 1, ref counter);
            }
        }
    }
}
