using System.Collections.Generic;
using System.Linq;

namespace LaboratoryWork10
{
    public static class BinaryConverter
    {
        public static int[] Convert(int value)
        {
            var result = new List<int>();
            while (value > 0)
            {
                result.Add(value % 2);
                value /= 2;
            }
            
            return result.ToArray();
        }

        public static int[] Expand(int[] value, int length)
            => value.Concat(Enumerable.Repeat(0, length - value.Length)).ToArray();
    }
}