using System;
using System.Text;
namespace Problems.Arrays.Rotation {
    using NUnit.Framework;

    [TestFixture]
    public class ReversalRotate {

        [TestCase (new int[] { }, 0, ExpectedResult = new int[] { })]
        [TestCase (new int[] { 1 }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase (new int[] { 1, 2, 3, 4 }, 0, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase (new int[] { 1, 2, 3, 4 }, 2, ExpectedResult = new int[] { 3, 4, 1, 2 })]
        public int[] RotateByReversal (int[] a, int d) {
            if (d > a.Length) throw new ArgumentException ($"the value of {nameof(d)} can't be more than lenth of {nameof(a)}");
            if (d == 0) return a;

            ReverseArray (a, start : 0, end : d - 1);
            PrintArray (a);

            ReverseArray (a, start : d, end : a.Length - 1);
            PrintArray (a);

            ReverseArray (a, start : 0, end : a.Length - 1);
            PrintArray (a);
            return a;
        }

        [TestCase (new int[] { }, ExpectedResult = new int[] { })]
        [TestCase (new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase (new int[] { 1, 2 }, 0, 1, ExpectedResult = new int[] { 2, 1 })]
        [TestCase (new int[] { 1, 2, 3 }, 0, 2, ExpectedResult = new int[] { 3, 2, 1 })]
        [TestCase (new int[] { 1, 2, 3, 4 }, 0, 3, ExpectedResult = new int[] { 4, 3, 2, 1 })]
        [TestCase (new int[] { 1, 2, 3, 4, 5 }, 3, 4, ExpectedResult = new int[] { 1, 2, 3, 5, 4 })]
        public int[] ReverseArray (int[] a, int start = 0, int end = 0) {
            if (start < 0 && start >= a.Length) throw new ArgumentException ("invalid start index");
            if (end < start && end >= a.Length) throw new ArgumentException ("invalid end index");
            int i = start;
            int j = end;
            while (i < j) {
                a[i] = a[i] + a[j];
                a[j] = a[i] - a[j];
                a[i] = a[i] - a[j];
                i++;
                j--;
            }
            return a;
        }

        private void PrintArray (int[] a) {
            var sb = new StringBuilder ();
            sb.AppendLine ();
            foreach (var item in a) sb.Append ($"{item}, ");
            Console.WriteLine (sb.Remove (sb.Length - 2, 2).ToString ());
        }
    }
}