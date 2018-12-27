using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Problems
{
    [TestClass]
    public class FirstSetBit
    {
        /// Given an integer an N, write a program to find the position of first set bit 
        /// found from right side in the binary representation of the number.
        /// https://practice.geeksforgeeks.org/problems/find-first-set-bit/0
        ///   Input: integer N
        ///   Output: integer denoting the position of the first set bit found from the
        ///   right side of the binary representation of the number. 
        ///   If there is no set bit, return 0.
        public int FindFirstSetBit(int n)
        {
            for (int j = 0; j < 32; j++)
            {
                // shift bits to the right (n >> j)
                // drop bits, except the last (... & 1)
                // check if it is 1
                if (1 == (n >> j & 1))
                {
                    return j + 1;
                }
            }
            return 0;
        }

        [TestMethod]
        public void TestDoFind()
        {
            Assert.AreEqual(0, FindFirstSetBit(0));
            Assert.AreEqual(1, FindFirstSetBit(1));  // 1:  0b 0001
            Assert.AreEqual(2, FindFirstSetBit(2));  // 2:  0b 0010
            Assert.AreEqual(1, FindFirstSetBit(3));  // 3:  0b 0011
            Assert.AreEqual(3, FindFirstSetBit(12)); // 12: 0b 1100
            Assert.AreEqual(2, FindFirstSetBit(18)); // 18: 0b 1110
            Assert.AreEqual(5, FindFirstSetBit(48)); // 48: 0b 0011 0000
            Assert.AreEqual(3, FindFirstSetBit(52)); // 52: 0b 0011 0100
        }
    }
}
