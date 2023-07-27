using ThuatToan;

namespace TestThuatToan
{
    public class Bai111
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            var result = algorithm.Bai111(3);
            Assert.Equal("   \n  *\n ***\n", result);
        }
        [Fact]
        public void Input0()
        {
            var result = algorithm.Bai111(0);
            Assert.Equal("", result);
        }
        [Fact]
        public void InputAm()
        {
            var result = algorithm.Bai111(-1);
            Assert.Equal("", result);
        }
    }
}