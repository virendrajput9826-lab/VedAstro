namespace VedAstro.Library;

public interface IAngle
{
	long Degrees { get; }

	long Minutes { get; }

	long Seconds { get; }

	double TotalDegrees { get; }

	double TotalMinutes { get; }
}
