<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="DefenseTraining.Web.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <style type="text/css">
        input[type=text], input[type=password], select, textarea
        {
            width: 275px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
        
        .date-picker
        {
            width: 100px;
            margin-bottom: 5px;
        }
        
        select
        {
            width: 279px;
        }
    </style>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.12.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _user;

        $(document).ready(function () {
            loadRoles();
            loadRanks();
            var queryString = decodeURI(window.location.search.substring(1));            
            loadUser(queryString);            
        });

        function loadRanks() {
            $.ajax({
                type: "POST",
                url: "RankList.aspx/GetRanks",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbRanks");
                        options.append($("<option />").val(0).text("Please Select"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.Name));
                        });
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

        function loadRoles() {
            $.ajax({
                type: "POST",
                url: "UserList.aspx/GetRoles",
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
            $("#txtFullName").val(_user.FullName);
            $("#txtEmail").val(_user.Email);
            $("#txtPhoneNo").val(_user.PhoneNo);
            $("#txtPersonalNo").val(_user.PersonalNo);
            $("#txtAppointment").val(_user.Appointment);
            $("#cmbRanks").val(_user.Rank.Id);
            populateUserRoles();
            $("#txtUserName").attr('readonly', true);
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
            _user.PersonalNo = $.trim($("#txtPersonalNo").val());
            _user.Rank = new Object();
            _user.Rank.Id = parseInt($.trim($("#cmbRanks").val(), 10));
            _user.Appointment = $.trim($("#txtAppointment").val());
            getUserRoleData();
        }

        function getUserRoleData() {
            var roles = new Array();
            $("#divRoles :checkbox:checked").each(function () {
                var role = new Object();
                role.Id = parseInt($(this).attr("dataId"), 10);
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
            if (_user.Rank.Id == 0) {
                msg += "Please select a rank\n";
            }
            if (_user.PersonalNo == '') {
                msg += "Please enter personal No\n";
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
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}"/> ${Name}
        </div>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            User Name <span style="color: Red">*</span>
        </div>
        <input type="text" id="txtUserName" />
        <div>
            Password <span style="color: Red">*</span>
        </div>
        <input type="password" id="txtPassword" />
        <div>
            Personal No <span style="color: Red">*</span>
        </div>
        <input type="text" id="txtPersonalNo" />
        <div>
            Rank <span style="color: Red">*</span>
        </div>
        <select id="cmbRanks">
        </select>
        <div>
            Full Name <span style="color: Red">*</span>
        </div>
        <input type="text" id="txtFullName" />
        <div>
            Roles <span style="color: Red">*</span>
        </div>
        <div id="divRoles" style="height: 150px; width: 283px; border: 1px solid #ccc; overflow: auto;
            margin-bottom: 5px; margin-top: 3px;" class="rounded">
        </div>
        <div>
            Email
        </div>
        <input type="text" id="txtEmail" />
        <div>
            Phone No
        </div>
        <input type="text" id="txtPhoneNo" />
        <div>
            Appointment
        </div>
        <input type="text" id="txtAppointment" />
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
