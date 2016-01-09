using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       String currentPath = Request.RawUrl;
        if(currentPath.ToLower().Contains("shop.aspx"))
        {
            this.home.Attributes["class"] = "active";
        }
        else if (currentPath.ToLower().Contains("browseproducts.aspx"))
        {
            this.browse.Attributes["class"] = "active";
        }
        else if (currentPath.ToLower().Contains("vendors.aspx"))
        {
            this.vendors.Attributes["class"] = "active";
        }
        else if (currentPath.ToLower().Contains("aboutus_page.aspx"))
        {
            this.about.Attributes["class"] = "active";
        }
        else if (currentPath.ToLower().Contains("myaccount.aspx"))
        {
            this.account.Attributes["class"] = "active";
        }
        else
        {
        }
    }

    public void Log_Out(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["user"] = null;
        Response.Redirect("Shop.aspx");
    }

    public void redirect(object sender, EventArgs e)
    {
        Response.Redirect("Shop.aspx");
    }
}
