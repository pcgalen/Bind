<%@ Page Title="" Language="C#" MasterPageFile="~/Binder.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Binder.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <table id="LoginTable" 
        style="border: 2px solid black; width: 39%; margin-left:auto; margin-right:auto ">
    <tr>
        <td style="width:34%;">
            UserID:</td>
        <td style="width: 75%">
            <asp:TextBox ID="UserIDTextBox" runat="server" Width="185px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="width: 34%;">
            Password:</td>
        <td style="width: 75%">
            
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" 
                Width="185px"></asp:TextBox>
            
            </td>
    </tr>
    <tr>
        <td colspan="2">
        
            <asp:Button ID="LoginButton" runat="server" CssClass="CenterObect" Text="LogIn" 
                Width="75px" />
        
        </td>
    </tr>
    </table>
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
