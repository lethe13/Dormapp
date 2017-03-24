<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FdeskStudentInfo.aspx.cs" Inherits="Comp229_TeamProject.Pages.FdeskStudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1>Current Student Info</h1>
    <p>Student:<asp:Label ID="fnamelbl" runat="server" Text="Label"></asp:Label> &nbsp;<asp:Label ID="lnamelbl" runat="server" Text="Label"></asp:Label></p>
    <p>Username:<asp:Label ID="profilename" runat="server" Text="Label"></asp:Label></p>
    <h1>Change Student Info</h1>
    <p>First Name:<asp:TextBox ID="fnamebx" runat="server" Width="142px"></asp:TextBox></p>
    <p>Last Name:<asp:TextBox ID="lnamebx" runat="server" Width="145px"></asp:TextBox></p>
    <p>Username:<asp:TextBox ID="usernamebx" runat="server" Width="146px"></asp:TextBox></p>
    <p>Password:<asp:TextBox ID="passbx" runat="server" Width="151px"></asp:TextBox></p>
    <asp:Button ID="Updatebx" runat="server" Text="Update" OnClick="Updatebx_Click" />
    <br />
    <asp:Label ID="WarningLbl" runat="server"></asp:Label>
</asp:Content>
