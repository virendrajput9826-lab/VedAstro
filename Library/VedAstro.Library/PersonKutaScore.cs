using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public record PersonKutaScore(string PersonId, string PersonName, Gender Gender, int Age, double KutaScore)
{
	public static List<PersonKutaScore> FromJsonList(JToken personKutaScoreList)
	{
		List<PersonKutaScore> list = new List<PersonKutaScore>();
		foreach (JToken item2 in (IEnumerable<JToken>)personKutaScoreList)
		{
			string personId = item2["PersonId"]?.Value<string>() ?? "EMPTY";
			string personName = item2["PersonName"]?.Value<string>() ?? "EMPTY";
			Gender gender = Enum.Parse<Gender>(item2["Gender"]?.Value<string>() ?? "Empty", ignoreCase: true);
			int age = item2["Age"]?.Value<int>() ?? 0;
			double kutaScore = item2["KutaScore"]?.Value<double>() ?? 0.0;
			PersonKutaScore item = new PersonKutaScore(personId, personName, gender, age, kutaScore);
			list.Add(item);
		}
		return list;
	}

	public static JArray ToJsonList(List<PersonKutaScore> personList)
	{
		JArray jArray = new JArray();
		foreach (PersonKutaScore person in personList)
		{
			JObject jObject = new JObject();
			jObject["PersonId"] = person.PersonId;
			jObject["PersonName"] = person.PersonName;
			jObject["Gender"] = person.Gender.ToString();
			jObject["Age"] = person.Age;
			jObject["KutaScore"] = person.KutaScore;
			jArray.Add(jObject);
		}
		return jArray;
	}
}
