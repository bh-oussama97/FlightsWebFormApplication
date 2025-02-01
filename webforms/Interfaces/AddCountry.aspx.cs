using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webforms.DataLayer;
using webforms.Models;

namespace webforms.Interfaces
{
    public partial class AddCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DataContext())
                {
                    string name = txtName.Text;
                    var countrybyName=context.Timeplaces.Where(el=>el.Place.ToLower().Equals(name)).FirstOrDefault();
                    if (countrybyName != null) {
                        Response.Write("<script>alert('Country already exists !');</script>");
                    }
                    else
                    {
                        TimePlaceRm newCountry = new TimePlaceRm
                        {
                            Time = DateTime.Now,
                            Place = txtName.Text
                        };

                        context.Timeplaces.Add(newCountry);
                        context.SaveChanges();
                        Response.Write("<script>alert('Country saved successfully!');</script>");
                        Response.Redirect("~/Interfaces/Timeplaces.aspx");
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