

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
    }
    //dunp: bài tập: thử viết 1 hàm đưa, 2 string là số , rồi cộng vào nhau , 2 số siêu to 
    //vd CongHaiSo("99999999999999999999999999999999999999999999999999","9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")
}
