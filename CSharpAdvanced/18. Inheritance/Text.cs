namespace Inheritance
{
    public class Text : PresentationObject
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
        public override void Duplicate()
        {
            Console.WriteLine("Dupplicate this text");
        }
        public void AddHyperLink(string url)
        {
            Console.WriteLine("We added a link to " + url);
        }

        public override void Identify()
        {
            Console.WriteLine("This is text:");
        }
    }
}
