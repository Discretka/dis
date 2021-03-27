using System.Collections;

namespace HuffmanCode
{
    public class StrComparer : IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            var str1 = (string) obj1;

            var str2 = (string) obj2;

            return str1.CompareTo(str2);
        }
    }
}