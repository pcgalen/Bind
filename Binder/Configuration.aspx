<%@ Page Title="" Language="C#" MasterPageFile="~/Binder.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="Binder.Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p />
<p />
<p />
    <table style="border-style: solid; border-color: #000000; width: 500px; margin-left: auto; margin-right: auto; text-align: center;">
    <tr>
        <th style="text-align: center" colspan="2">Configuration</th>
    </tr>
    <tr>
        <td style="text-align: right; width:50%">
        Username:
        </td>
        <td style="text-align: left; width:50%">
        <asp:TextBox ID="UserNameTextBox" runat="server" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
        Password:
        </td>
        <td style="text-align:left">
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" colspan="2"><strong>Database</strong></td>
    </tr>
    <tr>
        <td style="text-align: right;">Database Server:</td>
        <td style="text-align: left"><asp:TextBox ID="DatabaseServerTextBox" runat="server" 
                Width="188px" /></td>
    </tr>
    <tr>
        <td style="text-align:right;">
            Database:
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="DatabaseTextBox" runat="server" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            UserID:
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="DatabaseUserID" Runat="server" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            Password:
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="DatabasePassword" runat="server" Width="188px" 
                TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" colspan="2"><strong>Bind Server</strong></td>
    </tr>
    <tr>
        <td style="text-align: right;">
            Path:
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="BindPath" runat="server" Width="180px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align:center" colspan="2">
            <asp:Button ID="SubmitButton" Text="Submit" runat="server" 
                onclick="SubmitButton_Click" />
        </td>
    </tr>
</table>
<p />
<p />
<p />
</asp:Content>
