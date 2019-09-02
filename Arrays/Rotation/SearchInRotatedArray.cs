namespace Problems.Arrays.Rotation {
    using NUnit.Framework;

    [TestFixture]
    public class SearchInRotatedArray {

        [TestCase (new int[] { }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase (new int[] { 2, 1 }, 1, ExpectedResult = 1)]
        [TestCase (new int[] { 3, 1, 2 }, 1, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3, 4 }, 1, ExpectedResult = 0)]
        [TestCase (new int[] { 2, 3, 4, 1 }, 1, ExpectedResult = 3)]
        [TestCase (new int[] { 3, 4, 1, 2 }, 1, ExpectedResult = 2)]
        [TestCase (new int[] { 4, 1, 2, 3 }, 1, ExpectedResult = 1)]
        public int Search (int[] a, int k) => BinSearchRecursive (a, k, 0, a.Length - 1);

        public int BinSearchRecursive (int[] a, int k, int l, int h) {
            if (l > h) return -1;

            int m = (l + h) / 2;
            if (a[m] == k) return m;

            if (a[l] <= a[m]) {
                if (k >= a[l] && k <= a[m])
                    return BinSearchRecursive (a, k, l, m - 1);
                else
                    return BinSearchRecursive (a, k, m + 1, h);
            } else {
                if (k > a[m] && k < a[h])
                    return BinSearchRecursive (a, k, m + 1, h);
                else
                    return BinSearchRecursive (a, k, l, m - 1);
            }
        }

        [TestCase (new int[] { }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1 }, 0, ExpectedResult = -1)]
        [TestCase (new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = 1)]
        public int BinarySearch (int[] arr, int key) {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right) {
                int mid = (left + right) / 2;
                if (arr[mid] < key)
                    left = mid + 1;
                else if (arr[mid] > key)
                    right = mid - 1;
                else return mid;
            }
            return -1;
        }
    }
}