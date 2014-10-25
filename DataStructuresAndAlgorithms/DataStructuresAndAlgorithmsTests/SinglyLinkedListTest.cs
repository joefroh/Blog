using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresAndAlgorithmsTests
{
    [TestClass]
    public class SinglyLinkedListTest
    {
        [TestMethod]
        public void Constructor()
        {
            var list = new SinglyLinkedList<int>();

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void AddBaseCase()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);

            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));
        }

        [TestMethod]
        public void AddTwo()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);

            Assert.AreEqual(2, list.Length);

            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));

            Assert.AreEqual(1, list.Find(456));
            Assert.AreEqual(456, list.GetValueAtIndex(1));
        }

        [TestMethod]
        public void AddMany()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);
            list.Add(789);

            Assert.AreEqual(3, list.Length);

            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));

            Assert.AreEqual(1, list.Find(456));
            Assert.AreEqual(456, list.GetValueAtIndex(1));

            Assert.AreEqual(2, list.Find(789));
            Assert.AreEqual(789, list.GetValueAtIndex(2));
        }

        [TestMethod]
        public void RemoveValueBase()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            
            Assert.IsTrue(list.Remove(123));
            Assert.AreEqual(0, list.Length);
            Assert.AreEqual(-1, list.Find(123));
        }

        [TestMethod]
        public void RemoveHeadValue()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);

            Assert.IsTrue(list.Remove(123));
            Assert.AreEqual(1,list.Length);
            Assert.AreEqual(0,list.Find(456));
            Assert.AreEqual(456,list.GetValueAtIndex(0));
        }

        [TestMethod]
        public void RemoveTailValue()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);

            Assert.IsTrue(list.Remove(456));
            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));
        }

        [TestMethod]
        public void RemoveMultipleValue()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);
            list.Add(789);

            Assert.IsTrue(list.Remove(456));
            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));
            Assert.AreEqual(1, list.Find(789));
            Assert.AreEqual(789, list.GetValueAtIndex(1));
        }

        [TestMethod]
        public void RemoveIndexBase()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);

            Assert.IsTrue(list.RemoveIndex(0));
            Assert.AreEqual(0, list.Length);
            Assert.AreEqual(-1, list.Find(123));
        }

        [TestMethod]
        public void RemoveIndexHead()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);

            Assert.IsTrue(list.RemoveIndex(0));
            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.Find(456));
            Assert.AreEqual(456, list.GetValueAtIndex(0));
        }

        [TestMethod]
        public void RemoveIndexTail()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);

            Assert.IsTrue(list.RemoveIndex(1));
            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));
        }

        [TestMethod]
        public void RemoveIndexMultiple()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(123);
            list.Add(456);
            list.Add(789);

            Assert.IsTrue(list.RemoveIndex(1));
            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(0, list.Find(123));
            Assert.AreEqual(123, list.GetValueAtIndex(0));
            Assert.AreEqual(1, list.Find(789));
            Assert.AreEqual(789, list.GetValueAtIndex(1));
        }
    }
}