<%@ Page Title="" Language="C#" MasterPageFile="~/Binder.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="Binder._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p />
    <p />
    <p />
    <table style="width: 500px; margin-left: auto; margin-right: auto; text-align: center;">
        <tr>
            <td>
                Name Server Version:
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal runat="server" ID="ServerTypeLiteral"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                Configured Zones:
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal runat="server" ID="ZoneCountLiteral"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
