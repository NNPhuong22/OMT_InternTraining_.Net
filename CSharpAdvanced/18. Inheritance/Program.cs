namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Width = 100;
            text.Copy();
            text.AddHyperLink("Facebook.com");
        }
    }
    //dunp: viết thêm  code về cách dùng abstract  class, method 
}