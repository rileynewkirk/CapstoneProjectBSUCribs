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
        <div class="navbar navbar-inverse navbar-fixed-top" style="height: auto" role="banner">
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
                    <ul class="nav navbar-nav navbar-right" runat="server" id="navbar">
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

    <div class="container well" style="text-align: center; border-radius: 15px;">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-sm-12 hidden-xs">
                    <asp:Calendar ID="Calendar1" Style="width:100%; overflow:hidden" runat="server" SelectionMode="Day" Height="500px" FirstDayOfWeek="Sunday" DayStyle-BorderWidth="1px" DayStyle-BorderColor="#189EA5" BackColor="White" BorderColor="#189EA5" BorderWidth="2px" CellPadding="1" DayNameFormat="Full" Font-Names="Verdana" Font-Size="16pt" ForeColor="#189EA5" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" SelectorStyle-Wrap="True">
                        <DayHeaderStyle HorizontalAlign="Right" />
                        <DayStyle HorizontalAlign="Center" />
                        <NextPrevStyle Font-Size="12pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="silver" />
                        <SelectedDayStyle BackColor="#99CCFF" />
                        <TitleStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#189EA5" ForeColor="white" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    </asp:Calendar>
                </div>
            </div>

               <div class="row">
                <div class="col-xs-12 hidden-sm hidden-md hidden-lg">
                    <asp:Label ID="Label1" runat="server" Text="Choose a date to view showings"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 hidden-sm hidden-md hidden-lg ">
                    <asp:TextBox ID="tbmobileDate" CssClass="form-control col-xs-6" runat="server" TextMode="Date" OnTextChanged="tbmobileDate_TextChanged" AutoPostBack="True"></asp:TextBox>

                </div>
            </div>




            <br />
            <br />
            <h4 class="text-center">Showings</h4>
            <asp:Label ID="displayDateLabel" runat="server" Font-Size="Large"></asp:Label>

            <br />

            <div class="row">
                <div class="col-sm-12" style="text-align: center;">
                    <table style="width: 100%; border: none;">
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView1" Style="width: 100%; border: none;" CssClass="table table-responsive" runat="server"
                                    AutoGenerateColumns="false" ShowFooter="false"
                                    OnRowDataBound="OnRowDataBound"
                                    OnRowDeleting="OnRowDeleting"
                                    OnRowUpdating="GridView1_RowUpdating"
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                    OnRowEditing="GridView1_RowEditing" AlternatingRowStyle-BackColor="#189EA5" AlternatingRowStyle-ForeColor="White" AlternatingRowStyle-BorderStyle="NotSet" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShowingID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Showing_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Client" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Client") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditClient" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Client") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAddClient" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Address" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditAddress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Address") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAddAddress" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Leasing Agent"  HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeasingAgent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Leasing_Agent") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditLeasingAgent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Leasing_Agent") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAddLeasingAgent" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Showing Date"  HeaderStyle-Wrap="False" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShowingDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ShowingDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditShowingDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "showingDate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAddShowingDate" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="imgbtnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                                                <asp:Button ID="imgbtnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="imgbtnUpdate" runat="server" CommandName="Update" Text="Update" />
                                                <asp:Button ID="imgbtnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <!--<div class="col-sm-12" style="background-color: white">
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
        </div>-->

            <br />
            <br />




            <br />
            <br />
            <br />
            <br />

            <div>
                <asp:Button class="btn btn-primary" ID="CreateShowingBtn" runat="server" Text="Create Showing" OnClick="goToCreateShowing" />
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




