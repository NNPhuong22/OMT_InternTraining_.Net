using ThuatToan;

namespace TestThuatToan
{
    public class Bai134
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            int[] a = { 1, 25, 88, 5, 3, 75, 4 };
            var result = algorithm.Bai134(a);
            Assert.Equal(88, result);
        }

        [Fact]
        public void NhapInputAm()
        {
            int[] a = { 1, 25, 88, 5, 3, -75, 4 };
            var result = algorithm.Bai134(a);
            Assert.Equal(88, result);
        }
        [Fact]
        public void NhapInputBangNhau()
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0 };
            var result = algorithm.Bai134(a);
            Assert.Equal(0, result);
        }

        [Fact]
        public void NhapInputRong()
        {
            int[] a = { };
            var result = algorithm.Bai134(a);
            Assert.Throws<IndexOutOfRangeException>(() => { algorithm.Bai134(a); });
        }
    }
}
