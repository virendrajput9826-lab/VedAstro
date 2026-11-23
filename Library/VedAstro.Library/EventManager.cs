using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace VedAstro.Library;

public static class EventManager
{
	private const string AzureStorage = "vedastrowebsitestorage.z5.web.core.windows.net";

	private static List<Event> EventList { get; set; } = new List<Event>();

	public static List<Event> GetEventsInTimePeriod(DateTimeOffset startStdTime, DateTimeOffset endStdTime, GeoLocation geoLocation, Person person, double precisionInHours, List<EventData> eventDataList)
	{
		Time startTime = new Time(startStdTime, geoLocation);
		Time endTime = new Time(endStdTime, geoLocation);
		List<Event> list = new List<Event>();
		List<Time> timeListFromRange = Time.GetTimeListFromRange(startTime, endTime, precisionInHours);
		foreach (EventData eventData in eventDataList)
		{
			List<Event> collection = GetListOfEventsForEventData(eventData, person, timeListFromRange);
			list.AddRange(collection);
		}
		return list;
		static List<Event> GetListOfEventsForEventData(EventData eventData, Person person2, List<Time> timeList)
		{
			return EventSlicesToEvents(ConvertToEventSlice(timeList, eventData, person2));
		}
	}

	public static EventSlice[] ConvertToEventSlice(List<Time> timeList, EventData eventData, Person person, bool useParallel = true)
	{
		EventSlice[] returnList = new EventSlice[timeList.Count];
		if (useParallel)
		{
			Parallel.For(0, timeList.Count, delegate(int i)
			{
				EventSlice eventSlice2 = ConvertToEventSlice(timeList[i], eventData, person);
				returnList[i] = eventSlice2;
			});
		}
		else
		{
			for (int num = 0; num < timeList.Count; num++)
			{
				EventSlice eventSlice = ConvertToEventSlice(timeList[num], eventData, person);
				returnList[num] = eventSlice;
			}
		}
		return returnList;
	}

	public static EventSlice? ConvertToEventSlice(Time time, EventData eventData, Person person)
	{
		if (eventData == EventData.Empty)
		{
			return EventSlice.Empty;
		}
		CalculatorResult calculatorResult = eventData.EventCalculator(time, person);
		if (calculatorResult.Occuring)
		{
			_ = calculatorResult.RelatedBody;
			EventNature eventNature = ((calculatorResult.NatureOverride == EventNature.Empty) ? eventData.Nature : calculatorResult.NatureOverride);
			string description = ((!string.IsNullOrEmpty(calculatorResult.DescriptionOverride)) ? calculatorResult.DescriptionOverride : eventData.Description);
			if (eventNature == EventNature.Empty)
			{
				throw new Exception("Something wrong");
			}
			return new EventSlice(eventData.Name, eventNature, description, eventData.SpecializedSummary, time, calculatorResult.Occuring);
		}
		return null;
	}

	public static List<Event> EventSlicesToEvents(EventSlice[] eventSliceList)
	{
		return GetTrueRanges(Array.ConvertAll(eventSliceList, (EventSlice evtSlice) => evtSlice != null)).Select(RangeToEvent).ToList();
		Event RangeToEvent((int Start, int End) range)
		{
			EventSlice eventSlice = eventSliceList[range.Start];
			Time time = eventSlice.Time;
			Time time2 = eventSliceList[range.End].Time;
			List<EventTag> tagsByEventName = GetTagsByEventName(eventSlice.Name);
			return new Event(eventSlice.Name, eventSlice.Nature, eventSlice.Description, eventSlice.SpecializedSummary, time, time2, tagsByEventName);
		}
	}

	public static EventCalculatorDelegate GetEventCalculatorMethod(EventName inputEventName)
	{
		MethodInfo[] methods = typeof(EventCalculatorMethods).GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			EventCalculatorAttribute eventCalculatorAttribute = (EventCalculatorAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(EventCalculatorAttribute));
			if (eventCalculatorAttribute != null && eventCalculatorAttribute.EventName == inputEventName)
			{
				return (EventCalculatorDelegate)Delegate.CreateDelegate(typeof(EventCalculatorDelegate), methodInfo);
			}
		}
		throw new Exception($"Calculator method not found! : {inputEventName}");
	}

	public static HoroscopeCalculatorDelegate GetHoroscopeCalculatorMethod(HoroscopeName inputEventName)
	{
		MethodInfo[] methods = typeof(CalculateHoroscope).GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			HoroscopeCalculatorAttribute horoscopeCalculatorAttribute = (HoroscopeCalculatorAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(HoroscopeCalculatorAttribute));
			if (horoscopeCalculatorAttribute != null && horoscopeCalculatorAttribute.HoroscopeName == inputEventName)
			{
				return (HoroscopeCalculatorDelegate)Delegate.CreateDelegate(typeof(HoroscopeCalculatorDelegate), methodInfo);
			}
		}
		throw new Exception("Calculator method not found! : " + inputEventName);
	}

	public static List<Event> SplitEventsByDay(List<Event> events)
	{
		List<Event> list = new List<Event>(events);
		foreach (Event @event in events)
		{
			if (IsEventSpanMoreThan1Day(@event))
			{
				List<Event> collection = SplitEvent(@event);
				list.Remove(@event);
				list.AddRange(collection);
			}
		}
		return FilterOutShortEvents(list, 0);
		static bool IsEventSpanMoreThan1Day(Event _event)
		{
			int day = _event.GetStartTime().GetStdDateTimeOffset().Day;
			int day2 = _event.GetEndTime().GetStdDateTimeOffset().Day;
			if (day != day2)
			{
				return true;
			}
			return false;
		}
		static List<Event> SplitEvent(Event _event)
		{
			List<Event> list2 = new List<Event>();
			EventName name = _event.GetName();
			EventNature nature = _event.GetNature();
			string description = _event.GetDescription();
			SpecializedSummary specializedSummary = _event.SpecializedSummary;
			GeoLocation geoLocation = _event.GetStartTime().GetGeoLocation();
			TimeSpan offset = _event.GetStartTime().GetStdDateTimeOffset().Offset;
			DateTimeOffset stdDateTime = _event.GetStartTime().GetStdDateTimeOffset();
			int day = stdDateTime.Day;
			Time endTime = _event.GetEndTime();
			int day2 = endTime.GetStdDateTimeOffset().Day;
			Time startTime;
			Event item;
			while (day != day2)
			{
				DateTimeOffset stdDateTime2 = new DateTimeOffset(stdDateTime.Year, stdDateTime.Month, stdDateTime.Day, 23, 59, 59, offset);
				Time endTime2 = new Time(stdDateTime2, geoLocation);
				startTime = new Time(stdDateTime, geoLocation);
				List<EventTag> tagsByEventName = GetTagsByEventName(name);
				item = new Event(name, nature, description, specializedSummary, startTime, endTime2, tagsByEventName);
				list2.Add(item);
				stdDateTime = stdDateTime2.AddSeconds(1.0);
				day = stdDateTime.Day;
			}
			startTime = new Time(stdDateTime, geoLocation);
			List<EventTag> tagsByEventName2 = GetTagsByEventName(name);
			item = new Event(name, nature, description, specializedSummary, startTime, endTime, tagsByEventName2);
			list2.Add(item);
			return list2;
		}
	}

	public static List<Event> FilterOutShortEvents(List<Event> splittedEvents, int minimumMinutes)
	{
		List<Event> list = new List<Event>(splittedEvents);
		IEnumerable<Event> source = splittedEvents.Where((Event x) => x.GetDurationMinutes() <= (double)minimumMinutes);
		foreach (Event splittedEvent in splittedEvents)
		{
			if (source.Contains(splittedEvent))
			{
				list.Remove(splittedEvent);
			}
		}
		return list;
	}

	public static List<EventData> GetEventDataListByTag(EventTag tag)
	{
		return EventDataListStatic.Rows.FindAll((EventData eventData) => eventData.EventTags.Contains(tag));
	}

	public static List<EventTag> GetTagsByEventName(EventName eventName)
	{
		return EventDataListStatic.Rows.Find((EventData eventData) => eventData.Name == eventName).EventTags;
	}

	public static List<Event> CalculateEvents(double eventsPrecision, Time startTime, Time endTime, Person inputPerson, List<EventTag> inputedEventTags, bool filter0Duration = true)
	{
		EventList = new List<Event>();
		object sync = new object();
		Parallel.ForEach(inputedEventTags, delegate(EventTag eventTag, ParallelLoopState state)
		{
			List<Event> collection = CalculateEventsForTag(eventsPrecision, startTime, endTime, inputPerson.GetBirthLocation(), inputPerson, eventTag, filter0Duration);
			lock (sync)
			{
				EventList.AddRange(collection);
			}
		});
		return EventList;
	}

	public static List<Event> CalculateEventsForTag(double eventsPrecision, Time startTime, Time endTime, GeoLocation geoLocation, Person person, EventTag tag, bool filter0Duration = true)
	{
		List<EventData> eventDataListByTag = GetEventDataListByTag(tag);
		List<Event> source = GetEventsInTimePeriod(startTime.GetStdDateTimeOffset(), endTime.GetStdDateTimeOffset(), geoLocation, person, eventsPrecision, eventDataListByTag);
		if (filter0Duration)
		{
			source = source.Where((Event dasaEvent) => dasaEvent.DurationMin > 0.0).ToList();
		}
		return source.OrderBy((Event dasaEvent) => dasaEvent.StartTime.GetStdDateTimeOffset()).ToList();
	}

	public static List<(int Start, int End)> GetTrueRanges(bool[] array)
	{
		List<(int, int)> list = new List<(int, int)>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i])
			{
				int item = i;
				for (; i < array.Length && array[i]; i++)
				{
				}
				int item2 = i - 1;
				list.Add((item, item2));
			}
		}
		return list;
	}
}
