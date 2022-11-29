using Common.Contracts;

namespace Core.AmbientWeatherNetwork.Dto;
public record Device : IAmbientWeatherMetrics
{
	public Source Source => Source.Cloud;

	public Device(string? mac, string? stationType, string? passKey, string? dateUtc, short? windDir, float? windSpeedMph, float? windGustMph, short? windGustDir, float? maxDailyGust, float? windSpdMph_Avg2m, short? windDir_Avg2m, float? windSpdMph_Avg10m, short? windDir_Avg10m, short? windGustMph_Interval, short? humidity, short? humidityIn, short? humidity1, short? humidity2, short? humidity3, short? humidity4, short? humidity5, short? humidity6, short? humidity7, short? humidity8, short? humidity9, short? humidity10, float? tempF, float? tempInF, float? temp1F, float? temp2F, float? temp3F, float? temp4F, float? temp5F, float? temp6F, float? temp7F, float? temp8F, float? temp9F, float? temp10F, float? hourlyRainIn, float? dailyRainIn, float? twentyFourHourRainIn, float? weeklyRainIn, float? monthlyRainIn, float? yearlyRainIn, float? eventRainIn, float? totalRain, float? baromRelIn, float? baromAbsIn, short? uV, float? solarRadiation, short? cO2, short? pM25, float? pM25_24h, short? pM25_In, float? pM25_In_24h, short? pM10_In, float? pM10_In_24h, short? cO2_In, float? cO2_In_24h, float? pM_In_Temp, short? pM_In_Humidity, BoolEnum? relay1, BoolEnum? relay2, BoolEnum? relay3, BoolEnum? relay4, BoolEnum? relay5, BoolEnum? relay6, BoolEnum? relay7, BoolEnum? relay8, BoolEnum? relay9, BoolEnum? relay10, float? soilTemp1, float? soilTemp2, float? soilTemp3, float? soilTemp4, float? soilTemp5, float? soilTemp6, float? soilTemp7, float? soilTemp8, float? soilTemp9, float? soilTemp10, short? soilHum1, short? soilHum2, short? soilHum3, short? soilHum4, short? soilHum5, short? soilHum6, short? soilHum7, short? soilHum8, short? soilHum9, short? soilHum10, LeakSensorState? leak1, LeakSensorState? leak2, LeakSensorState? leak3, LeakSensorState? leak4, ulong? lightning_Time, short? lightning_Day, BoolEnum? lightning_Distance, BoolEnum? lowBattery, BoolEnum? normalBattery, BoolEnum? battOut, BoolEnum? battIn, BoolEnum? batt1, BoolEnum? batt2, BoolEnum? batt3, BoolEnum? batt4, BoolEnum? batt5, BoolEnum? batt6, BoolEnum? batt7, BoolEnum? batt8, BoolEnum? batt9, BoolEnum? batt10, BoolEnum? battR1, BoolEnum? battR2, BoolEnum? battR3, BoolEnum? battR4, BoolEnum? battR5, BoolEnum? battR6, BoolEnum? battR7, BoolEnum? battR8, BoolEnum? battR9, BoolEnum? battR10, BoolEnum? batt_25, BoolEnum? batt_25In, BoolEnum? batLeak1, BoolEnum? batLeak2, BoolEnum? batLeak3, BoolEnum? batLeak4, BoolEnum? batt_Lightning, BoolEnum? battSM1, BoolEnum? battSM2, BoolEnum? battSM3, BoolEnum? battSM4, BoolEnum? battRain, BoolEnum? batt_Co2, float? dewPoint, float? dewPoint1, float? dewPoint2, float? dewPoint3, float? dewPoint4, float? dewPoint5, float? dewPoint6, float? dewPoint7, float? dewPoint8, float? dewPoint9, float? dewPoint10, float? dewPointIn, float? feelsLike, float? feelsLike1, float? feelsLike2, float? feelsLike3, float? feelsLike4, float? feelsLike5, float? feelsLike6, float? feelsLike7, float? feelsLike8, float? feelsLike9, float? feelsLike10, float? feelsLikeIn)
	{
		Mac = mac;
		StationType = stationType;
		PassKey = passKey;

		if (dateUtc is not null) {
		     // Station sends timestamp as UTC "date time" string. Convert to DateTime.
		     DateTime dateResult;
                     if (DateTime.TryParse(dateUtc, out dateResult))
			 DateUtc = dateResult;
		     else
			 DateUtc = DateTime.Now;
		}

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

	public short? WindDir { get; init; }
	public float? WindSpeedMph { get; init; }
	public float? WindGustMph { get; init; }
	public short? WindGustDir { get; init; }
	public float? MaxDailyGust { get; init; }
	public float? WindSpdMph_Avg2m { get; init; }
	public short? WindDir_Avg2m { get; init; }
	public float? WindSpdMph_Avg10m { get; init; }
	public short? WindDir_Avg10m { get; init; }
	public short? WindGustMph_Interval { get; init; }
	public short? Humidity { get; init; }
	public short? HumidityIn { get; init; }
	public short? Humidity1 { get; init; }
	public short? Humidity2 { get; init; }
	public short? Humidity3 { get; init; }
	public short? Humidity4 { get; init; }
	public short? Humidity5 { get; init; }
	public short? Humidity6 { get; init; }
	public short? Humidity7 { get; init; }
	public short? Humidity8 { get; init; }
	public short? Humidity9 { get; init; }
	public short? Humidity10 { get; init; }
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
	public short? UV { get; init; }
	public float? SolarRadiation { get; init; }
	public short? CO2 { get; init; }
	public short? PM25 { get; init; }
	public float? PM25_24h { get; init; }
	public short? PM25_In { get; init; }
	public float? PM25_In_24h { get; init; }
	public short? PM10_In { get; init; }
	public float? PM10_In_24h { get; init; }
	public short? CO2_In { get; init; }
	public float? CO2_In_24h { get; init; }
	public float? PM_In_Temp { get; init; }
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
	public short? SoilHum1 { get; init; }
	public short? SoilHum2 { get; init; }
	public short? SoilHum3 { get; init; }
	public short? SoilHum4 { get; init; }
	public short? SoilHum5 { get; init; }
	public short? SoilHum6 { get; init; }
	public short? SoilHum7 { get; init; }
	public short? SoilHum8 { get; init; }
	public short? SoilHum9 { get; init; }
	public short? SoilHum10 { get; init; }
	public LeakSensorState? Leak1 { get; init; }
	public LeakSensorState? Leak2 { get; init; }
	public LeakSensorState? Leak3 { get; init; }
	public LeakSensorState? Leak4 { get; init; }
	public ulong? Lightning_Time { get; init; }
	public short? Lightning_Day { get; init; }
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
	public float? DewPointIn { get; init; }
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
	public float? FeelsLikeIn { get; init; }
}
