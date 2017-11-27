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
        <br />


    <form id="form1" runat="server">
        <div class="row">
        <div class="col-sm-offset-2">
            
        <asp:Calendar ID="Calendar1" runat="server" Width="1026px" Height="306px" FirstDayOfWeek="Sunday" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Calendar1_SelectionChanged">
            <DayHeaderStyle HorizontalAlign="Center" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="Silver" />
            <SelectedDayStyle BackColor="#99CCFF" />
            <SelectorStyle BackColor="#99CCFF" />
            <TitleStyle Font-Bold="True" HorizontalAlign="Center" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        </asp:Calendar>
</div>

        </div>
         <br /><br />
        <h4 class="col-sm-offset-5">Showings</h4>
        <br />
                   
        <div class="col-sm-12" style="background-color: white">
        <div class="row">
            <div class="col-sm-8 col-sm-offset-2">
                <div class="main-box clearfix">
                    <div class="table-responsive table-hover" id="showingTable">
                        <table class="table user-list">
                            <thead>
                                <tr>
<!--
                                    <th>&nbsp;</th>
-->

                                    <th class="text-center"><span>Leasing Agent</span></th>                                    
                                    <th class="text-center"><span>Client</span></th>
                                    <th class="text-center"><span>Address</span></th>
                                    <th class="text-center"><span>Showing Date</span></th>
                                    <th class="text-center"><span></span></th>
                                    <th class="text-center"><span></span></th>
                                    <!-- 
                                    <th class="text-center"><span>Date Created</span></th>
                                    <th style="text-indent: 60px;"><span>Showing Date</span></th>
                                    -->                        
                                </tr>
                            </thead>
                            <tbody id="showingList" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <br />
        <br />

        <asp:Label CssClass="col-sm-offset-4" ID="Label1" runat="server" Text="Label" Font-Size="Large"></asp:Label>

        <br /><br />

        <asp:ListBox CssClass="col-sm-offset-4" ID="ListBox1" runat="server" Width="533px">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>

         <br /><br />

<<<<<<< HEAD

         <asp:Button ID="Button1" runat="server" Height="74px" Text="Button" Width="68px" OnClick="goToCreateShowing" />

         <asp:Button CssClass="col-sm-offset-4" ID="Button2" runat="server" Height="74px" Text="Button" Width="68px" OnClick="testFunction" />

=======
         <asp:Button ID="Button" runat="server" Height="74px" Text="Button" Width="68px" OnClick="goToCreateShowing" />
>>>>>>> e2c6ae0de96a9607a417762e1a0a6c9b592030df

        <br />
            <br />
        <asp:TextBox CssClass="col-sm-offset-4" ID="clientTxtBx" runat="server" Text =" client"></asp:TextBox>
        <br />
            <br />
        <asp:TextBox CssClass="col-sm-offset-4" ID="dateTxtBx" runat="server" Text ="date"></asp:TextBox>
        <br />
            <br />
        <asp:TextBox CssClass="col-sm-offset-4" ID="propertyTxtBx" runat="server" Text ="property"></asp:TextBox>
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




