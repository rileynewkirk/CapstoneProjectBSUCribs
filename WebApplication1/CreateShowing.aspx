<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateShowing.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Create Showing Page" />
    <meta name="keywords" content="Create, Showing" /> 
    <meta name="author" content="Jacob Little, Nathan Barr, Riley Newkirk, Nicole Porten" />
    <title>Create Showing</title>
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

<body style="background: url('backgrounds/computer.jpeg')no-repeat center fixed; background-size: cover;">

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
                        <li class="scroll active"><a href="Calendar.aspx">Calendar</a></li>
                        <li class="scroll" id="navADD" runat="server"></li>
                        <li class="scroll"><a href="MassText.aspx">Mass Text</a></li>
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
    <div class="container well" style="text-align:center; border-radius: 15px;">
        <form id="form1" runat="server" class="form-horizontal">
            <h2>Create Showing</h2>
            <br />

            <div class="form-group">
                <asp:Label ID="LabelLeasingAgent" runat="server" Text="Leasing Agent" CssClass="control-label  col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="userNameLabel" runat="server" Text="Leasing Agent Name" CssClass="control-label  col-sm-4" ></asp:Label>
                </div>
                    <br />
            </div>
            <!-- close AgentName-->

            <div class="form-group">
                <asp:Label ID="LabelDate" runat="server" Text="Date" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="DatePicker" runat="server" style="margin-left: auto; margin-right: auto; width:100%" CssClass="form-control" TextMode="Date"></asp:TextBox>
                     <br />
                </div>
            </div>
            <!-- close Date-->

             <div class="form-group">
                <asp:Label ID="LabelClient" runat="server" Text="Client Name" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="clientTB" runat="server" CssClass="form-control"></asp:TextBox>
                     <br />
                </div>
            </div>
            <!-- close Client-->


            <div class="form-group">
                <asp:Label ID="LabelTime" runat="server" Text="Time" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TimePicker" runat="server" CssClass="form-control" style="margin-left: auto; margin-right: auto; width:100%" TextMode="Time"></asp:TextBox>
                     <br />
                </div>
            </div>
            <!-- close Time-->


            <div class="form-group">
                <div class="AddressSelector">
                    <asp:Label ID="LabelAddress" runat="server" Text="Address" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                    <div class="col-sm-4">
                     <asp:DropDownList ID="AddressDropDownList" runat="server" cssClass="form-control"></asp:DropDownList>
                         </div>
                     <div class="col-sm-1">
                     <asp:Button class="btn btn-warning" ID="addButton" runat="server" Text="Add" OnClick="AddToList" />
                          <br />
                        </div>
                 </div>
            </div>
            <!-- close Select Address-->

             <div class="form-group">
                <asp:Label ID="LabelHouses" runat="server" Text="List of Address" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium"></asp:Label>
                <div class="col-sm-4">
                     <asp:ListBox ID="ListOfHouses" runat="server" cssClass="form-control" ></asp:ListBox>
                     <br />
                </div>
            </div>
            <!-- close Housing List -->

           <div>
              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Create Showing" OnClick="createShowings" />

           </div>
            <br />
            <div>
              <asp:Button class="btn btn-warning" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click"  />

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
