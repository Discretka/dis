#include <iostream>
#include "linkedlist.h"
using namespace std;

int main()
{
	try
	{
		linked_list test;
		test.push_back(3);
		test.push_back(4);
		test.push_front(3);
		test.push_front(7);
		test.push_front(5);
		cout << "index start since zero\n\n";
		cout << "our list:" << endl;
		test.print_to_console();
		cout << "\n\nemoving the last element:" << endl;
		test.pop_back();
		test.print_to_console();
		cout << "\n\nadding element(10) before element with the 3rd index:" << endl;
		test.insert(10, 3);
		test.print_to_console();
		cout << "\n\nremoving element with the 4th index:" << endl;
		test.remove(4);
		test.print_to_console();
		//test.clear(); //
		//cout << "\n\nclearing the list...";
		cout << "\n\neplacing element with index 2 on 7:" << endl;
		test.set(2, 7);
		test.print_to_console();
		linked_list test2;
		test2.push_front(13);
		test2.push_front(14);
		test.push_back(&test, &test2);
		cout << "\n\nadding a list to a list:" << endl;
		cout << endl;
		test.print_to_console();
		test2.push_front(13);
		test2.push_front(14);
		cout << endl;
		cout << endl;
		test.print_to_console();
		cout << endl;
		test2.print_to_console();
		cout << endl;
		cout << endl;
		test2.clear();
		test.print_to_console();
		cout << endl;
		test2.print_to_console();
	}
	catch (out_of_range& e)
	{
		cerr << e.what() << '\n';
	}
	return 0;
}

