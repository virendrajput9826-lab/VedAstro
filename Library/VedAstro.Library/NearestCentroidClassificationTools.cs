using System;
using System.IO;

namespace VedAstro.Library;

public static class NearestCentroidClassificationTools
{
	public static double[][] MatLoad(string fn, int[] usecols, char sep, string comment)
	{
		int num = 0;
		string text = "";
		FileStream fileStream = new FileStream(fn, FileMode.Open);
		StreamReader streamReader = new StreamReader(fileStream);
		while ((text = streamReader.ReadLine()) != null)
		{
			if (!text.StartsWith(comment))
			{
				num++;
			}
		}
		streamReader.Close();
		fileStream.Close();
		int num2 = usecols.Length;
		double[][] array = new double[num][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new double[num2];
		}
		text = "";
		string[] array2 = null;
		fileStream = new FileStream(fn, FileMode.Open);
		streamReader = new StreamReader(fileStream);
		int num3 = 0;
		while ((text = streamReader.ReadLine()) != null)
		{
			if (!text.StartsWith(comment))
			{
				array2 = text.Split(sep);
				for (int j = 0; j < num2; j++)
				{
					int num4 = usecols[j];
					array[num3][j] = double.Parse(array2[num4]);
				}
				num3++;
			}
		}
		streamReader.Close();
		fileStream.Close();
		return array;
	}

	public static int[] VecLoad(string fn, int usecol, string comment)
	{
		char sep = ',';
		double[][] array = MatLoad(fn, new int[1] { usecol }, sep, comment);
		int num = array.Length;
		int[] array2 = new int[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = (int)array[i][0];
		}
		return array2;
	}

	public static double[][] MatMinMaxValues(double[][] X)
	{
		int num = X.Length;
		int num2 = X[0].Length;
		double[][] array = new double[2][];
		for (int i = 0; i < 2; i++)
		{
			array[i] = new double[num2];
		}
		for (int j = 0; j < num2; j++)
		{
			double num3 = X[0][j];
			double num4 = X[0][j];
			for (int k = 0; k < num; k++)
			{
				if (X[k][j] < num3)
				{
					num3 = X[k][j];
				}
				if (X[k][j] > num4)
				{
					num4 = X[k][j];
				}
			}
			array[0][j] = num3;
			array[1][j] = num4;
		}
		return array;
	}

	public static double[][] MatNormalizeUsing(double[][] X, double[][] minsMaxs)
	{
		int num = X.Length;
		int num2 = X[0].Length;
		double[][] array = new double[num][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new double[num2];
		}
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < num; k++)
			{
				array[k][j] = (X[k][j] - minsMaxs[0][j]) / (minsMaxs[1][j] - minsMaxs[0][j]);
			}
		}
		return array;
	}

	public static double[][] MatNormalizeUsing2(double[][] X, double[][] minsMaxs)
	{
		if (X.Length != minsMaxs.Length)
		{
			throw new ArgumentException("Input arrays X and minsMaxs must have the same number of rows.");
		}
		if (X[0].Length != minsMaxs[0].Length || X[0].Length != minsMaxs[1].Length)
		{
			throw new ArgumentException("Input arrays X, minsMaxs[0], and minsMaxs[1] must have the same number of columns.");
		}
		int num = X.Length;
		int num2 = X[0].Length;
		double[][] array = new double[num][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new double[num2];
		}
		for (int j = 0; j < num2; j++)
		{
			double num3 = minsMaxs[0][j];
			double num4 = minsMaxs[1][j] - num3;
			if (num4 == 0.0)
			{
				for (int k = 0; k < num; k++)
				{
					array[k][j] = 0.0;
				}
			}
			else
			{
				for (int l = 0; l < num; l++)
				{
					array[l][j] = (X[l][j] - num3) / num4;
				}
			}
		}
		return array;
	}

	public static double[] VecNormalizeUsing(double[] x, double[][] minsMaxs)
	{
		int num = x.Length;
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (x[i] - minsMaxs[0][i]) / (minsMaxs[1][i] - minsMaxs[0][i]);
		}
		return array;
	}

	public static void MatShow(double[][] M, int dec, int wid, int numRows, bool showIndices)
	{
		double num = 1.0 / Math.Pow(10.0, dec);
		for (int i = 0; i < numRows; i++)
		{
			if (showIndices)
			{
				int length = M.Length.ToString().Length;
				Console.Write("[" + i.ToString().PadLeft(length) + "]");
			}
			for (int j = 0; j < M[0].Length; j++)
			{
				double value = M[i][j];
				if (Math.Abs(value) < num)
				{
					value = 0.0;
				}
				Console.Write(value.ToString("F" + dec).PadLeft(wid));
			}
			Console.WriteLine("");
		}
		if (numRows < M.Length)
		{
			Console.WriteLine("...");
		}
	}

	public static void VecShow(int[] vec, int wid)
	{
		int num = vec.Length;
		for (int i = 0; i < num; i++)
		{
			if (i != 0 && i % 12 == 0)
			{
				Console.WriteLine("");
			}
			Console.Write(vec[i].ToString().PadLeft(wid));
		}
		Console.WriteLine("");
	}

	public static void VecShow(int[] vec, int wid, int nItems)
	{
		for (int i = 0; i < nItems; i++)
		{
			if (i != 0 && i % 12 == 0)
			{
				Console.WriteLine("");
			}
			Console.Write(vec[i].ToString().PadLeft(wid));
		}
		Console.WriteLine("");
	}

	public static void VecShow(double[] vec, int decimals, int wid)
	{
		int num = vec.Length;
		for (int i = 0; i < num; i++)
		{
			Console.Write(vec[i].ToString("F" + decimals).PadLeft(wid));
		}
		Console.WriteLine("");
	}
}
