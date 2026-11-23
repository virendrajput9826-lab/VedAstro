using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace VedAstro.Library;

public class UserData
{
	public static UserData Guest = new UserData("101", "Guest", "guest@example.com");

	private string _name;

	public string Id { get; set; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = ((value == "Vignes") ? "James Brown" : value);
		}
	}

	public List<GeoLocation> LocationList { get; set; }

	public string Email { get; set; }

	public string Locale { get; set; }

	public string FamilyName { get; set; }

	public string Picture { get; set; }

	public string FirstName => Name.Split(" ")[0];

	public UserData(string id = "", string name = "", string email = "", string familyName = "", string locale = "", string picture = "")
	{
		Id = id;
		Name = name;
		Email = email;
		FamilyName = familyName;
		Locale = locale;
		Picture = picture;
		LocationList = new List<GeoLocation>();
	}

	public static UserData? FromXml(XElement userDataXml)
	{
		return new UserData(userDataXml.Element("Id")?.Value, userDataXml.Element("Name")?.Value, userDataXml.Element("Email")?.Value, userDataXml.Element("FamilyName")?.Value, userDataXml.Element("Locale")?.Value, userDataXml.Element("Picture")?.Value);
	}

	public XElement ToXml()
	{
		XElement xElement = new XElement("UserData");
		XElement xElement2 = new XElement("Name", Name);
		XElement xElement3 = new XElement("Id", Id);
		XElement xElement4 = new XElement("Email", Email);
		XElement xElement5 = new XElement("FamilyName", FamilyName);
		XElement xElement6 = new XElement("Locale", Locale);
		XElement xElement7 = new XElement("Picture", Picture);
		xElement.Add(xElement3, xElement2, xElement4, xElement5, xElement7, xElement6);
		return xElement;
	}

	public override bool Equals(object value)
	{
		if (value.GetType() == typeof(UserData))
		{
			UserData userData = (UserData)value;
			return GetHashCode() == userData.GetHashCode();
		}
		return false;
	}

	public override string ToString()
	{
		return Name + "|" + Email;
	}

	public override int GetHashCode()
	{
		int stringHashCode = Tools.GetStringHashCode(Id);
		int stringHashCode2 = Tools.GetStringHashCode(Email);
		return Math.Abs(stringHashCode + stringHashCode2);
	}
}
