using NUnit.Framework;
using BinarySeachTree;

namespace BinarySeachTreeTest
{
    public class BFTTest
    {
        [Test]
        public void NextTest_AddTwoItems_GetSecondItem()
        {
            BinarySeachTree<string> binarySeachTree = new BinarySeachTree<string>();
            binarySeachTree.Insert(2,"second");
            binarySeachTree.Insert(-1,"first");
            
            Iterator<string> iterator = new BFT<string>(binarySeachTree.GetRoot());

            string expected = "first";

            string actual = iterator.Next().Item;
            
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void NextTest_AddFourItem_GetFourthItem()
        {
            BinarySeachTree<string> binarySeachTree = new BinarySeachTree<string>();
            binarySeachTree.Insert(2,"second");
            binarySeachTree.Insert(4,"third");
            binarySeachTree.Insert(-2,"first");
            binarySeachTree.Insert(6,"fourth");
            
            Iterator<string> iterator = new BFT<string>(binarySeachTree.GetRoot());

            string expected = "fourth";

            string actual = null;

            while (iterator.HasNext())
            {
                actual = iterator.Next().Item;

                if (actual == expected)
                {
                    break;
                }
            }
            
            Assert.AreEqual(expected,actual);
        }
    }
    }