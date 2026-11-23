using System.Data;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class PanchangaTable : IToJpeg, IToJson, IToDataTable
{
	public string Ayanamsa { get; set; }

	public LunarDay Tithi { get; set; }

	public LunarMonth LunarMonth { get; set; }

	public DayOfWeek Vara { get; set; }

	public Constellation Nakshatra { get; set; }

	public NithyaYoga Yoga { get; set; }

	public Karana Karana { get; set; }

	public PlanetName HoraLord { get; set; }

	public string DishaShool { get; set; }

	public Time Sunrise { get; set; }

	public Time Sunset { get; set; }

	public Angle IshtaKaala { get; set; }

	public PanchangaTable(string ayanamsa, LunarDay tithi, LunarMonth lunarMonth, DayOfWeek vara, Constellation nakshatra, NithyaYoga yoga, Karana karana, PlanetName horaLord, string dishaShool, Time sunrise, Time sunset, Angle ishtaKaala)
	{
		Ayanamsa = ayanamsa;
		Tithi = tithi;
		LunarMonth = lunarMonth;
		Vara = vara;
		Nakshatra = nakshatra;
		Yoga = yoga;
		Karana = karana;
		HoraLord = horaLord;
		DishaShool = dishaShool;
		Sunrise = sunrise;
		Sunset = sunset;
		IshtaKaala = ishtaKaala;
	}

	public byte[] ToJpeg()
	{
		return Tools.DataTableToJpeg(ToDataTable());
	}

	public DataTable ToDataTable()
	{
		DataTable dataTable = new DataTable("PanchangaTable");
		dataTable.Columns.Add("Name", typeof(string));
		dataTable.Columns.Add("Value", typeof(string));
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object value = propertyInfo.GetValue(this);
			if (value is Angle angle)
			{
				dataTable.Rows.Add(propertyInfo.Name, angle.DegreesMinutesSecondsText);
			}
			else
			{
				dataTable.Rows.Add(propertyInfo.Name, value.ToString());
			}
		}
		return dataTable;
	}

	public JObject ToJson()
	{
		JObject jObject = new JObject();
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			jObject[propertyInfo.Name] = ((propertyInfo.GetValue(this) is IToJson toJson) ? toJson.ToJson() : ((JToken)(propertyInfo.GetValue(this)?.ToString())));
		}
		return jObject;
	}
}
