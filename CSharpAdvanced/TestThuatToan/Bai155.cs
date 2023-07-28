using ThuatToan;

namespace TestThuatToan
{
    public class Bai155
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            int[] a = { 1, 25, 88, 5, 3, 75, 4 };
            var result = algorithm.Bai155(a, 1);
            Assert.Equal(88, result);
        }

        [Fact]
        public void NhapInputAm()
        {
            int[] a = { 1, 25, 88, 5, 3, 75, 4 };
            var result = algorithm.Bai155(a, -1);
            Assert.Equal(88, result);
        }
        [Fact]
        public void NhapMangRong()
        {
            int[] a = { };
            var result = algorithm.Bai155(a, -1);
            Assert.Throws<IndexOutOfRangeException>(() => { algorithm.Bai155(a, -1); });
        }

    }
}
