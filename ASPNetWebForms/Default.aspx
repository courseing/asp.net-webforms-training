<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTotal" runat="server"></asp:Label>
    <asp:Button ID="btnGetTotal" runat="server" Text="Get Total" OnClick="btnGetTotal_Click" />
</asp:Content>


