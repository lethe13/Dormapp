<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complaint.aspx.cs" Inherits="Comp229_TeamProject.Pages.Complaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="divBody">
     <h1>Complaints</h1>
    <p>Please enter any complaints you have about the </p>
    <p>dorms or the site and it will be submitted anonomously.</p>
    <p>*Max 600 characters</p> 
    <asp:TextBox ID="complaintbx" runat="server" Height="216px" Width="335px" MaxLength="600" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <asp:Button ID="submitbtn" runat="server" Text="Submit" OnClick="submitbtn_Click" />
       </div>
</asp:Content>
