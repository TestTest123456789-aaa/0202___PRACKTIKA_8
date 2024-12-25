using System;
using System.Windows;
using System.Windows.Input;

namespace _0202_8_Weather
{
    public partial class MainWindow : Window
    {
        const string content = "Введите название города";
        WeatherViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(city.Text))
            {
                city.Text = content;
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (city.Text == content)
            {
                city.Text = string.Empty;
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var cityName = city.Text;
                if (string.IsNullOrWhiteSpace(cityName))
                {
                    MessageBox.Show("Введите название города");
                    return;
                }
                try
                {
                    parent.Children.Clear();
                    if (_viewModel.ForecastData?.List != null)
                    {
                        foreach (var forecastItem in _viewModel.ForecastData.List)
                        {
                            var element = new Elements.Element
                            {
                                DataContext = forecastItem
                            };
                            parent.Children.Add(element);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
