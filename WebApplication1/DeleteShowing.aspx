﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteShowing.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Calendar</title>
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
    <link rel="https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.js" />
    <link rel="https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.css" />

</head>

<body>


        <form id="form1" runat="server">


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
            <div class="navbar navbar-inverse navbar-fixed-top navopaq" style="height: auto" role="banner">
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
                        <ul class="nav navbar-nav navbar-right" runat="server" id="navbar">
                        <li class="scroll active"><a href="Calendar.aspx">Calendar</a></li>
                        <li class="scroll"><a href="Login.aspx">Login</a></li>
                        <li class="scroll"><a href="Registration.aspx">Register</a></li>
                        <li class="scroll"><a href="MassText.aspx">Mass Text</a></li>

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

    <div class="container" style="text-align: left">
        <h2>Are you sure you want to delete this showing?</h2>

         <div class="form-group" style="text-align:left">
                <div id="btns" class="col-sm-4 col-sm-offset-4">
                    <asp:Button class="btn btn-primary" ID="btnSubmit"  runat="server" Text="Delete" BackColor="Black" OnClick="btnDelete_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button class="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" BackColor="White" OnClick="btnCancel_Click" />                    
                    <br />

                </div>
            </div>
    </div>
            




    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/smoothscroll.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.min.js"></script>
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="js/jquery.parallax.js"></script>
    <script type="text/javascript" src="js/main.js"></script>


</form>