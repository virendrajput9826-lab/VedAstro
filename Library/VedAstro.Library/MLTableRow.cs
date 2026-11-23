using System.Collections.Generic;

namespace VedAstro.Library;

public class MLTableRow
{
	public Time Time { get; set; }

	public List<APIFunctionResult> DataColumns { get; set; }

	public MLTableRow(Time time, List<APIFunctionResult> dataRowList)
	{
		Time = time;
		DataColumns = dataRowList;
	}
}
