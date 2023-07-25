// 10. Extension method

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
            double result = 0;
            try
            {
                result = Convert.ToDouble(a) + Convert.ToDouble(b);
            }
            catch (Exception)
            {

                throw;
            }
            return Convert.ToString(result);
        }
    }

    //dunp: bài tập: thử viết 1 hàm đưa, 2 string là số , rồi cộng vào nhau , 2 số siêu to 
    // kết quả là phép cộng của 2 số, chứ không phải cộng chuỗi 
    //vd CongHaiSo("99999999999999999999999999999999999999999999999999","9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")
}
