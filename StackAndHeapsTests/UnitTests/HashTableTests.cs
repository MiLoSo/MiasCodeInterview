using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndHeaps.Data;

namespace StackAndHeapsTests.UnitTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void AddingToHashTable()
        {
            myHashTable<int> hashTable = new myHashTable<int>();
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(5);

            int length = hashTable.GetArraySize();
            for (int i = 0; i < length; i++)
            {
                int value = hashTable.GetAt(i);
                if (i ==1 || i == 2 || i ==5)
                Assert.AreEqual(i, hashTable.GetAt(i));
            }
        }

        public void RemovingFromHashTable()
        {
            myHashTable<int> hashTable = new myHashTable<int>();
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(3);
            hashTable.Add(4);
            hashTable.Add(5);

            int length = hashTable.GetArraySize();
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(i, hashTable.GetAt(i));
            }

            hashTable.Remove(2);
            hashTable.Remove(3);

            for (int i = 0; i < length; i++)
            {
                int value = hashTable.GetAt(i);
                if (i >= 1 && i <= 2)
                    Assert.AreEqual(i, 0);
                else
                    Assert.AreEqual(i, hashTable.GetAt(i));
            }
        }
    }
}
