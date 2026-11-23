using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public interface IToJson
{
	JObject ToJson();
}
