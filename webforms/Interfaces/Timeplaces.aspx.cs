using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webforms.DataLayer;
using webforms.DTO;
using webforms.Models;

namespace webforms.Interfaces
{
    public partial class Timeplaces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountries();
            }
        }

        /// <summary>
        /// Loads the list of countries and binds it to the GridView.
        /// </summary>
        protected void LoadCountries()
        {
            using (var context = new DataContext()) // Ensure proper disposal of the database context
            {
                // Retrieve countries and map them to DTO objects
                var countries = context.Timeplaces
                    .Select(x => new CountryDTO(x.Id, x.Place, x.Time))
                    .ToList();

                // Bind the retrieved country data to the GridView
                gvCountries.DataSource = countries;
                gvCountries.DataBind();
            }
        }


        protected void btn_AddCountry(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaces/AddCountry.aspx");
        }


        protected void gvCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCountry")
            {
                // Extract the country ID from the command argument and redirect to the edit page
                int countryId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditCountry.aspx?countryId={countryId}");
            }
            else if (e.CommandName == "DeleteCountry")
            {
                // Extract the country ID and delete the corresponding record
                int countryId = Convert.ToInt32(e.CommandArgument);
                DeleteCountryById(countryId);

                // Reload the country list after deletion
                LoadCountries();
            }
        }

 
        protected void DeleteCountryById(int countryId)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var countryById = context.Timeplaces.Find(countryId);
                    if (countryById != null)
                    {
                        // Remove the country from the database
                        context.Timeplaces.Remove(countryById);
                        int result = context.SaveChanges();

                        if (result > 0)
                        {
                            // Redirect to refresh the page only if deletion was successful
                            Response.Redirect("~/Interfaces/Timeplaces.aspx", false);
                        }
                        else
                        {
                            // Show an alert if deletion failed
                            Response.Write($"<script>alert('Cannot delete element with Id: {countryId}');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions properly and display an error message
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }


    }
}