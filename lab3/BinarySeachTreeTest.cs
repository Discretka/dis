using NUnit.Framework;
using BinarySeachTree;

namespace BinarySeachTreeTest
{
    public class BinarySeachTreeTest
    {
        private BinarySeachTree.BinarySeachTree<string> binarySeachTree;
        
        [SetUp]
        public void Setup()
        {
            binarySeachTree = new BinarySeachTree.BinarySeachTree<string>();
        }

        [Test]
        public void ContainsTest_AddZeroItems_GetNull()
        {
            string expected = null;

            string actual = binarySeachTree.Contains(5);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void InsertTest_AddTwoItems_GetFirst()
        {
            binarySeachTree.Insert(3,"second");
            binarySeachTree.Insert(-6,"first");

            string expected = "first";

            string actual = binarySeachTree.Contains(-6);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void InsertTest_TwoIdenticalKeys_GetFirstItem()
        {
            binarySeachTree.Insert(2,"first");
            binarySeachTree.Insert(2,"second");

            string expected = "first";

            string actual = binarySeachTree.Contains(2);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void InsertTest_TwoIdenticalKeysAndRemoveFirst_GetSecond()
        {
            binarySeachTree.Insert(2,"first");
            binarySeachTree.Insert(2,"second");
            
            binarySeachTree.Remove(2);

            string expected = "second";

            string actual = binarySeachTree.Contains(2);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void RemoveTest_AddTwoItemAndRemoveOneItem_GetNull()
        {
            binarySeachTree.Insert(2,"second");
            binarySeachTree.Insert(-7,"first");
            
            binarySeachTree.Remove(-7);

            string expected = null;

            string actual = binarySeachTree.Contains(-7);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void BalanceTest_AddFiveItems_GetThird()
        {
            binarySeachTree.Insert(2,"first");
            binarySeachTree.Insert(3,"second");
            binarySeachTree.Insert(4,"third");
            binarySeachTree.Insert(5,"fourth");
            binarySeachTree.Insert(6,"fifth");
            
            binarySeachTree.Remove(5);

            string expected = "third";

            string actual = binarySeachTree.Contains(4);
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void RemoveTest_RemoveNullItem_NotExp()
        {
            binarySeachTree.Insert(2,"first");
            binarySeachTree.Remove(1);

            string expected = "first";

            string actual = binarySeachTree.Contains(2);
            
            Assert.AreEqual(expected,actual);
        }
    }
}