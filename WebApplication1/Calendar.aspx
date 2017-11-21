
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .user-list {
            height: 32px;
            width: 863px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Calendar ID="Calendar1" runat="server" Width="1026px" Height="306px"></asp:Calendar>

         <br /><br />
        <h4>Showings</h4>
        <br />
                   
        <div class="col-lg-12" style="background-color: white">
        <div class="row">
            <div class="col-lg-12">
                <div class="main-box clearfix">
                    <div class="table-responsive table-hover" id="showingTable">
                        <table class="table user-list">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th class="text-center"><span>Leasing Agent</span></th>
                                    <th style="text-indent: 60px;"><span>Showing Date</span></th>
                          
                                    <th class="text-center"><span>Client</span></th>
                                    <th class="text-center"><span>Address</span></th>
                                    <th class="text-center"><span>Date Created</span></th>                                    
                                </tr>
                            </thead>
                            <tbody id="showingList" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
            
        <br /><br />

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <br /><br />

        <asp:ListBox ID="ListBox1" runat="server" Width="533px">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>

         <br /><br />

         <asp:Button ID="Button1" runat="server" Height="74px" Text="Button" Width="68px" OnClick="goToCreateShowing" />

        <br />
        <asp:TextBox ID="clientTxtBx" runat="server" Text =" client"></asp:TextBox>
        <br />
        <asp:TextBox ID="dateTxtBx" runat="server" Text ="date"></asp:TextBox>
        <br />
        <asp:TextBox ID="propertyTxtBx" runat="server" Text ="property"></asp:TextBox>
        <br />
    </form>
</body>
</html>




