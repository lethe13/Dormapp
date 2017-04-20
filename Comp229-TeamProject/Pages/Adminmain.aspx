﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adminmain.aspx.cs" Inherits="Comp229_TeamProject.Pages.Adminmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="col-md-6 divBody heightRegistration" id="registerDiv">
        <h2>Make a Front Desk Account</h2>
        <table class="tableFillout">
        <tr><td>First Name:</td><td> <asp:TextBox runat="server" ID="firstNameTB" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNameTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="First name is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Last Name:</td><td> <asp:TextBox runat="server" ID="lastNameTB"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="lastNameTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="Last name is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Password:</td><td> <asp:TextBox runat="server" ID="regPasswordTB" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="regPasswordTB" Display="Dynamic" ValidationGroup="registration" ErrorMessage="Password is Required."></asp:RequiredFieldValidator></td></tr>
        <tr><td>Confirm Password:</td><td><asp:TextBox runat="server" ID="confirmPasswordTB" TextMode="Password"></asp:TextBox></td></tr>
            <asp:CompareValidator runat="server" ControlToValidate="confirmPasswordTB" ControlToCompare="regPasswordTB" Display="Dynamic" ErrorMessage="Passwords do not match"></asp:CompareValidator>
            </table>
        <br />
        <asp:Button CssClass="btn" runat="server" Text="Create Account" Onclick="Register_Click" />
        <asp:Label runat="server" ID="WarningLbl"></asp:Label>
        
            <br />
            <br />
            <br />
            <asp:Button ID="modifybtn" runat="server" CssClass="btn" Onclick="Modify_Click" Text="Modify Employees" />
            <br />
            <br />
            <asp:Button ID="modifybtn0" runat="server" CssClass="btn" Onclick="ModifyStud_Click" Text="Modify Students" />
            <br />
            <br />
        
    </div>
      
</asp:Content>
