using System;
using BinarySeachTree;
using NUnit.Framework;

namespace BinarySeachTreeTest
{
    public class QueueTest
    {
        [Test]
        public void PushTest_ThreeTwoItems_FrontGetFirstItem()
        {
            Queue<int> queue = new Queue<int>();
            
            queue.Push(3);
            
            queue.Push(4);
            
            queue.Push(5);

            int actual = queue.Front();

            int expected = 3;
            
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void FrontTest_AddOneItemAndPopOneItem_FrontGetExp()
        {
            Queue<int> queue = new Queue<int>();
            
            queue.Push(3);
            
            queue.Pop();

            Assert.Throws<Exception>(() => queue.Front());
        }

        [Test]
        public void PopTest_PopItemFromEmptyQueue_PopExp()
        {
            Queue<int> queue = new Queue<int>();

            Assert.Throws<Exception>(() => queue.Pop());
        }
    }
}