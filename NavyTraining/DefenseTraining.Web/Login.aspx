<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DefenseTraining.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Login.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtUserName").focus();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login-wrapper" class="clearfix">
        <div class="main-col">
            <img src="Styles/images/navy-logo.jpg" alt="" class="logo_img" />
            <div class="panel">
                <p class="heading_main">
                    Account Login
                </p>
                <label for="txtUserName">
                    Login
                </label>
                <input type="text" id="txtUserName" value="" runat="server" />
                <label for="txtPassword">
                    Password
                </label>
                <input type="password" id="txtPassword" value="" runat="server" />
                <div id="wwgrp_err_login" class="wwgrp">
                    <div id="wwctrl_err_login" class="wwctrl">
                        <label id="lblErrorMessage" class="loginErrorLabel" runat="server" style="color: Red;">
                            &nbsp;
                        </label>
                    </div>
                </div>
                <div class="submit_sect">
                    <input type="button" runat="server" id="btnLogin" value="Login" class="btn btn-beoro-3"
                        onserverclick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
