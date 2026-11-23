using System.Collections.Generic;

namespace VedAstro.Library;

public struct SumData
{
	public double NatureScore = 0.0;

	public List<PlanetName> Planet = null;

	public Time BirthTime = default(Time);

	public SumData()
	{
	}
}
