namespace Common.Contracts;
public interface IAmbientWeatherMetrics
{
	/// <summary>
	/// Did this data originate from a Local Console or from the Cloud
	/// </summary>
	public Source Source { get; }

	/// <summary>
	/// Mac Address of the weather console
	/// </summary>
	public string? Mac { get; set; }

	/// <summary>
	/// AmbientWeather System Type
	/// </summary>
	public string? StationType { get; init; }
	/// <summary>
	/// This can also be the mac address
	/// </summary>
	public string? PassKey { get; init; }
	/// <summary>
	/// UTC Date and Time of last update
	/// </summary>
	public DateTime? DateUtc { get; init; }
	/// <summary>
	/// 0-360º instantaneous wind direction
	/// </summary>
	public short? WindDir { get; init; }
	/// <summary>
	/// instantaneous wind speed
	/// </summary>
	public float? WindSpeedMph { get; init; }
	/// <summary>
	/// instantaneous wind gust
	/// </summary>
	public float? WindGustMph { get; init; }
	/// <summary>
	/// Wind direction at which the wind gust occurred, 0-360º
	/// </summary>
	public short? WindGustDir { get; init; }
	/// <summary>
	/// MPH
	/// </summary>
	public float? MaxDailyGust { get; init; }
	/// <summary>
	/// Average wind speed, 2 minute average
	/// </summary>
	public float? WindSpdMph_Avg2m { get; init; }
	/// <summary>
	/// Average wind direction, 2 minute average, 0-360deg
	/// </summary>
	public short? WindDir_Avg2m { get; init; }
	/// <summary>
	/// Average wind speed, 10 minute average
	/// </summary>
	public float? WindSpdMph_Avg10m { get; init; }
	/// <summary>
	/// Average wind direction, 10 minute average, 0-360deg
	/// </summary>
	public short? WindDir_Avg10m { get; init; }
	/// <summary>
	/// Max Wind Speed in update shorterval, the default is one minute
	/// </summary>
	public short? WindGustMph_Interval { get; init; }
	/// <summary>
	/// Outdoor Humidity, 0-100%
	/// </summary>
	public short? Humidity { get; init; }
	/// <summary>
	/// Indoor Humidity, 0-100%
	/// </summary>
	public short? HumidityIn { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity1 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity2 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity3 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity4 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity5 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity6 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity7 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity8 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity9 { get; init; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public short? Humidity10 { get; init; }
	/// <summary>
	/// Outdoor Temperature
	/// </summary>
	public float? TempF { get; init; }
	/// <summary>
	/// Indoor Temperature
	/// </summary>
	public float? TempInF { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp1F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp2F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp3F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp4F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp5F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp6F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp7F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp8F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp9F { get; init; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp10F { get; init; }
	/// <summary>
	/// Hourly Rain inches
	/// </summary>
	public float? HourlyRainIn { get; init; }
	public float? DailyRainIn { get; init; }
	// TODO - map to 24HourRainIn
	public float? TwentyFourHourRainIn { get; init; }
	public float? WeeklyRainIn { get; init; }
	public float? MonthlyRainIn { get; init; }
	public float? YearlyRainIn { get; init; }
	public float? EventRainIn { get; init; }
	/// <summary>
	/// inches
	/// </summary>
	public float? TotalRain { get; init; }
	/// <summary>
	/// Relative Pressure - inHg
	/// </summary>
	public float? BaromRelIn { get; init; }
	/// <summary>
	/// Absolute Pressure - inHg
	/// </summary>
	public float? BaromAbsIn { get; init; }
	/// <summary>
	/// Ultra-Violet Radiation Index
	/// </summary>
	public short? UV { get; init; }
	/// <summary>
	/// W/m^2
	/// </summary>
	public float? SolarRadiation { get; init; }
	/// <summary>
	/// ppm
	/// </summary>
	public short? CO2 { get; init; }
	/// <summary>
	/// PM2.5 Air Quality Sensor - µg/m3
	/// </summary>
	public short? PM25 { get; init; }
	/// <summary>
	/// PM2.5 Air Quality Sensor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM25_24h { get; init; }
	/// <summary>
	/// PM2.5 Air Quality Sensor, indoor - µg/m3
	/// </summary>
	public short? PM25_In { get; init; }
	/// <summary>
	/// PM2.5 Air Quality Sensor indoor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM25_In_24h { get; init; }
	/// <summary>
	/// PM1.0 Air Quality Sensor - µg/m3
	/// </summary>
	public short? PM10_In { get; init; }
	/// <summary>
	/// PM1.0 Air Quality Sensor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM10_In_24h { get; init; }
	/// <summary>
	/// Indoor CO2 - ppm
	/// </summary>
	public short? CO2_In { get; init; }
	/// <summary>
	/// Indoor CO2, 24 hour running average - ppm
	/// </summary>
	public float? CO2_In_24h { get; init; }
	/// <summary>
	///  	Indoor PM sensor temperature - F
	/// </summary>
	public float? PM_In_Temp { get; init; }
	/// <summary>
	/// Indoor PM sensor humidity - %
	/// </summary>
	public short? PM_In_Humidity { get; init; }
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
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp1 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp2 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp3 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp4 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp5 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp6 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp7 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp8 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp9 { get; init; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp10 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum1 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum2 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum3 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum4 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum5 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum6 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum7 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum8 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum9 { get; init; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public short? SoilHum10 { get; init; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak1 { get; init; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak2 { get; init; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak3 { get; init; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak4 { get; init; }
	/// <summary>
	/// Last strike date and time 	
	/// Seconds since January 1, 1970
	/// </summary>
	public ulong? Lightning_Time { get; init; }
	/// <summary>
	/// Number of strikes per day
	/// </summary>
	public short? Lightning_Day { get; init; }
	/// <summary>
	/// Distance of last strike - km
	/// </summary>
	public BoolEnum? Lightning_Distance { get; init; }
	public BoolEnum? LowBattery { get; init; }
	public BoolEnum? NormalBattery { get; init; }
	/// <summary>
	/// Low battery indication, outdoor sensor array or suite
	/// </summary>
	public BoolEnum? BattOut { get; init; }
	/// <summary>
	/// Low battery indication, indoor sensor or console
	/// </summary>
	public BoolEnum? BattIn { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt1 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt2 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt3 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt4 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt5 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt6 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt7 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt8 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt9 { get; init; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt10 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR1 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR2 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR3 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR4 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR5 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR6 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR7 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR8 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR9 { get; init; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR10 { get; init; }
	/// <summary>
	/// Low battery indication, PM2.5
	/// </summary>
	public BoolEnum? Batt_25 { get; init; }
	/// <summary>
	/// Low battery indication, PM2.5 indoor
	/// </summary>
	public BoolEnum? Batt_25In { get; init; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak1 { get; init; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak2 { get; init; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak3 { get; init; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak4 { get; init; }
	/// <summary>
	/// Low battery lighting sensor
	/// </summary>
	public BoolEnum? Batt_Lightning { get; init; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM1 { get; init; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM2 { get; init; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM3 { get; init; }

	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM4 { get; init; }
	/// <summary>
	/// Low battry Rain Gauge
	/// </summary>
	public BoolEnum? BattRain { get; init; }
	public BoolEnum? Batt_Co2 { get; init; }

	/// <summary>
	/// Source: Cloud
	/// Dew Poshort in F
	/// </summary>
	public float? DewPoint { get; init; }
	public float? DewPoint1 { get; init; }
	public float? DewPoint2 { get; init; }
	public float? DewPoint3 { get; init; }
	public float? DewPoint4 { get; init; }
	public float? DewPoint5 { get; init; }
	public float? DewPoint6 { get; init; }
	public float? DewPoint7 { get; init; }
	public float? DewPoint8 { get; init; }
	public float? DewPoint9 { get; init; }
	public float? DewPoint10 { get; init; }
	/// <summary>
	/// Indoor
	/// </summary>
	public float? DewPointIn { get; init; }
	/// <summary>
	/// Source: Cloud
	/// if < 50ºF => Wind Chill, if > 68ºF => Heat Index (calculated on server)
	/// </summary>
	public float? FeelsLike { get; init; }
	public float? FeelsLike1 { get; init; }
	public float? FeelsLike2 { get; init; }
	public float? FeelsLike3 { get; init; }
	public float? FeelsLike4 { get; init; }
	public float? FeelsLike5 { get; init; }
	public float? FeelsLike6 { get; init; }
	public float? FeelsLike7 { get; init; }
	public float? FeelsLike8 { get; init; }
	public float? FeelsLike9 { get; init; }
	public float? FeelsLike10 { get; init; }
	/// <summary>
	/// Indoor
	/// </summary>
	public float? FeelsLikeIn { get; init; }

}

public enum Source : byte
{
	Unknown = 0,
	Local = 1,
	Cloud = 2
}

public enum LeakSensorState : byte
{
	NoLeak = 0,
	Leak = 1,
	LossOfCommunication = 2, // for over 10 minutes
}

public enum BoolEnum : byte
{
	False = 0,
	True = 1
}
