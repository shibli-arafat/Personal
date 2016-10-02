<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="DefenseTraining.Web.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <style type="text/css">
        input[type=text], input[type=password], select, textarea
        {
            width: 275px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
        
        select
        {
            width: 279px;
        }
    </style>
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _user;

        $(document).ready(function () {
            loadRoles();
            var queryString = decodeURI(window.location.search.substring(1));
            loadUser(queryString);
        });

        function loadRoles() {
            $.ajax({
                type: "POST",
                url: "RoleList.aspx/GetRoles",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divRoles").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#divRoles");
                    }
                    else {
                        alert(data.d.ErrorMessage);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }

        function populateFormData() {
            $("#txtUserName").val(_user.UserName);
            $("#txtPassword").val(_user.Password);
            $("#txtFullName").val(_user.Password);
            $("#txtEmail").val(_user.Email);
            $("#txtPhoneNo").val(_user.PhoneNo);
            populateUserRoles();
        }

        function populateUserRoles() {
            $("#divRoles :checkbox").each(function () {
                for (var i = 0; i < _user.Roles.length; i++) {
                    var existing = _user.Roles[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }

        function getFormData() {
            _user.UserName = $.trim($("#txtUserName").val());
            _user.Password = $.trim($("#txtPassword").val());
            _user.FullName = $.trim($("#txtFullName").val());
            _user.Email = $.trim($("#txtEmail").val());
            _user.PhoneNo = $.trim($("#txtPhoneNo").val());
            getUserRoleData();
        }

        function getUserRoleData() {
            var roles = new Array();
            $("#divRoles :checkbox:checked").each(function () {
                var role = new Object();
                role.Id = parseInt($(this).attr("dataId"));
                roles.push(role);
            });
            _user.Roles = roles;
        }

        function isValidFormData() {
            var msg = "";
            if (_user.UserName == "") {
                msg += "Please enter user name\n";
            }
            if (_user.Password == "") {
                msg += "Please enter password\n";
            }
            if (_user.FullName == "") {
                msg += "Please enter full name\n";
            }
            if (_user.Roles.length == 0) {
                msg += "Please select at least one role\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function saveData() {
            getFormData();
            if (!isValidFormData()) {
                return;
            }
            $.ajax({
                type: "POST",
                url: "UserEdit.aspx/SaveUser",
                data: JSON.stringify({ user: _user }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _user = data.d.Data;
                        window.parent.populateData();
                    }
                    else {
                        alert(data.d.ErrorMessage);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }

        function loadUser(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (id == 0) {
                _user = new Object();
                return;
            }
            $.ajax({
                type: "POST",
                url: "UserEdit.aspx/GetUser",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _user = data.d.Data;
                        populateFormData();
                        window.parent.populateData();
                    }
                    else {
                        alert(data.d.ErrorMessage);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }
    </script>
    <script id="tmplData" type="text/html">
        <label for="checkbox">
            <input type="checkbox" dataId="${Id}" value="${Name}"/> ${Name}
        </label>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <label for="txtUserName">
            User Name <span style="color: Red">*</span>
        </label>
        <input type="text" id="txtUserName" />
        <label for="txtUserPassword">
            Password <span style="color: Red">*</span>
        </label>
        <input type="password" id="txtPassword" />
        <label for="txtFullName">
            Full Name <span style="color: Red">*</span>
        </label>
        <input type="text" id="txtFullName" />
        <label for="divRoles">
            Roles <span style="color: Red">*</span>
        </label>
        <div id="divRoles" style="height: 150px; width: 283px; border: 1px solid #ccc; overflow: auto;
            margin-bottom: 5px;" class="rounded">
        </div>
        <label for="txtEmail">
            Email
        </label>
        <input type="text" id="txtEmail" />
        <label for="txtPhoneNo">
            Phone No
        </label>
        <input type="text" id="txtPhoneNo" />
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
