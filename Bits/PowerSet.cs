namespace Problems.Bits {
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class PowerSet {

        [TestCase (ExpectedResult = "{}")]
        [TestCase (1, ExpectedResult = "{}{1}")]
        [TestCase (1, 2, ExpectedResult = "{}{1}{2}{12}")]
        [TestCase (1, 2, 3, ExpectedResult = "{}{1}{2}{12}{3}{13}{23}{123}")]
        public string DoPowerSet (params int[] a) {
            int n = a.Length;
            var p = new int[1 << n][]; // Math.Pow(2,n);

            for (int i = 0; i < p.Length; i++) {
                var subset = new HashSet<int> ();
                for (int j = 0; j < n; j++) {
                    // bitmask of a jth item in input: (1 << j)
                    // presence of jth item in subset: (i & (1<<j)) 
                    // if non-zero, jth item is present in subset
                    if ((i & (1 << j)) > 0) {
                        subset.Add (a[j]);
                    }
                }
                p[i] = subset.ToArray ();
            }

            return Print (p);
        }

        private string Print (int[][] p) {
            var sb = new StringBuilder ();
            foreach (var item in p) {
                sb.Append ("{");
                foreach (var i in item) sb.Append (i);
                sb.Append ("}");
            }
            return sb.ToString ();
        }
    }
}