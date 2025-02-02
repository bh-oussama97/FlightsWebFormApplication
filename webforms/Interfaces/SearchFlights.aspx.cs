using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using webforms.DataLayer;
using webforms.DTO;


namespace webforms.Interfaces
{
    public partial class SearchFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                LoadFlights("");
        }



        private void LoadFlights(string queryString)
        {
            var context = new DataContext();
            var flights = context.Flights.Select(a => new FlightDTO(
                a.Id, a.Airline, a.Price, a.Departure.Place, a.Arrival.Place, a.RemainingNumberOfSeats)).ToList();

            if (!String.IsNullOrEmpty(queryString))
            {
                flights = context.Flights.Where(f => f.Airline.ToLower().Contains(queryString)).Select(a => new FlightDTO(
                a.Id, a.Airline, a.Price, a.Departure.Place, a.Arrival.Place, a.RemainingNumberOfSeats)).ToList();
            }

            gvFlights.DataSource = flights;
            gvFlights.DataBind();

            // Check if GridView has no data and display the "No data found" message
            if (flights.Count == 0)
            {
                noDataMessage.Visible = true;
            }
            else
            {
                noDataMessage.Visible = false;
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchMaster.Text;
            LoadFlights(searchText);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaces/AddFlight.aspx");
        }
        protected void gvFlights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int flightId;
            if (int.TryParse(e.CommandArgument.ToString(), out flightId)) // Ensure valid flight ID
            {
                if (e.CommandName == "EditFlight")
                {
                    Response.Redirect($"EditFlight.aspx?id={flightId}");
                }
                else if (e.CommandName == "DeleteFlight")
                {
                    DeleteFlightById(flightId);
                    LoadFlights(""); // Reload flight list after deletion
                }
            }
        }

        private void DeleteFlightById(int flightId)
        {
            using (var context = new DataContext())
            {
                var flight = context.Flights.Find(flightId);
                if (flight != null)
                {
                    context.Flights.Remove(flight);
                    context.SaveChanges();
                }
            }
        }
    }
}