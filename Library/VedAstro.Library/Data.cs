using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace VedAstro.Library;

public class Data
{
	private readonly string _filePath;

	private readonly Stream _writeStream;

	private XDocument _document;

	private IEnumerable<XElement> _allRecords;

	private bool _fileType;

	private bool _blobType;

	private bool _readOnly;

	public Data(Stream readStream, Stream writeStream)
	{
		_writeStream = writeStream;
		_document = XDocument.Load(readStream);
		_allRecords = _document.Root.Elements();
		_blobType = true;
	}

	public Data(Stream readStream)
	{
		_document = XDocument.Load(readStream);
		_allRecords = _document.Root.Elements();
		_blobType = true;
		_readOnly = true;
	}

	public Data(string filePath)
	{
		_filePath = filePath;
		_document = XDocument.Load(filePath);
		_allRecords = _document.Root.Elements();
		_fileType = true;
	}

	public T GetValue<T>(string elementName)
	{
		IEnumerable<XElement> source = _allRecords.Where((XElement record) => record.Name.ToString() == elementName);
		if (!source.Any())
		{
			throw new Exception("Element doesn't exist!");
		}
		if (source.Count() > 1)
		{
			throw new Exception("More than 1 element found!");
		}
		return (T)Convert.ChangeType(source.FirstOrDefault().Value, typeof(T));
	}

	public Stream GetStream()
	{
		Stream stream = new MemoryStream();
		_document.Save(stream);
		stream.Position = 0L;
		return stream;
	}

	public XElement GetRecord(string elementName, string elementValue)
	{
		IEnumerable<XElement> source = _allRecords.Where((XElement record) => record.Element(elementName)?.Value == elementValue);
		if (source.Count() > 1)
		{
			throw new Exception("More than 1 record found!");
		}
		return source.FirstOrDefault();
	}

	public XElement GetRecord(string elementName)
	{
		IEnumerable<XElement> source = _allRecords.Where((XElement record) => record.Name == elementName);
		if (source.Count() > 1)
		{
			throw new Exception("More than 1 record found!");
		}
		return source.FirstOrDefault();
	}

	public bool IsExist(string elementName, string elementValue)
	{
		return GetRecord(elementName, elementValue) != null;
	}

	public void InsertRecord(XElement record)
	{
		if (_readOnly)
		{
			throw new InvalidOperationException("Data is read-only!");
		}
		_document.Root.Add(record);
		UpdateUnderlyingFile();
	}

	public void DeleteRecord(XElement record)
	{
		if (_readOnly)
		{
			throw new InvalidOperationException("Data is read-only!");
		}
		record.Remove();
	}

	public IEnumerable<XElement> GetAllRecords()
	{
		return _allRecords;
	}

	public void UpdateRecord(string name, string value)
	{
		if (_readOnly)
		{
			throw new InvalidOperationException("Data is read-only!");
		}
		IEnumerable<XElement> source = _allRecords.Where((XElement record) => record.Name.ToString() == name);
		if (!source.Any())
		{
			throw new Exception("Record not found in XML!");
		}
		source.FirstOrDefault().Value = value;
		UpdateUnderlyingFile();
	}

	public void UpdateUnderlyingFile()
	{
		if (_readOnly)
		{
			throw new InvalidOperationException("Data is read-only!");
		}
		if (_blobType)
		{
			_document.Save(_writeStream, SaveOptions.None);
		}
		else if (_fileType)
		{
			_document.Save(_filePath);
		}
	}
}
