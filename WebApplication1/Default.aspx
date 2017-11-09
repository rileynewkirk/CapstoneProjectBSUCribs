<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>BSU Cribs Calendar</h1>

        <asp:Calendar ID="Calendar1" runat="server" Width="1132px" Height="457px"></asp:Calendar>
        <br />
        <div class="row">
            <div class="col-md-4">

                <h3>&nbsp;Showings</h3>

                <asp:GridView ID="GVShowing" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    AutoGenerateColumns="false" Width="1021px" >

                    <AlternatingRowStyle BackColor="#CCCCCC" />

                    <EditRowStyle Wrap="True"></EditRowStyle>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                </asp:GridView>        
                <br />
                
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" Text="Edit" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                
            </div>
        </div>
    </div>


</asp:Content>
