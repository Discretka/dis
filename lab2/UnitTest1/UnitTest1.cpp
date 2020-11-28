#include "pch.h"
#include "CppUnitTest.h"
#include "../lab_2/sorting.h"
#include "../lab_2/sorting.cpp"
using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTestsFor2Lab)
	{
	public:
		int* array;
		char* CharArray;
		TEST_METHOD_INITIALIZE(Create)
		{
			array = new int[10];
			CharArray = new char[14];
		}
		TEST_METHOD_CLEANUP(Clean)
		{
			delete array;
			delete CharArray;
		}
		TEST_METHOD(BinarySearch1)
		{
			array[0] = -1;
			array[1] = 0;
			array[2] = 1;
			array[3] = 2;
			array[4] = 3;
			array[5] = 4;
			array[6] = 5;
			array[7] = 7;
			array[8] = 8;
			array[9] = 9;
			int index = binarySearch(array, 4, 10);
			Assert::AreEqual(index, 5);
		}
		TEST_METHOD(BinarySearch2)
		{
			array[0] = -4;
			array[1] = -2;
			array[2] = 1;
			array[3] = 2;
			array[4] = 3;
			array[5] = 4;
			array[6] = 5;
			array[7] = 7;
			int index = binarySearch(array, -2, 8);
			Assert::AreEqual(index, 1);
		}
		TEST_METHOD(QuickSort1)
		{
			array[0] = -1;
			array[1] = 1;
			array[2] = 0;
			array[3] = 2;
			array[4] = 1;
			array[5] = 5;
			array[6] = 0;
			array[7] = 9;
			QuickSort(array, 0, 8);
			int index = SortingCheck(array, 8);
			Assert::IsTrue(index);
		}
		TEST_METHOD(InsertionSort1)
		{
			array[0] = -1;
			array[1] = 1;
			array[2] = 0;
			array[3] = 2;
			array[4] = 1;
			array[5] = 7;
			array[6] = 6;
			array[7] = 9;
			InsertionSort(array, 8);
			int index = SortingCheck(array, 8);
			Assert::IsTrue(index);
		}
		TEST_METHOD(BogoSort1)
		{
			array[0] = -1;
			array[1] = 1;
			array[2] = 0;
			array[3] = 2;
			array[4] = 1;
			array[5] = 7;
			array[6] = 6;
			array[7] = 9;
			array[8] = 3;
			BogoSort(array, 9);
			int index = SortingCheck(array, 9);
			Assert::IsTrue(index);
		}
		TEST_METHOD(CountingSort1)
		{
			CharArray[0] = 'd';
			CharArray[1] = 'f';
			CharArray[2] = 'a';
			CharArray[3] = 'v';
			CharArray[4] = 'c';
			CharArray[5] = 'e';
			CharArray[6] = 'a';
			CharArray[7] = 't';
			CharArray[8] = 'f';
			CountingSort(CharArray, 9);
			Assert::AreEqual((int)CharArray[1], (int)'a');
			Assert::AreEqual((int)CharArray[7], (int)'t');
		}
		TEST_METHOD(CountingSort2)
		{
			CharArray[0] = 'd';
			CharArray[1] = 'n';
			CharArray[2] = 'k';
			CharArray[3] = 'v';
			CharArray[4] = 's';
			CharArray[5] = 'e';
			CharArray[6] = 'r';
			CharArray[7] = 't';
			CharArray[8] = 'i';
			CountingSort(CharArray, 9);
			Assert::AreEqual((int)CharArray[3], (int)'k');
			Assert::AreEqual((int)CharArray[4], (int)'n');
		}
	};
}
