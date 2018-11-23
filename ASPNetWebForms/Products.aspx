<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ASPNetWebForms.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <table class="nav-justified">
        <tr>
            <td style="height: 22px">
                <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
            </td>
        </tr>
    </table>
        
</asp:Content>
