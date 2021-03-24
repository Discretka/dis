using System;

namespace RB_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = new StringComparator();

                var map = new RbTree<string, int>(input);

                Console.Write("sum of items to insert = ");

                var count1 = Convert.ToInt32(Console.ReadLine());

                for (var i = 0; i < count1; i++)
                {
                    Console.Write("key = ");

                    var key = Console.ReadLine();

                    Console.Write("value = ");

                    var value = Convert.ToInt32(Console.ReadLine());

                    map.Insert(key, value);
                }

                Console.Write("sum of items to delete = ");

                var count2 = Convert.ToInt32(Console.ReadLine());

                for (var i = 0; i < count2; i++)
                {
                    Console.Write("key = ");

                    var key = Console.ReadLine();

                    map.Delete(key);
                }

                Console.Write("sum of items to be found = ");

                var count3 = Convert.ToInt32(Console.ReadLine());

                for (var i = 0; i < count3; i++)
                {
                    Console.Write("key =  ");

                    var key = Console.ReadLine();

                    var value = map.Find(key);

                    Console.WriteLine($"value = {value}");
                }

                Console.WriteLine("\n...output of the resulting items...");

                map.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}