using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Problems
{
    [TestClass]
    public class Solutions
    {
        /// https://practice.geeksforgeeks.org/problems/find-first-set-bit/0
        /// Given an integer an N, write a program to find the position of first set bit 
        /// found from right side in the binary representation of the number.
        /// Input: array of integers
        /// Output: array of integers, each item denoting the position of the first set bit found from
        /// the right side of the binary representation of the number. If there is no set bit, return 0.
        public int[] FindFirstSetBit(params int[] input)
        {
            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    // shift bits to the right (n >> j)
                    // drop bits, except the last (n >> j & 1)
                    // check if it is 1
                    if (1 == (input[i] >> j & 1))
                    {
                        output[i] = j + 1;
                        break;
                    }
                }
            }
            return output;
        }

        [TestMethod]
        public void TestDoFind()
        {
            Assert.IsTrue(new int[] {/* empty */}.SequenceEqual(FindFirstSetBit(/* empty */)));
            Assert.IsTrue(new int[] { 1, 2 }.SequenceEqual(FindFirstSetBit(1, 2)));
            Assert.IsTrue(new int[] { 1, 2 }.SequenceEqual(FindFirstSetBit(3, 2)));
            Assert.IsTrue(new int[] { 2, 3 }.SequenceEqual(FindFirstSetBit(18, 12)));
            Assert.IsTrue(new int[] { 5, 3 }.SequenceEqual(FindFirstSetBit(48, 52)));
        }
    }
}
