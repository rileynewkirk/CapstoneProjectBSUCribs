<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMessage.aspx.cs" Inherits="WebApplication1.EditMessage" %>

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
        
        table, th, td{ border:none; padding:5px;
        }tr:hover {background-color: #f5f5f5;}
         table{position:center;}
    </style>
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
                        <li class="scroll"><a href="Calendar.aspx">Calendar</a></li>
                        <li class="scroll"><a href="Login.aspx">Login</a></li>
                        <li class="scroll"><a href="Registration.aspx">Register</a></li>
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
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="Labelnum" runat="server" Text="Label" Font-Size="Larger" Font-Bold="True"></asp:Label>
    </div>
    <br />
    <br />
    <form id="form1"  runat="server">
        <div runat ="server" class="col-sm-offset-2 col-sm-8" id="test"></div>

        <br />
        <br />

          <div class="row" style="padding-top:5px;">
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
                        <asp:Button class="btn btn-block btn-success" ID="btnSend" runat="server" Text="Send" OnClientClick = "return confirm('Are you sure you want to send this?')" Onclick="btnSend_Click"/>
                        </div>
                </div>
        <br />
        <br />

                       <div class="row">    
                    <div class="col-sm-4 col-sm-offset-4">
                        <asp:Button class="btn btn-block btn-danger" ID="Buttondel" runat="server" Text="Delete Whole Thread" OnClientClick = "return confirm('Are you sure you want to delete this?')" Onclick="Buttondel_Click"/>
                        </div>
                </div>
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
