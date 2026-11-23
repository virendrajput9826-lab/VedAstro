using System;

namespace VedAstro.Library;

public class URL
{
	public const string ApiBetaDirect = "https://vedastroapibeta.azurewebsites.net/api";

	public const string ApiStableDirect = "https://vedastroapi.azurewebsites.net/api";

	public const string WebBeta = "https://beta.vedastro.org";

	public const string WebStable = "https://vedastro.org";

	public const string WebDirect = "https://vedastrowebsitestorage.z5.web.core.windows.net";

	public readonly string ToolbarSvgAzure;

	public readonly string EventsChartViewerHtml;

	public readonly string HoroscopeDataListXml;

	public readonly string APIHomePageTxt;

	public readonly string ApiUrlDirect;

	public readonly string WebUrl;

	public readonly string WebUrlDirect;

	public readonly string AddressToGeoLocationAPI;

	public readonly string CoordinatesToGeoLocationAPI;

	public readonly string IpAddressToGeoLocationAPI;

	public readonly string GeoLocationToTimezoneAPI;

	public readonly string HoroscopePredictions;

	public readonly string HoroscopeLLMSearch;

	public readonly string AddLifeEventApi;

	public readonly string AddMessageApi;

	public readonly string DeletePerson;

	public readonly string DeleteChartApi;

	public readonly string DeleteVisitorByUserId;

	public readonly string DeleteVisitorByVisitorId;

	public readonly string AddTaskApi;

	public readonly string AddVisitorApi;

	public static readonly string AddVisitorApiStable = "https://vedastroapi.azurewebsites.net/api/addvisitor";

	public readonly string GetSavedMatchReport;

	public readonly string GetMatchReportApi;

	public readonly string SaveMatchReportApi;

	public readonly string GetMatchReportList;

	public readonly string FindMatch;

	public readonly string AddPerson;

	public readonly string GetCallData;

	public readonly string GetMLTimeListFromExcel;

	public readonly string GenerateMLTable;

	public readonly string GetPersonList;

	public readonly string VerifyPersonList;

	public readonly string GetPerson;

	public readonly string GetPersonImage;

	public readonly string GetNewPersonId;

	public readonly string GetPersonIdFromSavedChartId;

	public readonly string UpdatePerson;

	public readonly string UpsertLifeEvent;

	public readonly string GetTaskListApi;

	public readonly string GetVisitorList;

	public readonly string GetMessageList;

	public readonly string GetEventsChart;

	public readonly string GetCallStatus;

	public readonly string GetEventsChartDirect;

	public readonly string GetSavedEventsChart;

	public readonly string GetSavedEventsChartIdList;

	public readonly string SaveEventsChart;

	public readonly string GetEventDataList;

	public readonly string GetEventsApi;

	public readonly string SignInGoogle;

	public readonly string SignInFacebook;

	public readonly string Login;

	public const string GoogleSignInJs = "https://accounts.google.com/gsi/client";

	public const string ExcelSampleMLFile = "https://github.com/VedAstro/VedAstro/raw/master/DataProcessor/TableGeneratorSampleInput.xlsx";

	public const string GeoJsApiUrl = "https://get.geojs.io/v1/ip/geo.json";

	public const string TelescopeBuyPage = "https://want.jp/product/A5D9B087602D14";

	public const string LaptopBuyPage = "https://www.ebay.com/itm/304878531330";

	public const string Paypal = "https://www.paypal.com/sdk/js?client-id=sb&enable-funding=venmo&currency=USD";

	public const string GitHubDiscussions = "https://github.com/orgs/VedAstro/discussions";

	public const string YoutubeChannel = "https://www.youtube.com/@vedastro/videos";

	public const string YoutubePythonGuide = "https://youtu.be/chEeF-xEQ48?si=RNTvGlSD-WXgso7P";

	public const string GitHubDemoFiles = "https://github.com/VedAstro/VedAstro/tree/master/Demo/JavaScript";

	public const string FacebookPage = "https://www.facebook.com/vedastro.org";

	public const string Instagram = "https://www.instagram.com/_vedastro/";

	public const string Twitter = "https://twitter.com/_VedAstro";

	public const string GitHub88000Lines = "https://github.com/VedAstro/VedAstro/discussions/4";

	public const string VedAstroJS = "https://github.com/VedAstro/VedAstro.js";

	public const string VedAstroSwift = "https://github.com/VedAstro/VedAstro.Swift";

	public const string VedAstroNuget = "https://www.nuget.org/packages/VedAstro.Library";

	public const string PatreonPage = "https://patreon.com/vedastro";

	public const string KoFiPage = "https://ko-fi.com/vedastro";

	public const string KoFiPageMemberships = "https://ko-fi.com/vedastro/tiers";

	public const string KoFiSponsorMemberships = "https://ko-fi.com/summary/2f3ac2df-9d55-4c48-87cf-2d6af0b80ceb";

	public const string StripeINRSupportPayementLink = "https://buy.stripe.com/aEU5lU7nV4Pl0DKcMM";

	public const string StripeUSDSupportPayementLink = "https://buy.stripe.com/7sI15E8rZepVbio289";

	public const string KoFiPrivateServer = "https://ko-fi.com/summary/783edc41-20e6-4e78-adb2-d4380577b5d1";

	public const string KoFiDonateIframe = "https://ko-fi.com/vedastro/?hidefeed=true&widget=true&embed=true&preview=true";

	public const string PaypalMePage = "https://paypal.me/VedAstroOrg";

	public const string NasaJplSource = "https://naif.jpl.nasa.gov/pipermail/spice_announce/2007-August/000055.html";

	public const string SwissEphSource = "https://www.astro.com/swisseph/swephinfo_e.htm";

	public const string AzureStorage = "vedastrowebsitestorage.z5.web.core.windows.net";

	public const string WhatsAppContact = "https://wa.me/601113395387?text=Hi";

	public const string TelegramContact = "https://t.me/vedastro_org";

	public const string EmailToClick = "mailto:contact@vedastro.org";

	public const string GitHubRepo = "https://github.com/VedAstro/VedAstro";

	public const string HuggingFaceRepo = "https://huggingface.co/datasets?sort=trending&search=vedastro";

	public const string JHoraEasyImportYoutube = "https://youtu.be/7K0N-2VWno8?si=7O09Xq_3u0YrFiT9";

	public const string GitHubPython = "https://github.com/VedAstro/VedAstro.Python";

	public const string GitHubIssues = "https://github.com/VedAstro/VedAstro/issues";

	public const string GitHubCommits = "https://github.com/gen-so/Genso.Astrology/commits/master";

	public const string GitDeveloperRoomProject = "https://github.com/orgs/VedAstro/projects/1";

	public const string SlackInviteURL = "https://join.slack.com/t/vedastro/shared_invite/zt-1u7pdqjky-hrJZ7e3_vM2dZOmVY8FeHA";

	public const string JohnLenonImagine = "https://youtu.be/rAn-AWXtHv0";

	public const string YukteswarWiki = "https://en.wikipedia.org/wiki/Swami_Sri_Yukteswar_Giri";

	public const string WHAudenWiki = "https://en.wikipedia.org/wiki/W._H._Auden";

	public const string SwamiRamaWiki = "https://en.wikipedia.org/wiki/Swami_Rama";

	public const string StarsThatDontGiveDam = "https://youtu.be/RhtrXdirXk4";

	public const string YoganandaWiki = "https://en.wikipedia.org/wiki/Paramahansa_Yogananda";

	public const string CarlSaganWiki = "https://en.wikipedia.org/wiki/Carl_Sagan";

	public const string RamanujanWiki = "https://en.wikipedia.org/wiki/Srinivasa_Ramanujan";

	public const string EmersonWiki = "https://en.wikipedia.org/wiki/Ralph_Waldo_Emerson";

	public const string MahatmaGandhiWiki = "https://en.wikipedia.org/wiki/Mahatma_Gandhi";

	public const string LaSalleWiki = "https://en.wikipedia.org/wiki/Jean-Baptiste_de_La_Salle";

	public const string BVRamanWiki = "https://en.wikipedia.org/wiki/B._V._Raman";

	public const string MiltonFriedmanWiki = "https://en.wikipedia.org/wiki/Milton_Friedman";

	public const string RamanujanQuoteWiki = "https://en.wikipedia.org/wiki/Srinivasa_Ramanujan#Personality_and_spiritual_life";

	public const string StPaulWiki = "https://en.wikipedia.org/wiki/Paul_the_Apostle";

	public const string FreedmanYoutubePencil = "https://youtu.be/67tHtpac5ws";

	public const string APIGuideNextStep = "https://youtu.be/y110RAgIorY?t=127";

	public const string Donate = "https://vedastro.org/Donate";

	public const string VSLifeSharePublicSession = "https://prod.liveshare.vsengsaas.visualstudio.com/join?CBAE0FED0D849DD2E74F90CD7F4DC639AA89";

	public const string HoroscopeDataListFile = "https://vedastrowebsitestorage.z5.web.core.windows.net/data/HoroscopeDataList.xml";

	public const string DesktopAppDownload = "https://vedastrowebsitestorage.blob.core.windows.net/download/VedAstroSetup.exe";

	public URL(bool isBetaRuntime, bool? debugMode = null)
	{
		ApiUrlDirect = Calculate.CurrentServerAddress;
		WebUrl = (isBetaRuntime ? "https://beta.vedastro.org" : "https://vedastro.org");
		WebUrlDirect = "https://vedastrowebsitestorage.z5.web.core.windows.net";
		GetCallData = ApiUrlDirect + "/GetCallData";
		Login = WebUrl + "/Account/Login";
		GetMLTimeListFromExcel = ApiUrlDirect + "/GetMLTimeListFromExcel";
		GenerateMLTable = ApiUrlDirect + "/GenerateMLTable";
		GetPersonList = ApiUrlDirect + "/GetPersonList";
		VerifyPersonList = ApiUrlDirect + "/VerifyPersonList";
		AddPerson = ApiUrlDirect + "/AddPerson";
		DeletePerson = ApiUrlDirect + "/DeletePerson";
		UpdatePerson = ApiUrlDirect + "/UpdatePerson";
		UpsertLifeEvent = ApiUrlDirect + "/UpsertLifeEvent";
		GetPerson = ApiUrlDirect + "/GetPerson";
		GetPersonImage = ApiUrlDirect + "/GetPersonImage/PersonId";
		GetNewPersonId = ApiUrlDirect + "/GetNewPersonId";
		AddressToGeoLocationAPI = ApiUrlDirect + "/Calculate/AddressToGeoLocation";
		CoordinatesToGeoLocationAPI = ApiUrlDirect + "/Calculate/CoordinatesToGeoLocation";
		IpAddressToGeoLocationAPI = ApiUrlDirect + "/Calculate/IpAddressToGeoLocation";
		GeoLocationToTimezoneAPI = ApiUrlDirect + "/Calculate/GeoLocationToTimezone";
		HoroscopePredictions = ApiUrlDirect + "/Calculate/HoroscopePredictions";
		HoroscopeLLMSearch = ApiUrlDirect + "/Calculate/HoroscopeLLMSearch";
		AddLifeEventApi = ApiUrlDirect + "/addlifeevent";
		AddMessageApi = ApiUrlDirect + "/addmessage";
		DeleteChartApi = ApiUrlDirect + "/deletesavedchart";
		DeleteVisitorByUserId = ApiUrlDirect + "/deletevisitorbyuserid";
		DeleteVisitorByVisitorId = ApiUrlDirect + "/deletevisitorbyvisitorid";
		AddTaskApi = ApiUrlDirect + "/addtask";
		AddVisitorApi = ApiUrlDirect + "/addvisitor";
		GetTaskListApi = ApiUrlDirect + "/gettasklist";
		GetVisitorList = ApiUrlDirect + "/getvisitorlist";
		GetMessageList = ApiUrlDirect + "/getmessagelist";
		FindMatch = ApiUrlDirect + "/FindMatch";
		GetMatchReportList = ApiUrlDirect + "/GetMatchReportList";
		GetPersonIdFromSavedChartId = ApiUrlDirect + "/getpersonidfromsavedchartid";
		GetMatchReportApi = ApiUrlDirect + "/getmatchreport";
		GetSavedMatchReport = ApiUrlDirect + "/GetSavedMatchReport";
		SaveMatchReportApi = ApiUrlDirect + "/SaveMatchReport";
		GetEventsChart = ApiUrlDirect + "/EventsChart";
		GetCallStatus = ApiUrlDirect + "/GetCallStatus";
		GetEventsChartDirect = ApiUrlDirect + "/geteventschart";
		GetSavedEventsChart = ApiUrlDirect + "/getsavedeventschart";
		GetSavedEventsChartIdList = ApiUrlDirect + "/getsavedchartnamelist";
		SaveEventsChart = ApiUrlDirect + "/SaveEventsChart";
		GetEventDataList = ApiUrlDirect + "/GetEventDataList";
		GetEventsApi = ApiUrlDirect + "/getevents";
		SignInGoogle = ApiUrlDirect + "/SignInGoogle";
		SignInFacebook = ApiUrlDirect + "/SignInFacebook";
		HoroscopeDataListXml = WebUrlDirect + "/data/HoroscopeDataList.xml";
		EventsChartViewerHtml = WebUrlDirect + "/data/EventsChartViewer.html";
		ToolbarSvgAzure = WebUrl + "/svg/Toolbar.svg";
		APIHomePageTxt = WebUrl + "/data/APIHomePage.html";
		Console.WriteLine("Dynamic URL:" + (isBetaRuntime ? "Beta" : "Stable"));
	}
}
