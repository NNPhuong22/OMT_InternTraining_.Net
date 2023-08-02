using System.Collections;

namespace ThuatToan
{
    public class Collection
    {
        static void Main2(string[] args)
        {
            Queue myQ = new Queue();
            // Enqueue: thêm phần tử vào cuối queue
            myQ.Enqueue("Hello");
            myQ.Enqueue("World");
            myQ.Enqueue("!");


            Console.WriteLine("myQ");
            // đếm số phần tử 
            Console.WriteLine("\tCount:    {0}", myQ.Count);
            // trả về phần tử đầu tiên và loại ra khỏi queue
            Console.WriteLine(myQ.Dequeue());
            //trả về phần tử đâu tiên
            Console.WriteLine(myQ.Peek());
            //kiểm tra phần tử có trong queue không
            Console.WriteLine(myQ.Contains("Hello"));

            //stack
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");
            myStack.Pop();
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
