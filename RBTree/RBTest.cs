using System;
using System.Collections.Generic;
using NUnit.Framework;
using RB_Tree;

namespace RB_Tree_Test
{
    public class Tests
    {

        [Test]
        public void Insert_InsertThreeElements_CorrectInsert()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("dog",44);
            
            map.Insert("cat",63);
            
            map.Insert("sun",81);

            var actualCount = map.Count;

            var expectedCount = 3;
            
            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void Clear_InsertTwoElementsAndClear_EmptyMap()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("me",55);
            
            map.Insert("you",43);
            
            map.Clear();

            var actualCount = map.Count;

            var expectedCount = 0;
            
            Assert.AreEqual(expectedCount,actualCount);
        }
        
        [Test]
        public void Find_InsertFiveElements_CorrectValue()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("Me",51);
            
            map.Insert("You",651);
            
            map.Insert("Her",89);
            
            map.Insert("Him",612);
            
            map.Insert("zero",-7);

            var actual = map.Find("Him");

            var expected = 612;
            
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void GetKeys_InsertThreeElements_GetThreeKeys()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("ss",55);
            
            map.Insert("aaa",-723);
            
            map.Insert("zzz",797);

            var actualKeys = map.GetKeys();

            var expectedKeys = new List<string> { "aaa","ss","zzz"};
            
            Assert.IsTrue(AreEqual(expectedKeys,actualKeys,comparer));
        }
        
        private bool AreEqual<T>(IReadOnlyList<T> list1, IReadOnlyList<T> list2,StringComparator comparer)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (comparer.compare(list1[i],list2[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
        
        [Test]
        public void Delete_TryDeleteNoExistElement_Exception()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("kgj",45);
            
            map.Insert("a",21);
            
            map.Insert("vba",90);

            Assert.Throws<Exception>(() => map.Delete("b"));
        }

        [Test]
        public void Print_InsertThreeElements_CorrectPrint()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("tt",145);
            
            map.Insert("bb",323);
            
            map.Insert("gg",476);

            var actualOutput = map.ToString();

            var expectedOutput = "key = bb value = 323\nkey = gg value = 476\nkey = tt value = 145\n";
            
            Assert.AreEqual(expectedOutput,actualOutput);
        }

        [Test]
        public void Delete_InsertSevenElementsAndDeleteFourElements_FindAllElement()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("aa",5);
            
            map.Insert("ab",1);
            
            map.Insert("zzz",9);
            
            map.Insert("4ga",189);
            
            map.Insert("11",22);
            
            map.Insert("bn",56);
            
            map.Insert("az",88);
            
            map.Delete("aa");
            
            map.Delete("ab");
            
            map.Delete("zzz");
            
            map.Delete("bn");

            var actual = map.GetKeys();

            var expected = new List<string> {"11", "4ga","az"};
            
            Assert.IsTrue(AreEqual(actual,expected,comparer));
        }
        
        [Test]
        public void Delete_InsertThreeElementsAndDeleteTwoElements_FindOneElement()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("vga",5);
            
            map.Insert("hj",1);
            
            map.Insert("vbz",9);
            
            map.Delete("vga");
            
            map.Delete("vbz");

            var actual = map.Find("hj");

            var expected = 1;
            
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void GetValues_InsertThreeElements_GetTheeValues()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("Fgd",453);
            
            map.Insert("ddd",123);
            
            map.Insert("czh",532);

            var actualValues = map.GetValues();

            var expectedValues = new List<int> {532, 123, 453};
            
            Assert.IsTrue(IsEqual(actualValues,expectedValues));
        }

        private bool IsEqual(List<int> list1, List<int> list2)
        {
            if (list1 == null || list2 == null)
            {
                return list1 == list2;
            }
            if (list1.Count != list1.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }

            return true;
        }
        
        [Test]
        public void Find_TryFindNoExistElement_Exception()
        {
            var comparer = new StringComparator();
            
            var map = new RbTree<string, int>(comparer);
            
            map.Insert("ffg",45);
            
            map.Insert("acb",21);
            
            map.Insert("hyred",90);
            
            map.Delete("acb");

            Assert.Throws<Exception>(() => map.Find("acb"));
        }
        

    }
}