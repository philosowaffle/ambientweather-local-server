using Common.Contracts;

namespace Core.MetricsHandlers.PrometheusMetrics;

public class PrometheusHandler : IMetricsHandler
{
	public Task ProcessAsync(IAmbientWeatherMetrics metrics)
	{
		ProcessHumditiy(metrics);
		ProcessLowBattery(metrics);
		ProcessRain(metrics);
		ProcessSolarRadiation(metrics);
		ProcessTemperature(metrics);
		ProcessUVIndex(metrics);
		ProcessWindDirection(metrics);
		ProcessWindSpeed(metrics);

		return Task.CompletedTask;
	}

	public void ProcessHumditiy(IAmbientWeatherMetrics metrics)
	{
		if (metrics.Humidity.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Humidity
				.WithLabels("outdoor", metrics)
				.Set(metrics.Humidity.Value);
		}

		if (metrics.HumidityIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Humidity
				.WithLabels("indoor", metrics)
				.Set(metrics.HumidityIn.Value);
		}
	}

	public void ProcessLowBattery(IAmbientWeatherMetrics metrics)
	{
		if (metrics.BattIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.LowBattery
				.WithLabels("indoor", metrics)
				.Set((int)metrics.BattIn.Value);
		}

		if (metrics.BattOut.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.LowBattery
				.WithLabels("outdoor", metrics)
				.Set((int)metrics.BattOut.Value);
		}

		if (metrics.Batt_Co2.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.LowBattery
				.WithLabels("co2", metrics)
				.Set((int)metrics.Batt_Co2.Value);
		}
	}

	public void ProcessRain(IAmbientWeatherMetrics metrics)
	{
		if (metrics.EventRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("event", metrics)
				.Set(metrics.EventRainIn.Value);
		}

		if (metrics.HourlyRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("hourly", metrics)
				.Set(metrics.HourlyRainIn.Value);
		}

		if (metrics.DailyRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("daily", metrics)
				.Set(metrics.DailyRainIn.Value);
		}

		if (metrics.WeeklyRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("weekly", metrics)
				.Set(metrics.WeeklyRainIn.Value);
		}

		if (metrics.MonthlyRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("monthly", metrics)
				.Set(metrics.MonthlyRainIn.Value);
		}

		if (metrics.YearlyRainIn.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Rain
				.WithLabels("yearly", metrics)
				.Set(metrics.YearlyRainIn.Value);
		}
	}

	public void ProcessSolarRadiation(IAmbientWeatherMetrics metrics)
	{
		if (metrics.SolarRadiation.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.SolarRadiation
				.WithLabels("solarradiation", metrics)
				.Set(metrics.SolarRadiation.Value);
		}
	}

	public void ProcessTemperature(IAmbientWeatherMetrics metrics)
	{
		if (metrics.TempF.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("outdoor", metrics)
				.Set(metrics.TempF.Value);
		}

		if (metrics.TempInF.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("indoor", metrics)
				.Set(metrics.TempInF.Value);
		}

		if (metrics.Temp1F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp1", metrics)
				.Set(metrics.Temp1F.Value);
		}

		if (metrics.Temp2F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp2", metrics)
				.Set(metrics.Temp2F.Value);
		}

		if (metrics.Temp3F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp3", metrics)
				.Set(metrics.Temp3F.Value);
		}

		if (metrics.Temp4F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp4", metrics)
				.Set(metrics.Temp4F.Value);
		}

		if (metrics.Temp5F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp5", metrics)
				.Set(metrics.Temp5F.Value);
		}

		if (metrics.Temp6F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp6", metrics)
				.Set(metrics.Temp6F.Value);
		}

		if (metrics.Temp7F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp7", metrics)
				.Set(metrics.Temp7F.Value);
		}

		if (metrics.Temp8F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp8", metrics)
				.Set(metrics.Temp8F.Value);
		}

		if (metrics.Temp9F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp9", metrics)
				.Set(metrics.Temp9F.Value);
		}

		if (metrics.Temp10F.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("temp10", metrics)
				.Set(metrics.Temp10F.Value);
		}

		if (metrics.PM_In_Temp.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("pmIndoor", metrics)
				.Set(metrics.PM_In_Temp.Value);
		}

		if (metrics.SoilTemp1.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp1", metrics)
				.Set(metrics.SoilTemp1.Value);
		}

		if (metrics.SoilTemp2.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp2", metrics)
				.Set(metrics.SoilTemp2.Value);
		}

		if (metrics.SoilTemp3.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp3", metrics)
				.Set(metrics.SoilTemp3.Value);
		}

		if (metrics.SoilTemp4.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp4", metrics)
				.Set(metrics.SoilTemp4.Value);
		}

		if (metrics.SoilTemp5.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp5", metrics)
				.Set(metrics.SoilTemp5.Value);
		}

		if (metrics.SoilTemp6.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp6", metrics)
				.Set(metrics.SoilTemp6.Value);
		}

		if (metrics.SoilTemp7.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp7", metrics)
				.Set(metrics.SoilTemp7.Value);
		}

		if (metrics.SoilTemp8.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp8", metrics)
				.Set(metrics.SoilTemp8.Value);
		}

		if (metrics.SoilTemp9.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp9", metrics)
				.Set(metrics.SoilTemp9.Value);
		}

		if (metrics.SoilTemp10.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.Temperature
				.WithLabels("soilTemp10", metrics)
				.Set(metrics.SoilTemp10.Value);
		}
	}

	public void ProcessUVIndex(IAmbientWeatherMetrics metrics)
	{
		if (metrics.UV.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.UVIndex
				.WithLabels("uv", metrics)
				.Set(metrics.UV.Value);
		}
	}

	public void ProcessWindDirection(IAmbientWeatherMetrics metrics)
	{
		if (metrics.WindDir.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("wind", metrics)
				.Set(metrics.WindDir.Value);
		}

		if (metrics.WindGustDir.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("gust", metrics)
				.Set(metrics.WindGustDir.Value);
		}

		if (metrics.WindDir_Avg2m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("2mAvg", metrics)
				.Set(metrics.WindDir_Avg2m.Value);
		}

		if (metrics.WindDir_Avg10m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("10mAvg", metrics)
				.Set(metrics.WindDir_Avg10m.Value);
		}
	}

	public void ProcessWindSpeed(IAmbientWeatherMetrics metrics)
	{
		if (metrics.WindSpeedMph.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindSpeed
				.WithLabels("wind", metrics)
				.Set(metrics.WindSpeedMph.Value);
		}

		if (metrics.WindGustMph.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindSpeed
				.WithLabels("gust", metrics)
				.Set(metrics.WindGustMph.Value);
		}

		if (metrics.WindSpdMph_Avg2m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindSpeed
				.WithLabels("2mAvg", metrics)
				.Set(metrics.WindSpdMph_Avg2m.Value);
		}

		if (metrics.WindSpdMph_Avg10m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindSpeed
				.WithLabels("10mAvg", metrics)
				.Set(metrics.WindSpdMph_Avg10m.Value);
		}

		if (metrics.MaxDailyGust.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindSpeed
				.WithLabels("maxDailyGust", metrics)
				.Set(metrics.MaxDailyGust.Value);
		}
	}
	
}
