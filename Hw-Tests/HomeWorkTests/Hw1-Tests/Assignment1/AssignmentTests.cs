using System;
using Hw1_Tests.Assignment1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyNamespace
{
    [TestClass]
    public class Assignment1Tests
    {
        [TestMethod]
        public void AddToList_1Point()
        {
            IIntegerList list = new IntegerList();
            list.Add(10);

            Assert.AreEqual(10, list.GetElement(0));
            Assert.AreEqual(1, list.Count);

            list.Add(11);
            Assert.AreEqual(10, list.GetElement(0));
            Assert.AreEqual(11, list.GetElement(1));

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void RemoveFromList_1Point()
        {
            IIntegerList list = new IntegerList();
            list.Add(11);
            list.Add(2);
            list.Add(11);

            Assert.AreEqual(false, list.Remove(10));
            Assert.AreEqual(3, list.Count);

            // will remove only first occurence
            Assert.AreEqual(true, list.Remove(11));
            Assert.AreEqual(11, list.GetElement(1));
            Assert.AreEqual(2, list.GetElement(0));
        }

        [TestMethod]
        public void RemoveAtIndex_1Point()
        {
            IIntegerList list = new IntegerList();
            list.Add(11);

            Assert.AreEqual(true, list.RemoveAt(0));
            Assert.AreEqual(0, list.Count);

            list.Add(11);
            list.Add(12);
            list.Add(13);

            Assert.AreEqual(true, list.RemoveAt(1));
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(11, list.GetElement(0));
            Assert.AreEqual(13, list.GetElement(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtIndex_ThrowsIndexOutOfRangeException_1Point()
        {
            IIntegerList list = new IntegerList();
            list.Add(11);

            list.RemoveAt(100);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetElement_ThrowsIndexOutOfRangeException_1Point()
        {
            IIntegerList list = new IntegerList();

            list.GetElement(100);
        }

        [TestMethod]
        public void IndexOf_1Point()
        {
            IIntegerList list = new IntegerList();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(2));
            Assert.AreEqual(-1, list.IndexOf(100));
        }

        [TestMethod]
        public void Count_1Point()
        {
            IIntegerList list = new IntegerList();
            Assert.AreEqual(0, list.Count);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Count);

            list.Remove(3);
            list.Remove(2);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void Clear_1Point()
        {
            IIntegerList list = new IntegerList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Count);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Contains_1Point()
        {
            IIntegerList list = new IntegerList();

            list.Add(11);
            list.Add(22);
            list.Add(33);
            Assert.IsTrue(list.Contains(33));
            Assert.IsTrue(list.Contains(22));
            Assert.IsTrue(list.Contains(11));
            Assert.IsFalse(list.Contains(44));

            list.Clear();
            Assert.IsFalse(list.Contains(33));
        }

        [TestMethod]
        public void ListRebuildTest_1Point()
        {
            IIntegerList list = new IntegerList(100);

            for (int i = 0; i < 100000; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(100000, list.Count);

            for (int i = 0; i < 100000; i++)
            {
                Assert.AreEqual(i, list.GetElement(i));
            }
        }
    }
}