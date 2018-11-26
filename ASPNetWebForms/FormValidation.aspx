<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormValidation.aspx.cs" Inherits="ASPNetWebForms.FormValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="1st Textbox Number must be equal to 10" ValueToCompare="10" ValidationGroup="btn1">Number must be equal to 10</asp:CompareValidator>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" ValidationGroup="btn1" />
    
    </div>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Compulsory" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="btn1">Required</asp:CustomValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="RegularExpressionValidator" ValidationExpression="[a-z]{2,4}"></asp:RegularExpressionValidator>
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
    </form>
</body>
</html>
