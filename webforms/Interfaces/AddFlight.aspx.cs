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
                setData();
            }
        }
        private void setData()
        {
            var context = new DataContext();
            //get airlines values list
            var airlines = context.Flights
                                 .Select(f => f.Airline)
                                 .Distinct()
                                 .OrderBy(a => a)
                                 .ToList();
            // get countries values list
           var timeplaces= context.Timeplaces
                    .Select(t => t.Place)
                    .Distinct()
                    .ToList();
            //set airlines values in dropdown list
            ddlAirlines.DataSource = airlines;
            // Set countries values in departures dropdown list
            departuresList.DataSource = timeplaces;
            // Set countries values in arrival dropdown list
            arrivalList.DataSource = timeplaces;

            ddlAirlines.DataBind();
            departuresList.DataBind();

            // Insert a default element inside departures list dropdown , disable it and ensure it appears selected
            departuresList.Items.Insert(0, new ListItem("Choose Departure", ""));
            departuresList.Items[0].Attributes["disabled"] = "true"; 
            departuresList.Items[0].Attributes["selected"] = "true"; 

            arrivalList.DataBind();

            // Insert a default element inside arrival list dropdown , disable it and ensure it appears selected
            arrivalList.Items.Insert(0, new ListItem("Choose Arrival", ""));
            arrivalList.Items[0].Attributes["disabled"] = "true";
            arrivalList.Items[0].Attributes["selected"] = "true";

            // Insert a default element inside airlines dropdown , disable it and ensure it appears selected
            ddlAirlines.Items.Insert(0, new ListItem("Select Airline", ""));
            ddlAirlines.Items[0].Attributes["disabled"] = "true"; 
            ddlAirlines.Items[0].Attributes["selected"] = "true"; 


        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DataContext())
                {
                    //Initialize new FlightRm object from selected values
                    FlightRm newFlight = new FlightRm
                    {
                        Airline = ddlAirlines.SelectedValue,
                        Departure = context.Timeplaces.Where(x => x.Place.Equals(departuresList.SelectedValue)).FirstOrDefault(),
                        Arrival = context.Timeplaces.Where(x => x.Place.Equals(arrivalList.SelectedValue)).FirstOrDefault(),
                        Price = txtPrice.Text.Trim(),
                        RemainingNumberOfSeats = Convert.ToInt32(seats.Text.Trim()),
                    };
                    // Add the new flight entity to the database context
                    context.Flights.Add(newFlight);

                    // Save changes to the database and retrieve the number of affected rows
                    int result = context.SaveChanges();
                    
                    if (result > 0)
                    {
                        //display success message  
                        Response.Write("<script>alert('Flight added successfully!');</script>");
                        Response.Redirect("~/Interfaces/SearchFlights.aspx");
                    }
                    //display error message
                    else
                    {
                        Response.Write("<script>alert('Error when adding flight');</script>");
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        }
}