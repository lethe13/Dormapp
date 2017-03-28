<%@ Page Title="Profile" MasterPageFile="../Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Comp229_TeamProject.Pages.Profile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="divBody">
        <asp:Image runat="server" ID="profileImage"/>
        <asp:Label runat="server" ID="profileName"></asp:Label>
            
        </div>
        
            
        <div class="divBody halfSize left">
            <p>First Name:<asp:Label runat="server" ID="Fnamelbl"></asp:Label></p>
            <p>Last Name:<asp:Label runat="server" ID="Lnamelbl"></asp:Label></p>
            <p>Room:<asp:Label runat="server" ID="roomlbl">Not In a Room</asp:Label></p>
           
      
        </div>

     
      
        <div ID="editbtndiv" runat="server" class ="divBody" visible="false">
            <p> <asp:Button ID="editbtn" runat="server" Text="Edit Profile" OnClick="editbtn_Click" Width="109px" /></p>
            <p> 
                <asp:Button ID="paybtn" runat="server" OnClick="paybtn_Click" Text="Pay Bill" Width="109px" />
            </p>
            <p> 
                <asp:Button ID="leavebtn" runat="server" OnClick="leavebtn_Click" Text="Leave Room" Width="109px" />
            </p>
            </div>
           <br />
     <br />
         <br />
            <div ID="editdiv" runat="server" class ="divBody" visible="false">
                <p>First Name:<asp:TextBox ID="Fnamebx" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fnamereq" runat="server" Display="Dynamic" ControlToValidate="fnamebx" ErrorMessage="First name required"></asp:RequiredFieldValidator>
                </p>
                <p>Last Name:<asp:TextBox ID="Lnamebx" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="lnamereq" runat="server" Display="Dynamic" ControlToValidate="lnamebx" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator>
                </p>

                <p> <asp:Button ID="submitbtn" runat="server" Text="Submit" OnClick="submitbtn_Click" /></p>
            </div>
                    <div ID="Fdeskdiv" runat="server" class ="divBody" visible="false">
                        <asp:Button ID="Evictdiv" runat="server" Text="Evict" OnClick="Evictdiv_Click" />
            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete Student" />
            </div>
        


    </div>
    </asp:Content>
