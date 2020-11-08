#include <iostream>
#include "linkedlist.h"
using namespace std;

int main()
{
	linked_list book;
	book.push_back(3);
	book.push_back(4);
	book.push_front(3);
	book.push_front(7);
	book.push_front(5);
	book.pop_back();
	book.insert(10, 3);
	book.remove(4);
	book.print_to_console();
	//book.clear();
	cout << endl;
	book.set(2, 7);
	book.print_to_console();
	linked_list book2;
	book2.push_front(13);
	book2.push_front(14);
	book.push_back1(&book, &book2);
	cout << endl;
	book.print_to_console();
}

