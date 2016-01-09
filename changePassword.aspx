<%@ Page Title="" Language="C#" MasterPageFile="~/commonpage.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="changePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            font-size: x-large;
            text-align: center;
        }
        .style7
        {
            width: 379px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table width="50%" style="border: thin solid #000000;top: 25%;margin-top: 22%;">
        <tr>
            <td class="style5" colspan="2" 
                style="  ">
                <strong>Change Password</strong></td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style7">
                Old Password</td>
            <td>
                <asp:TextBox ID="oldpwd" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style7">
                New Password</td>
            <td>
                <asp:TextBox ID="newpwd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style7">
                Confirm Password</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center"> 
         
                <asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="checkPassword" />
                <asp:Button ID="Button2" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>   
</asp:Content>

