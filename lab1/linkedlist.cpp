#include "linkedlist.h"
#include <iostream>
#include <stdexcept>

using namespace std;

void linked_list::reset()
{
	head = NULL;
	tail = NULL;
	size = 0;
}
linked_list::linked_list()
{
	reset();
}

linked_list::linked_list(int element)
{
	node* current = new node;
	current->data = element;
	current->next = NULL;
	head = current;
	tail = current;
	size++;
}
linked_list::~linked_list()
{
	clear();
}

void linked_list::push_back(int element)
{
	if (tail == NULL)
	{	
		node* current = new node;
		current->data = element;
		current->next = NULL;
		head = current;
		tail = current;
	}
	else 
	{
		node* current = new node;
		current->data = element;
		current->next = NULL;
		tail->next = current;
		tail = current;
	}
	size++;
}
void linked_list::push_front(int element)
{
	if (head == NULL)
	{
		node* current = new node;
		tail = current;
		current->data = element;
		current->next = NULL;
		head = current;
	}
	else
	{
		node* current = new node;
		current->next = head;
		current->data = element;
		head = current;
	}
	size++;
}
void linked_list::pop_back()
{
	if (size == 0) throw out_of_range("\nEmpty list"); // exception
	if (size == 1)
	{
		delete head;
		reset();
		size--;
	}
	else
	{
		node* current = new node;
		current = head;
		while (current->next != tail)
		{
			current = current->next;
		}
		current->next = NULL;
		delete tail;
		tail = current;
		size--;
	}
}
void linked_list::pop_front()
{
	if (size == 0) throw out_of_range("\nEmpty list"); //exception
	if (size == 1)
	{
		delete head;
		reset();
		size--;
	}
	else
	{
		node* current = new node;
		current = head;
		head = head->next;
		delete current; size--;
	}
}
void linked_list::insert(int element, size_t index)
{
	if (index > size)
	{
		throw out_of_range("\nIndex is greater than size of list");
	}
	if (index == 0) 
	{
		push_front(element); 
		size++;
	}
	node* current = new node;
	current = head;
	if (index != 0 && index <= size)
	{
		for (size_t i = 0; i < index - 1; i++) 
		{
			current = current->next;
		}
		node* interposed = new node; 
		interposed->data = element;
		interposed->next = current->next;
		current->next = interposed;
		if (index == size -1)
			tail = current;
		size++;
	}
}
int linked_list::at(size_t index)
{
	node* current = new node;
	current = head;
	if (index >= size) throw out_of_range("\nIndex is greater than size of list");
	else
	{
		for (size_t i = 0; i < index; i++) 
		{
			current = current->next;
		}
		return current->data;
	}
}
void linked_list::remove(size_t index)
{
	if (index >= size) throw out_of_range("Index is greater than size of list");
	if (index != 0)
	{
		if (size == 1 && index == 0)
		{
			delete head;
			reset();
			size--;
		}
		else
		{
			node* current = new node;
			current = head;
			for (size_t i = 0; i < index - 1; i++) 
			{
				current = current->next;
			}
			node* interposed = current->next;
			current->next = interposed->next;
			delete interposed;
			size--;
		}
	}
}
size_t linked_list::get_size()
{
	return size;
}
void linked_list::print_to_console()
{
	if (size < 1) throw out_of_range("List is empty");
	else
	{
		node* current = new node;
		current = head;
		for (size_t i = 0; i < size; i++)
		{
			cout << current->data << " ";
			current = current->next;
		}
	}
}
void linked_list::clear()
{
	node* current = new node;
	current = head;
	size_t sizer = size;
	for (size_t i = 0; i < sizer; i++)
	{
		node* interposed = current;
		current = current->next;
		delete interposed;
		size--;
	}
	reset();
}
void linked_list::set(size_t index, int element)
{
	if (index >= size) throw out_of_range("\nIndex is greater than size of list");
	else
	{
		node* current = new node;
		current = head;
		for (size_t i = 0; i < index; i++) 
		{
			current = current->next;
		}
		current->data = element;
	}
}
bool linked_list::isEmpty()
{
	if (head == NULL) 
		return true;
	else 
		return false;
}
void linked_list::push_back(linked_list* first_list, linked_list* second_list)
{
	if (second_list->size == 0) return;
	if (first_list->tail->next) first_list->tail = first_list->tail->next;
	first_list->tail->next= second_list->head;
	first_list->tail = second_list->tail;
	size += second_list->size;

	second_list->size = 0;
	second_list->head = NULL;
	second_list->head = NULL;
}