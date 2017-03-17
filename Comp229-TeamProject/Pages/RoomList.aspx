<%@ Page Title="Game List" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="Comp229_TeamProject.Pages.GameList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Room List</h1>
    <div class ="divBody small">
        <p>
            <asp:TextBox ID="searchbox" runat="server" Width="250px"></asp:TextBox>
           
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="gamelistsql" Width="400px" AllowPaging="True" DataKeyNames="RoomID">
                    <Columns>
                         <asp:HyperLinkField DataNavigateUrlFields="RoomID" DataNavigateUrlFormatString="RoomPage.aspx?RoomID={0}" DataTextField="RoomID" HeaderText="RoomID" NavigateUrl="~/Pages/RoomPage.aspx" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="gamelistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                    SelectCommand="SELECT [RoomID], [Description] FROM [Rooms] ORDER BY [RoomID]" OnSelecting="gamelistsql_Selecting">

                </asp:SqlDataSource>
        </p>
  </div>
    
   


    
    </asp:Content>
