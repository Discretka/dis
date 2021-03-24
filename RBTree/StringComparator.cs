

namespace RB_Tree
{
    public class StringComparator
    {
        public int compare(object? obj1, object? obj2)
        {
            var key1 = (string) obj1;

            var key2 = (string) obj2;
            
            return key1.CompareTo(key2);
        }
    }
}