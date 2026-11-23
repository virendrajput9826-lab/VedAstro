using System.Xml.Linq;

namespace VedAstro.Library;

public interface IToXml
{
	XElement ToXml();

	dynamic FromXml<T>(XElement personXml) where T : IToXml;
}
