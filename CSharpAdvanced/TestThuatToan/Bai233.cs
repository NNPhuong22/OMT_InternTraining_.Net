using ThuatToan;

namespace TestThuatToan
{
    public class Bai233
    {
        Algorithm algorithm = new Algorithm();

        [Fact]
        public void NhapDungInput()
        {
            int[] a = { 1, 25, 88, 5, 3, 75, 4 };
            var result = algorithm.Bai233(a);
            IDictionary<int, int> numFrequency = new Dictionary<int, int>();
            Assert.Equal(numFrequency, result);
        }
        [Fact]
        public void NhapInputAm()
        {
            int[] a = { 1, 25, -88, 5, 3, -75, 4 };
            var result = algorithm.Bai233(a);
            IDictionary<int, int> numFrequency = new Dictionary<int, int>();
            Assert.Equal(numFrequency, result);
        }
        [Fact]
        public void InputRong()
        {
            int[] a = { };
            var result = algorithm.Bai233(a);
            IDictionary<int, int> numFrequency = new Dictionary<int, int>();
            Assert.Throws<IndexOutOfRangeException>(() => { algorithm.Bai233(a); });
        }

    }
}
