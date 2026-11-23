using System;

namespace VedAstro.Library;

public class NoInternetError : Exception
{
	public NoInternetError()
	{
	}

	public NoInternetError(string message)
		: base(message)
	{
	}

	public NoInternetError(string message, Exception inner)
		: base(message, inner)
	{
	}
}
