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
        public int Find (int[] a) {
            int l = 0;
            int r = a.Length - 1;

            while (l <= r) {
                if (l == r) return a[l];

                int m = (l + r + 1) / 2;

                if (a[l] < a[m])
                    l = m;
                else if (a[m] < a[r])
                    r = m;
                else if (a[m] < a[m - 1])
                    return a[m];
            }

            return -1;
        }
    }
}