#include "pch.h"
#include "CppUnitTest.h"
#include "e:\Users\Елена\Desktop\3 сем\прога\аистрд\lab1\linkedlist.h"
#include "e:\Users\Елена\Desktop\3 сем\прога\аистрд\lab1\linkedlist.cpp"
using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTest1)
	{
	public:
		linked_list* test;
		linked_list* test2;
		TEST_METHOD_INITIALIZE(Create)
		{
			test = new linked_list();
			test2 = new linked_list();
		}
		TEST_METHOD_CLEANUP(Clean)
		{
			delete test;
		}
		TEST_METHOD(push_back)
		{
			test->push_front(5);
			test->push_front(3);
			test->push_back(7);
			test->push_front(5);
			test->push_back(2);
			Assert::AreEqual(test->at(1), 3);
			Assert::AreEqual(test->at(3), 7);
		}
		TEST_METHOD(push_front)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			Assert::AreEqual(test->at(1), 10);
			Assert::AreEqual(test->at(3), 4);
		}
		TEST_METHOD(pop_back)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->pop_back();
			Assert::AreEqual((int)test->get_size(), 6);
		}
		TEST_METHOD(pop_front)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->pop_front();
			Assert::AreEqual((int)test->get_size(), 6);
			Assert::AreEqual(test->at(0), 11);
		}
		TEST_METHOD(insert)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->insert(-1, 3);
			Assert::AreEqual(test->at(3), -1);
		}
		TEST_METHOD(at)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			Assert::AreEqual(test->at(1), 11);
			Assert::AreEqual(test->at(0), 0);
			Assert::AreEqual(test->at(6), 8);
		}
		TEST_METHOD(remove)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->remove(2);
			Assert::AreEqual((int)test->get_size(), 6);
			Assert::AreEqual(test->at(2), 2);
		}
		TEST_METHOD(get_size)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			Assert::AreEqual((int)test->get_size(), 7);
		}
		TEST_METHOD(clear)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->clear();
			Assert::AreEqual((int)test->get_size(), 0);
		}
		TEST_METHOD(set)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);
			test->set(2, -1);
			Assert::AreEqual(test->at(2), -1);
		}
		TEST_METHOD(IsEmpty)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->clear();
			Assert::AreEqual((int)test->get_size(), 0);
		}
		TEST_METHOD(push_back1)
		{
			test->push_back(4);
			test->push_front(2);
			test->push_back(1);
			test->push_front(10);
			test->push_back(8);
			test->push_front(11);
			test->push_front(0);

			test2->push_back(4);
			test2->push_front(1);
			test2->push_back(2);
			test->push_back1(test, test2);
			Assert::AreEqual(test->at(8), 4);
		}
	};
}
