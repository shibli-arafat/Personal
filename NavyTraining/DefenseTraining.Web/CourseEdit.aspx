<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="DefenseTraining.Web.CourseEdit" %>

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
    <script type="text/javascript">
        var _course;

        $(document).ready(function () {
            loadEventTypes();
            var queryString = decodeURI(window.location.search.substring(1));
            loadCourse(queryString);
        });

        function loadEventTypes() {
            $.ajax({
                type: "POST",
                url: "EventTypeList.aspx/GetEventTypes",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbEventTypes");
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

        function saveData() {
            _course.Name = $.trim($("#txtName").val());
            _course.EventType = new Object();
            _course.EventType.Id = $("#cmbEventTypes").val();
            _course.PreRequisites = $.trim($("#txtPreRequisites").val());
            if (!isValidData()) {
                return;
            }
            $.ajax({
                type: "POST",
                url: "CourseEdit.aspx/SaveCourse",
                data: JSON.stringify({ course: _course }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _course = data.d.Data;
                        window.parent.doSearch();
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

        function loadCourse(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            $.ajax({
                type: "POST",
                url: "CourseEdit.aspx/GetCourse",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _course = data.d.Data;
                        $("#txtName").val(_course.Name);
                        $("#cmbEventTypes").val(_course.EventType.Id);
                        $("#txtPreRquisites").val(_course.PreRequisites);
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

        function isValidData() {
            var msg = "";
            if (_course.Name == "") {
                msg += "Please enter name\n";
            }
            if (_course.EventType.Id == 0) {
                msg += "Please select course type\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            Name <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtName" maxlength="128" />
        </div>
        <div>
            Course Type <span style="color: Red">*</span>
        </div>
        <div>
            <select id="cmbEventTypes">
            </select>
        </div>
        <div>
            Pre Requisites <span style="color: Red">*</span>
        </div>
        <div>
            <textarea id="txtPreRequisites" rows="4" cols="1"></textarea>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
