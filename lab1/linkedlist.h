#pragma once

class linked_list  //singly linked integer list
{
	private: 
		struct node 
		{
			int data;
			node* next;
		};
		void reset();
		node* head;
		node* tail;
		node* first_element=0;
		size_t kol_vo=0; 
	public:
		void push_back(int); 
		void push_front(int); 
		void pop_back(); 
		void pop_front(); 
		void insert(int, size_t);
		int at(size_t); 
		void remove(size_t); 
		size_t get_size(); 
		void print_to_console(); 
		void clear(); 
		void set(size_t, int); 
		bool isEmpty();
		void push_back1(linked_list*, linked_list*); // 15. push another list to the end of source list
		linked_list(int element); 
		linked_list(); 
		~linked_list(); 
};
