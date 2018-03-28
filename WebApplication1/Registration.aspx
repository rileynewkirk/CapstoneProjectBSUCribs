<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Registration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Users</title>
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

<body style="background: url('backgrounds/road.jpeg')no-repeat center fixed;  background-size: cover;">

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
                    <a class="navbar-brand">
                        <h1>
                            <img src="Icons/logo.jpg" alt="logo" /></h1>
                    </a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="scroll"><a href="Calendar.aspx">Calendar</a></li>
                        <li class="scroll active"><a href="Registration.aspx">Users</a></li>
                        <li class="scroll"><a href="MassText.aspx">Mass Text</a></li>
                        <li class="scroll dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">Properties
                                <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="ViewProperties.aspx">View All Properties</a></li>
                                <li><a href="EditHousingList.aspx">Edit Housing List</a></li>
                            </ul>
                        </li>                  
                        <li class="scroll"><a href="Login.aspx">Log out</a></li>

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
    <div class="container well" style="text-align: center; border-radius: 15px;">
        <form id="form1" runat="server" class="form-horizontal">

            <h4>All Users</h4>
            <br />

            <div class="col-lg-12" style="background-color: white; border-radius: 15px;">

                <div class="row">
                    <div class="col-lg-12">
                        <div class="main-box clearfix">
                            <div class="table-responsive" id="userTable">
                                <table class="table user-list table-hover">
                                    <thead>
                                        <tr>
                                            <th>&nbsp;</th>
                                            <th class="text-center"><span>UserName</span></th>
                                            <th style="text-indent: 60px;"><span>Name</span></th>

                                            <th class="text-center"><span>User Type</span></th>
                                            <th class="text-center"><span>Email</span></th>
                                            <th class="text-center"><span>Phone Number</span></th>
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

            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" href="#collapse1">Register A User</a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="LabelFName" runat="server" Text="First Name" CssClass="control-label  col-sm-4" for="tbFirstName"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="PersonalInfoGroup" ControlToValidate="tbFirstName" ErrorMessage="First Name is required."></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbLastName" ErrorMessage="Last Name is Required"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbUsername" ErrorMessage="User Name is Required"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbEmail" ErrorMessage="You must enter a vaild email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <br />
                                </div>
                            </div>
                            <!-- close Email-->


                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="Password" CssClass="control-label col-sm-4" for="tbPassword"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword" ErrorMessage="Use at least 6 characters without special characters" ValidationExpression="[a-zA-Z0-9]{6,}"></asp:RegularExpressionValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPassword2" ErrorMessage="Confirm Password is Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="PersonalInfoGroup" ControlToCompare="tbPassword" ControlToValidate="tbPassword2" ErrorMessage="The passwords must be the same"></asp:CompareValidator>
                                    <br />
                                </div>
                            </div>
                            <!-- close Confirm Password-->


                            <div class="form-group">
                                <asp:Label ID="Label8" runat="server" Text="Phone Number" CssClass="control-label col-sm-4" for="tbPhoneNumber"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="PersonalInfoGroup" runat="server" ControlToValidate="tbPhoneNumber" ErrorMessage="A phone number is Required"></asp:RequiredFieldValidator>
                                    <br />
                                </div>
                            </div>
                            <!-- close phone number-->

                            <div class="form-group">
                                <div id="submitButtons" class="col-sm-3 col-sm-offset-3">
                                    <asp:Button class="btn btn-primary" ID="Button1" CausesValidation="true" ValidationGroup="PersonalInfoGroup" runat="server" Text="Submit" OnClick="addUser" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button class="btn btn-warning" ID="Button2" runat="server" Text="Clear" OnClick="clear" />
                                    <br />
                                </div>
                            </div>
                            <asp:Label for="submitButtons" CssClass="control-label col-sm-4" ID="lblResponse" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />


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
