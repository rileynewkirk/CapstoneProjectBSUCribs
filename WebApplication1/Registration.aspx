﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Registration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Health App for breast cancer survivors" />
    <meta name="keywords" content="Breast, Cancer, Awareness, Health, Black, Women, African, American, beyondbca" />
    <meta name="author" content="Nathan Barr & Marcus Berry" />
    <title>Registration</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <link href="css/prettyPhoto.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/background.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]-->
    <link rel="shortcut icon" href="images/ico/favicon.png" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png" />
    <link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png" />

</head>

<body>

    <div class="preloader">
        <div class="preloder-wrap">
            <div class="preloder-inner">
                <div class="ball"></div>
                <div class="ball"></div>
                <div class="ball"></div>
                <div class="ball"></div>
                <div class="ball"></div>
                <div class="ball"></div>
                <div class="ball"></div>
            </div>
        </div>
    </div>
    <!--/.preloader-->

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
                        <li class="scroll"><a href="Homepage.aspx">Home</a></li>
                        <li class="scroll"><a href="Login.aspx">Login</a></li>
                        <li class="scroll active"><a href="Registration.aspx">Register</a></li>
                        <li class="scroll"><a href="contact.aspx">Contact</a></li>
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
    <br />
    <div class="container" style="text-align: center">
        <form id="form1" runat="server" class="form-horizontal">
            <h2>Register A User</h2>
            <br />
            <div class="form-group">
                <asp:Label ID="LabelFName" runat="server" Text="First Name" CssClass="control-label  col-sm-4" for="tbFirstName"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" validationgroup="PersonalInfoGroup" ControlToValidate="tbFirstName" ErrorMessage="First Name is required."></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close FName-->

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Last Name" CssClass="control-label col-sm-4" for="tbLastName"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbLastName" ErrorMessage="Last Name is Required"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close LName-->


            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="User Name" CssClass="control-label col-sm-4" for="tbUsername"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbUsername" ErrorMessage="User Name is Required"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close UserName-->


            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Email" CssClass="control-label col-sm-4" for="tbEmail"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbEmail" ErrorMessage="You must enter a vaild email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>
            <!-- close Email-->


            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Password"  CssClass="control-label col-sm-4" for="tbPassword"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword" ErrorMessage="Use at least 6 characters without special characters" ValidationExpression="[a-zA-Z0-9]{6,}"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>
            <!-- close Password-->


            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Confirm Password" CssClass="control-label col-sm-4" for="tbPassword2"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword2" ErrorMessage="Confirm Password is Required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" validationgroup="PersonalInfoGroup" ControlToCompare="tbPassword" ControlToValidate="tbPassword2" ErrorMessage="The passwords must be the same"></asp:CompareValidator>
                    <br />
                </div>
            </div>
            <!-- close Confirm Password-->


            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Phone Number" CssClass="control-label col-sm-4" for="tbPhoneNumber"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" validationgroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPhoneNumber" ErrorMessage="A phone number is Required"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close Age-->

            <div class="form-group">
                <div id="submitButtons" class="col-sm-3 col-sm-offset-3">
                    <asp:Button class="btn btn-primary" ID="Button1" causesvalidation="true" validationgroup="PersonalInfoGroup" runat="server" Text="Submit" OnClick="addUser" />
                </div>
                <div class="col-sm-3">
                    <asp:Button class="btn btn-warning" ID="Button2" runat="server" Text="Clear" OnClick="clear" />
                    <br />
                </div>
            </div>
            <asp:Label for="submitButtons" CssClass="control-label col-sm-4" ID="lblResponse" runat="server" Text=""></asp:Label>
                     <br />
             <div class="row">
            <h4 class="col-sm-4 col-sm-offset-4">Remove a User</h4>
                 </div>
                     <br />
            <div class="row">
            <asp:Label ID="Label1" runat="server" Text="UserName" CssClass="control-label col-sm-4" for="tbRemove"></asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="tbRemove" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            </div>
            <br />
             <div class="row">
            <div id="removeButtons" class="col-sm-4 col-sm-offset-4">
                <asp:Button class="btn btn-primary" ID="removeButton" runat="server" Text="Remove" OnClick="removeButton_Click" />
            </div>
                  </div>
                     <br />
            <h4>All Users</h4>
                     <br />
          
                <asp:GridView ID="Gridview1" CssClass="col-sm-pull-2"  style="height: 600px; overflow-x: hidden; overflow-y: scroll" runat="server" AlternatingRowStyle-BackColor="#ECEBED" RowStyle-BorderWidth="5px" HeaderStyle-BorderStyle="NotSet" GridLines="Horizontal" RowStyle-BackColor="White" HeaderStyle-BackColor="White" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="5" CellSpacing="5" AllowPaging="False"></asp:GridView>
          
             <div class="col-lg-12" style="background-color: white">

        <div class="row">
            <div class="col-lg-12">
                <div class="main-box clearfix">
                    <div class="table-responsive table-hover" id="userTable">
                        <table class="table user-list">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th style="text-indent: 60px;"><span>Name</span></th>
                          
                                    <th class="text-center"><span>User Type</span></th>
                                    <th><span>Email</span></th>
                                    <th><span>Phone Number</span></th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody id="userList" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>



    </div>
        </form>
    </div>

    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/smoothscroll.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.min.js"></script>
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="js/jquery.parallax.js"></script>
    <script type="text/javascript" src="js/main.js"></script>

</body>
</html>
