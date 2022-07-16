namespace Common.Observe;

public static class Label
{
    public static string LabelPrefix = "ambientweather";

	// SYSTEM
	public static string BuildInfo = $"{LabelPrefix}_build_info";
	public static string Os = $"{LabelPrefix}_os";
	public static string OsVersion = $"{LabelPrefix}_os_version";
	public static string Version = $"{LabelPrefix}_version";
	public static string DotNetRuntime = $"{LabelPrefix}_dotnet_runtime";

	// HTTP
	public static string HttpMethod = $"{LabelPrefix}_http_method";
	public static string HttpHost = $"{LabelPrefix}_http_host";
	public static string HttpRequestPath = $"{LabelPrefix}_http_request_path";
	public static string HttpRequestQuery = $"{LabelPrefix}_http_request_query";
	public static string HttpStatusCode = $"{LabelPrefix}_http_status_code";
	public static string HttpMessage = $"{LabelPrefix}_http_message";
	public static string HttpDuration = $"{LabelPrefix}_http_duration_seconds";

	// DB
	public static string DbMethod = $"{LabelPrefix}_db_method";
	public static string DbQuery = $"{LabelPrefix}_db_query";
	public static string DbDuration = $"{LabelPrefix}_db_duration_seconds";

	// CACHE
	public static string CacheDuration = $"{LabelPrefix}_cache_duration_seconds";
	public static string CacheHitCounter = $"{LabelPrefix}_cache_hit_counter";
	public static string CacheMissCounter = $"{LabelPrefix}_cache_miss_counter";
	public static string CacheName = $"{LabelPrefix}_cache_name";
	public static string CacheOperation = $"{LabelPrefix}_cache_operation";
}
