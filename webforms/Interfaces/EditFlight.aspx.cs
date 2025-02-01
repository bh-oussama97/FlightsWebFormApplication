using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web.UI.WebControls;
using webforms.DataLayer;

namespace webforms.Interfaces
{
    public partial class EditFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  
            {
                int Id;
                if (int.TryParse(Request.QueryString["id"], out Id))
                {
                    if (Id > 0)
                    {
                        getFlightById(Id);
                    }
                }
            }
        }


        protected void getFlightById(int Id)
        {
            var context = new DataContext();
            var flightById = context.Flights.Find(Id);
            var airlines = context.Flights
                                  .Select(f => f.Airline)
                                  .Distinct()
                                  .OrderBy(a => a)
                                  .ToList();
            var timeplaces = context.Timeplaces
         .Select(t => t.Place)
         .Distinct()
         .ToList();
            ddlAirlines.DataSource = airlines;
            departuresList.DataSource = timeplaces;
            arrivalList.DataSource = timeplaces;
            ddlAirlines.DataBind();
            departuresList.DataBind();
            departuresList.Items.Insert(0, new ListItem("Choose Departure", ""));
            arrivalList.DataBind();
            arrivalList.Items.Insert(0, new ListItem("Choose Arrival", ""));
            if (flightById != null)
            {
                hfFlightId.Value = flightById.Id.ToString();  
                ddlAirlines.SelectedValue = flightById.Airline;
                departuresList.SelectedValue = context.Timeplaces.Find(flightById.DepartureId).Place;
                arrivalList.SelectedValue = context.Timeplaces.Find(flightById.ArrivalId).Place;
                price.Text = flightById.Price.ToString();
                seatsEdit.Text = flightById.RemainingNumberOfSeats.ToString();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id;
            if (int.TryParse(hfFlightId.Value, out Id))
            {
                using (var context = new DataContext())
                {
                    var flight = context.Flights.Find(Id);
                    if (flight != null)
                    {
                        flight.Airline = ddlAirlines.SelectedValue;

                        flight.DepartureId = context.Timeplaces
                            .Where(el => el.Place == departuresList.SelectedValue)
                            .Select(el => el.Id)
                            .FirstOrDefault();

                        flight.ArrivalId = context.Timeplaces
                            .Where(el => el.Place == arrivalList.SelectedValue)
                            .Select(el => el.Id)
                            .FirstOrDefault();

                 
                            flight.Price = price.Text;
                        
                        

                        int seats;
                        if (int.TryParse(seatsEdit.Text, out seats))
                        {
                            flight.RemainingNumberOfSeats = seats;
                        }
                        else
                        {
                            flight.RemainingNumberOfSeats = 0; 
                        }

                        context.Entry(flight).State = EntityState.Modified;
                        context.SaveChanges();

                        Response.Redirect("~/Interfaces/SearchFlights.aspx"); 
                    }
                }
            }
        }

    }
}
