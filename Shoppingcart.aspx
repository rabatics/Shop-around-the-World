<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="Shoppingcart.aspx.cs" Inherits="ShoppingCart" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">    
        <style type="text/css">
         ul
         {
             list-style-type:none;                          
         }   
         .style1
         {
              display: block;
              margin: 2% 0% 2% 2%;
              width: 100%;
              height:80px;
         }

          div.prodtable{
           background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#C8C8C8));
	background: -moz-linear-gradient(top,#E8E8E8,#C8C8C8);
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#E8E8E8', endColorstr='#C8C8C8');
            color:black;
            word-wrap: break-word;      
    overflow-wrap: break-word;
    height:250px;
    width:200px;
    display:inline-table;
    border-radius:20px;
    border:thin solid black;
    text-align:center;
    margin-left:35px;
    margin-top:50px;
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
    margin-left:35px;


}

.hButton2{
	display:block;
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
    margin-left:45%;


}

    </style>
     
    <script type="text/javascript" src="jquery-2.0.3.js"></script>
 
    <script type="text/javascript">
       
        $(document).ready(function () {

            $("input[type='button'][name='removeprod']").click(function (event) {



                var selectedVal = "";
                var selected = $("input[type='radio'][name='selproduct']:checked");
                if (selected.length > 0) {
                    selectedVal = selected.val();
                }
                if (selectedVal == "") {
                    alert("Please select a radio button");
                }


                var user = document.getElementById("user").value;



                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ShoppingCart.aspx/RemoveProducts",
                    dataType: "json",
                    data: JSON.stringify({ productId: selectedVal, customerId: user }),

                    success: function (data) {
                        $('div[id$="tableproducts"]').html("<p style='text-align:center;'><img src='./ajaxloading.gif' height=100 width=100 alt=loading style='border-radius:10px;'></p>");

                        setTimeout(function () {
                            $('div[id$="tableproducts"]').html(data.d);
                        }, 1200);



                    }
                });
            });

            $("input[type='button'][name='place']").click(function (event) {
                $('div[id$="order"]').slideToggle();
            });




            $("input[type='button'][name='placeorderfinal']").click(function (event) {


                var user = document.getElementById("user").value;
                var ship = document.getElementById("shipid").value;
               var bill= document.getElementById("billid").value;

               if (ship == "" || bill == "") {
                   alert("Please enter the Shipping Address and Billing Address");
                   return false;
               }

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ShoppingCart.aspx/PlaceOrder",
                    dataType: "json",
                    data: JSON.stringify({customerId: user,ship:ship,bill:bill }),

                    success: function (data) {
                        $('div[id$="tableserver"]').html("<p style='text-align:center;'><img src='./ajaxloading.gif' height=100 width=100 alt=loading style='border-radius:10px;'></p>");

                        setTimeout(function () {
                            $('div[id$="tableserver"]').slideDown();
                            $('div[id$="order"]').slideUp();
                            $("input[type='button'][name='removeprod']").hide();
                            $('div[id$="tableserver"]').html(data.d);
                        }, 1200);



                    }
                });



            });
        });
        
        
        
        

         </script>
    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <div style="margin:19% 25% 0% 20%; text-align:center; ">
    <div style="background-color:#cd3301;color:white;border-radius:15px;margin-left:20%;">
          <input type="text" id="user" hidden="hidden" value="<%=(int)Session["userid"] %>" >                <!-- =//(int)Session["userid"]-->
    <h2 style="text-align:center;">Your Cart Items</h2>
    <p><a href="BrowseProduct.aspx" style="color:white;text-decoration:none;"><h3>Back to Products</h3></a></p>
        </div>
        
        
   <div id="tableproducts" runat="server" style="position:absolute;align-items:flex-end;height:60%;width:70%;z-index:-1;margin-top:3%;overflow:scroll;" >
      
       </div>
         <input type="button" id="remove" name="removeprod" class="hButton"  value="Remove From Cart" style="display:inline-block;" />
          <input type="button" id="placeorder" name="place" class="hButton"  value="Check Out" style="display:inline-block;" />
       <div id="order" style="display:none; height:80%;width:99%;z-index:-1;margin-top:3%;margin-left:20%;text-align:center;border:thin solid black;padding-top:20px;padding-bottom:10px;">
            Shipping Address: <textarea name="ship" id="shipid" cols="60" required="required" rows="3" ></textarea><br /><br />

            Billing Address: <textarea name="bill" id="billid" cols="60" required="required" rows="3" ></textarea><br />
            <input type="button"  class="hButton2" name="placeorderfinal" id="orderfinal" value="Place Order">
        </div>
         <div id="tableserver" style="display:none;height:50%;width:99%;z-index:-1;margin-top:3%;margin-left:20%;text-align:center;" runat="server"></div>
    </div>
</asp:Content>
