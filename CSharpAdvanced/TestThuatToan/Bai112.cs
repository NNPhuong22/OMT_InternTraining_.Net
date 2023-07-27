using ThuatToan;

namespace TestThuatToan
{
    public class Bai112
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            var result = algorithm.Bai112(4, 3);
            Assert.Equal("****\n****\n****\n", result);
        }
        [Fact]
        public void Input0Ca2Canh()
        {
            var result = algorithm.Bai112(0, 0);
            Assert.Equal("", result);
        }
        [Fact]
        public void Input0ChieuDai()
        {
            var result = algorithm.Bai112(0, 6);
            Assert.Equal("", result);
        }
        [Fact]
        public void Input0ChieuRong()
        {
            var result = algorithm.Bai112(6, 0);
            Assert.Equal("", result);
        }
        [Fact]
        public void InputAm()
        {
            var result = algorithm.Bai112(-1, -1);
            Assert.Equal("", result);
        }
    }
}
