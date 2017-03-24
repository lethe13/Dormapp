<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complaint.aspx.cs" Inherits="Comp229_TeamProject.Pages.Complaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Complaints</h1>
    <p>Please enter any complaints you have about the </p>
    <p>dorms or the site and it will be submitted anonomously.</p> 
    <asp:TextBox ID="TextBox1" runat="server" Height="216px" Width="335px"></asp:TextBox>
    <br />
    <asp:Button ID="submitbtn" runat="server" Text="Submit" />
</asp:Content>
