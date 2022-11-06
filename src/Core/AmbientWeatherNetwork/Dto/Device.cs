using Common.Contracts;

namespace Core.AmbientWeatherNetwork.Dto;
public record Device : IAmbientWeatherMetrics
{
	public Source Source => Source.Cloud;

	public Device(string? mac, string? stationType, string? passKey, long? dateUtc, int? windDir, float? windSpeedMph, float? windGustMph, int? windGustDir, float? maxDailyGust, float? windSpdMph_Avg2m, int? windDir_Avg2m, float? windSpdMph_Avg10m, int? windDir_Avg10m, int? windGustMph_Interval, int? humidity, int? humidityIn, int? humidity1, int? humidity2, int? humidity3, int? humidity4, int? humidity5, int? humidity6, int? humidity7, int? humidity8, int? humidity9, int? humidity10, float? tempF, float? tempInF, float? temp1F, float? temp2F, float? temp3F, float? temp4F, float? temp5F, float? temp6F, float? temp7F, float? temp8F, float? temp9F, float? temp10F, float? hourlyRainIn, float? dailyRainIn, float? twentyFourHourRainIn, float? weeklyRainIn, float? monthlyRainIn, float? yearlyRainIn, float? eventRainIn, float? totalRain, float? baromRelIn, float? baromAbsIn, int? uV, float? solarRadiation, int? cO2, int? pM25, float? pM25_24h, int? pM25_In, float? pM25_In_24h, int? pM10_In, float? pM10_In_24h, int? cO2_In, float? cO2_In_24h, float? pM_In_Temp, int? pM_In_Humidity, BoolEnum? relay1, BoolEnum? relay2, BoolEnum? relay3, BoolEnum? relay4, BoolEnum? relay5, BoolEnum? relay6, BoolEnum? relay7, BoolEnum? relay8, BoolEnum? relay9, BoolEnum? relay10, float? soilTemp1, float? soilTemp2, float? soilTemp3, float? soilTemp4, float? soilTemp5, float? soilTemp6, float? soilTemp7, float? soilTemp8, float? soilTemp9, float? soilTemp10, int? soilHum1, int? soilHum2, int? soilHum3, int? soilHum4, int? soilHum5, int? soilHum6, int? soilHum7, int? soilHum8, int? soilHum9, int? soilHum10, LeakSensorState? leak1, LeakSensorState? leak2, LeakSensorState? leak3, LeakSensorState? leak4, long? lightning_Time, int? lightning_Day, BoolEnum? lightning_Distance, BoolEnum? lowBattery, BoolEnum? normalBattery, BoolEnum? battOut, BoolEnum? battIn, BoolEnum? batt1, BoolEnum? batt2, BoolEnum? batt3, BoolEnum? batt4, BoolEnum? batt5, BoolEnum? batt6, BoolEnum? batt7, BoolEnum? batt8, BoolEnum? batt9, BoolEnum? batt10, BoolEnum? battR1, BoolEnum? battR2, BoolEnum? battR3, BoolEnum? battR4, BoolEnum? battR5, BoolEnum? battR6, BoolEnum? battR7, BoolEnum? battR8, BoolEnum? battR9, BoolEnum? battR10, BoolEnum? batt_25, BoolEnum? batt_25In, BoolEnum? batLeak1, BoolEnum? batLeak2, BoolEnum? batLeak3, BoolEnum? batLeak4, BoolEnum? batt_Lightning, BoolEnum? battSM1, BoolEnum? battSM2, BoolEnum? battSM3, BoolEnum? battSM4, BoolEnum? battRain, BoolEnum? batt_Co2, double? dewPoint, double? dewPoint1, double? dewPoint2, double? dewPoint3, double? dewPoint4, double? dewPoint5, double? dewPoint6, double? dewPoint7, double? dewPoint8, double? dewPoint9, double? dewPoint10, double? dewPointIn, double? feelsLike, double? feelsLike1, double? feelsLike2, double? feelsLike3, double? feelsLike4, double? feelsLike5, double? feelsLike6, double? feelsLike7, double? feelsLike8, double? feelsLike9, double? feelsLike10, double? feelsLikeIn)
	{
		Mac = mac;
		StationType = stationType;
		PassKey = passKey;

		if (dateUtc is not null)
			DateUtc = new DateTime(dateUtc.GetValueOrDefault());

		WindDir = windDir;
		WindSpeedMph = windSpeedMph;
		WindGustMph = windGustMph;
		WindGustDir = windGustDir;
		MaxDailyGust = maxDailyGust;
		WindSpdMph_Avg2m = windSpdMph_Avg2m;
		WindDir_Avg2m = windDir_Avg2m;
		WindSpdMph_Avg10m = windSpdMph_Avg10m;
		WindDir_Avg10m = windDir_Avg10m;
		WindGustMph_Interval = windGustMph_Interval;
		Humidity = humidity;
		HumidityIn = humidityIn;
		Humidity1 = humidity1;
		Humidity2 = humidity2;
		Humidity3 = humidity3;
		Humidity4 = humidity4;
		Humidity5 = humidity5;
		Humidity6 = humidity6;
		Humidity7 = humidity7;
		Humidity8 = humidity8;
		Humidity9 = humidity9;
		Humidity10 = humidity10;
		TempF = tempF;
		TempInF = tempInF;
		Temp1F = temp1F;
		Temp2F = temp2F;
		Temp3F = temp3F;
		Temp4F = temp4F;
		Temp5F = temp5F;
		Temp6F = temp6F;
		Temp7F = temp7F;
		Temp8F = temp8F;
		Temp9F = temp9F;
		Temp10F = temp10F;
		HourlyRainIn = hourlyRainIn;
		DailyRainIn = dailyRainIn;
		TwentyFourHourRainIn = twentyFourHourRainIn;
		WeeklyRainIn = weeklyRainIn;
		MonthlyRainIn = monthlyRainIn;
		YearlyRainIn = yearlyRainIn;
		EventRainIn = eventRainIn;
		TotalRain = totalRain;
		BaromRelIn = baromRelIn;
		BaromAbsIn = baromAbsIn;
		UV = uV;
		SolarRadiation = solarRadiation;
		CO2 = cO2;
		PM25 = pM25;
		PM25_24h = pM25_24h;
		PM25_In = pM25_In;
		PM25_In_24h = pM25_In_24h;
		PM10_In = pM10_In;
		PM10_In_24h = pM10_In_24h;
		CO2_In = cO2_In;
		CO2_In_24h = cO2_In_24h;
		PM_In_Temp = pM_In_Temp;
		PM_In_Humidity = pM_In_Humidity;
		Relay1 = relay1;
		Relay2 = relay2;
		Relay3 = relay3;
		Relay4 = relay4;
		Relay5 = relay5;
		Relay6 = relay6;
		Relay7 = relay7;
		Relay8 = relay8;
		Relay9 = relay9;
		Relay10 = relay10;
		SoilTemp1 = soilTemp1;
		SoilTemp2 = soilTemp2;
		SoilTemp3 = soilTemp3;
		SoilTemp4 = soilTemp4;
		SoilTemp5 = soilTemp5;
		SoilTemp6 = soilTemp6;
		SoilTemp7 = soilTemp7;
		SoilTemp8 = soilTemp8;
		SoilTemp9 = soilTemp9;
		SoilTemp10 = soilTemp10;
		SoilHum1 = soilHum1;
		SoilHum2 = soilHum2;
		SoilHum3 = soilHum3;
		SoilHum4 = soilHum4;
		SoilHum5 = soilHum5;
		SoilHum6 = soilHum6;
		SoilHum7 = soilHum7;
		SoilHum8 = soilHum8;
		SoilHum9 = soilHum9;
		SoilHum10 = soilHum10;
		Leak1 = leak1;
		Leak2 = leak2;
		Leak3 = leak3;
		Leak4 = leak4;
		Lightning_Time = lightning_Time;
		Lightning_Day = lightning_Day;
		Lightning_Distance = lightning_Distance;
		LowBattery = lowBattery;
		NormalBattery = normalBattery;
		BattOut = battOut;
		BattIn = battIn;
		Batt1 = batt1;
		Batt2 = batt2;
		Batt3 = batt3;
		Batt4 = batt4;
		Batt5 = batt5;
		Batt6 = batt6;
		Batt7 = batt7;
		Batt8 = batt8;
		Batt9 = batt9;
		Batt10 = batt10;
		BattR1 = battR1;
		BattR2 = battR2;
		BattR3 = battR3;
		BattR4 = battR4;
		BattR5 = battR5;
		BattR6 = battR6;
		BattR7 = battR7;
		BattR8 = battR8;
		BattR9 = battR9;
		BattR10 = battR10;
		Batt_25 = batt_25;
		Batt_25In = batt_25In;
		BatLeak1 = batLeak1;
		BatLeak2 = batLeak2;
		BatLeak3 = batLeak3;
		BatLeak4 = batLeak4;
		Batt_Lightning = batt_Lightning;
		BattSM1 = battSM1;
		BattSM2 = battSM2;
		BattSM3 = battSM3;
		BattSM4 = battSM4;
		BattRain = battRain;
		Batt_Co2 = batt_Co2;
		DewPoint = dewPoint;
		DewPoint1 = dewPoint1;
		DewPoint2 = dewPoint2;
		DewPoint3 = dewPoint3;
		DewPoint4 = dewPoint4;
		DewPoint5 = dewPoint5;
		DewPoint6 = dewPoint6;
		DewPoint7 = dewPoint7;
		DewPoint8 = dewPoint8;
		DewPoint9 = dewPoint9;
		DewPoint10 = dewPoint10;
		DewPointIn = dewPointIn;
		FeelsLike = feelsLike;
		FeelsLike1 = feelsLike1;
		FeelsLike2 = feelsLike2;
		FeelsLike3 = feelsLike3;
		FeelsLike4 = feelsLike4;
		FeelsLike5 = feelsLike5;
		FeelsLike6 = feelsLike6;
		FeelsLike7 = feelsLike7;
		FeelsLike8 = feelsLike8;
		FeelsLike9 = feelsLike9;
		FeelsLike10 = feelsLike10;
		FeelsLikeIn = feelsLikeIn;
	}

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
