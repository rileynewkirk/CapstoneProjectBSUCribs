<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditShowing.aspx.cs" Inherits="WebApplication1.EditShowing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Edit Showing Page" />
    <meta name="keywords" content="Edit, Showing" /> 
    <meta name="author" content="Jacob Little, Nathan Barr, Riley Newkirk, Nicole Porten" />
    <title>Edit Showing</title>
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
            <h2>Edit Showing</h2>
            <br />



            <div class="form-group">
                <asp:Label ID="LabelDate" runat="server" Text="Date" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium" ></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="DatePicker" runat="server" CssClass="form-control" TextMode="Date"  style="margin-left: auto; margin-right: auto; width:100%"></asp:TextBox>
                     <br />
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="DateValidator" runat="server" validationgroup="showingInformationGroup" ControlToValidate="DatePicker" ErrorMessage="Date is required."></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close Date-->


            <div class="form-group">
                <asp:Label ID="LabelTime" runat="server" Text="Time" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium" ></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TimePicker" runat="server" CssClass="form-control" TextMode="Time"  style="margin-left: auto; margin-right: auto; width:100%"></asp:TextBox>
                     <br />
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="TimeValidator1" runat="server" validationgroup="ShowingInformationGroup" ControlToValidate="TimePicker" ErrorMessage="Time is required."></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <!-- close Time-->


            <div class="form-group">
                <div class="AddressSelector">
                    <asp:Label ID="LabelAddress" runat="server" Text="Address" CssClass="control-label col-sm-4" text-Bold="true" Font-Size="Medium" ></asp:Label>
                    <div class="col-sm-4">
                     <asp:DropDownList ID="AddressDropDownList" runat="server" cssClass="form-control"></asp:DropDownList>
                         </div>
                 </div>
            </div>
            <!-- close Select Address-->
            
           <div class="form-group">
           <div > 
              <asp:Button class="btn btn-primary" ID="editShowingBtn" runat="server" Text="Edit Showing" backColor ="MediumSeaGreen" OnClick="editShowingBtn_Click" />
           </div>
               <br />
            <div >
                <asp:Button class="btn btn-warning" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click"  />
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