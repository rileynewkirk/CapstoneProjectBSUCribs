﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProperties.aspx.cs" Inherits="WebApplication1.ViewProperties" %>
<%@ OutputCache CacheProfile="CacheWeek"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>View Properties</title>
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
                        <li class="scroll"><a href="MassText.aspx">Mass Text</a></li>
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
        <div class="container" style="background-color:white; border-radius:20px;">
        <div class="col-sm-8 col-sm-offset-2" style="height:1000px; overflow-y:scroll; overflow-x:hidden;">
                 
        <asp:GridView ID="GridView1" CssClass="table table-hover table-responsive " runat="server" ShowHeader="True" AlternatingRowStyle-BackColor="#E6E6E6" GridLines="None" style="width:100%; margin-left:15px" ></asp:GridView>



        </div>

        </div>
            <br />
    <br />
    <br />
    <br />

    </form>
        <script type="text/javascript" src="js/jquery.js"></script> 
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/smoothscroll.js"></script> 
	<script type="text/javascript" src="js/jquery.isotope.min.js"></script>
	<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script> 
	<script type="text/javascript" src="js/jquery.parallax.js"></script> 
	<script type="text/javascript" src="js/main.js"></script> 

</body>
</html>
