namespace Problems.Arrays.Rotation {
    using NUnit.Framework;

    [TestFixture]
    public class FindMaxSumByRotation {

        [TestCase (new int[] { 3, 1, 2 }, ExpectedResult = 8)]
        [TestCase (new int[] { 1, 2, 3, 4 }, ExpectedResult = 20)]
        [TestCase (new int[] { 1, 20, 2, 10 }, ExpectedResult = 72)]
        [TestCase (new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = 330)]
        public int FindMaxSum (int[] a) {

            // given: A{a,b,c,d},n=4
            // r=0: s0= 0a+1b+2c+3d
            // r=1: s1= 0d+1a+2b+3c
            // r=2: s2= 0c+1d+2a+3b
            // d1=s1-s0= (0d+1a+2b+3c)-(0a+1b+2c+3d) = a+b+c-3d = a+b+c+d -4d
            // d2=s2-s1= (0c+1d+2a+3b)-(0d+1a+2b+3c) = a+b-3c+d = a+b+c+d -4c              
            // dj=sj-s{j-1}= a+b+c+d -n*A[n-j]
            // sj=s{j-1}+dj

            int n = a.Length;
            int s = 0; // sum of a[i]*i
            int sum = 0; // sum of a[i]
            for (int i = 0; i < n; i++) {
                s += a[i] * i;
                sum += a[i];
            }

            int maxsum = s;
            int d = 0;
            for (int j = 1; j < n; j++) {
                d = sum - n * a[n - j];
                s = s + d;
                if (s > maxsum)
                    maxsum = s;
            }

            return maxsum;
        }

    }
}