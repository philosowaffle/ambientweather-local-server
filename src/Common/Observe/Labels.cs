namespace Common.Observe;

public static class Label
{
	// SYSTEM
	public static string Os = "os";
	public static string OsVersion = "os_version";
	public static string Version = "version";
	public static string DotNetRuntime = "dotnet_runtime";
	public static string RunningInDocker = "is_docker";
	public static string LatestVersion = "latest_version";

	// HTTP
	public static string HttpMethod = "http_method";
	public static string HttpHost = "http_host";
	public static string HttpRequestPath = "http_request_path";
	public static string HttpRequestQuery = "http_request_query";
	public static string HttpStatusCode = "http_status_code";
	public static string HttpMessage = "http_message";
	public static string HttpDuration = "http_duration_seconds";

	// DB
	public static string DbMethod = "db_method";
	public static string DbQuery = "db_query";
	public static string DbDuration = "db_duration_seconds";

	// CACHE
	public static string CacheDuration = "cache_duration_seconds";
	public static string CacheHitCounter = "cache_hit_counter";
	public static string CacheMissCounter = "cache_miss_counter";
	public static string CacheName = "cache_name";
	public static string CacheOperation = "cache_operation";
}
