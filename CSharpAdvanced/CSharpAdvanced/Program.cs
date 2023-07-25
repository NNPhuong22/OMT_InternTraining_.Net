namespace ConsoleApplication.lesson07
{
 class IndexersDemo
 {
   int[] aInt;
   public IndexersDemo(int size)
   {
    aInt = new int[size];
   }
   public int this[int index]
   {
    get
    {
     /* return value base on index*/
     return aInt[index];
    }
    set
    {
     /* set the specified index to value here */
     aInt[index] = value;
    }
   }
   static void Main(string[] args)
   {
     const int SIZE = 10;
     IndexersDemo id = new IndexersDemo(SIZE);
     Random r = new Random();
     for (int i = 0; i < SIZE; i++)
     { 
      id[i] = r.Next(1, 20);
     }
     Console.WriteLine("Elements of array ");
     for (int i = 0; i < SIZE; i++)
     {
       Console.Write(id[i] + " ");
     }
     Console.ReadLine();
   }
 }
}