using System;

namespace VedAstro.Library;

[Serializable]
public class ApiCommunicationFailed : Exception
{
	public ApiCommunicationFailed()
	{
	}

	public ApiCommunicationFailed(string message)
		: base(message)
	{
	}

	public ApiCommunicationFailed(string message, Exception inner)
		: base(message, inner)
	{
	}
}
