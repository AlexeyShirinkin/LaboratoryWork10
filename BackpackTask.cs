using System;
using System.Collections.Generic;
using System.Linq;

namespace LaboratoryWork10
{
    public static class BackpackTask
    {
        public static void Solve(List<Subject> subjects, int maxWeight)
        {
            var weight = 0;
            var bestCost = 0;
            var bestWeight = 0;

            var previousBits = BinaryConverter.Expand(BinaryConverter.Convert(0), subjects.Count);
            var bestMask = previousBits;

            foreach (var currentBits in GrayAlgorithm.GetGrayCode(subjects.Count).Skip(1))
            {
                var (index, isOne) = GetIndexOfDifference(previousBits, currentBits);
                previousBits = currentBits;

                if (isOne)
                    weight += subjects[index].Weight;
                else weight -= subjects[index].Weight;

                if (weight > maxWeight)
                    continue;

                var cost = subjects.Where((t, i) => currentBits[i] == 1).Sum(x => x.Cost);

                if (cost <= bestCost)
                    continue;
                bestCost = cost;
                bestMask = currentBits;
                bestWeight = weight;
            }

            Console.WriteLine("Max weight: " + bestWeight);
            Console.WriteLine("Max cost: " + bestCost);
            Console.Write("Using weights: ");
            for (var i = 0; i < subjects.Count; i++)
                if (bestMask[i] == 1)
                    Console.Write(subjects[i].Weight + " ");
            Console.WriteLine();
        }

        private static (int, bool) GetIndexOfDifference(int[] previousBits, int[] currentBits)
        {
            for (var i = 0; i < previousBits.Length; ++i)
                if (previousBits[i] != currentBits[i])
                    return (i, currentBits[i] == 1);
            return (0, true);
        }
    }
}
