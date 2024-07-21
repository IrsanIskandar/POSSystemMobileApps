namespace POSSystem.WebServices.Helpers;

public static class POSHelper
{
	public static string POS_CONNECTION_STRING { get; set; }
	public static string POS_DB_PASSWORD { get; set; }

	public static string JWT_KEY { get; set; }
	public static string JWT_ISSUER { get; set; }
	public static string JWT_AUDIENCE { get; set; }
}
