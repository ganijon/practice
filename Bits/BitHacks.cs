using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Problems
{
    /// This code inspired by:
    /// http://www.catonmat.net/blog/low-level-bit-hacks
    [TestClass]
    public class BitHacks
    {
        /*  
            &   -  bitwise and
            |   -  bitwise or
            ^   -  bitwise xor
            ~   -  bitwise not
            <<  -  bitwise shift left
            >>  -  bitwise shift right
        */

        // Bit Hack #1. Check if the integer is even or odd.
        public bool CheckIfEven(int x)
        {
            return ((x & 1) == 0);

            /*
                    01111001 (121 in binary)
                &  00000001   
                    --------
                    00000001
            */
        }

        [TestMethod]
        public void Test_CheckIfEvenOrOdd()
        {
            Assert.IsTrue(CheckIfEven(2));
            Assert.IsFalse(CheckIfEven(3));
            Assert.IsTrue(CheckIfEven(4));
            Assert.IsFalse(CheckIfEven(5));
        }

        ///  Bit Hack #2. Check if the n-th bit is set.
        public bool CheckIfNthBitSet(int x, int n)
        {
            // shift the first 1-bit n positions to the left (1 << --n)
            // eliminate all bits but n th (x & (1<<--n))
            // check if result is non-zero
            return (x & (1 << n)) > 0;

            /*
                    11011111     (-33 in binary)
                &  00100000     (1<<5)
                    --------
                    00000000
            */
        }

        [TestMethod]
        public void Test_CheckIfNthBitSet()
        {
            Assert.IsTrue(CheckIfNthBitSet(1, 0));  // 1:  0001
            Assert.IsTrue(CheckIfNthBitSet(2, 1));  // 2:  0010
            Assert.IsTrue(CheckIfNthBitSet(3, 0));  // 3:  0011
            Assert.IsTrue(CheckIfNthBitSet(12, 2)); // 12: 1100
            Assert.IsTrue(CheckIfNthBitSet(18, 1)); // 18: 1110
            Assert.IsTrue(CheckIfNthBitSet(48, 4)); // 48: 0011 0000
            Assert.IsTrue(CheckIfNthBitSet(52, 2)); // 52: 0011 0100
            Assert.IsTrue(CheckIfNthBitSet(122, 3)); // 122: 0111 1010
            Assert.IsFalse(CheckIfNthBitSet(-33, 5)); //-33: 1101 1111
        }

        /// Bit Hack #3. Set the n-th bit.!--
        public int SetTheNthBit(int x, int n)
        {
            return x | (1 << n);

            /* 
                    01111000    (120 in binary)
                |  00000100    (1<<2)
                    --------
                    01111100    
            */
        }

        [TestMethod]
        public void Test_SetTheNthBit()
        {
            Assert.IsTrue(CheckIfNthBitSet(SetTheNthBit(1, 1), 1));
            Assert.IsTrue(CheckIfNthBitSet(SetTheNthBit(2, 2), 2));
            Assert.IsTrue(CheckIfNthBitSet(SetTheNthBit(3, 3), 3));
            Assert.IsTrue(CheckIfNthBitSet(SetTheNthBit(-33, 5), 5));
            Assert.IsTrue(CheckIfNthBitSet(SetTheNthBit(-120, 8), 8));
        }

        /// Bit Hack #4. Unset the n-th bit.
        public int UnsetTheNthBit(int x, int n)
        {
            return x & ~(1 << n);

            /* 
                    01111111    (127 in binary)
                &   11101111    (~(1<<4))
                    --------
                    01101111
            */
        }

        [TestMethod]
        public void Test_UnsetTheNthBit()
        {
            Assert.IsFalse(CheckIfNthBitSet(UnsetTheNthBit(1, 1), 1));
            Assert.IsFalse(CheckIfNthBitSet(UnsetTheNthBit(2, 2), 2));
            Assert.IsFalse(CheckIfNthBitSet(UnsetTheNthBit(3, 3), 3));
            Assert.IsFalse(CheckIfNthBitSet(UnsetTheNthBit(-33, 5), 5));
            Assert.IsFalse(CheckIfNthBitSet(UnsetTheNthBit(-120, 8), 8));
        }

        /// Bit Hack #5. Toggle the n-th bit.
        public int ToggleTheNthBit(int x, int n)
        {
            return x ^ (1 << n);

            /* 
                    01110101
                ^   00100000
                    --------
                    01010101
            */
        }

        [TestMethod]
        public void Test_ToggleTheNthBit()
        {
            Assert.IsTrue(CheckIfNthBitSet(ToggleTheNthBit(1, 1), 1));
            Assert.IsFalse(CheckIfNthBitSet(ToggleTheNthBit(1, 0), 0));

        }

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
    }
}
