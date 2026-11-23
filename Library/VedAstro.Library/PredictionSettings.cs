namespace VedAstro.Library;

public class PredictionSettings
{
	public string ServerUrl { get; set; }

	public string ApiKey { get; set; }

	public double MaxTokens { get; set; }

	public double Temperature { get; set; }

	public double TopP { get; set; }

	public object[] SysMessage { get; set; }
}
