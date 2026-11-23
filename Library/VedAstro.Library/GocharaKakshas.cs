using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class GocharaKakshas : IToJson, IToJpeg, IToDataTable
{
	public List<PlanetName> Column1 { get; }

	public Dictionary<PlanetName, ZodiacSign> Column2 { get; }

	public Dictionary<PlanetName, string> Column3 { get; }

	public Dictionary<PlanetName, int> Column4 { get; }

	public Dictionary<PlanetName, int> Column5 { get; }

	public Dictionary<PlanetName, int> Column6 { get; }

	public GocharaKakshas(List<PlanetName> column1, Dictionary<PlanetName, ZodiacSign> column2, Dictionary<PlanetName, string> column3, Dictionary<PlanetName, int> column4, Dictionary<PlanetName, int> column5, Dictionary<PlanetName, int> column6)
	{
		Column1 = column1;
		Column2 = column2;
		Column3 = column3;
		Column4 = column4;
		Column5 = column5;
		Column6 = column6;
	}

	public JObject ToJson()
	{
		JObject jObject = new JObject();
		foreach (PlanetName item in Column1)
		{
			JObject value = new JObject
			{
				["Sign"] = Column2[item].GetSignName().ToString(),
				["KakshaScore"] = Column4[item],
				["KakshaLord"] = Column3[item],
				["Ashtaka"] = Column5[item],
				["Sarvashtaka"] = Column6[item]
			};
			jObject[item.Name.ToString()] = value;
		}
		return jObject;
	}

	public byte[] ToJpeg()
	{
		return Tools.DataTableToJpeg(ToDataTable());
	}

	public DataTable ToDataTable()
	{
		DataTable dataTable = new DataTable("GocharaKakshas");
		dataTable.Columns.Add("Planet", typeof(string));
		dataTable.Columns.Add("Sign", typeof(string));
		dataTable.Columns.Add("KakshaScore", typeof(string));
		dataTable.Columns.Add("KakshaLord", typeof(string));
		dataTable.Columns.Add("Ashtaka", typeof(string));
		dataTable.Columns.Add("Sarvashtaka", typeof(string));
		foreach (PlanetName item in Column1)
		{
			dataTable.Rows.Add(item.Name.ToString(), Column2[item].GetSignName().ToString(), Column4[item], Column3[item], Column5[item], Column6[item]);
		}
		return dataTable;
	}
}
