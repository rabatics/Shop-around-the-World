<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <title title="welcome">Welcome and shop</title>
    <link rel="stylesheet" type="text/css" href="./CSS-Styles/DisplayPage.css" />
    <link rel="stylesheet" type="text/css" href="./CSS-Styles/deals.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="./jquery.maphilight.min.js"></script>
    <script type="text/javascript">        $(function () 
    {
        $('.map').maphilight({ fade: false });
    });
    </script>
    <script type="text/javascript">
        var img1 = '<%= path1 %>'
        var img2 = '<%= path2 %>'
        var image1 = new Image()
        image1.src = img1
        var image2 = new Image()
        image2.src = img2
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <table class="Main-table" width="100%" style="margin-top:20%; vertical-align: top;" cellspacing="5" >
        <tr>
            <td width="30%" class="td-map" style="vertical-align:top;">
                <table class="worldmap-table " cellspacing="10">
                    <tr>
                        <td class="curve" align="center" style="box-shadow: 0 10px 6px -6px #777; color:#404082;" valign="middle" height="60">
                          <img src="./Homepage_images/world1.png" width="40" height="70" alt="slide" style="vertical-align:middle;"  />&nbsp;&nbsp;  <h3 style="display:inline;text-align:center;vertical-align:middle;">You can reach the world</h3> 
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin solid silver;box-shadow: 10px 10px 6px -6px #777;">
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
	
    
</asp:imagemap>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" class="td-newrelase"style="vertical-align:top;">
                <table class="newrelase-table"  cellspacing="10" style="top: 0;">
                    <tr >
                        <td align="center" class="curve"  style="box-shadow: 0 10px 6px -6px #777;">
                            <img src="./Homepage_images/new-release.png" width="200" height="70" alt="new-relase pic" style="border-radius:25px;" />
                        </td>
                    </tr>
                    <tr>
                        <td  style="box-shadow: 10px 10px 6px -6px #777;">
                            <img style="border: thin solid silver" src="boxingring.png" name="slide" width="600" height="330" alt="slide" />
                            <script type="text/javascript">
                                var step = 1
                                function slideit() {
                                document.images.slide.src = eval("image" + step + ".src")
                                if (step < 2)
                                step++
                                else
                                step = 1
                                setTimeout("slideit()", 2500)
                                }
                                slideit()
                            </script>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20%" class="td-deals" align="center">
                <table class="deals-table" align="center" style="font-size:medium;font-weight:600;">
                    <tr align="center">
                        <td>
                            <img src="./Homepage_images/best-deals.png" width="130" height="70" alt="slide" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Special Deals
                            <div class="container">
                                <img src="./Homepage_images/sp.png" width="150" height="150" alt="slide" />
                                <div class="textbox">
                                    <p class="text ApplyFont" style="background-color:#4262A3; color:White;">"50%" on all <b>Traditional Wears</b><br /> Deal starts on Dec-17-2014<br /> till Dec-31-2014</p>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h4>Weekly Deals</h4>
                            <div class="container">
                                <img src="./Homepage_images/Weeklydeals.png" width="100" height="90" alt="slide" />
                                <div class="textbox">
                                    <p class="text ApplyFont" style="background-color:#4262A3; color:White;">"40%" on all <b>"Traditional Jewelery"</b></p>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h4>Monthly Deals</h4>
                            <div class="container">
                                <img src="./Homepage_images/Md.png" width="100" height="90" alt="slide" />
                                <div class="textbox">
                                    <p class="text ApplyFont" style="background-color:#4262A3; color:White;">"60%" on all <b>"Indian products"</b></p>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


