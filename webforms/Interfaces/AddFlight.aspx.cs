using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using webforms.DataLayer;
using webforms.Models;

namespace webforms.Interfaces
{
    public partial class AddFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                PopulineAirlineDropdown();
            }
        }
        private void PopulineAirlineDropdown()
        {
            var context = new DataContext();
            var airlines = context.Flights
                                 .Select(f => f.Airline)
                                 .Distinct()
                                 .OrderBy(a => a)
                                 .ToList();
           var timeplaces= context.Timeplaces
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
            ddlAirlines.Items.Insert(0, new ListItem("Select Airline", ""));
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DataContext())
                {
                    FlightRm newFlight = new FlightRm
                    {
                        Airline = ddlAirlines.SelectedValue,
                        Departure = context.Timeplaces.Where(x => x.Place.Equals(departuresList.SelectedValue)).FirstOrDefault(),
                        Arrival = context.Timeplaces.Where(x => x.Place.Equals(arrivalList.SelectedValue)).FirstOrDefault(),
                        Price = txtPrice.Text.Trim(),
                        RemainingNumberOfSeats = Convert.ToInt32(seats.Text.Trim()),
                    };

                    context.Flights.Add(newFlight);
                    context.SaveChanges();
                    Response.Write("<script>alert('Flight added successfully!');</script>");
                    Response.Redirect("~/Interfaces/SearchFlights.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        }
}