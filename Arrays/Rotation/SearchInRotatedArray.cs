namespace problems.Arrays.Rotation {
    using NUnit.Framework;

    [TestFixture]
    public class SearchInRotatedArray {
        [TestCase (new int[] { 3, 4, 5, 0, 1, 2 }, 1, ExpectedResult = 1)]
        public int SearchItemInSortedRotatedArray (int[] a, int key) {
            return 0;
        }

        public int FindPivot (int[] a) {
            return -1;
        }

        public int BinarySearch (int[] a, int key) {
            return -1;
        }
    }
}