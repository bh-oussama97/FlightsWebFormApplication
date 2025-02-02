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
                        GetFlightById(Id);
                    }
                }
            }
        }


        protected void GetFlightById(int Id)
        {
            using (var context = new DataContext())
            {
                // Retrieve flight details by ID
                var flightById = context.Flights.Find(Id);

                // Retrieve distinct airlines and sort them alphabetically
                var airlines = context.Flights
                                      .Select(f => f.Airline)
                                      .Distinct()
                                      .OrderBy(a => a)
                                      .ToList();

                // Retrieve distinct timeplaces (departure/arrival locations)
                var timeplaces = context.Timeplaces
         .Select(t => t.Place)
                                        .Distinct()
                                        .ToList();

                // Bind data to dropdown lists
                ddlAirlines.DataSource = airlines;
                departuresList.DataSource = timeplaces;
                arrivalList.DataSource = timeplaces;
                ddlAirlines.DataBind();
                departuresList.DataBind();
                departuresList.Items.Insert(0, new ListItem("Choose Departure", ""));
                arrivalList.DataBind();
                arrivalList.Items.Insert(0, new ListItem("Choose Arrival", ""));

                // Populate fields if flight exists
                if (flightById != null)
                {
                    hfFlightId.Value = flightById.Id.ToString();
                    ddlAirlines.SelectedValue = flightById.Airline;

                    // Set selected values for departure and arrival dropdowns
                    var departure = context.Timeplaces.Find(flightById.DepartureId);
                    var arrival = context.Timeplaces.Find(flightById.ArrivalId);

                    if (departure != null) departuresList.SelectedValue = departure.Place;
                    if (arrival != null) arrivalList.SelectedValue = arrival.Place;

                    price.Text = flightById.Price.ToString();
                    seatsEdit.Text = flightById.RemainingNumberOfSeats.ToString();
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hfFlightId.Value, out int Id))
            {
                using (var context = new DataContext()) // Ensure proper disposal of the database context
                {
                    var flight = context.Flights.Find(Id);
                    if (flight != null)
                    {
                        // Update airline
                        flight.Airline = ddlAirlines.SelectedValue;

                        // Retrieve DepartureId based on selected place
                        flight.DepartureId = context.Timeplaces
                            .Where(el => el.Place == departuresList.SelectedValue)
                            .Select(el => el.Id)
                            .FirstOrDefault();

                        // Retrieve ArrivalId based on selected place
                        flight.ArrivalId = context.Timeplaces
                            .Where(el => el.Place == arrivalList.SelectedValue)
                            .Select(el => el.Id)
                            .FirstOrDefault();

                 
                            flight.Price = price.Text;
                        
                        

                        // Parse and assign remaining seats
                        if (int.TryParse(seatsEdit.Text, out int seats))
                        {
                            flight.RemainingNumberOfSeats = seats;
                        }
                        else
                        {
                            flight.RemainingNumberOfSeats = 0; // Default to 0 if invalid input
                        }

                        // Mark the entity as modified before saving changes
                        context.Entry(flight).State = EntityState.Modified;
                        context.SaveChanges();

                        // Redirect to the search flights page after a successful update
                        Response.Redirect("~/Interfaces/SearchFlights.aspx"); 
                    }
                }
            }
        }


    }
}
