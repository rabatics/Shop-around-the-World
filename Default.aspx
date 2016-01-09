<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <title title="welcome">Welcome and shop</title>
<link href="bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .map
        {
            margin: 25% 10% 20% 10%;
            top: 25%;
            left: 20%;
            clip: rect(25%, 10%, 20%, 10%);
            right: 20%;
            bottom: 20%;
        }
        .caraousel
        {
            margin: 5% 15% 20% 10%;
            top: 5%;
            right: 15%;
            bottom: 20%;
            left: 10%;
        }
        .map-title
        {
            font-family: "Courier New", Courier, monospace;
            font-size: large;
            color: #800000;
            background-color: #FFFFFF;
            top: 23%;
            right: 10%;
            bottom: 10%;
            left: 20%;
            font-weight: bolder;
        }
        .caraousel-titlehttp://localhost:51920/BrowseProduct.aspx ~ RFb2e8bc.TMP {
            font-family: "Courier New", Courier, monospace;
            font-size: large;
            font-weight: bolder;
            color: #800000;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
	<script type="text/javascript" src="./jquery.maphilight.min.js"></script>
    <script type="text/javascript">$(function () {
            $('.map1').maphilight({ fade: false });
        });</script>
    <script type="text/javascript">
var image1=new Image()
image1.src="image4.png"
var image2=new Image()
image2.src="image1.jpg"
var image3=new Image()
image3.src="image2.jpg"
var image4 = new Image()
image4.src = "image3.jpg"
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

   

   <div class="map"> 
    <div  class="map-title">You can reach the World!!</div>
    <br />
      
<asp:imagemap id="world" class="map1"           
        imageurl="demo_world.png"
        alternatetext="Sales regions" 
        hotspotmode="PostBack"
        width="400"
        height="330"
        onclick="RegionMap_Clicked"   
        runat="Server">      
    <asp:PolygonHotSpot 
          coordinates="64,76,94,77,109,83,109,90,126,80,111,109,113,119,101,110,91,118,70,104,62,91,64,76"         
          postbackvalue="1,United States of America"
          alternatetext="USA">
        </asp:PolygonHotSpot>      
	 <asp:PolygonHotSpot 
          coordinates="287,101,291,114,299,117,308,112,304,122,291,137,288,151,278,124,280,115,285,104,287,101"         
          postbackvalue="2,India"
          alternatetext="India">
        </asp:PolygonHotSpot>
     <asp:PolygonHotSpot 
          coordinates="284,94,298,78,317,90,337,70,348,81,333,97,334,117,316,126,303,114,289,108,284,94"         
          postbackvalue="3,China"
          alternatetext="China">
        </asp:PolygonHotSpot>
	
    
</asp:imagemap></div>
   <div class="caraousel">
   <div class="caraousel-title">New Release</div>
   <br />
 <img id="myScreen" style="border: thin solid black" src="boxingring.png" name="slide" width="100%" height="350" alt="placeholder" />  
<script type="text/javascript">

    var step = 1;
    var img = [<%=rows %>];
    var myScreen = document.getElementById('myScreen');
   
    var totalPics = img.length;
    var i = 0;
    function loop() {
        if (i > (totalPics - 1)) {
            i = 0;
        }
        myScreen.src =  img[i];
        i++;
        loopTimer = setTimeout('loop()', 3000);
    }
    loop();

</script>
   </div>
   
    
</asp:Content>


