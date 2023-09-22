using System;
using System.Collections.Generic;

namespace Tree
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<string> tree = new Tree<string>("A",
                                        new Tree<string>("B"),
                                        new Tree<string>("C", new Tree<string>("O")),
                                        new Tree<string>("D"));


            Tree<string> tree2 = new Tree<string>("U",
                                             new Tree<string>("V"));
            tree.AddChild("A", tree2);

            tree.Swap("O", "C");

            PrintTreeWithBfsAlgorithm(tree);
        }

        private static void PrintTreeWithBfsAlgorithm<T>(Tree<T> tree)
        {
            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
        }
    }
}
