/// https://www.geeksforgeeks.org/find-minimum-element-in-a-sorted-and-rotated-array/
/// Finding a min element in sorted and rotated array 
/// is esseantially finding a pivot 
/// Time, space complexity: O(n), O(1)

namespace Problems.Arrays.Rotation {
    using NUnit.Framework;

    [TestFixture]
    public class FindMinInSortedRotatedArray {
        [TestCase (new int[] { }, ExpectedResult = -1)]
        [TestCase (new int[] { 0 }, ExpectedResult = 0)]
        [TestCase (new int[] { 1, 0 }, ExpectedResult = 0)]
        [TestCase (new int[] { 2, 0, 1 }, ExpectedResult = 0)]
        [TestCase (new int[] { 1, 2, 0 }, ExpectedResult = 0)]
        [TestCase (new int[] { 1, 2, 3, 0 }, ExpectedResult = 0)]
        [TestCase (new int[] { 2, 3, 0, 1 }, ExpectedResult = 0)]
        [TestCase (new int[] { 3, 0, 1, 2 }, ExpectedResult = 0)]
        [TestCase (new int[] { 4, 0, 1, 2, 3 }, ExpectedResult = 0)]
        [TestCase (new int[] { 0, 1, 2, 3, 4 }, ExpectedResult = 0)]

        public int FindMin (int[] a) {

            int l = 0;
            int r = a.Length - 1;

            // if empty array
            if (a.Length == 0) return -1;

            // if array not rotated
            if (a[l] < a[r]) return a[0];

            while (l <= r) {
                // if only one left
                if (l == r) return a[l];

                int m = (l + r + 1) / 2;

                // drop sorted left side
                if (a[l] < a[m]) l = m;

                // drop sorted right side
                else if (a[m] < a[r]) r = m;

                // if smaller than prev return min/pivot 
                else if (a[m] < a[m - 1])
                    return a[m];
            }

            // shouldn't reach here
            return -1;
        }
    }
}