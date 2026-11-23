using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace VedAstro.Library;

public static class LogManager
{
	private enum LogType
	{
		Error,
		Debug,
		Failure
	}

	public delegate void LogEvent(string message = "");

	private static Data _logFile;

	private static bool _logSet;

	public static string LogText { get; set; }

	public static Data LogFile
	{
		get
		{
			return _logFile;
		}
		private set
		{
			_logFile = value;
		}
	}

	public static event LogEvent LogUpdated;

	public static event LogEvent ErrorOccurred;

	public static void Initialize(Data log)
	{
		LogFile = log;
		if (_logSet)
		{
			Error("Log file set more than once!");
		}
		_logSet = true;
	}

	public static void Error(Exception e)
	{
		Exception originalException = e.GetBaseException();
		AddToLog(originalException.Message, LogType.Error);
		SaveToFile();
		LogUpdated?.Invoke();
		ErrorOccurred?.Invoke(e.Message);
		void SaveToFile()
		{
			string fileName = default(string);
			string methodName = default(string);
			int line = default(int);
			int columnNumber = default(int);
			string message = default(string);
			string source = default(string);
			if (LogFile != null)
			{
				ExtractDataFromException();
				XElement record = new XElement("Error", new XElement("Message", message), new XElement("Source", source), new XElement("FileName", fileName), new XElement("SourceLineNumber", line), new XElement("SourceColNumber", columnNumber), new XElement("MethodName", methodName), new XElement("Time", GetNow()));
				LogFile.InsertRecord(record);
			}
			void ExtractDataFromException()
			{
				StackTrace stackTrace = new StackTrace(e, fNeedFileInfo: true);
				StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
				fileName = frame.GetFileName();
				methodName = frame.GetMethod().Name;
				line = frame.GetFileLineNumber();
				columnNumber = frame.GetFileColumnNumber();
				message = originalException.ToString();
				source = originalException.Source;
			}
		}
	}

	public static void Error(string errorMessage)
	{
		AddToLog(errorMessage, LogType.Error);
		SaveToFile();
		LogUpdated?.Invoke();
		ErrorOccurred?.Invoke(errorMessage);
		void SaveToFile()
		{
			if (LogFile != null)
			{
				XElement record = new XElement("Error", new XElement("Message", errorMessage), new XElement("Time", GetNow()));
				LogFile.InsertRecord(record);
			}
		}
	}

	public static void Debug(string message)
	{
		AddToLog(message, LogType.Debug);
		SaveToFile();
		LogUpdated?.Invoke();
		void SaveToFile()
		{
			if (LogFile != null)
			{
				XElement record = new XElement("Debug", new XElement("Message", message), new XElement("Time", GetNow()));
				LogFile.InsertRecord(record);
			}
		}
	}

	private static void AddToLog(string message, LogType debug)
	{
		LogText += $"\n{GetNow()}:\t{debug}:\t{message}";
	}

	public static void Initialize(object data)
	{
		throw new NotImplementedException();
	}

	private static DateTimeOffset GetNow()
	{
		TimeSpan offset = new TimeSpan(8, 0, 0);
		return DateTimeOffset.Now.ToUniversalTime().ToOffset(offset);
	}
}
