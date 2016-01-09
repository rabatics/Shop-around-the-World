using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

public partial class _Default : System.Web.UI.Page
{
    public string rows = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        
        // set the stored procedure name   
        comm.CommandText = "SELECT TOP 10 productImagePath FROM dbo.Product ORDER BY productAddDate DESC;";
        comm.CommandType = CommandType.Text;
        comm.Connection.Open();
        // Execute the command and save the results in a DataTable  
        DbDataReader reader = comm.ExecuteReader();
       
         
        int i = 0;
        while (reader.Read())
        {
            if (i != 0)
            {
                rows += ",";
            }
            rows += "\"" + reader.GetString(0) + "\"";
            i++;
        }



             
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