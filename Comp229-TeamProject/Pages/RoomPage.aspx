<%@ Page Title="GamePage" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="RoomPage.aspx.cs" Inherits="Comp229_TeamProject.Pages.GamePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divBody heightGamePages">
    <asp:Button CssClass="btn float" runat="server" ID="joinroomBtn" Text="+" OnClick="joinroomnBtn_Click"/>
    <div class="gameInformation">
    <h1><asp:Label runat="server" ID="roomnameLbl"></asp:Label> </h1><br />
    Description: <asp:Label runat="server" ID="descLbl"></asp:Label>
        <br />
        <br />
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="gamelistsql" Width="400px" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="studentID" HeaderText="studentID" SortExpression="studentID" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="gamelistsql" runat="server"
                     ConnectionString="<%$ ConnectionStrings:DormsConnectionString %>" 
                    SelectCommand="SELECT [studentID] FROM [roomline] WHERE ([roomID] = @roomID)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="roomID" QueryStringField="RoomID" Type="String" />
                    </SelectParameters>

                </asp:SqlDataSource>
        </div>
    </div>
    </asp:Content>
