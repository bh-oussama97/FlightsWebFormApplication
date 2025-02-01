using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webforms.DTO
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string Price { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int RemainingNumberOfSeats { get; set; }

        public FlightDTO(int id, string airline, string price, string departure, string arrival, int remainingNumberOfSeats)
        {
            Id = id;
            Airline = airline;
            Price = price;
            Departure = departure;
            Arrival = arrival;
            RemainingNumberOfSeats = remainingNumberOfSeats;
        }
    }
}