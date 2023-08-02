using System.Diagnostics;

namespace ThuatToan
{
    public class TestExecutionTimeSort
    {

        static void Main(string[] args)
        {
            Sort sort = new Sort();
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            var sw = Stopwatch.StartNew();
            sort.BubbleSort(arr);
            sw.Stop();
            Console.WriteLine("Bubble sort: " + sw.Elapsed);

            var sw2 = Stopwatch.StartNew();
            sort.InsertionSort(arr);
            sw.Stop();
            Console.WriteLine("Insertion sort: " + sw2.Elapsed);

            var sw3 = Stopwatch.StartNew();
            sort.SelectionSort(arr);
            sw.Stop();
            Console.WriteLine("Selection sort: " + sw3.Elapsed);
        }
    }
    public class Sort
    {
        public void Swap(int[] array, int i, int m)
        {
            int temp = array[i];
            array[i] = array[m];
            array[m] = temp;
        }
        public int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int m = i;
                int minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        m = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, m);
            }
            return array;
        }
        public int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
            return array;
        }

        public int[] BubbleSort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
            return array;
        }
    }
}
