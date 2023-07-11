namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            Shape shape = text;
            text.x = 200;
            shape.x = 100;
            Console.WriteLine(text.x);
        }
    }
}