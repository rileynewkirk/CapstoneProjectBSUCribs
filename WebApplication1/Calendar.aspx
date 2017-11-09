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

        <asp:ListBox ID="ListBox1" runat="server" Width="533px"></asp:ListBox>

         <asp:Button ID="Button1" runat="server" Height="74px" Text="Button" Width="68px" />

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
