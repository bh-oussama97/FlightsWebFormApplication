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
                        getCountryById(Id);
                    }
                }
            }
        }
        protected void getCountryById(int countryId)
        {
            var context = new DataContext();
            var countryById = context.Timeplaces.Find(countryId);
            if (countryById != null)
            {
                hfCountryId.Value = countryId.ToString();
                txtName.Text = countryById.Place.ToString();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id;
            DataContext context = new DataContext();
            bool result = int.TryParse(hfCountryId.Value, out Id);

                if (result)
            {
                var countryById = context.Timeplaces.Find(Id);
                if (countryById != null)
                {
                    countryById.Place = txtName.Text;
                    context.Entry(countryById).State = EntityState.Modified;
                    context.SaveChanges();

                    Response.Redirect("~/Interfaces/Timeplaces.aspx");
                }
            }           
        }
    }
}