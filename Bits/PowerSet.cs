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
        public string DoPowerSet (params int[] input) {
            int n = input.Length;
            var pwset = new int[1 << n][]; // (1 << n) = Math.Pow(2,n)
            for (int i = 0; i < pwset.Length; i++) {
                var subset = new HashSet<int> ();
                for (int j = 0; j < n; j++) {
                    // bitmask of a jth item in input: (1 << j)
                    // presence of jth item in subset: (i & (1<<j)) 
                    // if non-zero, jth item is present in subset
                    if ((i & (1 << j)) > 0)
                        subset.Add (input[j]);
                }
                pwset[i] = subset.ToArray ();
            }
            return Print (pwset);
        }

        private string Print (int[][] pwset) {
            var s = new StringBuilder ();
            foreach (var arr in pwset) {
                s.Append ("{");
                foreach (var i in arr) s.Append (i);
                s.Append ("}");
            }
            return s.ToString ();
        }
    }
}