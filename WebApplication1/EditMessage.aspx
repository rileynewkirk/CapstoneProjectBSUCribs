﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMessage.aspx.cs" Inherits="WebApplication1.EditMessage" %>
<%@ OutputCache CacheProfile="CacheWeek"%>
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

    <style>
        table, th, td {
            border: none;
            padding: 5px;
            text-align: center;
        }

        tr:hover {
            background-color: #f5f5f5;
        }

        table {
            position: center;
        }
    </style>
</head>

<body style="background: url('backgrounds/southRoad.jpeg')no-repeat center fixed; background-size: cover;">

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
                        <li class="scroll" id="navADD" runat="server"></li>
                        <li class="scroll active"><a href="MassText.aspx">Mass Text</a></li>
                        <li class="scroll dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">Properties
                                <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="ViewProperties.aspx">View All Properties</a></li>
                                <li id="editADD" runat="server"></li>
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
    <form id="form1" runat="server">
        <div class="container" style="border-radius: 15px; background-color: #f9f9f9">
            <br />
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="Labelnum" runat="server" Text="Label" Font-Size="Larger" Font-Bold="True"></asp:Label>
            </div>
            <br />
            <br />
            
                <div runat="server" class="col-sm-offset-2 col-sm-8" id="Div1"></div>
           
            <br />
           
                <div runat="server" class="col-sm-offset-2 col-sm-8" id="test"></div>
           
            <br />
            <br />

            <div class="row" style="padding-top: 5px;">
                <asp:Label ID="Label6" runat="server" Text="Message" CssClass="control-label col-sm-1 col-sm-offset-3" for="tbMessage"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="tbMessage" Placeholder="Send to all numbers listed above:" TextMode="MultiLine" runat="server" CssClass="form-control" Rows="10" Columns="10"></asp:TextBox>
                </div>
                <br />
            </div>
            <!-- close Message-->
            <br />
            <div class="row">
                <div id="submitButtons" class="col-sm-4 col-sm-offset-4">
                    <asp:Button class="btn btn-block btn-success" ID="btnSend" runat="server" Text="Send" OnClientClick="return confirm('Are you sure you want to send this?');" OnClick="btnSend_Click" />
                </div>
            </div>
            <br />
            <br />

            <div class="row">
                <div class="col-sm-4 col-sm-offset-4" style="padding-top: 5px">
                    <asp:Button class="btn btn-block btn-danger" ID="Buttondel" runat="server" Text="Delete Whole Thread" OnClientClick="return confirm('Are you sure you want to delete this?')" OnClick="Buttondel_Click" />
                </div>
            </div>
            <br />

        </div>

    </form>

    



    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/smoothscroll.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.min.js"></script>
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="js/jquery.parallax.js"></script>
    <script type="text/javascript" src="js/main.js"></script>

</script>
</body>
</html>
