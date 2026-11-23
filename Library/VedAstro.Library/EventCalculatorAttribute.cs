using System;

namespace VedAstro.Library;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class EventCalculatorAttribute : Attribute
{
	public EventName EventName { get; set; }

	public EventCalculatorAttribute(EventName eventName)
	{
		EventName = eventName;
	}
}
