// 6. Generic

//namespace Generic
//{
//    public class Book
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//    }
//    public class GenericDictionary<Tkey, Tvalue>
//    {
//        public void Add(Tkey key, Tvalue value)
//        {

//        }
//    }
//    public class GenericList<T>
//    {
//        public List<T> Add(T value, List<T> list)
//        {
//            list.Add(value);
//            return list;
//        }
//    }
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var a = new List<Book>();
//            var books = new GenericList<Book>();
//            books.Add(new Book() { Id = 1, Name = "Math" }, a);
//            books.Add(new Book() { Id = 2, Name = "Litterature" }, a);
//            books.Add(new Book() { Id = 3, Name = "English" }, a);
//            foreach (var item in a)
//            {
//                Console.WriteLine(item.Name);
//            }
//        }
//    }
//}


// 7. Delegate

//namespace Event
//{
//    public class Publisher
//    {
//        public delegate void NotifyNews(object data);

//        public NotifyNews event_news;

//        public void Send()
//        {
//            event_news?.Invoke("New notify");
//        }
//    }

//    public class SubscriberA
//    {
//        public void Sub(Publisher p)
//        {
//            p.event_news += ReceiverFromPublisher;
//        }

//        void ReceiverFromPublisher(object data)
//        {
//            Console.WriteLine("SubscriberA: " + data.ToString());
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Publisher p = new Publisher();
//            SubscriberA sa = new SubscriberA();

//            sa.Sub(p);

//            p.Send();
//        }
//    }
//}


// 8. Lambda expression
//namespace Lambda
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Func<int, int> square = number => number * number;
//            Console.WriteLine(square(5));
//        }
//    }
//}


// 9. Event

//namespace Event
//{
//    public class Video
//    {
//        public string Title { get; set; }
//    }
//    public class VideoEncoder
//    {
//        public delegate void VideoEncoderEventHandler(object source, EventArgs args);
//        public event VideoEncoderEventHandler VideoEncoded;
//        public void Encode(Video video)
//        {
//            Console.WriteLine("Encoding video...");
//            Thread.Sleep(3000);
//            OnVideoEncoded();
//        }
//        protected virtual void OnVideoEncoded()
//        {
//            if (VideoEncoded != null)
//            {
//                VideoEncoded(this, EventArgs.Empty);
//            }
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var video = new Video() { Title = "Video 1" };
//            var videoEncoder = new VideoEncoder();
//            var mailService = new MailService();
//            var messageService = new MessageService();

//            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
//            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

//            videoEncoder.Encode(video);
//        }
//    }
//    public class MailService
//    {
//        public void OnVideoEncoded(object source, EventArgs e)
//        {
//            Console.WriteLine("MailService: Sending an email...");
//        }
//    }
//    public class MessageService
//    {
//        public void OnVideoEncoded(object source, EventArgs e)
//        {
//            Console.WriteLine("MessageService: Sending a message...");
//        }
//    }
//}


// 10. Extension method
namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "";
            //ExtensionMethod.String.CheckNull(a);
            //a.CheckNull();
            var a = ExtensionMethod.String.CongHaiSo("99999999999999999999999999999999999999999999999999", "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999");
            Console.WriteLine(a);
        }
    }
}


// 11. LinQ

//namespace LinQ
//{
//    public class Product
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }

//    }
//    public class Program
//    {
//        public static List<Product> Products = new List<Product>() { new Product { Id = 1, Name = "Laptop" },
//            new Product { Id = 1, Name = "TV" },
//            new Product { Id = 1, Name = "Smartphone" }
//    };


//        static void Main(string[] args)
//        {
//            Product a = (Product)Products.Where(o => o.Name == "Laptop").SingleOrDefault();
//            Console.WriteLine(a.Name);
//        }
//    }
//}


// 12. Nullable type
//namespace Nullable
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int? a = null;
//            bool? b = null;
//            DateTime? dateTime = null;
//            Console.WriteLine(a);
//            Console.WriteLine(dateTime);
//        }
//    }
//}


// 13. Dynamic

//namespace Dynamic
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            dynamic a = "adc";
//            dynamic b = 4;
//            dynamic doubleNum = 4.5;
//            dynamic c = a + b;
//            dynamic d = b + doubleNum;
//            Console.WriteLine(c.GetType());
//            Console.WriteLine(d.GetType());
//        }
//    }
//}

// 14. Exception handling

//namespace Exception
//{
//	using System;
//	public static class Calculator
//	{
//		public static double Divine(this ref int a, ref int b) { return a / b; }

//	}
//	public class CalculatorException : Exception
//	{
//		public CalculatorException(string message, Exception innerException) : base(message, innerException) { }
//	}
//	class Program
//	{
//		static void Main(string[] args)
//		{
//			try
//			{
//				int a = 5;
//				int b = 0;
//				double c = a.Divine(ref b);
//				Console.WriteLine(c);
//				throw new Exception("Oops");
//			}
//			catch (Exception ex)
//			{
//				//Console.WriteLine("Can not divine for zero");
//				throw new CalculatorException("Can not divine for zero", ex);
//			}
//		}
//	}
//}


// 15. Asynchronous

//using System.Net;

//namespace Asynchronous
//{
//    public class DownloadAsync
//    {

//        public static async Task DownloadFile(string url)
//        {
//            Action downloadaction = () =>
//            {
//                using (var client = new WebClient())
//                {
//                    Console.WriteLine("Starting download ..." + url);

//                    byte[] data = client.DownloadData(new Uri(url));

//                    string filename = System.IO.Path.GetFileName(url);
//                    System.IO.File.WriteAllBytes(filename, data);
//                }
//            };

//            Task task = new Task(downloadaction);
//            task.Start();

//            await task;
//            Console.WriteLine("Download file complete");
//        }
//        public static async Task AnotherTask()
//        {
//            Console.WriteLine("1. Loading task 2");
//            Console.WriteLine("2. Loading task 2");
//            Console.WriteLine("3. Loading task 2");
//            Console.WriteLine("4. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("5. Loading task 2");
//            Console.WriteLine("123. Loading task 2");
//        }
//        static async Task Main(string[] args)
//        {
//            string url = "https://github.com/microsoft/vscode/archive/1.48.0.tar.gz";
//            var taskdonload = DownloadFile(url);
//            var a = AnotherTask();
//            Console.WriteLine("Downloading...");
//            await Task.WhenAll(taskdonload, a);
//            Console.WriteLine("Download success");
//        }
//    }
//}
