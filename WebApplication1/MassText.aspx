<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MassText.aspx.cs" Inherits="WebApplication1.MassText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Mass Text</title>
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
                    <a class="navbar-brand">
                        <h1>
                            <img src="images/logo.png" alt="logo" /></h1>
                    </a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="scroll"><a href="Calendar.aspx">Calendar</a></li>
                        <li class="scroll"><a href="Registration.aspx">Users</a></li>
                        <li class="scroll active"><a href="MassText.aspx">Mass Text</a></li>
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
    <div class="container">
        <div class="container" style="">

            <h1 style="text-align:center; padding-right:15px;">Mass Text</h1>
            <br />


            <form id="contactForm" runat="server" class="form-horizontal">

            <div class="row">
            <div class="col-lg-12">
                <div class="main-box clearfix">
                    <div class="table-responsive table-hover" id="userTable">
                        <table class="table user-list">
                            <thead>
                                <tr>
                                    <th><span>Address</span></th>                          
                                    <th><span>Message</span></th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody id="messageList" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
                <br />
                <br />
                 <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Address" CssClass="control-label col-sm-4" for="tbNumber"></asp:Label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="AddressDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>


                    </div>
                </div>
                <!-- close Name-->

                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Message" CssClass="control-label col-sm-4" for="tbMessage"></asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="tbMessage" TextMode="MultiLine" runat="server" CssClass="form-control" Rows="10" Columns="10"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbMessage" ErrorMessage="Message is Required"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                </div>
                <!-- close Message-->


                <div class="form-group">
                    <div id="submitButtons" class="col-sm-4 col-sm-offset-4">
                        <asp:Button class="btn btn-block btn-success" ID="btnSend" runat="server" Text="Send" OnClientClick = "return confirm('Are you sure you want to send this?')" OnClick="btnSend_Click"/>
                        </div>
                </div>
                <asp:Label for="submitButtons" CssClass="control-label col-sm-4" ID="lblResponse" runat="server" Text=""></asp:Label>
                <br />
                <div class="row" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="Label1" CssClass="well well-sm" runat="server"><a href="ViewProperties.aspx">View All Properties</a></asp:Label>
                </div>
                <br />
                                <br />

                <div class="row" style="margin-left: auto; margin-right: auto; text-align: center;">

                <asp:Label ID="Label2" CssClass="well well-sm"  runat="server"><a href="EditHousingList.aspx">Edit Properties</a></asp:Label>
                </div>
                                <br />

            </form>
        </div>
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
