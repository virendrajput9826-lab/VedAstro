using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class NithyaYoga(NithyaYogaName name, string description) : IToJson, IToJpeg, IToDataTable
{
	private static readonly Dictionary<NithyaYogaName, string> YogaDescriptions = new Dictionary<NithyaYogaName, string>
	{
		{
			NithyaYogaName.Vishkambha,
			"Door bolt/supporting pillar"
		},
		{
			NithyaYogaName.Priti,
			"Love/affection"
		},
		{
			NithyaYogaName.Ayushman,
			"Long-lived"
		},
		{
			NithyaYogaName.Saubhagya,
			"Long life of spouse (good fortune)"
		},
		{
			NithyaYogaName.Sobhana,
			"Splendid, bright"
		},
		{
			NithyaYogaName.Atiganda,
			"Great danger"
		},
		{
			NithyaYogaName.Sukarma,
			"One with good deeds"
		},
		{
			NithyaYogaName.Dhriti,
			"Firmness"
		},
		{
			NithyaYogaName.Soola,
			"Shiva's weapon of destruction (pain)"
		},
		{
			NithyaYogaName.Ganda,
			"Danger"
		},
		{
			NithyaYogaName.Vriddha,
			"Growth"
		},
		{
			NithyaYogaName.Dhruva,
			"Fixed, constant"
		},
		{
			NithyaYogaName.Vyagatha,
			"Great blow"
		},
		{
			NithyaYogaName.Harshana,
			"Cheerful"
		},
		{
			NithyaYogaName.Vajra,
			"Diamond (strong)"
		},
		{
			NithyaYogaName.Siddhi,
			"Accomplishment"
		},
		{
			NithyaYogaName.Vyatapata,
			"Great fall"
		},
		{
			NithyaYogaName.Variyan,
			"Chief/best"
		},
		{
			NithyaYogaName.Parigha,
			"Obstacle/hindrance"
		},
		{
			NithyaYogaName.Siva,
			"Lord Shiva (purity)"
		},
		{
			NithyaYogaName.Siddha,
			"Accomplished/ready"
		},
		{
			NithyaYogaName.Sadhya,
			"Possible"
		},
		{
			NithyaYogaName.Subha,
			"Auspicious"
		},
		{
			NithyaYogaName.Sukla,
			"White, bright"
		},
		{
			NithyaYogaName.Brahma,
			"Creator (good knowledge and purity)"
		},
		{
			NithyaYogaName.Indra,
			"Ruler of gods"
		},
		{
			NithyaYogaName.Vaidhriti,
			"A class of gods"
		}
	};

	public NithyaYogaName Name { get; set; } = name;

	public string Description { get; set; } = description;

	public static NithyaYoga FromNumber(double nithyaYogaNumber)
	{
		int num = (int)nithyaYogaNumber;
		string descriptionFromName = GetDescriptionFromName((NithyaYogaName)num);
		return new NithyaYoga((NithyaYogaName)num, descriptionFromName);
	}

	private static string GetDescriptionFromName(NithyaYogaName yogaName)
	{
		if (YogaDescriptions.TryGetValue(yogaName, out var value))
		{
			return value;
		}
		return "Unknown Yoga";
	}

	public override string ToString()
	{
		return Name.ToString() + " - " + Description;
	}

	public DataTable ToDataTable()
	{
		DataTable obj = new DataTable
		{
			Columns = 
			{
				{
					"Name",
					typeof(string)
				},
				{
					"Description",
					typeof(string)
				}
			}
		};
		DataRow dataRow = obj.NewRow();
		dataRow["Name"] = Name.ToString();
		dataRow["Description"] = Description;
		obj.Rows.Add(dataRow);
		return obj;
	}

	public byte[] ToJpeg()
	{
		return Tools.DataTableToJpeg(ToDataTable());
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["Name"] = Name.ToString(),
			["Description"] = Description
		};
	}
}
