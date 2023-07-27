namespace ThuatToan
{
    public class BigNumber
    {
        private List<int> digits;

        public BigNumber(string value)
        {
            digits = new List<int>();

            for (int i = value.Length - 1; i >= 0; i--)
            {
                digits.Add(int.Parse(value[i].ToString()));
            }
        }

        public static BigNumber Add(BigNumber a, BigNumber b)
        {
            List<int> sum = new List<int>();
            int carry = 0;
            int i = 0;

            while (i < a.digits.Count || i < b.digits.Count)
            {
                int x = i < a.digits.Count ? a.digits[i] : 0;
                int y = i < b.digits.Count ? b.digits[i] : 0;
                int s = x + y + carry;

                sum.Add(s % 10);
                carry = s / 10;
                i++;
            }

            if (carry > 0)
            {
                sum.Add(carry);
            }

            BigNumber result = new BigNumber("");

            for (int j = sum.Count - 1; j >= 0; j--)
            {
                result.digits.Add(sum[j]);
            }

            return result;
        }

        public override string ToString()
        {
            string result = "";

            foreach (int digit in digits)
            {
                result += digit.ToString();
            }

            return result;
        }
    }
}

