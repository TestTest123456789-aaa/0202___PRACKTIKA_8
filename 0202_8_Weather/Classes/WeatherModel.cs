using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _0202_8_Weather.Classes
{
    public class WeatherModel
    {
        private const string ApiKey = "84d08dfffe2e4b631d17c38cfc1e730e";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/forecast";
        private readonly HttpClient _httpClient;

        public WeatherModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ForecastData> GetWeatherForecastAsync(string city)
        {
            var url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric&lang=ru";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Не удалось получить данные о погоде");
            }

            var json = await response.Content.ReadAsStringAsync();
            var forecastData = JsonConvert.DeserializeObject<ForecastData>(json);
            return forecastData;
        }
    }

    public class ForecastData
    {
        [JsonProperty("list")]
        public ListItem[] List { get; set; }
    }

    public class ListItem
    {
        [JsonProperty("dt")]
        public long DateTimeUnix { get; set; }

        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("weather")]
        public WeatherDescription[] Weather { get; set; }

        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(DateTimeUnix).DateTime;
        public string WeatherDescription => Weather?.Length > 0 ? Weather[0].Description : "Неизвестно";
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        public int TemperatureRounded => (int)Math.Round(Temperature);

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }
    }

    public class WeatherDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}


//INSERT INTO `Weather` VALUES (1,'Пермь','{\"list\":[{\"dt\":1734102000,\"main\":{\"temp\":-3.3,\"TemperatureRounded\":-3,\"pressure\":986.0,\"humidity\":80.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-13T15:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734112800,\"main\":{\"temp\":-4.77,\"TemperatureRounded\":-5,\"pressure\":986.0,\"humidity\":83.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-13T18:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734123600,\"main\":{\"temp\":-6.14,\"TemperatureRounded\":-6,\"pressure\":987.0,\"humidity\":86.0},\"weather\":[{\"description\":\"пасмурно\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-13T21:00:00\",\"WeatherDescription\":\"пасмурно\"},{\"dt\":1734134400,\"main\":{\"temp\":-9.19,\"TemperatureRounded\":-9,\"pressure\":988.0,\"humidity\":89.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T00:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734145200,\"main\":{\"temp\":-10.42,\"TemperatureRounded\":-10,\"pressure\":989.0,\"humidity\":90.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T03:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734156000,\"main\":{\"temp\":-11.0,\"TemperatureRounded\":-11,\"pressure\":992.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-14T06:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734166800,\"main\":{\"temp\":-10.42,\"TemperatureRounded\":-10,\"pressure\":994.0,\"humidity\":91.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-14T09:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734177600,\"main\":{\"temp\":-11.01,\"TemperatureRounded\":-11,\"pressure\":997.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T12:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734188400,\"main\":{\"temp\":-11.23,\"TemperatureRounded\":-11,\"pressure\":999.0,\"humidity\":93.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T15:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734199200,\"main\":{\"temp\":-11.78,\"TemperatureRounded\":-12,\"pressure\":1000.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T18:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734210000,\"main\":{\"temp\":-13.11,\"TemperatureRounded\":-13,\"pressure\":1002.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-14T21:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734220800,\"main\":{\"temp\":-15.29,\"TemperatureRounded\":-15,\"pressure\":1004.0,\"humidity\":93.0},\"weather\":[{\"description\":\"пасмурно\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-15T00:00:00\",\"WeatherDescription\":\"пасмурно\"},{\"dt\":1734231600,\"main\":{\"temp\":-16.8,\"TemperatureRounded\":-17,\"pressure\":1006.0,\"humidity\":94.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-15T03:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734242400,\"main\":{\"temp\":-17.11,\"TemperatureRounded\":-17,\"pressure\":1009.0,\"humidity\":94.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"DateTime\":\"2024-12-15T06:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734253200,\"main\":{\"temp\":-15.4,\"TemperatureRounded\":-15,\"pressure\":1010.0,\"humidity\":93.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"DateTime\":\"2024-12-15T09:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734264000,\"main\":{\"temp\":-17.49,\"TemperatureRounded\":-17,\"pressure\":1012.0,\"humidity\":95.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-15T12:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734274800,\"main\":{\"temp\":-21.94,\"TemperatureRounded\":-22,\"pressure\":1013.0,\"humidity\":100.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-15T15:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734285600,\"main\":{\"temp\":-17.83,\"TemperatureRounded\":-18,\"pressure\":1013.0,\"humidity\":96.0},\"weather\":[{\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-15T18:00:00\",\"WeatherDescription\":\"облачно с прояснениями\"},{\"dt\":1734296400,\"main\":{\"temp\":-14.78,\"TemperatureRounded\":-15,\"pressure\":1011.0,\"humidity\":96.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-15T21:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734307200,\"main\":{\"temp\":-11.97,\"TemperatureRounded\":-12,\"pressure\":1010.0,\"humidity\":95.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T00:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734318000,\"main\":{\"temp\":-8.73,\"TemperatureRounded\":-9,\"pressure\":1007.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T03:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734328800,\"main\":{\"temp\":-5.71,\"TemperatureRounded\":-6,\"pressure\":1006.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-16T06:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734339600,\"main\":{\"temp\":-3.64,\"TemperatureRounded\":-4,\"pressure\":1005.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-16T09:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734350400,\"main\":{\"temp\":-2.81,\"TemperatureRounded\":-3,\"pressure\":1003.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T12:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734361200,\"main\":{\"temp\":-3.02,\"TemperatureRounded\":-3,\"pressure\":1002.0,\"humidity\":90.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T15:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734372000,\"main\":{\"temp\":-2.26,\"TemperatureRounded\":-2,\"pressure\":999.0,\"humidity\":96.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T18:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734382800,\"main\":{\"temp\":-1.55,\"TemperatureRounded\":-2,\"pressure\":997.0,\"humidity\":97.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-16T21:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734393600,\"main\":{\"temp\":-1.55,\"TemperatureRounded\":-2,\"pressure\":996.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-17T00:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734404400,\"main\":{\"temp\":-2.91,\"TemperatureRounded\":-3,\"pressure\":997.0,\"humidity\":93.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-17T03:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734415200,\"main\":{\"temp\":-3.85,\"TemperatureRounded\":-4,\"pressure\":997.0,\"humidity\":90.0},\"weather\":[{\"description\":\"пасмурно\",\"icon\":\"04d\"}],\"DateTime\":\"2024-12-17T06:00:00\",\"WeatherDescription\":\"пасмурно\"},{\"dt\":1734426000,\"main\":{\"temp\":-4.19,\"TemperatureRounded\":-4,\"pressure\":997.0,\"humidity\":87.0},\"weather\":[{\"description\":\"пасмурно\",\"icon\":\"04d\"}],\"DateTime\":\"2024-12-17T09:00:00\",\"WeatherDescription\":\"пасмурно\"},{\"dt\":1734436800,\"main\":{\"temp\":-6.28,\"TemperatureRounded\":-6,\"pressure\":997.0,\"humidity\":90.0},\"weather\":[{\"description\":\"пасмурно\",\"icon\":\"04n\"}],\"DateTime\":\"2024-12-17T12:00:00\",\"WeatherDescription\":\"пасмурно\"},{\"dt\":1734447600,\"main\":{\"temp\":-4.94,\"TemperatureRounded\":-5,\"pressure\":996.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-17T15:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734458400,\"main\":{\"temp\":-5.01,\"TemperatureRounded\":-5,\"pressure\":994.0,\"humidity\":92.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-17T18:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734469200,\"main\":{\"temp\":-4.41,\"TemperatureRounded\":-4,\"pressure\":992.0,\"humidity\":91.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-17T21:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734480000,\"main\":{\"temp\":-5.29,\"TemperatureRounded\":-5,\"pressure\":991.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-18T00:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734490800,\"main\":{\"temp\":-4.81,\"TemperatureRounded\":-5,\"pressure\":989.0,\"humidity\":94.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-18T03:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734501600,\"main\":{\"temp\":-5.89,\"TemperatureRounded\":-6,\"pressure\":990.0,\"humidity\":91.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-18T06:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734512400,\"main\":{\"temp\":-6.91,\"TemperatureRounded\":-7,\"pressure\":990.0,\"humidity\":95.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13d\"}],\"DateTime\":\"2024-12-18T09:00:00\",\"WeatherDescription\":\"небольшой снег\"},{\"dt\":1734523200,\"main\":{\"temp\":-8.44,\"TemperatureRounded\":-8,\"pressure\":991.0,\"humidity\":97.0},\"weather\":[{\"description\":\"небольшой снег\",\"icon\":\"13n\"}],\"DateTime\":\"2024-12-18T12:00:00\",\"WeatherDescription\":\"небольшой снег\"}]}','2024-12-13 18:48:20');
//CREATE TABLE `Weather` (
//  `Id` int NOT NULL AUTO_INCREMENT,
//  `City` varchar(255) NOT NULL,
//  `JsonData` text NOT NULL,
//  `RequestDate` datetime NOT NULL,
//  PRIMARY KEY (`Id`)
//)