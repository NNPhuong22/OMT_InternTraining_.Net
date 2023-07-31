using Lambda_Expressions;

namespace LambdaExpressions
{
    class Program
    {
        // gán cho delegate
        public delegate int Caculate(int a, int b);
        static void Main(string[] args)
        {
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));
            var bookList = new BookRepository().GetBooks();
            var goodPrice = bookList.FindAll(IsCheaperThan10);
            foreach (var item in goodPrice)
            {
                Console.WriteLine(item.Title);
            }
            // gán lambda cho func
            Func<int, int, int> caculate = (int x, int y) => { return x + y; };
            // gán lambda cho action 
            Action<int> mess = (int x) => { Console.WriteLine(x); };

            var a = caculate(1, 2);
            mess(a);

            Console.WriteLine(caculate);

            // Lambda expression using in LinQ

            bookList.Where(o => o.Price < 10).ToList();
            bookList.SingleOrDefault(o => o.Title == "Title 1");
        }
        static bool IsCheaperThan10(Book book)
        {
            return book.Price < 10;
        }
    }
}
//dunp@20230721: doc va thuc hanh queue, stack : https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
//dunp: đọc thêm , viết các ví dụ chạy trên console dựa trên https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
