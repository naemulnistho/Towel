﻿using BenchmarkDotNet.Attributes;
using System;
using Towel;
using static Towel.Statics;

namespace Towel_Benchmarking
{
	[Value(Program.Name, "Sorting Algorithms")]
	public class Sort_Benchmarks
	{
		[Params(10, 1000, 10000)] public int N;

		public int[] Values;

		[IterationSetup] public void IterationSetup()
		{
			Values = new int[N];
			Extensions.Iterate(N, i => Values[i] = i);
			Random random = new Random(7);
			random.Shuffle(Values);
		}

		[Benchmark] public void SystemArraySort() =>
			Array.Sort(Values);

		[Benchmark] public void SystemArraySortDelegate() =>
			Array.Sort(Values, (int a, int b) => a.CompareTo(b));

		[Benchmark] public void SystemArraySortIComparer() =>
			Array.Sort(Values, default(ComparerInt));

		[Benchmark] public void BubbleRunTime() =>
			SortBubble(Values);

		[Benchmark] public void BubbleCompileTime() =>
			SortBubble<int, CompareInt>(Values);

		[Benchmark] public void SelectionRunTime() =>
			SortSelection(Values);

		[Benchmark] public void SelectionCompileTime() =>
			SortSelection<int, CompareInt>(Values);

		[Benchmark] public void InsertionRunTime() =>
			SortInsertion(Values);

		[Benchmark] public void InsertionCompileTime() =>
			SortInsertion<int, CompareInt>(Values);

		[Benchmark] public void QuickRunTime() =>
			SortQuick(Values);

		[Benchmark] public void QuickCompileTime() =>
			SortQuick<int, CompareInt>(Values);

		[Benchmark] public void MergeRunTime() =>
			SortMerge(Values);

		[Benchmark] public void MergeCompileTime() =>
			SortMerge<int, CompareInt>(Values);

		[Benchmark] public void HeapRunTime() =>
			SortHeap(Values);

		[Benchmark] public void HeapCompileTime() =>
			SortHeap<int, CompareInt>(Values);

		[Benchmark] public void OddEvenRunTime() =>
			SortOddEven(Values);

		[Benchmark] public void OddEvenCompileTime() =>
			SortOddEven<int, CompareInt>(Values);

		[Benchmark] public void GnomeRunTime() =>
			SortGnome(Values);

		[Benchmark] public void GnomeCompileTime() =>
			SortGnome<int, CompareInt>(Values);

		[Benchmark] public void CombRunTime() =>
			SortComb(Values);

		[Benchmark] public void CombCompileTime() =>
			SortComb<int, CompareInt>(Values);

		[Benchmark] public void ShellRunTime() =>
			SortShell(Values);

		[Benchmark] public void ShellCompileTime() =>
			SortShell<int, CompareInt>(Values);

		[Benchmark] public void CocktailRunTime() =>
			SortCocktail(Values);

		[Benchmark] public void CocktailCompileTime() =>
			SortCocktail<int, CompareInt>(Values);

		[Benchmark] public void SlowRunTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			SortSlow(Values);
		}

		[Benchmark] public void SlowCompileTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			SortSlow<int, CompareInt>(Values);
		}

		[Benchmark] public void BogoRunTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			SortBogo(Values);
		}

		[Benchmark] public void BogoCompileTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			SortBogo<int, CompareInt>(Values);
		}

		public struct ComparerInt : System.Collections.Generic.IComparer<int>
		{
			public int Compare(int a, int b) => a.CompareTo(b);
		}
	}
}
