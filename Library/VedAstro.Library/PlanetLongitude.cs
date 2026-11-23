namespace VedAstro.Library;

public struct PlanetLongitude(PlanetName planetName, Angle planetLongitude)
{
	private PlanetName _planetName = planetName;

	private Angle _planetLongitude = planetLongitude;

	public PlanetName GetPlanetName()
	{
		return _planetName;
	}

	public Angle GetPlanetLongitude()
	{
		return _planetLongitude;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(PlanetLongitude))
		{
			PlanetLongitude planetLongitude = (PlanetLongitude)value;
			return GetHashCode() == planetLongitude.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = _planetName.GetHashCode();
		int hashCode2 = _planetLongitude.GetHashCode();
		return hashCode + hashCode2;
	}

	public override string ToString()
	{
		return $"{_planetName} - {_planetLongitude}";
	}
}
