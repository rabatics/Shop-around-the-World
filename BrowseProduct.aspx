<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="BrowseProduct.aspx.cs" Inherits="BrowseProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <title>Browse Products</title>
    <style type="text/css">
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

         tr.prodtable{
           background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#C8C8C8));
	background: -moz-linear-gradient(top,#E8E8E8,#C8C8C8);
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#E8E8E8', endColorstr='#C8C8C8');
            color:black;
          

        }

          tr.prodtable:hover{
           background: -webkit-gradient(linear, left top, left bottom, from(#FFFFFF), to(#C8C8C8));
	background: -moz-linear-gradient(top,#FFFFFF,#C8C8C8);
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFFF', endColorstr='#C8C8C8');
            color:black;
       }
       div.prodtable:hover{
           background: -webkit-gradient(linear, left top, left bottom, from(#FFFFFF), to(#C8C8C8));
	background: -moz-linear-gradient(top,#FFFFFF,#C8C8C8);
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFFF', endColorstr='#C8C8C8');
            color:black;
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
    margin-left:25px;


}



      
    </style>
    <script type="text/javascript" src="jquery-2.0.3.js"></script>
 
    <script type="text/javascript">

     
        $(document).ready(function () {
          
            $("input[name=selcountry]:radio").change(function (event) {
               
               
                var selectedVal = "";
                var selected = $("input[type='radio'][name='selcountry']:checked");
                if (selected.length > 0) {
                    selectedVal = selected.val();
                }

                


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "BrowseProduct.aspx/getProducts",
                    dataType: "json",
                    data: JSON.stringify({ countryid: selectedVal }),
                   
                    success: function (data) {
                        $('div[id$="tableproduct"]').html("<p style='text-align:center;'><img src='./ajaxloading.gif' height=100 width=100 alt=loading style='border-radius:10px;'></p>");
                           
                        setTimeout(function () {
                            $('div[id$="tableproduct"]').html(data.d);
                        }, 1200);
                       
                       

                    }
                });
               
                


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "BrowseProduct.aspx/getCategories",
                    dataType: "json",
                    data: JSON.stringify({ countryid: selectedVal }),
                   
                    success: function (data) {

                        $('div[id$="tablecategory"]').html(data.d);
                        $('div[id$="tablecategory"]').slideDown();
                    }
                });
               


            });

           


        });
        
        function displayrangevalue() {
            document.getElementById("newprice").innerText = document.getElementById("price").value;
}
          function onCatSelect(){

             
                var selectedVal = "";
                
                var selected = $("input[type='radio'][name='selcountry']:checked");
                if (selected.length > 0) {
                    selectedVal = selected.val();
                }
              
                var selectedVal2 = "";
                var selected2 = $("input[type='radio'][name=selcategory]:checked");
                if (selected2.length > 0) {
                    selectedVal2 = selected2.val();
                }
                
                var selectedVal3 = document.getElementById("price").value;

                var sel = selectedVal + "," + selectedVal2 +","+selectedVal3;
                
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "BrowseProduct.aspx/getProductsConCat",
                    dataType: "json",
                    data: JSON.stringify({ concat: sel }),
                   
                  success: function (data) {
                        
                        
                        $('div[id$="tablerange"]').slideDown();
                        
                        $('div[id$="tableproduct"]').html("<p style='text-align:center;'><img src='./ajaxloading.gif' height=100 width=100 alt=loading style='border-radius:10px;'></p>");

                        setTimeout(function () {
                            $('div[id$="tableproduct"]').html(data.d);
                        }, 1200);
                      
                    }
                });



           

          }

          function rotate() {
              (this).rotate(360);
          }

         

         
       
       
       
   
        </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <div style="height:100%;width:100%;margin-top:0px;z-index:-5;overflow:scroll;background-color:#C8C8C8;" >
     <div style="position:absolute;height:420px;width:220px;text-align:center;z-index:-;left:50px;margin-top:320px;border: thin solid black; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#C8C8C8));border-radius:5px;" >
      <p  style='font-size:medium;background-color:#FF6600'>  <b>   Select a Country  </b></p>
         <p id="Literalcountry"  runat="server"></p> 
          <% 
		if(Session["product"]!=null){
		Session.Remove("product");
			} %>
         <div id="tablecategory"  runat="server" style="height:auto;width:auto;display:none;"></div>
        <div id="tablerange"  runat="server" style="margin-left:10px;margin-top:10px;height:80px;width:200px;background-color:#A8A8A8 ;color:white;display:none;"> <p  style='font-size:medium;'> Select a Price Range</p>
        1 <input type="range" id="price" name="pricerange"  min="1" max="<%=(max+5) %>" onchange="onCatSelect()" oninput="displayrangevalue()"><%=(max+5) %><br />
            <p id="newprice"> </p>
        </div>
    
         
         
        </div>
   <div id="tableproduct" runat="server" style="padding-left:110px;position:absolute;align-items:flex-end;height:60%;width:65%;z-index:-1;margin-left:15%;margin-top:20%;overflow:scroll;" >
      
       </div>
                    
       </div>
            
      
   
         

        
   
        
  
        
   



</asp:Content>
    
