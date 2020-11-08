#include "linkedlist.h"
#include <iostream>
#include <stdexcept>

using namespace std;

void linked_list::reset()
{
	head = NULL;
	tail = NULL;
	kol_vo = 0;
}
linked_list::linked_list()
{
	reset();
}

linked_list::linked_list(int element)
{
	node* first_element = new node;
	first_element->data = element;
	first_element->next = NULL;
	head = first_element;
	tail = first_element;
	kol_vo++;
}
linked_list::~linked_list()
{
	clear();
}

void linked_list::push_back(int element)
{
	if (tail == NULL)
	{	
		node* first_element = new node;
		first_element->data = element;
		first_element->next = NULL;
		head = first_element;
		tail = first_element;
	}
	else 
	{
		node* first_element = new node;
		first_element->data = element;
		first_element->next = NULL;
		tail->next = first_element;
		tail = first_element;
	}
	kol_vo++;
}
void linked_list::push_front(int element)
{
	if (head == NULL)
	{
		node* first_element = new node;
		tail = first_element;
		first_element->data = element;
		first_element->next = NULL;
		head = first_element;	
	}
	else
	{
		node* first_element = new node;
		first_element->next = head;
		first_element->data = element;
		head = first_element;
	}
	kol_vo++;
}
void linked_list::pop_back()
{
	if (kol_vo == 0) throw out_of_range("\nEmpty list"); // exception
	if (kol_vo == 1)
	{
		delete head;
		reset();
		kol_vo--;
	}
	else
	{
		first_element = head;
		while (first_element->next != tail)
		{
			first_element = first_element->next;
		}
		first_element->next = NULL;
		delete tail;
		tail = first_element;
		kol_vo--;
	}
}
void linked_list::pop_front()
{
	if (kol_vo == 0) throw out_of_range("\nEmpty list"); //exception
	if (kol_vo == 1)
	{
		delete head;
		reset();
		kol_vo--;
	}
	else
	{
		first_element = head;
		head = head->next;
		delete first_element; kol_vo--;
	}
}
void linked_list::insert(int element, size_t index)
{
	if (index < 0)
		throw out_of_range("\nIndex is less then 0");
	if (index > kol_vo)
	{
		throw out_of_range("\nIndex is greater than size of list");
	}
	if (index == 0) 
	{
		push_front(element); 
		kol_vo++;
	}
	first_element = head;
	if (index != 0 && index <= kol_vo)
	{
		for (size_t i = 0; i < index - 1; i++) 
		{
			first_element = first_element->next;
		}
		node* interposed = new node; 
		interposed->data = element;
		interposed->next = first_element->next;
		first_element->next = interposed;
		if (index == kol_vo-1)
			tail = first_element; 
		kol_vo++;
	}
}
int linked_list::at(size_t index)
{
	first_element = head;
	if (index < 0) throw out_of_range("\nIndex is less then 0");
	if (index >= kol_vo) throw out_of_range("\nIndex is greater than size of list");
	else
	{
		for (size_t i = 0; i < index; i++) 
		{
			first_element = first_element->next;
		}
		return first_element->data;
	}
}
void linked_list::remove(size_t index)
{
	if (index < 0) throw out_of_range("\nIndex is less then 0");
	if (index >= kol_vo) throw out_of_range("Index is greater than size of list");
	if (index != 0)
	{
		if (kol_vo == 1 && index == 0)
		{
			delete head;
			reset();
			kol_vo--;
		}
		else
		{
			node* first_element = new node;
			first_element = head;
			for (size_t i = 0; i < index - 1; i++) 
			{
				first_element = first_element->next;
			}
			node* interposed = first_element->next;
			first_element->next = interposed->next;
			delete interposed;
			kol_vo--;
		}
	}
}
size_t linked_list::get_size()
{
	return kol_vo;
}
void linked_list::print_to_console()
{
	if (kol_vo < 1) throw out_of_range("List is empty"); 
	else
	{
		first_element = head;
		for (size_t i = 0; i < kol_vo; i++)
		{
			cout << first_element->data << " ";
			first_element = first_element->next;
		}
	}
}
void linked_list::clear()
{
	first_element = head;
	for (size_t i = 0; i < kol_vo; i++) 
	{
		node* interposed = first_element;
		first_element = first_element->next;
		delete interposed;
	}
	reset();
}
void linked_list::set(size_t index, int element)
{
	if (index < 0) throw out_of_range("\nIndex is less then 0");
	if (index >= kol_vo) throw out_of_range("\nIndex is greater than size of list");
	else
	{
		first_element = head;
		for (size_t i = 0; i < index; i++) 
		{
			first_element = first_element->next;
		}
		first_element->data = element;
	}
}
bool linked_list::isEmpty()
{
	if (head == NULL) 
		return true;
	else 
		return false;
}
void linked_list::push_back1(linked_list* first_list, linked_list* second_list)
{
	if (second_list->kol_vo == 0) return;
	if (first_list->tail->next) first_list->tail = first_list->tail->next;
	first_list->tail->next= second_list->head;
	first_list->tail = second_list->tail;
	kol_vo += second_list->kol_vo;
}