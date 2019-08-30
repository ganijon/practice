using System;
namespace Problems.Arrays.Search {
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearch {
        [TestCase (new int[] { }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase (new int[] { 1 }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = 1)]
        public int BinSearch (int[] a, int k) {
            if (a.Length > 0) {
                int l = 0, r = a.Length - 1, m;
                while (l <= r) {
                    m = (l + r) / 2;
                    if (a[m] > k)
                        r = m - 1;
                    else if (a[m] < k)
                        l = m + 1;
                    else return m;
                }
            }
            return -1;
        }

        [TestCase (new int[] { }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase (new int[] { 1 }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = 1)]
        public int BinSearchBottenbruch (int[] a, int k) {
            if (a.Length == 0) return -1;
            int l = 0, r = a.Length - 1, m;
            while (l != r) {
                m = (int) Math.Ceiling ((double) (l + r) / 2);
                if (a[m] > k)
                    r = m - 1;
                else
                    l = m;
            }
            return a[l] == k ? l : -1;
        }

        [TestCase (new int[] { }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase (new int[] { 1 }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = 1)]
        public int BinSearchRecursive (int[] arr, int key) =>
            BinarySearchRecursive (arr, key, 0, arr.Length - 1);
        private int BinarySearchRecursive (int[] arr, int key, int left, int right) {
            if (left > right) return -1;
            int m = (left + right) / 2;
            if (arr[m] < key)
                return BinarySearchRecursive (arr, key, m + 1, right);
            else if (arr[m] > key)
                return BinarySearchRecursive (arr, key, left, m - 1);
            else return m;
        }
    }
}