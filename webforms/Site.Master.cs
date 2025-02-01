using System;
using System.Web.UI;

namespace webforms
{
    public partial class SiteMaster : MasterPage
    {
        void Page_Load(Object sender, EventArgs e)
        {
            // Manually register the event-handling method for
            // the Click event of the Button control.
        }

         protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaces/Login.aspx");
        }
    }
}