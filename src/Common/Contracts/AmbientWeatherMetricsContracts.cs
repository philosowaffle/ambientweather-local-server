﻿namespace Common.Contracts;

/// <summary>
/// https://ambientweather.com/faqs/question/view/id/1857/
/// </summary>
public class AmbientWeatherMetricsPostRequest
{
	/// <summary>
	/// Mac Address of the weather console
	/// </summary>
	public string? Mac { get; set; }

	/// <summary>
	/// AmbientWeather System Type
	/// </summary>
	public string? StationType { get; set; }
	/// <summary>
	/// This can also be the mac address
	/// </summary>
	public string? PassKey { get; set; }
	public DateTime DateUtc { get; set; }
	/// <summary>
	/// 0-360º instantaneous wind direction
	/// </summary>
	public int? WindDir { get; set; }
	/// <summary>
	/// instantaneous wind speed
	/// </summary>
	public float? WindSpeedMph { get; set; }
	/// <summary>
	/// instantaneous wind gust
	/// </summary>
	public float? WindGustMph { get; set; }
	/// <summary>
	/// Wind direction at which the wind gust occurred, 0-360º
	/// </summary>
	public int? WindGustDir { get; set; }
	/// <summary>
	/// MPH
	/// </summary>
	public float? MaxDailyGust { get; set; }
	/// <summary>
	/// Average wind speed, 2 minute average
	/// </summary>
	public float? WindSpdMph_Avg2m { get; set; }
	/// <summary>
	/// Average wind direction, 2 minute average, 0-360deg
	/// </summary>
	public int? WindDir_Avg2m { get; set; }
	/// <summary>
	/// Average wind speed, 10 minute average
	/// </summary>
	public float? WindSpdMph_Avg10m { get; set; }
	/// <summary>
	/// Average wind direction, 10 minute average, 0-360deg
	/// </summary>
	public int? WindDir_Avg10m { get; set; }
	/// <summary>
	/// Max Wind Speed in update interval, the default is one minute
	/// </summary>
	public int? WindGustMph_Interval { get; set; }
	/// <summary>
	/// Outdoor Humidity, 0-100%
	/// </summary>
	public int? Humidity { get; set; }
	/// <summary>
	/// Indoor Humidity, 0-100%
	/// </summary>
	public int? HumidityIn { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity1 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity2 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity3 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity4 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity5 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity6 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity7 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity8 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity9 { get; set; }
	/// <summary>
	/// Humidity, 0-100%
	/// </summary>
	public int? Humidity10 { get; set; }
	/// <summary>
	/// Outdoor Temperature
	/// </summary>
	public float? TempF { get; set; }
	/// <summary>
	/// Indoor Temperature
	/// </summary>
	public float? TempInF { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp1F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp2F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp3F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp4F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp5F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp6F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp7F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp8F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp9F { get; set; }
	/// <summary>
	/// Temperature
	/// </summary>
	public float? Temp10F { get; set; }
	/// <summary>
	/// Hourly Rain inches
	/// </summary>
	public float? HourlyRainIn { get; set; }
	public float? DailyRainIn { get; set; }
	// TODO - map to 24HourRainIn
	public float? TwentyFourHourRainIn {get; set;}
	public float? WeeklyRainIn { get; set; }
	public float? MonthlyRainIn { get; set; }
	public float? YearlyRainIn { get; set; }
	public float? EventRainIn { get; set; }
	/// <summary>
	/// inches
	/// </summary>
	public float? TotalRain { get; set; }
	/// <summary>
	/// Relative Pressure - inHg
	/// </summary>
	public float? BaromRelIn { get; set; }
	/// <summary>
	/// Absolute Pressure - inHg
	/// </summary>
	public float? BaromAbsIn { get; set; }
	/// <summary>
	/// Ultra-Violet Radiation Index
	/// </summary>
	public int? UV { get; set; }
	/// <summary>
	/// W/m^2
	/// </summary>
	public float? SolarRadiation { get; set; }
	/// <summary>
	/// ppm
	/// </summary>
	public int? CO2 { get; set; }
	/// <summary>
	/// PM2.5 Air Quality Sensor - µg/m3
	/// </summary>
	public int? PM25 { get; set; }
	/// <summary>
	/// PM2.5 Air Quality Sensor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM25_24h { get; set; }
	/// <summary>
	/// PM2.5 Air Quality Sensor, indoor - µg/m3
	/// </summary>
	public int? PM25_In { get; set; }
	/// <summary>
	/// PM2.5 Air Quality Sensor indoor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM25_In_24h { get; set; }
	/// <summary>
	/// PM1.0 Air Quality Sensor - µg/m3
	/// </summary>
	public int? PM10_In { get; set; }
	/// <summary>
	/// PM1.0 Air Quality Sensor, 24 hour running average - µg/m3
	/// </summary>
	public float? PM10_In_24h { get; set; }
	/// <summary>
	/// Indoor CO2 - ppm
	/// </summary>
	public int? CO2_In { get; set; }
	/// <summary>
	/// Indoor CO2, 24 hour running average - ppm
	/// </summary>
	public float? CO2_In_24h { get; set; }
	/// <summary>
	///  	Indoor PM sensor temperature - F
	/// </summary>
	public float? PM_In_Temp { get; set; }
	/// <summary>
	/// Indoor PM sensor humidity - %
	/// </summary>
	public int? PM_In_Humidity { get; set; }
	public BoolEnum? Relay1 { get; set; }
	public BoolEnum? Relay2 { get; set; }
	public BoolEnum? Relay3 { get; set; }
	public BoolEnum? Relay4 { get; set; }
	public BoolEnum? Relay5 { get; set; }
	public BoolEnum? Relay6 { get; set; }
	public BoolEnum? Relay7 { get; set; }
	public BoolEnum? Relay8 { get; set; }
	public BoolEnum? Relay9 { get; set; }
	public BoolEnum? Relay10 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp1 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp2 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp3 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp4 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp5 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp6 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp7 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp8 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp9 { get; set; }
	/// <summary>
	/// F
	/// </summary>
	public float? SoilTemp10 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum1 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum2 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum3 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum4 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum5 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum6 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum7 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum8 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum9 { get; set; }
	/// <summary>
	/// Soil Moisture - %
	/// </summary>
	public int? SoilHum10 { get; set; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak1 { get; set; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak2 { get; set; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak3 { get; set; }
	/// <summary>
	/// Leak Detection
	/// </summary>
	public LeakSensorState? Leak4 { get; set; }
	/// <summary>
	/// Last strike date and time 	
	/// Seconds since January 1, 1970
	/// </summary>
	public long? Lightning_Time { get; set; }
	/// <summary>
	/// Number of strikes per day
	/// </summary>
	public int? Lightning_Day { get; set; }
	/// <summary>
	/// Distance of last strike - km
	/// </summary>
	public BoolEnum? Lightning_Distance { get; set; }
	public BoolEnum? LowBattery { get; set; }
	public BoolEnum? NormalBattery { get; set; }
	/// <summary>
	/// Low battery indication, outdoor sensor array or suite
	/// </summary>
	public BoolEnum? BattOut { get; set; }
	/// <summary>
	/// Low battery indication, indoor sensor or console
	/// </summary>
	public BoolEnum? BattIn { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt1 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt2 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt3 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt4 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt5 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt6 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt7 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt8 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt9 { get; set; }
	/// <summary>
	/// Low battery indication
	/// </summary>
	public BoolEnum? Batt10 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR1 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR2 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR3 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR4 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR5 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR6 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR7 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR8 { get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR9{ get; set; }
	/// <summary>
	/// Low battery relay indication
	/// </summary>
	public BoolEnum? BattR10 { get; set; }
	/// <summary>
	/// Low battery indication, PM2.5
	/// </summary>
	public BoolEnum? Batt_25 { get; set; }
	/// <summary>
	/// Low battery indication, PM2.5 indoor
	/// </summary>
	public BoolEnum? Batt_25In { get; set; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak1 { get; set; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak2 { get; set; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak3 { get; set; }
	/// <summary>
	/// Low battery leak detection
	/// </summary>
	public BoolEnum? BatLeak4 { get; set; }
	/// <summary>
	/// Low battery lighting sensor
	/// </summary>
	public BoolEnum? Batt_Lightning { get; set; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM1 { get; set; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM2 { get; set; }
	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM3 { get; set; }

	/// <summary>
	/// Low battery Soil Moisture
	/// </summary>
	public BoolEnum? BattSM4 { get; set; }
	/// <summary>
	/// Low battry Rain Gauge
	/// </summary>
	public BoolEnum? BattRain { get; set; }
	public BoolEnum? Batt_Co2 { get; set; }


}

public enum LeakSensorState
{
	NoLeak = 0,
	Leak = 1,
	LossOfCommunication = 2, // for over 10 minutes
}

public enum BoolEnum
{
	False = 0,
	True = 1
}
