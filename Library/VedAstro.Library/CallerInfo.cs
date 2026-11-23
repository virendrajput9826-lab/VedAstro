namespace VedAstro.Library;

public class CallerInfo
{
	public string CallerId { get; set; }

	public string VisitorId { get; set; }

	public string UserId { get; set; }

	public bool IsLoggedIn => UserId != "101";

	public bool Both101
	{
		get
		{
			if (UserId == "101")
			{
				return VisitorId == "101";
			}
			return false;
		}
	}

	public CallerInfo(string visitorId, string userId)
	{
		VisitorId = visitorId;
		UserId = userId;
		CallerId = Tools.GetCallerId(UserId, VisitorId);
	}

	public override string ToString()
	{
		return $"{{ UserId = {UserId}, VisitorId = {VisitorId} }}";
	}
}
