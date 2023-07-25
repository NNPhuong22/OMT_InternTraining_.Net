namespace Access_modifier
{
    class InternalEx
    {
        internal void GetInternal() { }
        protected internal void SetInternal() { }
    }
    class InternalTest : InternalEx
    {
        static void Main(string[] args)
        {
            // InternalTest khác assembly với Lib với Assembly hiện tại nên không thể sử dụng được
            //InternalTest internalTest = new InternalTest();

            InternalEx internalEx = new InternalEx();
            internalEx.GetInternal();

            internalEx.SetInternal();
        }
    }
}
