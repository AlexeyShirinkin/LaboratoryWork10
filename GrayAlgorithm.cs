using System;
using System.Collections.Generic;

namespace LaboratoryWork10
{
    public static class GrayAlgorithm
    {
        public static IEnumerable<int[]> GetGrayCode(int length)
        {
            var count = (int)Math.Pow(2, length);

            for (var i = 0; i < count; ++i)
            {
                var value = i ^ (i >> 1);
                var binaryValue = BinaryConverter.Convert(value);
                yield return BinaryConverter.Expand(binaryValue, length);
            }
        }
    }
}