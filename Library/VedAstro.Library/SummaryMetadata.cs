namespace VedAstro.Library;

public class SummaryMetadata
{
	public double Weight { get; set; }

	public EventNature Nature { get; set; }

	public SummaryMetadata(double weight, EventNature nature)
	{
		Weight = weight;
		Nature = nature;
	}

	public SummaryMetadata(EventNature nature)
	{
		Weight = 0.0;
		Nature = nature;
	}
}
