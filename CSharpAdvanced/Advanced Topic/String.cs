

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
}
