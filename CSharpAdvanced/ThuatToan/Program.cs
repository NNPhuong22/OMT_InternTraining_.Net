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


            //// 134
            //int[] a = { 12, 20, 1, 60 };
            //Console.WriteLine(lonnhat(a));



            ////155
            //int[] a = { 12, -50, 1, 60 };
            //Console.WriteLine(Bai155(a, 15));

            ////233
            //int[] a = { 12, 50, 1, 60, 1, 1, 23 };
            //Bai233(a);

            //// 384
            //int[] a = { 12, 50, 1, 60, 1, 1, 23 };
            //List<int> b = new List<int>();
            //for (int i = 0; i < a.Length; i++)
            //{
            //    while (a[i] != 0)
            //    {
            //        b.Add(a[i] % 10);
            //        a[i] /= 10;
            //    }
            //}
            //Bai384(b);

            // 407
            Bai407(381);


            // 449


        }
        public static int lonnhat(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }
        public static int Bai155(int[] a, int num)
        {
            int max = 0;
            int com = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - num) > com)
                {
                    com = Math.Abs(a[i] - num);
                    max = a[i];

                }
            }
            return max;
        }
        public static void Bai233(int[] arr)
        {
            int[] fr = new int[arr.Length];
            int visited = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                        fr[j] = visited;
                    }
                }
                if (fr[i] != visited)
                    fr[i] = count;
            }

            Console.WriteLine(" gia tri  tan suat");
            for (int i = 0; i < fr.Length; i++)
            {
                if (fr[i] != visited)
                    Console.WriteLine("    " + arr[i] + "         " + fr[i]);
            }
        }
        public static void Bai384(List<int> arr)
        {
            int[] fr = new int[arr.Count];
            int visited = -1;
            int max = 0;
            int number = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                int count = 1;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                        fr[j] = visited;
                    }
                }
                if (fr[i] != visited)
                    fr[i] = count;
            }
            for (int i = 0; i < fr.Length; i++)
            {
                if (fr[i] > max)
                {
                    max = fr[i];
                    number = arr[i];
                }
            }
            Console.WriteLine("Chu so xuat hien nhieu nhat: " + number + " so lan suat hien: " + max);
        }
        public static void Bai407(double number)
        {
            List<int> arr = new List<int>();
            while (Convert.ToInt32(number) != 0)
            {
                arr.Add((int)(number % 10));
                number /= 10;
            }
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write(arr[i]);
            }
        }
    }
}
