<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComplaintDetails.aspx.cs" Inherits="Comp229_TeamProject.Pages.ComplaintDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divBody">
        <h1>Complaint Details</h1>
    <asp:Label ID="detailslbl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="deletebtn" runat="server" Text="Delete Complaint" OnClick="deletebtn_Click" />
    </div>
</asp:Content>
