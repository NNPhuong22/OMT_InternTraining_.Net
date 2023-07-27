using System.Diagnostics;

namespace ThuatToan
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 111

            //Bai111();

            //// 112

            //Bai112();


            ////// 134

            //Bai134();

            //////155

            //Bai155();

            ////233
            //Bai233();

            //// 384

            //Bai384(b);

            //// 407
            //Bai407();

            // 449
            Bai449();

        }
        //dunp: 20230726# tạo hàm riêng cho các bài 111,112 ... 449 ... rồi gọi hàm trong void main . 


        public static void Bai111()
        {
            Console.WriteLine("a");
            var a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine("b");
            var b = Convert.ToInt32(Console.ReadLine());
            /*
                            b=5
             *              i=1; j=1  * = 5
            * *             i=2; j=2  * = 4 6
           *   *            i=3; j=3  * = 3 7
          *     *           i=4; j=4  * = 2 8
         *********

             */
            for (int i = 1; i <= b; i++)
            {
                for (int j = 1; j < 2 * b; j++)
                {
                    if (Math.Abs(b - j) == i - 1 || i == b)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }


            //c
            Console.WriteLine("c");
            var c = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= c; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


            //d
            Console.WriteLine("d");
            var d = Convert.ToInt32(Console.ReadLine());

            /*

            *
            * *
            *   *
            *     *
            *********

             */
            for (int i = 1; i <= d; i++)
            {
                for (int j = 1; j < 2 * d; j++)
                {
                    if (j == 1 || j == i * 2 - 1)
                    {
                        Console.Write("*");
                    }
                    else if (i == d)
                    {
                        Console.Write(" ");
                        Console.Write("*");
                        j++;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Bai112()
        {
            //a
            int dai = Convert.ToInt32(Console.ReadLine());
            int rong = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= rong; i++)
            {
                for (int j = 1; j <= dai; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            //b

            for (int i = 1; i <= rong; i++)
            {
                for (int j = 1; j <= dai; j++)
                {
                    if (j == 1 || j == dai || i == 1 || i == rong)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Bai134()
        {

            int[] a = { 12, 20, 1, 60 };
            var sw = Stopwatch.StartNew();
            Console.WriteLine(lonnhat(a));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            var sw2 = Stopwatch.StartNew();
            Console.WriteLine(a.Max(x => x));

            sw2.Stop();
            Console.WriteLine(sw2.Elapsed);
        }
        public static void Bai155()
        {
            int[] a = { 12, -50, 1, 60 };

            var sw = Stopwatch.StartNew();
            Console.WriteLine(Bai155(a, 15));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            var sw2 = Stopwatch.StartNew();
            Console.WriteLine(a.MaxBy(o => Math.Abs(15 - o)));
            sw2.Stop();
            Console.WriteLine(sw2.Elapsed);
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
        public static void Bai233()
        {
            //dunp: 20230726# tìm hiểu dictionary để lưu số lần xuất hiện của 1 element cùng value trong mảng
            int[] a = { 12, 50, 1, 60, 1, 1, 23 };
            IDictionary<int, int> numFrequency = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!numFrequency.ContainsKey(a[i]))
                {
                    numFrequency.Add(a[i], 0);
                }
                numFrequency[a[i]]++;
            }
            foreach (KeyValuePair<int, int> kv in numFrequency)
            {
                Console.WriteLine(kv.Key + " - " + kv.Value);
            }
        }
        public static void Bai384(List<int> arr)
        {
            //dunp: 20230726# xem lại bài chưa thấy logic xác định từng chữ số trong số lớn hơn 1 chữ số . 
            int[] a = { 12, 50, 1, 60, 1, 1, 23 };
            List<int> b = new List<int>();

            // em dùng vòng for với while này để tách từng chữ số ở các số rồi cho vào list b ở bên trên ạ
            for (int i = 0; i < a.Length; i++)
            {
                while (a[i] != 0)
                {
                    b.Add(a[i] % 10);
                    a[i] /= 10;
                }
            }

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
        public static void Bai407()
        {
            ////dunp: 20230726# ý bài này là cho 1 ma trận: m*n, n là số dòng, và viết thuật
            //toán để sắp xếp tăng dần cho từng dòng từ trái sang 
            int hang = 0;
            int cot = 0;

            Console.Write("So Hang:");
            hang = Convert.ToInt32(Console.ReadLine());

            Console.Write("So cot:");
            cot = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[hang, cot];


            for (int i = 0; i < hang; i++)
            {

                for (int j = 0; j < cot; j++)
                {
                    Console.Write("arr[{0}][{1}]:", i, j);
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < hang; i++)
            {

                for (int n = 0; n < cot; n++)
                {
                    for (int k = n + 1; k < cot; k++)
                    {
                        if (arr[i, n] > arr[i, k])
                        {
                            int swap = arr[i, n];
                            arr[i, n] = arr[i, k];
                            arr[i, k] = swap;
                        }
                    }
                }

            }

            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    Console.Write(" " + arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void Bai449()
        {
            int hang = 0;
            List<int> numList = new List<int>();
            List<int> newNumList = new List<int>();

            Console.Write("So Hang:");
            hang = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[hang, hang];
            int[,] arr2 = new int[3, 3];

            for (int i = 0; i < hang; i++)
            {

                for (int j = 0; j < hang; j++)
                {
                    Console.Write("arr[{0}][{1}]:", i, j);
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < hang; i++)
            {

                for (int n = 0; n < hang; n++)
                {
                    numList.Add(arr[i, n]);
                }
            }
            for (int i = 0; i < numList.Count; i++)
            {
                for (int j = i + 1; j < numList.Count; j++)
                {
                    if (numList[i] < numList[j])
                    {
                        int temp = numList[i];
                        numList[i] = numList[j];
                        numList[j] = temp;
                    }
                }
            }
            int o = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int n = 0; n < 3; n++)
                {
                    arr2[i, n] = numList[o];
                    o++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + arr2[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
    //dunp: 20230726# chưa thấy bài 449
}
