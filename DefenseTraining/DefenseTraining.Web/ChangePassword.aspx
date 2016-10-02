<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="DefenseTraining.Web.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=password]
        {
            width: 200px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
    </style>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtOldPassword").focus();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 45px;">
        <div style="margin-bottom: 5px;">
            <asp:Label ID="lblMessage" runat="server" />
        </div>
        <div>
            User Name
        </div>
        <div>
            <input type="text" runat="server" id="txtUserName" />
        </div>
        <div>
            Old Password<span style="color: Red">*</span>
        </div>
        <div>
            <input type="password" id="txtOldPassword" runat="server" />
        </div>
        <div>
            New Password<span style="color: Red">*</span>
        </div>
        <div>
            <input type="password" id="txtNewPassword" runat="server" />
        </div>
        <div>
            Confirm Password<span style="color: Red">*</span>
        </div>
        <div>
            <input type="password" id="txtConfirmPassword" runat="server" />
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnChangePassword" value="Change Password" onserverclick="btnChangePassword_Click"
                runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
