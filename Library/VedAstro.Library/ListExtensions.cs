using System;
using System.Collections.Generic;

namespace VedAstro.Library;

public static class ListExtensions
{
	public static void MoveToEnd<T>(this List<T> list, Predicate<T> itemSelector)
	{
		if (list.Count > 1)
		{
			list.Move(itemSelector, list.Count - 1);
		}
	}

	public static void MoveToBeginning<T>(this List<T> list, Predicate<T> itemSelector)
	{
		list.Move(itemSelector, 0);
	}

	public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
	{
		int num = list.FindIndex(itemSelector);
		if (num != newIndex)
		{
			T item = list[num];
			list.RemoveAt(num);
			list.Insert(newIndex, item);
		}
	}
}
