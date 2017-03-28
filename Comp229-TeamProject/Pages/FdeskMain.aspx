<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FdeskMain.aspx.cs" Inherits="Comp229_TeamProject.Pages.FdeskMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="divBody">
     <p><asp:TextBox ID="searchbx" runat="server"></asp:TextBox><asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" /></p>      
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="userlistsql" Width="265px" AllowPaging="True">
            <Columns>
                 <asp:HyperLinkField DataNavigateUrlFields="Username" DataNavigateUrlFormatString="Profile.aspx?Username={0}" DataTextField="UserName" HeaderText="UserName" NavigateUrl="~/Pages/Profile.aspx" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="userlistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                    SelectCommand="SELECT [Username] FROM [Students] WHERE ([Username] LIKE '%' + @Username + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="searchbx" Name="Username" PropertyName="Text" Type="String" DefaultValue="%" />
            </SelectParameters>
    </asp:SqlDataSource>
       </div>
</asp:Content>
