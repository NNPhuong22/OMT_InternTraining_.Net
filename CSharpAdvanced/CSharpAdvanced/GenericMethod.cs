namespace Generic
{
    class GenericMethod
    {
        public class GenericList<T>
        {
            public void Add(T value)
            {

            }
            public T this[int index]
            {
                get { throw new NotImplementedException(); }
            }
        }

    }
}
