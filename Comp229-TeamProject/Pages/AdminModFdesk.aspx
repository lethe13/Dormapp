<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminModFdesk.aspx.cs" Inherits="Dormapp.AdminModFdesk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divBody">
            <h1>Current Employee Info</h1>
    <p>First Name: <asp:Label ID="fnamelbl" runat="server" Text="Label"></asp:Label> &nbsp;</p>
            <p>Last Name: <asp:Label ID="lnamelbl" runat="server" Text="Label"></asp:Label></p>
    <p>Username:<asp:Label ID="profilename" runat="server" Text="Label"></asp:Label></p>
    <h1>Change Employee Info</h1>
    <p>First Name:<asp:TextBox ID="fnamebx" runat="server" Width="142px"></asp:TextBox></p>
    <p>Last Name:<asp:TextBox ID="lnamebx" runat="server" Width="145px"></asp:TextBox></p>
    <p>Password:<asp:TextBox ID="passbx" runat="server" Width="151px"></asp:TextBox></p>
    <asp:Button ID="Updatebx" runat="server" Text="Update" OnClick="Updatebx_Click" />
    <br />
    <asp:Label ID="WarningLbl" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="deletebtn" runat="server" OnClick="deletebtn_Click" Text="Delete Employee" />
        </div>
</asp:Content>
