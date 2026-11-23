namespace VedAstro.Library;

public struct DegreeRange(double startDegree, double endDegree)
{
	public double StartDegree { get; set; } = startDegree;

	public double EndDegree { get; set; } = endDegree;

	public bool IsWithinRange(double degree)
	{
		if (degree >= StartDegree)
		{
			return degree <= EndDegree;
		}
		return false;
	}
}
