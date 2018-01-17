<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditHousingList.aspx.cs" Inherits="WebApplication1.EditHousingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Edit Housing And Tenant Info</title>
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
                        <li class="scroll"><a href="Login.aspx">Login</a></li>
                        <li class="scroll"><a href="Registration.aspx">Users</a></li>
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
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Address" CssClass="control-label col-sm-1 col-sm-offset-1"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="AddressDropDownList" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="AddressDropDownList_TextChanged"></asp:DropDownList>
                </div>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="main-box clearfix col-sm-offset-1 col-sm-7">
                <div class="table-responsive table-hover" id="userTable">
                    <asp:Table ID="Table1" class="table user-list" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Text="First Name:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="Last Name:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="Mobile:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text=""></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>

                </div>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="Button1" class="col-sm-offset-1 col-sm-2" runat="server" Text="Update" OnClientClick="return confirm('Are you sure you want to update ?')" BackColor="#CFE3C4" />
        </div>
        <br />
        <div class="row">
            <asp:Button ID="Button2" CssClass="col-sm-offset-1 col-sm-2" runat="server" Text="Remove This Listing" OnClientClick="return confirm('Are you sure you want to delete this house from the list ?')" BackColor="#FFD7D7" />
        </div>
        <br />
        <hr />
        <br />

        <div class="row">
            <h5 class="col-sm-offset-1">Create new listing:</h5>
        </div>
        <div class="row">
            <asp:TextBox class="col-sm-offset-1 col-sm-2" ID="tbNumofRes" runat="server" TextMode="Number" Placeholder="Enter number of residents here:" AutoPostBack="true" OnTextChanged="tbNumofRes_TextChanged"></asp:TextBox>
        </div>
        <div class="row">
            <div class="col-sm-offset-1" runat="server" id="newListing">
            </div>
        </div>


        <br />
        <hr />
        <br />
        <div class="row">
            <div class="col-sm-offset-1">
                <h5 style="color: #FF3300; font-weight: bolder">This will replace all previous entries</h5>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Button Text="Upload" OnClick="Upload" runat="server" OnClientClick="return confirm('Are you sure you want to upload? This action will delete all of the previous listings!')" />
            </div>
        </div>



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
