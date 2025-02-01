using System;
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
            string search = Request.QueryString["srch"];
            if (!IsPostBack)
            {
                LoadFlights(search);
            }
            if (!String.IsNullOrEmpty(search))
            {
                LoadFlights(search);
            }

        }

        private void LoadFlights(string queryString)
        {
            var context = new DataContext();

            var flights = context.Flights.Select(a => new FlightDTO(
                a.Id,a.Airline,a.Price,a.Departure.Place,a.Arrival.Place,a.RemainingNumberOfSeats)).ToList();


            if (!String.IsNullOrEmpty(queryString))
            {
                flights = context.Flights.Where(f => f.Airline.ToLower().Contains(queryString)).Select(a => new FlightDTO(
                a.Id, a.Airline, a.Price, a.Departure.Place, a.Arrival.Place, a.RemainingNumberOfSeats)).ToList();
            }

            gvFlights.DataSource = flights;
            gvFlights.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = Server.UrlEncode(txtSearchMaster.Text);
            Response.Redirect("~/Interfaces/SearchFlights.aspx?srch=" + searchText);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaces/AddFlight.aspx");
        }
        protected void gvFlights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditFlight")
            {
                int flightId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditFlight.aspx?id={flightId}");
            }
            else if (e.CommandName == "DeleteFlight")
            {
                int flightId = Convert.ToInt32(e.CommandArgument);
                DeleteFlightById(flightId);
                LoadFlights("");
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