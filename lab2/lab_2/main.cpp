#include <iostream>
#include "sorting.h"
#include <time.h>
using namespace std;

void Timer(int size, bool flag) 
{
	int* array = new int[size];
	srand(time(0));
	cout << "\nSize = " << size << endl;
	for (int i = 0; i < size; i++)
	{
		array[i] = rand() % 100;
	}
	clock_t start = clock();
	if (flag)
	{
		cout << "\nyou chose the Insertion Sort\n";
		InsertionSort(array, size);
	}
	else
	{
		QuickSort(array, 0, size);
		cout << "\nyou chose the Quick Sort\n" << endl;
	}
	clock_t stop = clock();
	cout << "running time = " << stop - start << "ms" << endl;
}

int main()
{
	char number;
	do
	{
		cout << "\nChoose a sorting method (correct number!):\n" << "1. Quick Sort\n" << "2. Insertion Sort\n";
		cin >> number;
	} while (number != '1' && number != '2');
	if (number == '1') Timer(100000, 0); else Timer(10000, 1);
}