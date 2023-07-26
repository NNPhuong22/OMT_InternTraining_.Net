namespace ThuatToan
{
    class Program
    {

        static void Main(string[] args)
        {
            // 111
            //   Console.WriteLine("a");
            //   var a = Convert.ToInt32(Console.ReadLine());
            //   for (int i = 0; i < a; i++)
            //   {
            //       for (int j = 0; j < a - i; j++)
            //       {
            //           Console.Write(" ");
            //       }
            //       for (int j = 0; j < 2 * i - 1; j++)
            //       {
            //           Console.Write("*");
            //       }
            //       Console.WriteLine();
            //   }

            //   Console.WriteLine("b");
            //   var b = Convert.ToInt32(Console.ReadLine());
            //   /*
            //                   b=5
            //    *              i=1; j=1  * = 5
            //   * *             i=2; j=2  * = 4 6
            //  *   *            i=3; j=3  * = 3 7
            // *     *           i=4; j=4  * = 2 8
            //*********

            //    */
            //   for (int i = 1; i <= b; i++)
            //   {
            //       for (int j = 1; j < 2 * b; j++)
            //       {
            //           if (Math.Abs(b - j) == i - 1 || i == b)
            //           {
            //               Console.Write("*");
            //           }
            //           else
            //           {
            //               Console.Write(" ");
            //           }
            //       }
            //       Console.WriteLine();
            //   }


            ////c
            //Console.WriteLine("c");
            //var c = Convert.ToInt32(Console.ReadLine());

            //for (int i = 1; i <= c; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}


            ////d
            //Console.WriteLine("d");
            //var d = Convert.ToInt32(Console.ReadLine());

            ///*

            //*
            //* *
            //*   *
            //*     *
            //*********

            // */
            //for (int i = 1; i <= d; i++)
            //{
            //    for (int j = 1; j < 2 * d; j++)
            //    {
            //        if (j == 1 || j == i * 2 - 1)
            //        {
            //            Console.Write("*");
            //        }
            //        else if (i == d)
            //        {
            //            Console.Write(" ");
            //            Console.Write("*");
            //            j++;
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}



            // 112

            ////a
            //int dai = Convert.ToInt32(Console.ReadLine());
            //int rong = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i <= rong; i++)
            //{
            //    for (int j = 1; j <= dai; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}
            //b
            //int dai = Convert.ToInt32(Console.ReadLine());
            //int rong = Convert.ToInt32(Console.ReadLine());

            //for (int i = 1; i <= rong; i++)
            //{
            //    for (int j = 1; j <= dai; j++)
            //    {
            //        if (j == 1 || j == dai || i == 1 || i == rong)
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}


            // 134
            float[] a = { 12, 20, 1, 60 };
            Program ab = new Program();
            Console.WriteLine(lonnhat(a));

        }
        public static float lonnhat(float[] a)
        {
            float max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }
    }
}
