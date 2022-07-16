using Prometheus;

namespace Common.Observe;
public static class CacheMetrics
{
	public static readonly Histogram CacheActionDuration = Prometheus.Metrics.CreateHistogram(Label.CacheDuration, "Histogram of Cache duration.", new HistogramConfiguration()
	{
		LabelNames = new[] { Label.CacheName, Label.CacheOperation }
	});
}