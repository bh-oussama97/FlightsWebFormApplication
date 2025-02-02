using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webforms.DataLayer;
using webforms.Models;

namespace webforms.Interfaces
{
    public partial class EditCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id;
                if (int.TryParse(Request.QueryString["countryId"], out Id))
                {
                    if (Id > 0)
                    {
                        GetCountryById(Id);
                    }
                }
            }
        }

        protected void GetCountryById(int countryId)
        {
            using (var context = new DataContext()) 
            {
                var countryById = context.Timeplaces.Find(countryId);
                if (countryById != null)
                {
                    // Store the country ID in a hidden field for later use
                    hfCountryId.Value = countryId.ToString();

                    // Populate the text field with the country's name
                    txtName.Text = countryById.Place;
                }
            }
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new DataContext())
            {
                // Attempt to parse the country ID from the hidden field
                if (int.TryParse(hfCountryId.Value, out int id))
                {
                    var countryById = context.Timeplaces.Find(id);
                    if (countryById != null)
                    {
                        // Update the country's name
                        countryById.Place = txtName.Text.Trim(); 

                        // Mark entity as modified before saving
                        context.Entry(countryById).State = EntityState.Modified;

                        // Persist changes to the database
                        int changes =context.SaveChanges();
                        if(changes >0 )
                        {
                            // Redirect to the Timeplaces interface page after a successful update
                            Response.Redirect("~/Interfaces/Timeplaces.aspx", false);
                        }
                        else
                        {
                            Response.Write("<script>alert('Error when editing country ');</script>");
                        }

                    }
                }
                else
                {
                    Response.Write("<script>alert('Error when parsing countryId');</script>");
                }
            }
        }

    }
}