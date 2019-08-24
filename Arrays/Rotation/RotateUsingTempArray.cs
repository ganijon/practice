    /// https://www.geeksforgeeks.org/array-rotation/

    namespace Problems.Arrays.Rotation {
        using NUnit.Framework;

        [TestFixture]
        public class RotateUsingTempArray {
            [TestCase (new int[] { 1, 2, 3, 4 }, 4, 3, ExpectedResult = new int[] { 4, 1, 2, 3 })]
            [TestCase (new int[] { 1, 2, 3, 4 }, 4, 2, ExpectedResult = new int[] { 3, 4, 1, 2 })]
            [TestCase (new int[] { 1, 2, 3, 4 }, 4, 1, ExpectedResult = new int[] { 2, 3, 4, 1 })]
            // Time compexity O(n)
            // Additional space O(d)
            public int[] Rotate (int[] arr, int n, int d) {
                int[] tmp = new int[d];
                for (int i = 0; i < d; i++) {
                    tmp[i] = arr[i];
                }
                for (int j = d; j < n; j++) {
                    arr[j - d] = arr[j];
                }
                for (int k = 0; k < d; k++) {
                    arr[n - d + k] = tmp[k];
                }
                return arr;
            }
        }
    }