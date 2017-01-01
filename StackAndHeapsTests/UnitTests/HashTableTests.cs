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
            myHashTable<string, int> hashTable = new myHashTable<string, int>();
            hashTable.Add("Kasper", 31);
            hashTable.Add("Mia", 26);
            hashTable.Add("Yingmei", 28);
        }

        [TestMethod]
        public void GetValue()
        {
            myHashTable<string, int> hashTable = new myHashTable<string, int>();
            hashTable.Add("Kasper", 31);
            hashTable.Add("Mia", 26);
            hashTable.Add("Yingmei", 28);

            Assert.AreEqual(28, hashTable.Get("Yingmei"));
            Assert.AreEqual(26, hashTable.Get("Mia"));
            Assert.AreEqual(31, hashTable.Get("Kasper"));
        }

        [TestMethod]
        //[ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveKey()
        {
            myHashTable<string, int> hashTable = new myHashTable<string, int>();
            hashTable.Add("Kasper", 31);
            hashTable.Add("Mia", 26);
            hashTable.Add("Yingmei", 28);
            hashTable.Remove("Kasper");

            Assert.AreEqual(28, hashTable.Get("Yingmei"));
            Assert.AreEqual(26, hashTable.Get("Mia"));
            Assert.AreEqual(0, hashTable.Get("Kasper"));//kasper doesn't exist
        }

        [TestMethod]
        //[ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKeyList()
        {
            myHashTable<string, int> hashTable = new myHashTable<string, int>();
            hashTable.Add("Kasper", 31);
            hashTable.Add("Mia", 26);
            hashTable.Add("Yingmei", 28);

            Assert.AreEqual(3, hashTable.GetKeyList().Length);

            string[] a = hashTable.GetKeyList();

            //remove one key, and count again:
            hashTable.Remove("Kasper");
            Assert.AreEqual(2, hashTable.GetKeyList().Length);
        }
    }
}
