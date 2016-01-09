using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public String path1,path2;
    protected void Page_Load(object sender, EventArgs e)
    {
        int countryId = 1;
        String p1 = CatalogAccess.getProductpath(countryId);
        this.path1 = p1;
       
        countryId = 2;
        String p2 = CatalogAccess.getProductpath(countryId);
        this.path2 = p2;
    }

    protected void RegionMap_Clicked(object sender, ImageMapEventArgs e)
    {
        string country = e.PostBackValue;
        string[] country1 = country.Split(',');
        Session["country"] = country1[0];
        Session["countryname"] = country1[1];
        Response.Redirect("BrowseProduct.aspx");





    }

}