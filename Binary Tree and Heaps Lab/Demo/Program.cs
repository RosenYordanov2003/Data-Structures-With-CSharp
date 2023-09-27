using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;
using System;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(
                        17,
                        new BinaryTree<int>(
                            9,
                            new BinaryTree<int>(3, null, null),
                            new BinaryTree<int>(11, null, null)
                        ),
                        new BinaryTree<int>(
                            25,
                            new BinaryTree<int>(20, null, null),
                            new BinaryTree<int>(31, null, null)
                        ));
            //Post Order
            int[] expected = { 3, 11, 9, 20, 31, 25, 17 };

            var result = tree.PreOrder().Select(x => x.Value);
            Console.WriteLine(string.Join(" ", result));

            //MaxHeap<int> maxHeap = new MaxHeap<int>();
            //maxHeap.Add(4);
            //maxHeap.Add(7);
            //maxHeap.Add(11);
            //maxHeap.Add(18);
            //maxHeap.Add(2);
            //maxHeap.Add(5);
            //maxHeap.Add(8);
            //maxHeap.Add(1);
            //maxHeap.Add(21);

            //maxHeap.ExtractMax();
        }
    }
}