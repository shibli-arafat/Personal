<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="DefenseTraining.Web.RoleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <style type="text/css">
        input[type=text], select, textarea
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
        var _role;

        $(document).ready(function () {
            loadPrivileges();
            var queryString = decodeURI(window.location.search.substring(1));
            loadRole(queryString);
        });

        function loadPrivileges() {
            $.ajax({
                type: "POST",
                url: "RoleEdit.aspx/GetPrivileges",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divPrivileges").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#divPrivileges");
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
            $("#txtName").val(_role.Name);
            $("#divPrivileges :checkbox").each(function () {
                for (var i = 0; i < _role.Privileges.length; i++) {
                    var existing = _role.Privileges[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }

        function getFormData() {
            _role.Name = $.trim($("#txtName").val());
            var privileges = new Array();
            $("#divPrivileges :checkbox:checked").each(function () {
                var privilege = new Object();
                privilege.Id = parseInt($(this).attr("dataId"));
                privileges.push(privilege);
            });
            _role.Privileges = privileges;
        }

        function isValidFormData() {
            var msg = "";
            if (_role.Name == "") {
                msg += "Please enter role name\n";
            }
            if (_role.Privileges.length == 0) {
                msg += "Please select at least one privilege\n";
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
                url: "RoleEdit.aspx/SaveRole",
                data: JSON.stringify({ role: _role }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _role = data.d.Data;
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

        function loadRole(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (id == 0) {
                _role = new Object();
                return;
            }
            $.ajax({
                type: "POST",
                url: "RoleEdit.aspx/GetRole",
                data: JSON.stringify({ id: id }),
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _role = data.d.Data;
                        populateFormData();
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
            <input type="checkbox" dataId="${Id}" value="${Name}">${Name}</input>
        </div>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            Name <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtName" />
        </div>
        <div>
            Privileges <span style="color: Red">*</span>
        </div>
        <div id="divPrivileges" style="height: 200px; width: 275px; border: 1px solid #dadada;
            overflow: auto; margin-top: 3px;">
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
