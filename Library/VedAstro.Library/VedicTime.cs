namespace VedAstro.Library;

public class VedicTime
{
	private const double TATPARAS_PER_PARA = 60.0;

	private const double PARAS_PER_VILIPTA = 60.0;

	private const double VILIPTAS_PER_LIPTHA = 60.0;

	private const double LIPTHAS_PER_VIGHATI = 60.0;

	private const double VIGHATIS_PER_GHATI = 60.0;

	private const double SECONDS_PER_VIGHATI = 24.0;

	private const double MINUTES_PER_GHATI = 24.0;

	private const double HOURS_PER_DAY = 2.5;

	public double TatParas { get; private set; }

	public double Paras { get; set; }

	public double Viliptas { get; set; }

	public double Lipthas { get; set; }

	public double Vighatis { get; set; }

	public double Ghatis { get; private set; }

	public static VedicTime FromTotalGhatis(double totalGhatis)
	{
		long num = (long)totalGhatis;
		double vighatis = (totalGhatis - (double)num) * 60.0;
		return new VedicTime
		{
			Ghatis = num,
			Vighatis = vighatis
		};
	}

	public override string ToString()
	{
		return $"{Ghatis}Gh. {Vighatis}Vi.";
	}
}
