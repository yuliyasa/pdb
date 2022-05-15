using System;
namespace Sorting
{
	public delegate void SortDelegate(ref int[][] arr, bool reverse);
	public class Context
	{
		private SortDelegate sortDelegate;
		public Context(SortDelegate sortDelegate)
		{
			this.sortDelegate = sortDelegate;
		}
		public void Sort(ref int[][] arr, bool reverse = false)
		{
			sortDelegate(ref arr, reverse);
		}
	}
	public class BaseSorting
	{
		public void Sort(ref int[][] arr, bool reverse)
		{
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = i; j < arr.GetLength(0); j++)
				{
					if ((Compare(arr[i], arr[j]) == 0) ^ reverse)
					{
						int[] temp = new int[arr[j].Length];
						Array.Copy(arr[j], temp, arr[j].Length);
						Array.Copy(arr[i], arr[j], arr[j].Length);
						arr[i] = temp;
					}
				}
			}
		}
		private int Compare(int[] arr1, int[] arr2)
		{
			if (Measure(arr1) <= Measure(arr2))
				return 1;
			else
				return 0;
		}
		public virtual int Measure(int[] arr) { throw new NotImplementedException("Нельзя использовать сортировку без спецификации"); }
	}
	public class SumSorting : BaseSorting
	{
		public override int Measure(int[] arr)
		{
			int sum = 0;
			foreach (int i in arr)
				sum = sum + i;
			return sum;
		}
	}
	public class MaxSorting : BaseSorting
	{
		public override int Measure(int[] arr)
		{
			int maxS = int.MinValue;
			foreach (int i in arr)
				if (maxS < i)
				{
					maxS = i;
				}
			return maxS;
		}

	}
	public class MinSorting : BaseSorting
	{
		public override int Measure(int[] arr)
		{
			int minSum = int.MaxValue;
			foreach (int i in arr)
				if (minSum > i)
				{
					minSum = i;
				}
			return minSum;
		}
	}
}