using System;

namespace BinarySeachTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySeachTree<string> binarySeachTree = new BinarySeachTree<string>();
            Console.Write("Enter the number of items to add: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the key: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value: ");
                binarySeachTree.Insert(key,Console.ReadLine());
            }
            Console.Write("Enter the number of items to remove: ");
            int m = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                Console.Write("Enter the key to remove: ");
                int key = Convert.ToInt32(Console.ReadLine());
                binarySeachTree.Remove(key);
            }
            Console.Write("Enter the number of items to display: ");
            int d = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < d; i++)
            {
                Console.Write("Enter the key: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(binarySeachTree.Contains(key));
            }
        }
    }
}