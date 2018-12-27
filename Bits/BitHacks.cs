using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Problems
{
  [TestClass]
  public class BitHacks
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
      for (int i = 0; i < 32; i++)
      {
        // shift bits to the right (n >> j)
        // drop bits, except the last (... & 1)
        // check if it is 1
        if (1 == (n >> i & 1))
        {
          return i + 1;
        }
      }
      return 0;
    }

    [TestMethod]
    public void Test_FindFirstSetBit()
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

    /// Test if the n-th bit is set.
    //  this solution inspired by:
    /// http://www.catonmat.net/blog/low-level-bit-hacks/
    public bool CheckIfNthBitSet(int x, int n)
    {
      // shift the first 1-bit n-1 positions to the left (1 << --n)
      // eliminate all bits but n-1 th (x & (1<<--n))
      // check if result is non-zero
      return (x & (1 << --n)) > 0;
    }

    [TestMethod]
    public void Test_CheckIfNthBitSet()
    {
      Assert.IsTrue(CheckIfNthBitSet(1, 1));  // 1:  0b 0001
      Assert.IsTrue(CheckIfNthBitSet(2, 2));  // 2:  0b 0010
      Assert.IsTrue(CheckIfNthBitSet(3, 1));  // 3:  0b 0011
      Assert.IsTrue(CheckIfNthBitSet(12, 3)); // 12: 0b 1100
      Assert.IsTrue(CheckIfNthBitSet(18, 2)); // 18: 0b 1110
      Assert.IsTrue(CheckIfNthBitSet(48, 5)); // 48: 0b 0011 0000
      Assert.IsTrue(CheckIfNthBitSet(52, 3)); // 52: 0b 0011 0100
    }
  }
}
