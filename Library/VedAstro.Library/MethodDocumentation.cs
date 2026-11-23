using System.Collections.Generic;

namespace VedAstro.Library;

public class MethodDocumentation
{
	public string Description { get; set; }

	public Dictionary<string, string> Params { get; set; }

	public int LineNumber { get; set; }

	public string Signature { get; set; }

	public MethodDocumentation()
	{
		Params = new Dictionary<string, string>();
	}
}
