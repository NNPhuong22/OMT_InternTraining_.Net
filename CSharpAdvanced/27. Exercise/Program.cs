//namespace Exercise
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var stack = new Stack();
//            stack.Push(1);
//            stack.Push(2);
//            stack.Push(3);
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//        }
//    }
//}

using _27._Exercise;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass sc = new SampleClass();
            IControl ctrl = new SampleClass();
            ISurface srfc = new SampleClass();

            sc.Paint();
            ctrl.Paint();
            srfc.Paint();
            var a = new Class2();
        }

        interface IControl
        {
            void Paint();
        }
        interface ISurface
        {
            void Paint();
        }
        class SampleClass : IControl, ISurface
        {
            public void Paint()
            {
                Console.WriteLine("Paint method in SampleClass");
                Console.ReadKey();
            }
            void IControl.Paint()
            {
                Console.WriteLine("Paint method in IControl");
                Console.ReadKey();
            }

            void ISurface.Paint()
            {
                Console.WriteLine("Paint method in ISurface");
                Console.ReadKey();
            }
        }
    }
}