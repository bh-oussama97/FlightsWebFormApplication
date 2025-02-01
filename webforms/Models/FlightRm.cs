using System;
using System.Collections.Generic;

namespace webforms.Models
{
    public class FlightRm
    {
        public int Id { get; set; }

        public string Airline { get; set; }

        public string Price { get; set; }

        public TimePlaceRm Departure { get; set; }

        public virtual int DepartureId { get; set; }

        public TimePlaceRm Arrival { get; set; }

        public virtual int ArrivalId { get; set; }


        public int RemainingNumberOfSeats { get; set; }

        public FlightRm()
        {

        }

        public FlightRm(string airline, string price, TimePlaceRm departure, TimePlaceRm arrival, int remainingNumberOfSeats)
        {
            Airline = airline;
            Price = price;
            Departure = departure;
            Arrival = arrival;
            RemainingNumberOfSeats = remainingNumberOfSeats;
        }

        public FlightRm(int id, string airline, string price, TimePlaceRm departure, TimePlaceRm arrival, int remainingNumberOfSeats)
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