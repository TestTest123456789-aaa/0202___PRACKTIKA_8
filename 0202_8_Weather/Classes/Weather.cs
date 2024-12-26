using System;
using System.ComponentModel.DataAnnotations;

namespace _0202_8_Weather.Classes
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string JsonData { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
