using System.Collections;

namespace FordBellman
{
    public class StrComparer : IComparer
    {
        public int Compare(object? key1, object? key2)
        {
            var strKey1 = (string) key1;
            var strKey2 = (string) key2;

            return strKey1.CompareTo(strKey2);
        }
    }
}