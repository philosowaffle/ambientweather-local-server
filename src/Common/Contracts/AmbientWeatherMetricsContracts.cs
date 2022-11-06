﻿namespace Common.Contracts;

/// <summary>
/// https://ambientweather.com/faqs/question/view/id/1857/
/// </summary>
public record AmbientWeatherMetricsPostRequest : IAmbientWeatherMetrics
{
	public Source Source => Source.Local;

	public string? Mac { get; init; }
	public string? StationType { get; init; }
	public string? PassKey { get; init; }
	public DateTime? DateUtc { get; init; }
	public int? WindDir { get; init; }
	public float? WindSpeedMph { get; init; }
	public float? WindGustMph { get; init; }
	public int? WindGustDir { get; init; }
	public float? MaxDailyGust { get; init; }
	public float? WindSpdMph_Avg2m { get; init; }
	public int? WindDir_Avg2m { get; init; }
	public float? WindSpdMph_Avg10m { get; init; }
	public int? WindDir_Avg10m { get; init; }
	public int? WindGustMph_Interval { get; init; }
	public int? Humidity { get; init; }
	public int? HumidityIn { get; init; }
	public int? Humidity1 { get; init; }
	public int? Humidity2 { get; init; }
	public int? Humidity3 { get; init; }
	public int? Humidity4 { get; init; }
	public int? Humidity5 { get; init; }
	public int? Humidity6 { get; init; }
	public int? Humidity7 { get; init; }
	public int? Humidity8 { get; init; }
	public int? Humidity9 { get; init; }
	public int? Humidity10 { get; init; }
	public float? TempF { get; init; }
	public float? TempInF { get; init; }
	public float? Temp1F { get; init; }
	public float? Temp2F { get; init; }
	public float? Temp3F { get; init; }
	public float? Temp4F { get; init; }
	public float? Temp5F { get; init; }
	public float? Temp6F { get; init; }
	public float? Temp7F { get; init; }
	public float? Temp8F { get; init; }
	public float? Temp9F { get; init; }
	public float? Temp10F { get; init; }
	public float? HourlyRainIn { get; init; }
	public float? DailyRainIn { get; init; }
	public float? TwentyFourHourRainIn { get; init; }
	public float? WeeklyRainIn { get; init; }
	public float? MonthlyRainIn { get; init; }
	public float? YearlyRainIn { get; init; }
	public float? EventRainIn { get; init; }
	public float? TotalRain { get; init; }
	public float? BaromRelIn { get; init; }
	public float? BaromAbsIn { get; init; }
	public int? UV { get; init; }
	public float? SolarRadiation { get; init; }
	public int? CO2 { get; init; }
	public int? PM25 { get; init; }
	public float? PM25_24h { get; init; }
	public int? PM25_In { get; init; }
	public float? PM25_In_24h { get; init; }
	public int? PM10_In { get; init; }
	public float? PM10_In_24h { get; init; }
	public int? CO2_In { get; init; }
	public float? CO2_In_24h { get; init; }
	public float? PM_In_Temp { get; init; }
	public int? PM_In_Humidity { get; init; }
	public BoolEnum? Relay1 { get; init; }
	public BoolEnum? Relay2 { get; init; }
	public BoolEnum? Relay3 { get; init; }
	public BoolEnum? Relay4 { get; init; }
	public BoolEnum? Relay5 { get; init; }
	public BoolEnum? Relay6 { get; init; }
	public BoolEnum? Relay7 { get; init; }
	public BoolEnum? Relay8 { get; init; }
	public BoolEnum? Relay9 { get; init; }
	public BoolEnum? Relay10 { get; init; }
	public float? SoilTemp1 { get; init; }
	public float? SoilTemp2 { get; init; }
	public float? SoilTemp3 { get; init; }
	public float? SoilTemp4 { get; init; }
	public float? SoilTemp5 { get; init; }
	public float? SoilTemp6 { get; init; }
	public float? SoilTemp7 { get; init; }
	public float? SoilTemp8 { get; init; }
	public float? SoilTemp9 { get; init; }
	public float? SoilTemp10 { get; init; }
	public int? SoilHum1 { get; init; }
	public int? SoilHum2 { get; init; }
	public int? SoilHum3 { get; init; }
	public int? SoilHum4 { get; init; }
	public int? SoilHum5 { get; init; }
	public int? SoilHum6 { get; init; }
	public int? SoilHum7 { get; init; }
	public int? SoilHum8 { get; init; }
	public int? SoilHum9 { get; init; }
	public int? SoilHum10 { get; init; }
	public LeakSensorState? Leak1 { get; init; }
	public LeakSensorState? Leak2 { get; init; }
	public LeakSensorState? Leak3 { get; init; }
	public LeakSensorState? Leak4 { get; init; }
	public long? Lightning_Time { get; init; }
	public int? Lightning_Day { get; init; }
	public BoolEnum? Lightning_Distance { get; init; }
	public BoolEnum? LowBattery { get; init; }
	public BoolEnum? NormalBattery { get; init; }
	public BoolEnum? BattOut { get; init; }
	public BoolEnum? BattIn { get; init; }
	public BoolEnum? Batt1 { get; init; }
	public BoolEnum? Batt2 { get; init; }
	public BoolEnum? Batt3 { get; init; }
	public BoolEnum? Batt4 { get; init; }
	public BoolEnum? Batt5 { get; init; }
	public BoolEnum? Batt6 { get; init; }
	public BoolEnum? Batt7 { get; init; }
	public BoolEnum? Batt8 { get; init; }
	public BoolEnum? Batt9 { get; init; }
	public BoolEnum? Batt10 { get; init; }
	public BoolEnum? BattR1 { get; init; }
	public BoolEnum? BattR2 { get; init; }
	public BoolEnum? BattR3 { get; init; }
	public BoolEnum? BattR4 { get; init; }
	public BoolEnum? BattR5 { get; init; }
	public BoolEnum? BattR6 { get; init; }
	public BoolEnum? BattR7 { get; init; }
	public BoolEnum? BattR8 { get; init; }
	public BoolEnum? BattR9 { get; init; }
	public BoolEnum? BattR10 { get; init; }
	public BoolEnum? Batt_25 { get; init; }
	public BoolEnum? Batt_25In { get; init; }
	public BoolEnum? BatLeak1 { get; init; }
	public BoolEnum? BatLeak2 { get; init; }
	public BoolEnum? BatLeak3 { get; init; }
	public BoolEnum? BatLeak4 { get; init; }
	public BoolEnum? Batt_Lightning { get; init; }
	public BoolEnum? BattSM1 { get; init; }
	public BoolEnum? BattSM2 { get; init; }
	public BoolEnum? BattSM3 { get; init; }
	public BoolEnum? BattSM4 { get; init; }
	public BoolEnum? BattRain { get; init; }
	public BoolEnum? Batt_Co2 { get; init; }
	public double? DewPoint { get; init; }
	public double? DewPoint1 { get; init; }
	public double? DewPoint2 { get; init; }
	public double? DewPoint3 { get; init; }
	public double? DewPoint4 { get; init; }
	public double? DewPoint5 { get; init; }
	public double? DewPoint6 { get; init; }
	public double? DewPoint7 { get; init; }
	public double? DewPoint8 { get; init; }
	public double? DewPoint9 { get; init; }
	public double? DewPoint10 { get; init; }
	public double? DewPointIn { get; init; }
	public double? FeelsLike { get; init; }
	public double? FeelsLike1 { get; init; }
	public double? FeelsLike2 { get; init; }
	public double? FeelsLike3 { get; init; }
	public double? FeelsLike4 { get; init; }
	public double? FeelsLike5 { get; init; }
	public double? FeelsLike6 { get; init; }
	public double? FeelsLike7 { get; init; }
	public double? FeelsLike8 { get; init; }
	public double? FeelsLike9 { get; init; }
	public double? FeelsLike10 { get; init; }
	public double? FeelsLikeIn { get; init; }
}
