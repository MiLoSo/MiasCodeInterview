using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Data;

namespace StackAndHeapsTests.UnitTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void PostOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(11);
            tree.Add(3);
            tree.Add(4);
            tree.Add(9);

            int[] values = new int[7];
            int[] expected = new int[7] {3,4,3,9,11,10,5};
            int i = 0;
            tree.nonRecursiveTransversePostOrder((value) => {
                values[i] = value; i++;//Console.WriteLine(value + " ");
            });

            for (int k = 0; k < 7; k++)
            {
                Assert.AreEqual(expected[k], values[k]);
            }
        }

        [TestMethod]
        public void PreOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(11);
            tree.Add(3);
            tree.Add(4);
            tree.Add(9);

            int[] values = new int[7];
            int[] expected = new int[7] {5,3,3,4,10,9,11};
            int i = 0;
            tree.nonRecursiveTransversePreOrder((value) => {
                values[i] = value; i++;//Console.WriteLine(value + " ");
            });

            for (int k = 0; k < 7; k++)
            {
                Assert.AreEqual(expected[k], values[k]);
            }
        }
        [TestMethod]
        public void InOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(11);
            tree.Add(3);
            tree.Add(4);
            tree.Add(9);

            int[] values = new int[7];
            int[] expected = new int[7] {3,3,4,5,9,10,11};
            int i = 0;
            tree.nonRecursiveTraverseInOrder((value) => {
                values[i] = value; i++;//Console.WriteLine(value + " ");
            });

            for (int k = 0; k < 7; k++)
            {
                Assert.AreEqual(expected[k], values[k]);
            }
        }
    }
}
