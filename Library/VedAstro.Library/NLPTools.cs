using System;
using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library;

public static class NLPTools
{
	public static double DotProduct(double[] vector1, double[] vector2)
	{
		return vector1.Zip(vector2, (double a, double b) => a * b).Sum();
	}

	public static double Magnitude(double[] vector)
	{
		return Math.Sqrt(vector.Sum((double i) => i * i));
	}

	public static double CosineSimilarity(double[] vector1, double[] vector2)
	{
		if (vector1 == null || vector2 == null || vector1.Length != vector2.Length)
		{
			throw new ArgumentException("Invalid input.");
		}
		double num = DotProduct(vector1, vector2);
		double num2 = Magnitude(vector1);
		double num3 = Magnitude(vector2);
		return num / (num2 * num3);
	}

	public static List<string> Tokenize(string sentence)
	{
		string text = sentence.ToLowerInvariant();
		int num = text.IndexOf(' ');
		List<string> list = new List<string>();
		while (num >= 0)
		{
			if (num > 0)
			{
				list.Add(text.Substring(0, num));
			}
			text = text.Remove(0, num + 1);
			num = text.IndexOf(' ');
		}
		if (!string.IsNullOrEmpty(text))
		{
			list.Add(text);
		}
		return list;
	}

	public static Tuple<List<int>, List<int>> GetWordCountVectorFromText(string sentence1, string sentence2)
	{
		Dictionary<string, int> wordCountDict = new Dictionary<string, int>();
		string[] array = new string[2] { sentence1, sentence2 };
		for (int i = 0; i < array.Length; i++)
		{
			foreach (string item in Tokenize(array[i]))
			{
				if (wordCountDict.ContainsKey(item))
				{
					wordCountDict[item]++;
				}
				else
				{
					wordCountDict[item] = 1;
				}
			}
		}
		List<string> source = (from y in wordCountDict
			orderby y.Value descending
			select y.Key).ToList();
		IDictionary<string, int> sortedWordCountDict = new SortedDictionary<string, int>(source.ToDictionary((string key) => key, (string value) => wordCountDict[value]));
		Func<string, int> func = (string word) => sortedWordCountDict.Keys.ToList().IndexOf(word);
		Func<string, int> func2 = (string word) => wordCountDict.TryGetValue(word, out var value) ? value : 0;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (string item2 in Tokenize(sentence1))
		{
			int num = func(item2);
			if (num >= 0 && num < sortedWordCountDict.Count)
			{
				list.Add(func2(item2));
			}
		}
		foreach (string item3 in Tokenize(sentence2))
		{
			int num2 = func(item3);
			if (num2 >= 0 && num2 < sortedWordCountDict.Count)
			{
				list2.Add(func2(item3));
			}
		}
		return new Tuple<List<int>, List<int>>(list, list2);
	}
}
