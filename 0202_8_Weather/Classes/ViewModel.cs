using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace _0202_8_Weather.Classes
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ForecastData _forecastData;
        private readonly WeatherModel _weatherService;
        public int _requestCount = 0;
        public int MaxRequestsPerDay = 50;

        public ViewModel() => _weatherService = new WeatherModel();

        public ForecastData ForecastData
        {
            get => _forecastData;
            set
            {
                _forecastData = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadWeatherAsync(string city)
        {
            using (var dbContext = new Connection())
            {
                var existingData = dbContext.Weather.FirstOrDefault(w => w.City == city && w.RequestDate.Date == DateTime.Today);
                if (existingData != null)
                {
                    ForecastData = JsonConvert.DeserializeObject<ForecastData>(existingData.JsonData);
                }
                else
                {
                    if (_requestCount >= MaxRequestsPerDay)
                    {
                        throw new Exception("Достигнут лимит запросов на сегодня.");
                    }
                    ForecastData = await _weatherService.GetWeatherForecastAsync(city);
                    _requestCount++;
                    var weatherData = new Weather
                    {
                        City = city,
                        JsonData = JsonConvert.SerializeObject(ForecastData),
                        RequestDate = DateTime.Now
                    };
                    dbContext.Weather.Add(weatherData);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
