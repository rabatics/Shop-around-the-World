using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;

public partial class Shopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int productid=0;
        if (Session["product"] != null)
        {
            Product product = (Product)Session["product"];
            productid = product.getProductId();
            prodname.Text = product.getProductName();
            vendor.Text = product.getProductVendorName();
            price.Text = product.getProductPrice().ToString();
            desc.Text = product.getProductShortDesc();
        }
        else
        {
            productid = Int32.Parse(Request.QueryString["productId"]);
            Product product = ShopDataAccess.GetProduct(productid);
            Session["product"] = product;
            prodname.Text = product.getProductName();
            vendor.Text = product.getProductVendorName();
            price.Text = product.getProductPrice().ToString();
            desc.Text = product.getProductShortDesc();
        }
       
    }


    

    protected void AddToCart(object sender, EventArgs e)
    {
        int customerId=1;
        
        if (Session["user"] == null)
        {
            Session["prevpage"] = "Shopping.aspx";
            Response.Redirect("loginpage.aspx");
        }
        else{
        customerId=(int)Session["userid"];
        }
        Product product = (Product)Session["product"];
        Product[] productCart = null;
        int qty1 = 1;
        
        product.setProductQuantity(qty1);
        if (Session["productCart"] == null)
        {
            productCart = new Product[20];
        }
        else
        {
            productCart =(Product[]) Session["productCart"];
        }
        product.addProduct(product,productCart);
        DbCommand comm = GenericDataAccess.CreateCommand();
        try
        {
           
            // set the stored procedure name   
            comm.CommandText = "INSERT INTO dbo.ShoppingCart VALUES('" + product.getProductQuantity() + "','"+customerId+"','" + product.getProductId() + "','" + product.getProductVendorId() + "');";      // change 2 column value frm '1' to '"+customerId+"'
            comm.CommandType = CommandType.Text;
            comm.Connection.Open();
            comm.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            error.Text = "Sorry, the product could not be added to the Cart. Please try again.";
            
        }
        finally
        {
            comm.Connection.Close();
        }
        Session["productCart"] = productCart;
        
        
        // Redirect the user to view their shopping cart
        Response.Redirect("Shoppingcart.aspx");
    }

    protected void travelHome(object sender, EventArgs e)
    {
        Response.Redirect("Shop.aspx");
    }

}
