using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems.Bits
{
    [TestClass]
    public class PowerSet
    {
        public object[] DoPowerSet(params object[] input)
        {
            int inputSize = input.Length;
            int powersetSize = (1 << inputSize); // Math.Pow(2,n);
            var powerset = new object[powersetSize];

            for (int i = 0; i < powersetSize; i++)
            {
                var subset = new HashSet<object>();
                for (int j = 0; j < inputSize; j++)
                {
                    // bitmask of a jth item in input: (1 << j)
                    // presence of jth item in subset: (i & (1<<j)) 
                    // if non-zero, jth item is present in subset
                    if ((i & (1 << j)) > 0)
                    {
                        subset.Add(input[j]);
                    }
                }
                powerset[i] = subset.ToArray();
            }
            return powerset;
        }
/*
        [TestMethod]
        public void TestDoPowerSet() => Assert.IsTrue(DoPowerSet(1, 2)
              .SequenceEqual(new object[]
              {
                  new object[]{},
                  new object[]{1},
                  new object[]{2},
                  new object[]{1,2},
              }));
*/    }
}