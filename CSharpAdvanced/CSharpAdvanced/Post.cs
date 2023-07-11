namespace Exercise
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Votes { get; private set; }

        public void Upvote()
        {
            Votes++;
        }
        public void DownVote() { Votes--; }


        public void PrintFullPost()
        {
            Console.WriteLine("Date Posted: " + CreatedDate.ToLongDateString());
            Console.WriteLine(Title);
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.WriteLine("Votes: " + Votes);

        }
    }
}
