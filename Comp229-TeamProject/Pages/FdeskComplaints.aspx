<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FdeskComplaints.aspx.cs" Inherits="Comp229_TeamProject.Pages.FdeskComplaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Complaints</h1>
    <div class ="divBody small">
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="userlistsql" Width="265px" AllowPaging="True" DataKeyNames="complaintID">
            <Columns>
                  <asp:HyperLinkField DataNavigateUrlFields="complaintID" DataNavigateUrlFormatString="ComplaintDetails.aspx?complaintID={0}" DataTextField="complaintID" HeaderText="Complaint ID" NavigateUrl="~/Pages/ComplaintDetails.aspx" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="userlistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                    SelectCommand="SELECT [complaintID] FROM [Complaints] ORDER BY [complaintID]"></asp:SqlDataSource>
    </p>
        </div>

    

</asp:Content>
