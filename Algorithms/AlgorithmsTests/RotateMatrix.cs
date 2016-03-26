using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class RotateMatrix
    {
        [TestMethod]
        public void Rotate_Test()
        {

            int[][] m = new int[][]
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 6, 7, 8 },
                    new int[] { 9, 10, 11, 12},
                    new int[] { 13,14,15,16}
                };


            int[][] e = new int[][]
            {
                    new int[] { 13, 9, 5, 1 },
                    new int[] { 14, 10, 6, 2 },
                    new int[] { 15, 11, 7, 3},
                    new int[] { 16,12, 8, 4}
            };
            Rotate(m);
            Assert.IsTrue(Equal(m, e));

        }


        private void Rotate(int[][] a)
        {
            int n = a.Length;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - 1; j++)
                {
                    //rotate the 4 elements
                    int t = a[i][i];
                    a[i][j] = a[i][n - j];
                    a[i][n - j] = a[n - i][n - j];
                    a[n - i][n - j] = a[j][n - i];
                    a[j][n - i] = t;
                }
            }
        }

        private bool Equal(int[][] a, int[][] b)
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (a[i][j] != b[i][j])
                        return false;
            return true;
        }
    }
}
