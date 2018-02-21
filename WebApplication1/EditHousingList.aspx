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

<body style="background: url('backgrounds/southRoad.jpeg')no-repeat center fixed;  background-size: cover;">

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

    <header runat="server" id="navigation">
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
    <form id="form1" runat="server">
        <div  class="container well" style="border-radius: 15px; text-align:center;">
        <div class="row">
            <h3>Edit Current Listing:</h3>
        </div>
        <br />

        <div class="row">
            <div class="form-group" style="margin-left: auto; margin-right: auto; text-align: center;">
               
                <asp:Label ID="Label3" runat="server" Text="Address" CssClass="control-label"></asp:Label>

                    <asp:DropDownList ID="AddressDropDownList" CssClass="form-control" style="margin-left: auto; margin-right: auto; text-align: center; width:25%;" runat="server" AutoPostBack="true" OnTextChanged="AddressDropDownList_TextChanged"></asp:DropDownList>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="main-box clearfix" style="margin-left: auto; margin-right: auto; text-align: center; width:60%">
                <div class="table-responsive table-hover" id="userTable">
                    <asp:Table ID="Table1" class="table user-list table-hover" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Text="First Name:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="Last Name:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="Mobile:"></asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                <asp:LinkButton ID="LinkButton1" OnClick="AddRow" runat="server" ToolTip="Add another tenant to this address"><span class="glyphicon glyphicon-plus" style="font-size:larger; padding-left:23px"></span></asp:LinkButton></></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow Visible="false" ID="row1">
                            <asp:TableCell>
                                <asp:TextBox ID="fn1" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln1" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m1" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn1" CssClass="btn btn-danger" CommandArgument="1" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row2">
                            <asp:TableCell>
                                <asp:TextBox ID="fn2" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln2" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m2" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn2" CssClass="btn btn-danger" CommandArgument="2" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row3">
                            <asp:TableCell>
                                <asp:TextBox ID="fn3" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln3" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m3" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn3" CssClass="btn btn-danger" CommandArgument="3" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row4">
                            <asp:TableCell>
                                <asp:TextBox ID="fn4" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln4" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m4" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn4" CssClass="btn btn-danger" CommandArgument="4" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row5">
                            <asp:TableCell>
                                <asp:TextBox ID="fn5" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln5" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m5" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn5" CssClass="btn btn-danger" CommandArgument="5" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row6">
                            <asp:TableCell>
                                <asp:TextBox ID="fn6" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln6" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m6" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn6" CssClass="btn btn-danger" CommandArgument="6" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row7">
                            <asp:TableCell>
                                <asp:TextBox ID="fn7" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln7" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m7" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn7" CssClass="btn btn-danger" CommandArgument="7" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row8">
                            <asp:TableCell>
                                <asp:TextBox ID="fn8" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln8" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m8" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn8" CssClass="btn btn-danger" CommandArgument="8" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row9">
                            <asp:TableCell>
                                <asp:TextBox ID="fn9" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln9" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m9" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn9" CssClass="btn btn-danger" CommandArgument="9" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="False" ID="row10">
                            <asp:TableCell>
                                <asp:TextBox ID="fn10" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln10" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m10" CssClass="form-control" Style="width: 75%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn10" CssClass="btn btn-danger" CommandArgument="10" OnClientClick="return confirm('Are you sure you want to delete this person ?')" OnClick="btnevent_Click" runat="server" Text="Delete" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="UpdateListing" style="margin-left: auto; margin-right: auto; text-align: center;" class="btn btn-success" runat="server" Text="Update" OnClientClick="return confirm('Are you sure you want to update ?')" OnClick="UpdateListing_Click" AutoPostback="false" />
        </div>
        <br />
        <div class="row">
            <asp:Button ID="DeleteListing" style="margin-left: auto; margin-right: auto; text-align: center;" CssClass="btn btn-danger" runat="server" Text="Remove This Listing" OnClientClick="return confirm('Are you sure you want to delete this house from the list ?')" OnClick="DeleteListing_Click" />
        </div>
        <br />
        <hr />
        <br />
        <div class="row">
            <h3>Add Listing:</h3>
        </div>
        <br />
        <div class="row">
            <div style="margin-left: auto; margin-right: auto; text-align: center; width:25%">
                <asp:TextBox class=" form-control" ID="tbNumofRes" runat="server" TextMode="Number" Placeholder="Enter number of residents here:" AutoPostBack="true" OnTextChanged="tbNumofRes_TextChanged" ValidateRequestMode="Inherit"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div style="margin-left: auto; margin-right: auto; text-align: center; width:25%">
                <asp:TextBox class="form-control" ID="tbNewAddress" runat="server" Visible="false" Placeholder="Enter the new address here:"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="main-box clearfix" style="margin-left: auto; margin-right: auto; text-align: center; width:60%">
                <div class="table-responsive table-hover" id="addlist">
                    <asp:Table ID="Table2" class="table user-list table-hover" runat="server">
                        <asp:TableRow Visible="false" ID="row11">
                            <asp:TableCell>
                                <asp:TextBox ID="fn11" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln11" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m11" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row12">
                            <asp:TableCell>
                                <asp:TextBox ID="fn12" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln12" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m12" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row13">
                            <asp:TableCell>
                                <asp:TextBox ID="fn13" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln13" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m13" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row14">
                            <asp:TableCell>
                                <asp:TextBox ID="fn14" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln14" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m14" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row15">
                            <asp:TableCell>
                                <asp:TextBox ID="fn15" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln15" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m15" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row16">
                            <asp:TableCell>
                                <asp:TextBox ID="fn16" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln16" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m16" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row17">
                            <asp:TableCell>
                                <asp:TextBox ID="fn17" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln17" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m17" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row18">
                            <asp:TableCell>
                                <asp:TextBox ID="fn18" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln18" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m18" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row19">
                            <asp:TableCell>
                                <asp:TextBox ID="fn19" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln19" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m19" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Visible="false" ID="row110">
                            <asp:TableCell>
                                <asp:TextBox ID="fn110" CssClass="form-control" Style="width: 75%" Placeholder="First Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="ln110" CssClass="form-control" Style="width: 75%" Placeholder="Last Name:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="m110" CssClass="form-control" Style="width: 75%" Placeholder="Mobile:" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <asp:Button ID="btnNewListing" runat="server" class="btn btn-success"  style="margin-left: auto; margin-right: auto; text-align: center;" Text="Add New Listing" OnClientClick="return confirm('Are you sure you want to add?')" OnClick="btnNewListing_Click" />
        </div>



        <br />
        <hr />
        <br />

        <div class="row">
            <div>
                <h5 style="color: #FF3300; font-weight: bolder">This will replace all previous entries</h5>
                <asp:FileUpload ID="FileUpload1" style="margin-left: auto; margin-right: auto; text-align: center;" CssClass="btn btn-default" runat="server" />
                <br />
                <asp:Button Text="Upload" style="margin-left: auto; margin-right: auto; text-align: center;" CssClass="btn btn-warning" OnClick="Upload" runat="server" OnClientClick="return confirm('Are you sure you want to upload? This action will delete all of the previous listings!')" />
            </div>
        </div>
                <br />
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

</body>
</html>
