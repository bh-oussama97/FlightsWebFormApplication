using System;
using System.ComponentModel.DataAnnotations;

namespace webforms.Models
{
    public class TimePlaceRm
    {
        [Key]
        public int Id { get; set; }
        public string Place { get; set; }

        public DateTime Time { get; set; }

        public TimePlaceRm(int Id, string Place, DateTime Time)
        {
            this.Id = Id;
            this.Place = Place;
            this.Time = Time;
        }

        public TimePlaceRm(string place, DateTime time)
        {
            Place = place;
            Time = time;
        }

        public TimePlaceRm()
        {
        }
    }
}