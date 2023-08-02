namespace ThuatToan
{
    public class Algorithm
    {
        public string Bai111(int height)
        {
            string triangle = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i; j++)
                {
                    triangle += " ";
                }
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    triangle += "*";
                }
                triangle += "\n";
            }
            return triangle;
        }

        public string Bai112(int dai, int rong)
        {
            string rectangle = "";
            for (int i = 1; i <= rong; i++)
            {
                for (int j = 1; j <= dai; j++)
                {
                    rectangle += "*";
                }
                rectangle += "\n";
            }
            return rectangle;
        }

        public int Bai134(int[] a)
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
        public int Bai155(int[] a, int num)
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
        public IDictionary<int, int> Bai233(int[] a)
        {
            IDictionary<int, int> numFrequency = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!numFrequency.ContainsKey(a[i]))
                {
                    numFrequency.Add(a[i], 0);
                }
                numFrequency[a[i]]++;
            }
            return numFrequency;
        }
        public int Bai384(List<int> arr)
        {
            int[] a = { 12, 50, 1, 60, 1, 1, 23 };
            List<int> b = new List<int>();
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
            return number;
        }
        public int[,] Bai407(int[,] arr, int hang, int cot)
        {

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

            return arr;
        }

        public int[,] Bai449(int[,] arr, int hang)
        {
            int[,] arr2 = new int[3, 3];
            List<int> numList = new List<int>();

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

            return arr2;


        }
    }
}
