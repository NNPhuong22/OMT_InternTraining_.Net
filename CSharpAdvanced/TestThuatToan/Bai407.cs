using ThuatToan;

namespace TestThuatToan
{
    public class Bai407
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            int[,] a = new int[3, 3];
            int[,] b = new int[3, 3];
            a[0, 0] = 2;
            a[0, 1] = 10;
            a[0, 2] = 6;
            a[1, 0] = 5;
            a[1, 1] = 4;
            a[1, 2] = 3;
            a[2, 0] = 9;
            a[2, 1] = 5;
            a[2, 2] = 10;

            b[0, 0] = 2;
            b[0, 1] = 6;
            b[0, 2] = 10;
            b[1, 0] = 3;
            b[1, 1] = 4;
            b[1, 2] = 5;
            b[2, 0] = 5;
            b[2, 1] = 9;
            b[2, 2] = 10;
            var result = algorithm.Bai407(a, 3, 3);
            Assert.Equal(b, result);
        }
        [Fact]
        public void NhapHangCot0()
        {
            int[,] a = new int[0, 0];
            Assert.Throws<IndexOutOfRangeException>(() => { algorithm.Bai407(a, 0, 0); });
        }
    }
}
