using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LaboratoryWork10
{
    internal class GrayAlgorithmTests
    {
        private static readonly List<int[]> FirstTestData = new List<int[]>
        {
            new[] {0, 0, 0},
            new[] {1, 0, 0},
            new[] {1, 1, 0},
            new[] {0, 1, 0},
            new[] {0, 1, 1}, 
            new[] {1, 1, 1},
            new[] {1, 0, 1},
            new[] {1, 0, 0},
        };

        private static readonly List<int[]> SecondTestData = new List<int[]>
        {
            new[] {0, 0, 0, 0},
            new[] {1, 0, 0, 0},
            new[] {1, 1, 0, 0},
            new[] {0, 1, 0, 0},
            new[] {0, 1, 1, 0},
            new[] {1, 1, 1, 0},
            new[] {1, 0, 1, 0},
            new[] {0, 0, 1, 0},
            new[] {0, 0, 1, 1},
            new[] {1, 0, 1, 1},
            new[] {1, 1, 1, 1},
            new[] {0, 1, 1, 1},
            new[] {0, 1, 0, 1},
            new[] {1, 1, 0, 1},
            new[] {1, 0, 0, 1},
            new[] {0, 0, 0, 1},
        };

        [Test]
        public void CorrectGrayAlgorithm_WhenSequenceLengthIsThree()
        {
            var grayCode = GrayAlgorithm.GetGrayCode(3).ToArray();

            foreach (var code in grayCode)
                for(var j = 0; j < code.Length; ++j)
                    Assert.AreEqual(FirstTestData[j], grayCode[j]);
        }

        [Test]
        public void CorrectGrayAlgorithm_WhenSequenceLengthIsFour()
        {
            var grayCode = GrayAlgorithm.GetGrayCode(4).ToArray();

            foreach (var code in grayCode)
                for (var j = 0; j < code.Length; ++j)
                    Assert.AreEqual(SecondTestData[j], grayCode[j]);
        }
    }
}