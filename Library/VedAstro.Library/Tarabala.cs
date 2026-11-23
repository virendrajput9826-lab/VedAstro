using System;

namespace VedAstro.Library;

[Serializable]
public struct Tarabala(int tarabalaNumber, int cycle)
{
	private readonly TarabalaName _name = (TarabalaName)tarabalaNumber;

	private readonly int _cycle = cycle;

	public TarabalaName GetName()
	{
		return _name;
	}

	public int GetCycle()
	{
		return _cycle;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() == typeof(Tarabala))
		{
			Tarabala tarabala = (Tarabala)obj;
			return GetHashCode() == tarabala.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return $"{_name} - Cycle:{_cycle}";
	}

	public override int GetHashCode()
	{
		int hashCode = _name.GetHashCode();
		int hashCode2 = _cycle.GetHashCode();
		return hashCode + hashCode2;
	}

	public static bool operator ==(Tarabala left, Tarabala right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Tarabala left, Tarabala right)
	{
		return !(left == right);
	}
}
