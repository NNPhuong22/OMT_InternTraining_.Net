namespace Inheritance
{
    public abstract class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract void Identify();
        public virtual void Copy()
        {
            Console.WriteLine("Object copied to clipboard");
        }
        public virtual void Duplicate()
        {
            Console.WriteLine("Object was duplicated");
        }
    }
}
