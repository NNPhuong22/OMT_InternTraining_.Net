

namespace ExtensionMethod2
{
    public static class String2
    {
        public static bool CheckNull(this string a)
        {
            bool result = false;
            if (a == null) { result = true; }
            return result;
        }
    }
}
