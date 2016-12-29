using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Containers;

namespace StackAndHeapsTests.UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestClear()
        {
            myStack<int> stack = new myStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);
            stack.Clear();

            Assert.AreEqual(0, stack.Count());
        }
        [TestMethod]
        public void TestClearAddClear()
        {
            myStack<int> stack = new myStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);
            stack.Clear();
            Assert.AreEqual(0, stack.Count());

            stack.Add(4);
            stack.Clear();
            Assert.AreEqual(0, stack.Count());
        }

        [TestMethod]
        public void TestStackSize()
        {
            myStack<int> stack = new myStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);
            stack.Add(4);
            stack.Add(5);

            Assert.AreEqual(5, stack.Count());
        }

        [TestMethod]
        public void TestPopAll()
        {
            var stack = new myStack<int>();
            stack.Add(1);
            stack.Add(2);
            stack.Add(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }
    }
}
