using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void MergeSort_Test()
        {
            int[] arr = GenerateArrray(4192);
            MergeSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
            //sort an already sorted array
            MergeSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
            //reverse and sort again
            Reverse(arr);
            MergeSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);

            arr = GenerateArrray(1);
            MergeSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
        }

        private void Reverse(int[] nums)
        {
            for (int i = 0; i < nums.Length / 2; i++)
            {
                int t = nums[i];
                nums[i] = nums[nums.Length - i - 1];
                nums[nums.Length - i - 1] = t;
            }
        }

        [TestMethod]
        public void QuickSort_Test()
        {
            int[] arr = GenerateArrray(4);
            QuickSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
            //sort an already sorted array
            QuickSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
            //reverse and sort again
            Reverse(arr);
            QuickSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);

            arr = GenerateArrray(1);
            QuickSort(arr, 0, arr.Length - 1);
            ValidateISSrotedDesc(arr);
        }

        public void QuickSort(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int p = Partition(nums, l, r);
                QuickSort(nums, l, p);
                QuickSort(nums, p + 1, l);
            }
        }

        private int Partition(int[] nums, int l, int r)
        {
            int p = nums[(l + r) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {

                while (i<=r && nums[i] < p) i++;
                while (j>=l && nums[j] > p) j--;

                if (i <= j)
                {
                    int t = nums[i];
                    nums[i] = nums[j];
                    nums[j] = t;

                    i++;
                    j--;
                }
            }
            return i;
        }

        public void MergeSort(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSort(nums, l, m);
                MergeSort(nums, m + 1, r);
                Merge(nums, l, m, r);
            }
        }

        private void Merge(int[] nums, int l, int m, int r)
        {
            Queue<int> lq = new Queue<int>();
            Queue<int> rq = new Queue<int>();

            for (int i = l; i <= m; i++) lq.Enqueue(nums[i]);
            for (int j = m + 1; j <= r; j++) rq.Enqueue(nums[j]);

            int k = l;
            while (lq.Count > 0 && rq.Count > 0)
            {
                if (lq.Peek() < rq.Peek())
                {
                    nums[k++] = lq.Dequeue();
                }
                else
                {
                    nums[k++] = rq.Dequeue();
                }
            }

            while (lq.Count > 0) nums[k++] = lq.Dequeue();
            while (rq.Count > 0) nums[k++] = rq.Dequeue();

        }

        private void ValidateISSrotedDesc(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.IsTrue(arr[i] <= arr[i + 1], $"Elements not ordered at {i}, {arr[i]} > {arr[i + 1]}");
            }
        }

        private int[] GenerateArrray(int length)
        {
            int[] arr = new int[length];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next();
            }
            return arr;
        }
    }
}
