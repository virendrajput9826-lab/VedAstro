using System;
using System.Linq;
using System.Threading.Tasks;

namespace VedAstro.Library;

public static class PersonManagerTools
{
	public static async Task<string> GeneratePersonId(string ownerId, string personName, string birthYear, bool failIfDuplicate = false)
	{
		string text = Tools.RemoveWhiteSpace(personName) + birthYear;
		bool flag = IsUniquePersonId(text);
		if (failIfDuplicate && !flag)
		{
			throw new Exception("Person ID already Exist!");
		}
		int num = 1;
		string text2;
		while (true)
		{
			text2 = text;
			if (flag)
			{
				break;
			}
			text2 += num;
			num++;
			flag = IsUniquePersonId(text2);
			if (flag)
			{
				return text2;
			}
		}
		return text2;
		static bool IsUniquePersonId(string personId)
		{
			return !(AzureTable.PersonList_Indic?.Query((PersonListEntity row) => row.RowKey == personId)).Any();
		}
	}
}
