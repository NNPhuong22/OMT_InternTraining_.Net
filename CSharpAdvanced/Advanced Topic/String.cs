// 10. Extension method

using System.Numerics;

namespace ExtensionMethod
{
    public static class String
    {
        public static bool CheckNull(this string a)
        {
            bool result = false;
            if (a == null) { result = true; }
            return result;
        }
        public static string CongHaiSo(this string a, string b)
        {
            BigInteger result = 0;
            result = BigInteger.Parse(a) + BigInteger.Parse(b);
            return Convert.ToString(result);
        }
    }

    //dunp: bài tập: thử viết 1 hàm đưa, 2 string là số , rồi cộng vào nhau , 2 số siêu to 
    // kết quả là phép cộng của 2 số, chứ không phải cộng chuỗi 
    //vd CongHaiSo("99999999999999999999999999999999999999999999999999","9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")

    //dunp: 20230726# Viết 1 class tương tự như biginterger và không dùng lại class BigInterger hay các thư viện xử lý số lớn. viết các operator +-*/ ( cộng trừ nhân chia cho các class này). 
}
