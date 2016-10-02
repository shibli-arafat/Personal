<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonEdit.aspx.cs" Inherits="DefenseTraining.Web.PersonEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
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
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _person;

        $(document).ready(function () {
            $("#txtPersonNo").focus();
            loadRanks();
            var queryString = decodeURI(window.location.search.substring(1));
            loadPerson(queryString);
        });

        function loadRanks() {
            $.ajax({
                type: "POST",
                url: "RankList.aspx/GetRanks",
                data: '{}',
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

        function populateFormData() {
            $("#txtPersonNo").val(_person.PersonNo);
            $("#txtName").val(_person.Name);
            $("#cmbRanks").val(_person.Rank.Id);
            $("#txtEmail").val(_person.Email);
            $("#txtMobileNo").val(_person.MobileNo);
        }

        function getFormData() {
            _person.PersonNo = $.trim($("#txtPersonNo").val());
            _person.Name = $.trim($("#txtName").val());
            _person.Rank = new Object();
            _person.Rank.Id = parseInt($("#cmbRanks").val(), 10);
            _person.Email = $.trim($("#txtEmail").val());
            _person.MobileNo = $.trim($("#txtMobileNo").val());
        }

        function isValidFormData() {
            var msg = "";
            if (_person.PersonNo == "") {
                msg += "Please enter person no\n";
            }
            if (_person.Name == "") {
                msg += "Please enter name\n";
            }
            if (_person.Rank.Id == 0) {
                msg += "Please select rank\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function saveData() {
            getFormData();
            if (!isValidFormData()) return;
            $.ajax({
                type: "POST",
                url: "PersonEdit.aspx/SavePerson",
                data: JSON.stringify({ person: _person }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _person = data.d.Data;
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

        function loadPerson(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (id == 0) {
                _person = new Object();
                return;
            } 
            $.ajax({
                type: "POST",
                url: "PersonEdit.aspx/GetPerson",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _person = data.d.Data;
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            Person No
        </div>
        <div>
            <input type="text" id="txtPersonNo" maxlength="16" />
        </div>
        <div>
            Name
        </div>
        <div>
            <input type="text" id="txtName" maxlength="128" />
        </div>
        <div>
            Rank
        </div>
        <div>
            <select id="cmbRanks">
            </select>
        </div>
        <div>
            Email
        </div>
        <div>
            <input type="text" id="txtEmail" maxlength="64" />
        </div>
        <div>
            Mobile No
        </div>
        <div>
            <input type="text" id="txtMobileNo" maxlength="16" />
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData();" />
        </div>
    </div>
    </form>
</body>
</html>
