﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
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

public partial class ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["prevpage"] = "ShoppingCart.aspx";
            Response.Redirect("loginpage.aspx");
        }
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        int customerId = (int)Session["userid"];
        comm.CommandText = "SELECT ShoppingCart.customerId,ShoppingCart.productId,ShoppingCart.quantity,Product.productName,Product.productPrice,Product.productImagePath,Product.productCountryId,Product.categoryId,Product.vendorId,Product.productRating,Product.productShortDesc,Product.productLongDesc,Vendor.vendorName FROM dbo.ShoppingCart INNER JOIN dbo.Product ON ShoppingCart.productId=Product.productId INNER JOIN dbo.Vendor ON ShoppingCart.vendorId=Vendor.vendorId WHERE ShoppingCart.customerId="+customerId+";";
        comm.CommandType = CommandType.Text;
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        DbDataReader reader = table.CreateDataReader();
        string rows = null;
        int i = 0;
        Product[] productCart = new Product[20];
        while (reader.Read())
        {
            Product product = new Product();
            product.setProductId(reader.GetInt32(1));
            int custid = reader.GetInt32(0);
            product.setProductQuantity(reader.GetInt32(2));
            product.setproductName(reader.GetString(3));
            product.setProductPrice(reader.GetDouble(4));
            product.setProductImagePath(reader.GetString(5));
            product.setProductCountryId(reader.GetInt32(6));
            product.setProductCategoryId(reader.GetInt32(7));
            product.setProductVendorId(reader.GetInt32(8));
            product.setProductRating(reader.GetInt32(9));
            product.setProductShortDesc(reader.GetString(10));
            product.setProductLongDesc(reader.GetString(11));
            product.setproductVendorName(reader.GetString(12));
            product.addProduct(product, productCart);


            rows += "<div class='prodtable'><input type=radio id=cart runat=server name=selproduct value=" + product.getProductId() + " /><img src=" + product.getProductImagePath() + " height=100 width=100 /><br /><b>Name:  </b>" + product.getProductName() + " <br /><b>Vendor:  </b>" + product.getProductVendorName() + " <br /><b>Quantity:  </b>" + product.getProductQuantity() + "<br /><b>Price:  </b>" + product.getProductPrice() + "<br /><br /></div>";

           

        }
        if (productCart[0] != null)
        {
            rows += "<p style='margin-top:50px;font-size:60px;'>Total Price= " + productCart[0].calcTotalPrice(productCart);
        }
        /*  <table width="80%" style="border: thin solid #000000; top:20%;">
        <% Product[] productCart=(Product[])Session["productCart"]; %>>
        <% for (int i = 0; i < productCart.Length; i++)
           {
               if (productCart[i] != null)
               { %>
        <tr>
            <td>
                <img= id="img1"  height="412" width="473" 
                    src="<%=productCart[i].getProductImagePath()%>">
            </td>
            <td class="style1">
                <ul>
                    <li>Product Name: <%=productCart[i].getProductName()%></li>
                    <li>Quantity:<%=productCart[i].getProductQuantity()%></li>
                    <li>Rating:<%=productCart[i].getProductRating()%>
                        </li>
                    <li> 
           </li>
                </ul>
            </td>

         </tr>
        <%}
           }
           %>
       TotalPrice= <%=productCart[0].calcTotalPrice(productCart) %>
    </table>    */
        if (Session["productCart"] == null)
        {
            Session["productCart"] = productCart;
        }
        tableproducts.InnerHtml = rows;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string RemoveProducts(int productId,int customerId)
    {
        
       
        string rows = null;
        
      //  user = (string)Session["user"];
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "DELETE FROM dbo.ShoppingCart WHERE customerId="+customerId+" AND productId="+productId+";";
        comm.CommandType = CommandType.Text;
        comm.Connection.Open();
        comm.ExecuteNonQuery();
        
        Product[] productCart=ShopDataAccess.GetCart(customerId);
        
        for(int i=0;i<productCart.Length;i++){
            if(productCart[i]!=null){

                rows += "<div class='prodtable'><input type=radio id=cart runat=server name=selproduct value=" + productCart[i].getProductId() + " /><img src=" + productCart[i].getProductImagePath() + " height=100 width=100 /><br /><b>Name:  </b>" + productCart[i].getProductName() + " <br /><b>Vendor:  </b>" + productCart[i].getProductVendorName() + " <br /><b>Quantity:  </b>" + productCart[i].getProductQuantity() + "<br /><b>Price:  </b>" + productCart[i].getProductPrice() + "<br /><br /></div>";
            }
            }
        if (productCart[0] != null)
        {
            rows += "<p style='margin-top:50px;font-size:60px;'>Total Price= " + productCart[0].calcTotalPrice(productCart) + "</p>";
        }
        return rows;
        }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string PlaceOrder(int customerId,string ship,string bill)
    {


        

        //  string user = (string)Session["user"];
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        string reply = null;
        Product[] productCart = ShopDataAccess.GetCart(customerId);
        double totalprice=0.00;
        if (productCart[0] != null)
        {


            string today = DateTime.Today.ToString("yyyy-MM-dd");
            totalprice = productCart[0].calcTotalPrice(productCart);

            DbCommand comm1 = GenericDataAccess.CreateCommand();
            comm1.CommandText = " INSERT INTO Orders VALUES(" + totalprice + ",'"+ship+"','"+bill+"',"+customerId+",'" + today + "');";
            comm1.CommandType = CommandType.Text;
            comm1.Connection.Open();
            comm1.ExecuteNonQuery();
            comm1.Connection.Close();

            
            comm.CommandText = " SELECT orderId from Orders where customerId="+customerId+" AND orderDate='"+today+"';";
            comm.CommandType = CommandType.Text;
            comm.Connection.Open();
            // Execute the command and save the results in a DataTable  
            DbDataReader reader = comm.ExecuteReader();     
            int orderId = 0;
            while (reader.Read())
            {
                orderId = reader.GetInt32(0);
            }
            comm.Connection.Close();
            DbCommand comm2 = GenericDataAccess.CreateCommand();
            for (int i = 0; i < productCart.Length; i++)
            {
                if (productCart[i] != null)
                {
                    
                    comm2.CommandText = " INSERT INTO OrderItem VALUES(" + orderId + "," +productCart[i].getProductId()+"," + customerId + ",'" +productCart[i].getProductQuantity() + "'," + (productCart[i].getProductPrice()*productCart[i].getProductQuantity()) + ");";
                    comm2.CommandType = CommandType.Text;
                    comm2.Connection.Open();
                    comm2.ExecuteNonQuery();
                    comm2.Connection.Close();
                }
            }

            DbCommand comm3 = GenericDataAccess.CreateCommand();
            comm3.CommandText = "DELETE FROM ShoppingCart WHERE customerId=" + customerId + ";";
            comm3.CommandType = CommandType.Text;
            comm3.Connection.Open();
            comm3.ExecuteNonQuery();
            comm3.Connection.Close();
            reply = "<p style='color:green;'>Thank you for your purchase. Your order has been successfully placed and this is your OrderID:" + orderId + ". Please save this for future reference.</p><a href='ViewOrders.aspx' class='hButton'>View Orders</a>";

        }
        else
        {
            reply = "<p>Sorry, The system is not able to place your order.Your Shopping Cart is empty. Please add Products to the Cart and then place the order.</p> ";
        }

       
        return reply;
    }






}