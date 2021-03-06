﻿<%@ Page Title="Registration/Login" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Comp229_TeamProject.Pages.Registration" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6 divBody heightRegistration" id="registerDiv">
        <h2>Register for an account</h2>
        <table class="tableFillout">
        <tr><td>First Name:</td><td> <asp:TextBox runat="server" ID="firstNameTB" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNameTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="First name is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Last Name:</td><td> <asp:TextBox runat="server" ID="lastNameTB"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="lastNameTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="Last name is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Username:</td><td> <asp:TextBox runat="server" ID="regUsernameTB" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="regUsernameTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="Username is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Password:</td><td> <asp:TextBox runat="server" ID="regPasswordTB" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="regPasswordTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="Password is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Confirm Password:</td><td><asp:TextBox runat="server" ID="confirmPasswordTB" TextMode="Password"></asp:TextBox></td></tr>
            <asp:CompareValidator runat="server" ControlToValidate="confirmPasswordTB" ControlToCompare="regPasswordTB" Display="Dynamic" ErrorMessage="Passwords do not match"></asp:CompareValidator>
            </table>
        <br />
        <asp:Button CssClass="btn" runat="server" Text="Create Account" Onclick="Register_Click" />
        <asp:Label runat="server" ID="WarningLbl"></asp:Label>
        
    </div>
    <div class="col-md-6 divBody heightRegistration" id="loginDiv">
        <h2>Login</h2>
        <table class="tableFillout">
        <tr><td>Username:</td><td> <asp:TextBox runat="server" ID="loginUsernameTB"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="loginUsernameTB" Display="Dynamic" ValidationGroup="login" ErrorMessage="Username is Required."></asp:RequiredFieldValidator>
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
