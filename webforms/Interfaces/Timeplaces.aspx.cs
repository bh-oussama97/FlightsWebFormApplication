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

        protected void LoadCountries()
        {
            var context = new DataContext();

            var countries = context.Timeplaces.Select(x => new CountryDTO(x.Id,x.Place,x.Time)).ToList();

            gvCountries.DataSource = countries;
            gvCountries.DataBind();

        }
        protected void btn_AddCountry(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaces/AddCountry.aspx");

        }

        protected void gvCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCountry")
            {
                int countryId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditCountry.aspx?countryId={countryId}");
            }
            else if (e.CommandName == "DeleteCountry")
            {
                int flightId = Convert.ToInt32(e.CommandArgument);
                DeleteCountryById(flightId);
                LoadCountries();
            }
        }
        protected void DeleteCountryById(int countryId)
        {
            using (var context = new DataContext())
            {
                var countryById = context.Timeplaces.Find(countryId);
                if (countryById != null)
                {
                    context.Timeplaces.Remove(countryById);
                    context.SaveChanges();
                }
            }
        }

    }
}