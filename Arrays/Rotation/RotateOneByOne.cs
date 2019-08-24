    /// https://www.geeksforgeeks.org/array-rotation/

    namespace Problems.Arrays.Rotation {
        using NUnit.Framework;

        [TestFixture]
        public class RotateOneByOne {
            [TestCase (new int[] { 1, 2, 3, 4 }, 0, ExpectedResult = new int[] { 1, 2, 3, 4 })]
            [TestCase (new int[] { 1, 2, 3, 4 }, 1, ExpectedResult = new int[] { 2, 3, 4, 1 })]
            [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = new int[] { 3, 4, 1, 2 })]
            [TestCase (new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = new int[] { 4, 1, 2, 3 })]
            public int[] Rotate (int[] arr, int d) {
                int n = arr.Length;
                int tmp = -1;
                for (int i = 0; i < d; i++) {
                    tmp = arr[0];
                    for (int j = 0; j < n - 1; j++) {
                        arr[j] = arr[j + 1];
                    }
                    arr[n - 1] = tmp;
                }
                return arr;
            }
        }
    }