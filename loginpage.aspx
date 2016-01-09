<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="loginpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="login.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    #log
    {   
        top:18%;
        left:35%;
        margin: 18% 0% 1% 35%;
        text-align:center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="log">
        <table style="border:thin solid #000000; padding:5%; text-align:center; box-shadow: 10px 10px 6px -6px #CC3300;">
            <tr>
                <td colspan="2" style="font-weight:bold;height:50px;">Sign In</td>
            </tr>
            <tr> 
                <td style="width:30%;text-align:center;">  
                    UserName:
                </td>
                <td style="text-align:right;margin-right:2%;right:2%;">  
                    <asp:TextBox ID="txtLogin" runat="server" Width="200px" Height="23px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLogin" ErrorMessage="  ** User Name is Required" 
                    ForeColor="Red" style="color: #FF0000"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>  
                <td style="width:30%;text-align:center;">  
                    Password:
                </td>
                <td>  
                    <asp:TextBox ID="txtPassword" type="password" runat="server" Width="200px" Height="21px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="  ** Password is Required" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblError" runat="server" Text="" style="color:Red;">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="96px"  
                        align="center" onclick="btnLogin_Click" BackColor="#CC3300" BorderColor="#CC3300" 
                        BorderStyle="Solid" ForeColor="White" style="font-weight: 700;text-align:center;margin:auto;"/>
                </td>
            </tr>
        </table>
        <br /><br />
    </div>
</asp:Content>

