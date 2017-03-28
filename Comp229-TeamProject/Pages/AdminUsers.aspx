<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="Comp229_TeamProject.Pages.AdminUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divBody">
       
     <p><asp:TextBox ID="searchbx" runat="server"></asp:TextBox><asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" /></p>      
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="userlistsql" Width="265px" AllowPaging="True" DataKeyNames="FdeskID">
            <Columns>
                 <asp:HyperLinkField DataNavigateUrlFields="FdeskID" DataNavigateUrlFormatString="AdminModFdesk.aspx?Username={0}" DataTextField="FdeskID" HeaderText="Employees" NavigateUrl="~/Pages/AdminModFdesk.aspx" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="userlistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                                        SelectCommand="SELECT [FdeskID] FROM [Fdesk] WHERE ([FdeskID] LIKE '%' + @Username + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="searchbx" Name="Username" PropertyName="Text" Type="String" DefaultValue="%" />
            </SelectParameters>
    </asp:SqlDataSource>
        
        </div>
</asp:Content>
