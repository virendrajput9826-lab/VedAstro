using System.Threading.Tasks;

namespace VedAstro.Library;

public interface IFromUrl
{
	static int OpenAPILength = 2;

	static abstract Task<dynamic> FromUrl(string url);
}
