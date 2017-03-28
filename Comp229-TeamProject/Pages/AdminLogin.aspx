<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adminlogin.aspx.cs" Inherits="Comp229_TeamProject.Pages.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="col-md-6 divBody heightRegistration" id="loginDiv">
        <h2>Admin Login</h2>
        <table class="tableFillout">
        <tr><td>Admin ID:</td><td> <asp:TextBox runat="server" ID="loginUsernameTB"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="loginUsernameTB" Display="Dynamic" ValidationGroup="login" ErrorMessage="ID is Required."></asp:RequiredFieldValidator>
                              </td></tr>

        <tr><td>Password:</td><td> <asp:TextBox runat="server" ID="loginPasswordTB" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="loginPasswordTB" Display="Dynamic" ValidationGroup="login" ErrorMessage="Password is Required."></asp:RequiredFieldValidator>
                              </td></tr>
            </table>
        <br />
        <asp:Button CssClass="btn" runat="server" Text="Login" Onclick="Login_Click" />
        <asp:Label runat="server" ID="WarningLblLogin"></asp:Label>
    </div>
</asp:Content>
