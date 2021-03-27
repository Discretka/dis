using System.Collections;

namespace HuffmanCode
{
    public class IntComparer : IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            var num1 = (int) obj1;

            var num2 = (int) obj2;

            return num1 - num2;
        }
    }
}