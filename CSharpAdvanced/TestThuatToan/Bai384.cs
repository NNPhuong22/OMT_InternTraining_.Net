using ThuatToan;

namespace TestThuatToan
{
    public class Bai384
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            List<int> a = new List<int> { 1, 2, 24, 6, 7, 34, 1, 6, 7, 2, 2 };
            var result = algorithm.Bai384(a);
            Assert.Equal(2, result);
        }

        [Fact]
        public void NhapInputAm()
        {
            List<int> a = new List<int> { 0, 0, 0, 0, 0, 0,, 0, 0, 0 };
            var result = algorithm.Bai384(a);
            Assert.Equal(0, result);
        }
        [Fact]
        public void NhapInput0()
        {
            List<int> a = new List<int> { 1, 2, -24, 6, -7, -34, -1, 6, 7, 2, 2 };
            var result = algorithm.Bai384(a);
            Assert.Equal(2, result);
        }
    }
}
