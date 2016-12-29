using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Containers;

namespace StackAndHeapsTests.UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void SizeAndContentsTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddHead(1);
            lList.AddHead(2);
            lList.AddHead(3);
            lList.AddHead(4);

            Console.WriteLine("size: " + lList.Size());
            int size = lList.Size();
            Assert.AreEqual(size, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SizeNotNegativeTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            Assert.AreEqual(lList.Size(), 0);
            lList.RemoveFirst(); //remove head
        }

        [TestMethod]
        public void AddAndRemoveTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            Assert.AreEqual(lList.Size(), 0);
            lList.AddHead(1);
            Assert.AreEqual(lList.Size(), 1);
            lList.RemoveFirst();
            Assert.AreEqual(lList.Size(), 0);
        }

        [TestMethod]
        public void AddAndRemoveTailTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddTail(2);
            Assert.AreEqual(lList.Size(), 1);
            lList.RemoveLast();
            Assert.AreEqual(lList.Size(), 0);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddTail(1); // 0
            lList.AddTail(2); // 1
            lList.AddTail(3); // 2
            lList.AddTail(4);
            Assert.AreEqual(lList.Size(), 4);
            lList.RemoveAt(2);
            Assert.AreEqual(lList.Size(), 3);
        }
        [TestMethod]
        public void GetTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddTail(1); // 0
            lList.AddTail(2); // 1
            lList.AddTail(3); // 2
            lList.AddTail(4);

            int value = lList.Get(0);
            Assert.AreEqual(value, 1);
            Assert.AreEqual(lList.Get(lList.Size()-1), 4);
            Assert.AreEqual(lList.Get(2), 3);
        }

        [TestMethod]
        public void GetAndSizeTest()
        {
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddTail(1); // 0
            lList.AddTail(2); // 1
            lList.AddTail(3); // 2
            lList.AddTail(4);
            Assert.AreEqual(4, lList.Size());
            int value = lList.Get(0);
            Assert.AreEqual(value, 1);
            Assert.AreEqual(lList.Get(lList.Size()-1), 4);
            Assert.AreEqual(lList.Get(2), 3);
            Assert.AreEqual(4, lList.Size());
        }
    }
}
