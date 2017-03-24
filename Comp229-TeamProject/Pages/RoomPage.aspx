<%@ Page Title="GamePage" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="RoomPage.aspx.cs" Inherits="Comp229_TeamProject.Pages.GamePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divBody heightGamePages">
    <asp:Button CssClass="btn float" runat="server" ID="joinroomBtn" Text="+" OnClick="joinroomnBtn_Click"/>
    <h1><asp:Label runat="server" ID="roomnameLbl"></asp:Label> </h1>
        <p>Max Occupants:<asp:Label ID="maxlbl" runat="server" Text="Label"></asp:Label>
        </p>
  
        <br />
    Description: <asp:Label runat="server" ID="descLbl"></asp:Label>
        <br />
        <br />
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="gamelistsql" Width="198px" AllowPaging="True">
                    <Columns>
                 <asp:HyperLinkField DataNavigateUrlFields="Username" DataNavigateUrlFormatString="Profile.aspx?Username={0}" DataTextField="UserName" HeaderText="UserName" NavigateUrl="~/Pages/Profile.aspx" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="gamelistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                    SelectCommand="SELECT Students.Username FROM roomline INNER JOIN Students ON roomline.studentID = Students.StudentID WHERE (roomline.roomID = @roomID)" OnSelecting="gamelistsql_Selecting">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="roomID" QueryStringField="RoomID" Type="String" />
                    </SelectParameters>

                </asp:SqlDataSource>
        </div>
  
    </asp:Content>
