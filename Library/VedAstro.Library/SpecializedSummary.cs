using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public class SpecializedSummary : IToJson
{
	public static SpecializedSummary Empty => new SpecializedSummary();

	public SummaryMetadata Mind { get; set; }

	public SummaryMetadata Studies { get; set; }

	public SummaryMetadata Family { get; set; }

	public SummaryMetadata Money { get; set; }

	public SummaryMetadata Love { get; set; }

	public SummaryMetadata Body { get; set; }

	JObject IToJson.ToJson()
	{
		return ToJson();
	}

	public JObject ToJson()
	{
		return new JObject
		{
			["Mind"] = SummaryMetadataToJson(Mind),
			["Studies"] = SummaryMetadataToJson(Studies),
			["Family"] = SummaryMetadataToJson(Family),
			["Money"] = SummaryMetadataToJson(Money),
			["Love"] = SummaryMetadataToJson(Love),
			["Body"] = SummaryMetadataToJson(Body)
		};
	}

	public static SpecializedSummary FromJson(JToken eventData)
	{
		return new SpecializedSummary
		{
			Mind = eventData["Mind"].ToObject<SummaryMetadata>(),
			Studies = eventData["Studies"].ToObject<SummaryMetadata>(),
			Family = eventData["Family"].ToObject<SummaryMetadata>(),
			Money = eventData["Money"].ToObject<SummaryMetadata>(),
			Love = eventData["Love"].ToObject<SummaryMetadata>(),
			Body = eventData["Body"].ToObject<SummaryMetadata>()
		};
	}

	private static JToken SummaryMetadataToJson(SummaryMetadata metadata)
	{
		if (metadata == null)
		{
			return null;
		}
		return new JObject
		{
			["Weight"] = metadata.Weight,
			["Nature"] = metadata.Nature.ToString()
		};
	}
}
