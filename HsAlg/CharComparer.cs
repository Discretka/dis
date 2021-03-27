using System.Collections;

namespace HuffmanCode
{
    public class CharComparer : IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            var symbol1 = (char) obj1;

            var symbol2 = (char) obj2;

            return symbol1.CompareTo(symbol2);
        }
    }
}