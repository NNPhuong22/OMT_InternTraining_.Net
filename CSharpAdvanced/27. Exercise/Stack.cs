namespace Exercise
{
    class Stack
    {
        private readonly List<object> stackList = new List<object>();
        public void Push(object obj)
        {
            stackList.Add(obj);
        }
        public object Pop()
        {
            if (stackList.Count() >= 1)
            {
                var a = stackList.Last();
                stackList.Remove(a);
                return a;
            }
            return null;
        }
        public void Clear()
        {
            stackList.Clear();
        }
    }
}