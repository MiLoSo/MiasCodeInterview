using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Containers.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        [TestMethod()]
        public void verifyEmptyArray()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            Assert.AreEqual(0, array.Size());
        }

        [TestMethod()]
        public void verifyTwoElements()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.AreEqual(3, array.Size());
        }

        [TestMethod()]
        public void verifyGetElements()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.AreEqual(3, array.Size());
            Assert.AreEqual(1, array.Get(0));
            Assert.AreEqual(2, array.Get(1));
            Assert.AreEqual(3, array.Get(2));
            Assert.AreEqual(0, array.Size());
        }

        [TestMethod()]
        public void verifyGetManyElements()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            for (int i = 0; i < 100000; i++)
            {
                array.Add(i);
            }
            Assert.AreEqual(100000, array.Size());
            for (int i = 0; i < 100000; i++)
            {
                Assert.AreEqual(i, array.Get(i));
            }
            Assert.AreEqual(0, array.Size());
        }

        [TestMethod()]
        public void verifyRemove()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            for (int i = 0; i < 100000; i++)
            {
                array.Add(i);
            }
            Assert.AreEqual(100000, array.Size());
            for (int i = 0; i < 100; i++)
            {
                array.Remove(i);
            }
            Assert.AreEqual(100000 - 100, array.Size());
        }

        [TestMethod()]
        public void verifyRemoveThenGet()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            for (int i = 0; i < 100000; i++)
            {
                array.Add(i);
            }
            Assert.AreEqual(100000, array.Size());
            for (int i = 0; i < 100; i++)
            {
                array.Remove(i);
            }
            Assert.AreEqual(100000 - 100, array.Size());
            Assert.AreEqual(100, array.Get(0));
        }

        [TestMethod()]
        public void verifyRemoveThenAdd()
        {
            DynamicArray<int> array = new DynamicArray<int>();
            for (int i = 0; i < 100000; i++)
            {
                array.Add(i);
            }
            Assert.AreEqual(100000, array.Size());
            for (int i = 0; i < 100; i++)
            {
                array.Remove(i);
            }
            for (int i = 0; i < 200; i++)
            {
                array.Add(999999 + i);
            }
            Assert.AreEqual(100000 - 100 + 200, array.Size());
            Assert.AreEqual(100, array.Get(0));
            Assert.AreEqual(999999 + 199, array.Get(array.Size() - 1));
        }
    }
}