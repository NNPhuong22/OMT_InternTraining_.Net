namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            ////ex1
            ///
            //Console.Write("Start");
            //DateTime start = DateTime.Now;
            //var a = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(a))
            //{
            //    start = DateTime.Now;
            //}
            //Console.Write(" - End: ");
            //DateTime end = DateTime.Now;
            //var b = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(b))
            //{
            //    end = DateTime.Now;
            //}
            //Console.Write(end.Subtract(start));

            //// Ex2

            Post post = new Post()
            {
                CreatedDate = DateTime.Now,
                Description = "Probably and Statistic math",
                Title = "Statistic math",
            };
            post.DownVote();
            post.PrintFullPost();



        }
    }
}