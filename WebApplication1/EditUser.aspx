<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication1.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Edit User</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/adminUsers.css" rel="stylesheet" />

    <link href="css/prettyPhoto.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]-->
    <link rel="shortcut icon" href="images/ico/favicon.png" />

</head>
<body style="background-color: darkslategrey; color: white;">
    <header id="navigation">
        <div class="navbar navbar-inverse navbar-fixed-top" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="index.html">
                        <h1>
                            <img src="images/logo.png" alt="logo" /></h1>
                    </a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="scroll"><a href="Login.aspx">Login</a></li>
                        <li class="scroll"><a href="Registration.aspx">Registration</a></li>
                        <li class="scroll"><a href="Calendar.aspx">Calendar</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--/navbar-->
    </header>
    <!--/#navigation-->

    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="container" style="text-align: center">
        <h2>Edit User</h2>
        <h4 runat="server" id="nameTitle">Name</h4>
        <img src="#" class="img-responsive profile-thumbnail-edit" runat="server" id="profilePic" />
        <br />

        <form runat="server" id="editUser" class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblSubject" runat="server" Text="User Type" CssClass="control-label col-sm-4" for="ddlTypes"></asp:Label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlTypes" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Agent">Agent</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTypes" ErrorMessage="Subject is Required"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close Types-->

            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Phone Number" CssClass="control-label col-sm-4" for="tbPhoneNumber"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                </div>
                <br />
            </div>

            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Password" CssClass="control-label col-sm-4" for="tbPassword"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="passwordupdate" runat="server" ControlToValidate="tbPassword" ErrorMessage="Use at least 6 characters without special characters" ValidationExpression="[a-zA-Z0-9]{6,}"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Email" CssClass="control-label col-sm-4" for="tbEmail"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                </div>
                <br />
            </div>

             <div class="form-group">
                <div class="col-sm-4 col-sm-offset-4">
                    <asp:Button ID="Email" CssClass="btn btn-primary" BackColor="Green" runat="server" Text="Update" OnClick="updateInfo" />
                </div>
            </div>
            <br />
            <!-- close Email-->

            <div class="form-group">
                <div class="col-sm-4 col-sm-offset-4">
            <asp:Button ID="btnRemove" CssClass="btn btn-danger" runat="server" Text="Remove User" OnClientClick="return confirm('Are you sure you want to submit ?')"  OnClick="btnRemove_Click" />
                    </div>
                </div>
        </form>
    </div>

</body>
</html>
