using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLen = 10000;
            int arrRange = 10000000;
            Stopwatch watch = new Stopwatch();
            long mergesorttime;
            long autosorttime;
            int[] arr = new int[arrLen];
            int[] mergeSortArr = new int[arrLen];
            MergeSorter sorter = new MergeSorter();
            Random g = new Random();
            for (int i = 0; i < arrLen; i++)
            {
                arr[i] = g.Next(1, arrRange);
                mergeSortArr[i] = g.Next(1, arrRange);
            }
            watch.Start();
            sorter.MergeSort(mergeSortArr, 0, arrLen - 1);
            watch.Stop();
            mergesorttime = watch.ElapsedMilliseconds;
            watch.Reset();
            watch.Start();
            Array.Sort(arr);
            watch.Stop();
            autosorttime = watch.ElapsedMilliseconds;
        }

    }
    public class MergeSorter
    {
        public void MergeSort(int[] arr, int start, int end)
        {
            if (end > start)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr, (mid + 1), end);
                Merger(arr, start, mid, end);
            }
        }

        public void Merger(int[] arr, int start, int mid, int end)
        {
            int[] temp = new int[(end - start) + 1];

            int i = start;
            int j = mid + 1;
            int k = 0;

            while (i < mid + 1 && j < end + 1)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                    k++;
                }
            }
            //fill in the rest
            while (i <= mid)
            {
                temp[k] = arr[i];
                i++;
                k++;

            }
            while (j <= end)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }
            //now make array the sorted version
            i = start;
            k = 0;
            while (k < temp.Length && i <= end)
            {
                arr[i] = temp[k];
                k++;
                i++;
            }
        }
    }
}
