using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Containers;

namespace StackAndHeapsTests.UnitTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void TestQueueSize()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Count());
        }

        [TestMethod]
        public void TestDequeueSize()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();

            Assert.AreEqual(4, queue.Count());
        }

        [TestMethod]
        public void TestDequeueValue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Count());
            int value = queue.Dequeue();
            Assert.AreEqual(1, value);
            Assert.AreEqual(4, queue.Count());
        }

        [TestMethod]
        public void TestQueuePeek()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Count());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(5, queue.Count());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(4, queue.Count());
        }

        [TestMethod]
        public void TestMultiDequeue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Count());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Count());
        }

        [TestMethod]
        public void TestMultiDequeueTheQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Count());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Count());
            queue.Enqueue(6);
            queue.Enqueue(7);
            Assert.AreEqual(4, queue.Count());
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(6, queue.Dequeue());
            Assert.AreEqual(7, queue.Dequeue());
            Assert.AreEqual(0, queue.Count());
        }
    }
}
