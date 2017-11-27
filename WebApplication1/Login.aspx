<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/> 
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
	<title>Login</title> 
	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
	<link href="css/font-awesome.min.css" rel="stylesheet"/> 
    <link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/background.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
	<!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]--> 
	<link rel="shortcut icon" href="images/ico/favicon.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png"/>
    
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
	</div><!--/.preloader-->

        <header id="navigation"> 
		<div class="navbar navbar-inverse navbar-fixed-top navopaq" role="banner"> 
			<div class="container"> 
				<div class="navbar-header"> 
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> 
						<span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> 
					</button> 
					<a class="navbar-brand" href="index.html"><h1><img src="images/logo.png" alt="logo"/></h1></a> 
				</div> 
				<div class="collapse navbar-collapse"> 
					<ul class="nav navbar-nav navbar-right"> 
						<li class="scroll"><a href="Calendar.aspx">Calendar</a></li> 
						<li class="scroll active"><a href="Login.aspx">Login</a></li>  
					</ul> 
				</div> 
			</div> 
		</div><!--/navbar--> 
	</header> <!--/#navigation--> 

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="container" style="text-align:center">
    <form id="formLogin" runat="server" class ="col-sm-4 col-sm-offset-4" >
        <h2>Login</h2>
        <br />
        <div class="form-group">
            <div class="input-group">
                <span class ="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                <asp:TextBox ID="TextBoxUserName" runat="server" Text="" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="input-group">
                <span class ="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            </div>
        </div>

        
        <div class="form-group">
            <asp:Button ID="ButtonLogin" runat="server" Text ="Login" CssClass="btn btn-success" OnClick="ButtonLogin_click"/>
            <asp:Label ID="LabelMessage" runat="server" Text ="Label" Visible="false"></asp:Label>
        </div>

        <hr />
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
