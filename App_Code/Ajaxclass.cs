using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for Ajaxclass
/// </summary>
public class Ajaxclass  : System.Web.UI.Page
{
    [System.Web.Services.WebMethod]
     [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
	public string AjaxExecute()
	{
        string json=null;
        string task = Request.QueryString[0];
   if (task.Equals("countrytable")) { 
        string countryid = Request.QueryString[1];
        DataTable table1 = ShopDataAccess.GetProducts(countryid);
        DbDataReader reader = table1.CreateDataReader();
        String dt = null;
       
        string rows2 = null;
        while (reader.Read())
        {
            
            string PName = reader.GetString(0);
            string PSDesc = reader.GetString(1);
            double PPrice = reader.GetDouble(2);
            string PImg = reader.GetString(3);



            rows2 += "<tr class='prodtable'><td>" + PName + "</td><td>" + PSDesc + "</td><td>" + PPrice + "</td><td><img src=" + PImg + " height=100 width=100 /></td></tr>";
        }
        String table = "<table  runat=server id=productTable align=center style='border: thin solid black;width:600px;color:black;'> <tr class='prodtable'><th>Product Name</th><th>Description</th><th>Price</th><th>Image</th></tr>";
       
        
        table = table + rows2 + "</table>";
        Console.WriteLine(table);
        HttpContext.Current.Response.ContentType = "application/json";
        JavaScriptSerializer JavaScriptConvert = new JavaScriptSerializer();
       json = JavaScriptConvert.Serialize(table);
   }
        return json;
    
    }

     
        

    }

	
