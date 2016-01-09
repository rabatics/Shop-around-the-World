<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="Shopping.aspx.cs" Inherits="Shopping" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  
    <title></title>  
        <style type="text/css">
            .style2
            {
                width: 50%;
                height: 85px;
                display:block;
                margin:1% 0% 0% 4%;                                                            
            }
            .style3
            {
                width: 50%;
                height: 355px;
            }

             .hButton > a:link{
	color:#000000;
	text-decoration:none;

}

.hButton > a:visited {
	  color:#000000;
	text-decoration:none;
}


.hButton:hover{
	
	background: #9966cc;
	background: -webkit-gradient(linear, left top, left bottom, from(#ff6600), to(#ff9900));
	background: -moz-linear-gradient(top,  #ff6600,  #ff9900);
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ff6600', endColorstr='#ff9900');
    text-decoration:none;
}

.hButton{
	display:inline-block;
 	padding: 5px 0px 0px 0px;
     	height:30px;
     	width: 150px; 
	color:#000000;
     	border-radius :5px;
     	background-color: #FF6600;
	text-align:center;
	text-decoration:none;
	font-size: 9pt;
	font-family: arial;
	font-weight: bold;
    margin-left:25px;


}

    </style>
    
       
    </asp:Content>

    
    
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
        <div style="margin:19% 18% 0% 18%;">
            <% Product product = (Product)Session["product"]; %>>
        <table style="border: thin solid #000000; height:355px;">
            <tr>
                <td class="style3">
                    <img ID="img"  height="355" width="438"
                    src="<%=product.getProductImagePath() %>" alt="Product" />
                </td>

                <td class="style2">
                   
                    <p><b>Product Name&nbsp;:&nbsp;&nbsp;</b><%=product.getProductName()  %><asp:Literal ID="prodname" runat="server"></asp:Literal></p>

                    <p><b>Quantity&nbsp;:&nbsp;&nbsp;</b><input type="text" id="qty" name="quant" title="Quantity" value="1" pattern="[0-9]+" required="required"   runat="server" /></p>
                    
                    <p><b>Vendor&nbsp;:&nbsp;&nbsp;</b><%=product.getProductVendorName() %><asp:Literal ID="vendor" runat="server"></asp:Literal></p>
                    
                    <p><b>Price&nbsp;:&nbsp;&nbsp;</b><%=product.getProductPrice() %></p><asp:Literal ID="price" runat="server"></asp:Literal>
                    
                    <p><b>Description&nbsp;:&nbsp;&nbsp;</b><%=product.getProductLongDesc() %><asp:Literal ID="desc" runat="server"></asp:Literal></p>
                </td>
            </tr>
            </table>
            <table style="text-align:center; height:40px; margin-top:1%; width:100%"><tr><td><p>
            <asp:Button ID="Button1" runat="server" OnClick="AddToCart" Text="Add to Cart" CausesValidation="true"  BorderStyle="Ridge" BorderColor="Blue" Font-Bold="true"></asp:Button>
            <asp:Button ID="Button2" runat="server" OnClick="travelHome" Text="Continue shopping" BorderStyle="Ridge" BorderColor="Blue" Font-Bold="true"></asp:Button>
            </p></td></tr></table>

            <asp:Label ID="error" runat="server"></asp:Label>

         <a href="ShoppingCart.aspx" shape="circle" style="color:Black; background-color:ButtonShadow; " >View Cart</a>
         </div>
</asp:Content>