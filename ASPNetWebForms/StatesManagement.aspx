<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatesManagement.aspx.cs" Inherits="ASPNetWebForms.SessionState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtTotal" runat="server" EnableViewState="False"></asp:TextBox>
    <asp:Button ID="btnSaveTotal" runat="server" Text="Save Total" OnClick="btnSaveTotal_Click" />
</asp:Content>
