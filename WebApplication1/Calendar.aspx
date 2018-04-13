<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" Async="true" %>

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
    <link href='http://fonts.googleapis.com/css?family=Economica' rel='stylesheet' type='text/css'/>

    <script src="Scripts/jquery-3.3.1.min.js"></script>

    <script src="0.9/js/responsive-calendar.js"></script>
    <link href="0.9/css/responsive-calendar.css" rel="stylesheet" media="screen" />

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

    <div class="container well" style="text-align: center; border-radius: 15px;">
        <form id="form1" runat="server">
            <div class="row">
                <div class="hidden">
                    <asp:Calendar ID="Calendar1" Style="width: 100%; overflow: hidden" runat="server" SelectionMode="Day" Height="500px" FirstDayOfWeek="Sunday" DayStyle-BorderWidth="1px" DayStyle-BorderColor="#019143" BackColor="White" BorderColor="#019143" BorderWidth="2px" CellPadding="1" DayNameFormat="Full" Font-Names="Verdana" Font-Size="16pt" ForeColor="#019143" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" SelectorStyle-Wrap="True">
                        <DayHeaderStyle HorizontalAlign="Right" />
                        <DayStyle HorizontalAlign="Center" />
                        <NextPrevStyle Font-Size="12pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="silver" />
                        <SelectedDayStyle BackColor="#99CCFF" />
                        <TitleStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#019143" ForeColor="white" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    </asp:Calendar>
                </div>
            </div>

            <br />
            <!-- Responsive calendar - START -->
            <div class="responsive-calendar">
        <div class="controls">
            <a class="pull-left" data-go="prev"><div class="btn btn-primary" style="background-color:#019143">Prev</div></a>
            <h4><span data-head-year></span> <span data-head-month></span></h4>
            <a class="pull-right" data-go="next"><div class="btn btn-primary" style="background-color:#019143">Next</div></a>
        </div><hr/>
                <div class="day-headers">
                    <div class="day header">Mon</div>
                    <div class="day header">Tue</div>
                    <div class="day header">Wed</div>
                    <div class="day header">Thu</div>
                    <div class="day header">Fri</div>
                    <div class="day header">Sat</div>
                    <div class="day header">Sun</div>
                </div>
                <div class="days" data-group="days">
                </div>
            </div>
            <!-- Responsive calendar - END -->

            <br />
            <br />
            <h4 class="text-center">Showings</h4>
            <asp:Label ID="displayDateLabel" runat="server" Font-Size="Large"></asp:Label>

            <br />
            <!-- #189EA5 -->
            <div class="row">
                <div class="col-sm-12" style="text-align: center; overflow-x: auto; width: 100%">
                    <asp:GridView ID="GridView1" Style="width: 100%; border: none;" CssClass="table table-responsive" runat="server"
                        AutoGenerateColumns="false" ShowFooter="false"
                        OnRowDataBound="OnRowDataBound"
                        OnRowDeleting="OnRowDeleting"
                        OnRowUpdating="GridView1_RowUpdating"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowEditing="GridView1_RowEditing" AlternatingRowStyle-BackColor="#019143" AlternatingRowStyle-ForeColor="White" AlternatingRowStyle-BorderStyle="NotSet" GridLines="None">
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

                            <asp:TemplateField HeaderText="Leasing Agent" HeaderStyle-CssClass="text-center">
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

                            <asp:TemplateField HeaderText="Showing Date" HeaderStyle-Wrap="False" HeaderStyle-CssClass="text-center">
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
            <asp:Button ID="btndayclick" runat="server" Text="Button" OnClick="btndayclick_Click" style="visibility:hidden"/>
        </form>
    </div>



    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.min.js"></script>
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="js/jquery.parallax.js"></script>
    <script type="text/javascript" src="js/main.js"></script>

    <script src="0.9/js/responsive-calendar.js"></script>

    <script type="text/javascript">
        function setbtnval(date) {
            $("#<%=btndayclick.ClientID%>").attr("value", date);
            $("#<%=btndayclick.ClientID%>").click();
        }
    </script>

</body>
</html>





<!--
        var d = new Date();
        var output = d.getFullYear() + '-' + (d.getMonth() + 1);
        $(document).ready(function () {
            $(".responsive-calendar").responsiveCalendar({
                time: output,
                events: {
                    "2018-04-30": { "number": 5 },
                    "2018-04-26": { "number": 1 },
                    "2018-04-03": { "number": 17 },
                    "2018-06-12": {}
                },
                onDayClick: function (events) {
                    var thisDayEvent, key;
                    key = $(this).data('year') + '-' + $(this).data('month') + '-' + $(this).data('day');
                    setbtnval(key);
                },
            });
        });
-->