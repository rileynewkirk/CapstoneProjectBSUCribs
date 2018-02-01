<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" %>

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

<body style="background-color: whitesmoke;" >


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
        <br />

    <div class="container" style="text-align: center">
    <form id="form1" runat="server">
        <div class="row">
        <div class="col-sm-offset-0">
            
        <asp:Calendar ID="Calendar1" runat="server" Width="1400px" Height="500px" FirstDayOfWeek="Sunday" BackColor="white" BorderColor="mediumseagreen" BorderWidth="2px" CellPadding="1" DayNameFormat="Full" Font-Names="Verdana" Font-Size="16pt" ForeColor="mediumseagreen" OnSelectionChanged="Calendar1_SelectionChanged">
            <DayHeaderStyle HorizontalAlign="Center"  />
            <NextPrevStyle Font-Size="12pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="silver" />
            <SelectedDayStyle BackColor="#99CCFF" />
            <SelectorStyle BackColor="#99CCFF" />
            <TitleStyle Font-Bold="True" HorizontalAlign="Center" BackColor="mediumSeaGreen" ForeColor="white" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        </asp:Calendar>
    </div>

        </div>
         <br /><br />
        <h4 class="text-left"> Showings</h4>
        <asp:Label  ID="displayDateLabel" runat="server"  Font-Size="Large"></asp:Label>

        <br />
                   
        <div class="col-sm-12" style="background-color: white">
        <div class="row">
                <div class="main-box clearfix">
                    <div class="table-responsive table-hover" id="showingTable">
                        
                        <table class="table showing-list">
                            <thead>
                                <tr>

                                    <th class="text-center"><span>Leasing Agent</span></th>                                    
                                    <th class="text-center"><span>Client</span></th>
                                    <th class="text-center"><span>Address</span></th>
                                    <th class="text-center" aria-sort="descending"><span>Showing Date</span></th>
                                    <th class="text-center"><span></span></th>
                                    <th class="text-center"><span></span></th>
                                   
                                </tr>
                            </thead>
                            <tbody id="showingList" runat="server">
                                
                            </tbody>
                        </table>
                    
                    
                    </div>
                </div>
        </div>
        </div>

        <br />
        <br />


       

        <br /><br />
         <br /><br />

        <div>
         <asp:Button class="btn btn-primary" ID="CreateShowingBtn" runat="server" Text="Create Showing"  OnClick="goToCreateShowing"/>
        </div>
        <br />
       
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




