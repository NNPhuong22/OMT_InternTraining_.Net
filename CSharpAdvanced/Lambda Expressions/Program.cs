using Lambda_Expressions;

namespace LambdaExpressions
{
    class Program
    {
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
        }
        static bool IsCheaperThan10(Book book)
        {
            return book.Price < 10;
        }
    }
}

//dunp: đọc thêm , viết các ví dụ chạy trên console dựa trên https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
