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
using System.Web.Services;
using System.Web.UI.HtmlControls;

public partial class BrowseProduct : System.Web.UI.Page
{
    string rows;
   string rows1;
  public double max = 0.00;
   int nop = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        getCountries();
        if (Session["userid"] != null)
        {
            int customerId = (int)Session["userid"];
            Product[] productCart = ShopDataAccess.GetCart(customerId);
            Session["productCart"] = productCart;
        }
        if (Session["product"] != null)
        {
            Session.Remove("product");
        }
        
       
        if (Session["country"] != null)
        {
           CreateProductTable();
           // string country=(string)Session["country"];
           // getCategories(country);
        }
        else
        {
             Session["datatable"]=CreateAllProductTable();
		Session.Remove("datatable");
             
        }
    }

    private DataTable CreateAllProductTable()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        string country = (string)(Session["country"]);
        string countryn = (string)(Session["countryname"]);
        // set the stored procedure name   
        comm.CommandText = "SELECT Product.productName,Product.productShortDesc,Product.productPrice,Product.productImagePath,Country.countryName,Vendor.vendorName,Product.productID FROM dbo.Product INNER JOIN dbo.Country ON Product.productCountryId=Country.countryId INNER JOIN dbo.Vendor ON Product.vendorId=Vendor.vendorId;";
        comm.CommandType = CommandType.Text;
        comm.Connection.Open();
        
        // Execute the command and save the results in a DataTable  
        DbDataReader reader = comm.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        DbDataReader reader1 = dt.CreateDataReader();

        String table = "<h3 style='margin-left:200px'>Products from All over the World</h3>";
        int nop1 = nop;
        while (reader1.Read())
        {

            if (nop1 == 0)
            {
                nop1 = nop;
                rows += "<br />";
            }
            string PName = reader1.GetString(0);
            string PSDesc = reader1.GetString(1);
            double PPrice = reader1.GetDouble(2);
            if (PPrice > max)
            {
                max = PPrice;
            }
            string PImg = reader1.GetString(3);
            string vendor = reader1.GetString(5);
            int Pid = reader1.GetInt32(6);



            rows += "<div class='prodtable'><img src=" + PImg + " height=100 width=100 /><br /><b>Name:  </b>" + PName + " <br /><b>Vendor:  </b>" + vendor + " <br /><b>Price:  </b>" + PPrice + "<br /><br /><a class=hButton href='Shopping.aspx?productId="+Pid+"'>View Product</a><br /></div>";
            nop1--;
        }
        
        reader.Close();
       tableproduct.InnerHtml =table+rows ;
        return dt;
      
    }

    private void CreateProductTable()
    {
        // DataTable dt1 = new DataTable();
      
        string country = (string)(Session["country"]);
        string countryn = (string)(Session["countryname"]);
        // set the stored procedure name   
     /*   comm.CommandText = "SELECT productName,productShortDesc,productPrice,productImagePath FROM dbo.Product where productCountryId='" + country + "';";
        comm.CommandType = CommandType.Text;
        comm.Connection.Open();*/
        // Execute the command and save the results in a DataTable  
        DataTable table1 = ShopDataAccess.GetProducts(country);
        DbDataReader reader = table1.CreateDataReader();

        String table = "<h3 style='margin-left:200px'>Products from " + countryn + "</h3>";
        int nop1 = nop;
        string rows = null;
        while (reader.Read())
        {
            if (nop1 == 0)
            {
                nop1 = nop;
                rows += "<br />";
            }
            string PName = reader.GetString(0);
            string PSDesc = reader.GetString(1);
            double PPrice = reader.GetDouble(2);
            if (PPrice > max)
            {
                max = PPrice;
            }
            string PImg = reader.GetString(3);
            string vendor = reader.GetString(5);
            int Pid = reader.GetInt32(6);



            rows += "<div class='prodtable'><img src=" + PImg + " height=100 width=100 /><br /><b>Name:  </b>" + PName + " <br /><b>Vendor:  </b>" + vendor + " <br /><b>Price:  </b>" + PPrice + "<br /><br /><a class='hButton' href='Shopping.aspx?productId=" + Pid + "'>View Product</a><br /></div>";
            nop1--;
        }
        
        tableproduct.InnerHtml = table + rows;
        Session.Remove("country");
        Session.Remove("countryname");
       
    }

    
    public string getCountries()
    {
        DataTable table1 = ShopDataAccess.GetCountries();
        DbDataReader reader = table1.CreateDataReader();
        String dt = null;
       

        
        while (reader.Read())
        {

            int countryId = reader.GetInt32(0);
            string countryName = reader.GetString(1);



            if (countryId.Equals((string)Session["country"]))
            {
                rows1 += "<tr class=prodtable><td style='width:10%;'><input type=radio id=country runat=server selected=selected name=selcountry value=" + countryId + " /></td><td>" + countryName + "</td></tr>";
            }
            else
            {
                rows1 += "<tr class=prodtable><td style='width:10%;'><input type=radio id=country runat=server name=selcountry value=" + countryId + " /></td><td>" + countryName + "</td></tr>";
            }
            }
        string table=" <table  runat=server id=countryTable align=center style='border: thin solid black;width:800px;color:black;'>" + rows1+"</table>";
        Literalcountry.InnerHtml = " <table  runat=server id=countryTable align=center style='border: thin solid black;width:200px;color:black;'>" + rows1+"</table>";
        return table;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public  static string getCategories(String countryid)
    {
        DataTable table1 = ShopDataAccess.GetCategories(countryid);
        DbDataReader reader = table1.CreateDataReader();
        String dt = null;
        string rows2 = null;


        while (reader.Read())
        {

            int categoryId = reader.GetInt32(0);
            string categoryName = reader.GetString(1);




            rows2 += "<tr class=prodtable><td style='width:10%;'><input type=radio id=category runat=server  name=selcategory value=" + categoryId + " onchange='onCatSelect()' /></td><td>" + categoryName + "</td></tr>";
        }
        
       // tablecategory.InnerHtml = " <table  runat=server id=categoryTable align=center style='border: thin solid black;width:600px;color:black;'>" + rows2 + "</table>";
        string table2 = "<p  style='font-size:medium;background-color:#FF6600'> Select a Category</p> <table  runat=server id=categoryTable align=center style='border: thin solid black;width:200px;color:black;'>" + rows2 + "</table>";

         return table2;
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public static string getProducts(String countryid)
    {
        DataTable tableproducts = ShopDataAccess.GetProducts(countryid);
        DbDataReader reader = tableproducts.CreateDataReader();
        int nop = 3;

        string countryn = null;
        string rows2 = null;
        int nop1 = nop;
        while (reader.Read())
        {

            if (nop1 == 0)
            {
                nop1 = nop;
                rows2 += "<br />";
            }
            string PName = reader.GetString(0);
            string PSDesc = reader.GetString(1);
            double PPrice = reader.GetDouble(2);
            string PImg = reader.GetString(3);
            countryn = reader.GetString(4);
            string vendor = reader.GetString(5);
            int Pid = reader.GetInt32(6);


            rows2 += "<div class='prodtable'><img src=" + PImg + " height=100 width=100 /><br /><b>Name:  </b>" + PName + " <br /><b>Vendor:  </b>" + vendor + " <br /><b>Price:  </b>" + PPrice + "<br /><br /><a class=hButton href='Shopping.aspx?productId=" + Pid + "'>View Product</a><br /></div>";
            nop1--;
        }
        String table = "<h3 style='margin-left:200px'>Products from " + countryn + "</h3>";
       
        
        table = table + rows2;
        Console.WriteLine(table);
      //  HttpContext.Current.Response.ContentType = "application/json";
     //   JavaScriptSerializer JavaScriptConvert = new JavaScriptSerializer();
    //    string json = JavaScriptConvert.Serialize(table);
        return table;
     
        

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string getProductsConCat(String concat)
    {
        string[] concatnew = concat.Split(',');
        string query = null;
        int nop = 3;
        
           if (concatnew[0]!="")
            {
                query = "Product.productCountryId='" + concatnew[0]+"'";
           }
         if (concatnew[1] != "")
           {
            if (concatnew[1]!=null && concatnew[0]!=null)
               {
                    query = query +" AND Product.categoryId='" + concatnew[1]+"'";
              }
            }
                    query = query + " AND Product.productPrice<" + concatnew[2];
        DataTable tableproducts = ShopDataAccess.GetProductsConCat(query);
        DbDataReader reader = tableproducts.CreateDataReader();


        string countryn = null;
        string rows2 = null;
        String table = null;
        if (tableproducts!=null)
        {
            int nop1 = nop;
            while (reader.Read())
            {
                if (nop1 == 0)
                {
                    nop1 = nop;
                    rows2 += "<br />";
                }
                string PName = reader.GetString(0);
                string PSDesc = reader.GetString(1);
                double PPrice = reader.GetDouble(2);
                string PImg = reader.GetString(3);
                countryn = reader.GetString(4);
                string vendor = reader.GetString(5);
                int Pid = reader.GetInt32(6);


                rows2 += "<div class='prodtable'><img src=" + PImg + " height=100 width=100 /><br /><b>Name:  </b>" + PName + " <br /><b>Vendor:  </b>" + vendor + " <br /><b>Price:  </b>" + PPrice + "<br /><br /><a class=hButton href='Shopping.aspx?productId=" + Pid + "'>View Product</a><br /></div>";
                nop1--;
            }
            table = "<h3 style='margin-left:200px'>Products from " + countryn + "</h3>";


            table = table + rows2;
        }
        else
        {
            table = "No Results";
        }
        Console.WriteLine(table);
        //  HttpContext.Current.Response.ContentType = "application/json";
        //   JavaScriptSerializer JavaScriptConvert = new JavaScriptSerializer();
        //    string json = JavaScriptConvert.Serialize(table);
        return table;



    }



}