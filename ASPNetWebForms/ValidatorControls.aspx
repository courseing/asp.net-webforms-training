<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidatorControls.aspx.cs" Inherits="ASPNetWebForms.ValidatorControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="PersonalDetailsValidation"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ControlToValidate="txtFirstName" ID="reqvValidateFirstName" runat="server" ErrorMessage="Enter First Name" Text="Required!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td><asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="PersonalDetailsValidation"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ValidationExpression="[a-z]{5,10}" ID="reqvValidateLastName" runat="server" ErrorMessage="Last Name Min 5 Max 10 Chars" Text="Min 5 Max 10 Chars!" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtAge" runat="server" ValidationGroup="PersonalDetailsValidation"></asp:TextBox>
            </td>
            <td>
                <asp:RangeValidator ID="reqvValidateAge" MinimumValue="1" MaximumValue="100" runat="server" ErrorMessage="Enter Age between 1-100" Text="Range 1 - 100!" ControlToValidate="txtAge" Type="Integer"></asp:RangeValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label></td>
            <td>
                <asp:RadioButton  ID="rbtnGenderMale" runat="server" Text="Male" />
                <asp:RadioButton ID="rbtnGenderFemale" runat="server" Text="Female" />
            </td>
            <td>
                <asp:CustomValidator ID="cstvSelectGender" runat="server" ErrorMessage="Select Gender" OnServerValidate="cstvSelectGender_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="PersonalDetailsValidation" />
            </td>
            <td>
                <asp:ValidationSummary ID="validationSummary" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
