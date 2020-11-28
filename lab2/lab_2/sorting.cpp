#include <iostream>
#include "sorting.h"
#define charCount 128
using namespace std;
int binarySearch(int *array, int element, int size)
{
	int first = 0, last = size - 1, index;
	while (first <= last)
	{
		index = (first + last) / 2;
		if (array[index] > element)
			last = index - 1;
		else if (array[index] < element)
			first = index + 1;
		if (array[index] == element)
		{
			return index;
			break;
		}
	}
	return index; 
}
void QuickSort(int* array, int start, int size)
{
	int tail = size - 1;
	int head = start;
	int mid = array[(head + tail) / 2];
	do {
		while (array[head] < mid)
			head++;
		while (array[tail] > mid)
			tail--;
		if (head <= tail)
		{
			swap(array[head], array[tail]);
			head++;
			tail--;
		}
	} while (head < tail);
		if (head < size - 1) QuickSort(array, head, size - 1);
		if (tail > start) QuickSort(array, start, tail);
}
void InsertionSort(int* array, int size)
{
	//int current, index;
	for (int i = 0; i < size - 1; i++)
	{
		int index = i;
		while (index > 0 && array[i + 1] < array[i])
		{
			swap(array[i + 1], array[i]);
			index--;
		}
	}
}
void BogoSort(int* array, int size)
{
	int flag = 1;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size - 1; j++)
		{
			if (array[j] > array[j + 1])
			{
				swap(array[j], array[j + 1]);
				j = 0;
			}
		}
	}
}
void CountingSort(char* array, int size)
{
	int max = array[0], min = array[0], i = 0;
	for (i = 0; i < size; i++)
	{
		if (array[i] > max) max = array[i];
		if (array[i] < min) min = array[i];
	}
	int sizeCount = max - min + 1;
	int* NewArray = new int[sizeCount];
	for (i = 0; i < sizeCount; i++)
	{
		NewArray[i] = 0;
	}
	for (i = 0; i < size; i++)
	{
		NewArray[(int)array[i] - min]++;
	}
	int count = 0;
	if (NewArray)
	{
		for (i = 0; i < sizeCount; i++)
			for (int j = 0; j < NewArray[i]; j++)
			{
				array[count] = (char)i + min;
				count++;
			}
	}
}
bool SortingCheck(int* array, int size)
{
	for (int i = 0; i < size - 1; i++)
		if (array[i] > array[i + 1])
		{
			return false; break;
		}
	return true;
}