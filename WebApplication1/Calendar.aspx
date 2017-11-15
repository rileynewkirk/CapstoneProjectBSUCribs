<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Calendar ID="Calendar1" runat="server" Width="534px"></asp:Calendar>

         <br /><br />

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <br /><br />

        <asp:ListBox ID="ListBox1" runat="server" Width="533px">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>

         <br /><br />

         <asp:Button ID="Button1" runat="server" Height="74px" Text="Button" Width="68px" OnClick="Button1_Click" />

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
