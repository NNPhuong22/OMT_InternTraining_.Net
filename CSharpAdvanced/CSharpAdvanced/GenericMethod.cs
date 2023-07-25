namespace Generic
{
    class GenericMethod
    {
        public class GenericList<T>
        {
            public void Print(T value)
            {
                Console.WriteLine(value);
            }
            public T this[int index]
            {
                //dunp: cái này là gì, và dùng như thế nào , trả lời = comment ở đây, và viết ví dụ dùng ở console

                /* Generic dùng để tùy biến các tham số truyền vào ở các dạng khác nhau. ví dụ 1 hàm add bình thường thì với mỗi loại tham số 
                truyền vào như string, int, double,..... thì phải viết từng hàm riêng để truyền tham số vào, làm phình code lên. Dùng generic 
                ta có thể định nghĩa kiểu tham số truyền vào khi sử dụng.
                 */

                // khi trong hàm chưa có code và chưa return lại gì thì dùng NotImplementedException() để không bị lỗi trong compile time
                //dunp: hàm này   public T this[int index] được gọi là gì, và dùng ntn trong C#
                
                get { throw new NotImplementedException(); }
            }
        }
        class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericMethod = new GenericList<int>();
            genericMethod.Print(9);


        }
    }
    }
     
}
