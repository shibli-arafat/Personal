<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankEdit.aspx.cs" Inherits="DefenseTraining.Web.RankEdit" %>

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
        var _rank;

        $(document).ready(function () {
            loadRankGroups();
            var queryString = decodeURI(window.location.search.substring(1));
            loadRank(queryString);
        });

        function loadRankGroups() {
            $.ajax({
                type: "POST",
                url: "RankGroupList.aspx/GetRankGroups",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbRankGroups");
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
            _rank.Name = $.trim($("#txtName").val());
            _rank.Group = new Object();
            _rank.Group.Id = $("#cmbRankGroups").val();
            if (!isValidData()) {
                return;
            }
            $.ajax({
                type: "POST",
                url: "RankEdit.aspx/SaveRank",
                data: JSON.stringify({ rank: _rank }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _rank = data.d.Data;
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

        function isValidData() {
            var msg = "";
            if (_rank.Name == "") {
                msg += "Please enter name\n";
            }
            if (_rank.Group.Id == 0) {
                msg += "Please select rank group\n;";
            }
            if (msg != "") {
                return false;
            }
            return true;
        }

        function loadRank(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            $.ajax({
                type: "POST",
                url: "RankEdit.aspx/GetRank",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _rank = data.d.Data;
                        $("#txtName").val(_rank.Name);
                        $("#cmbRankGroups").val(_rank.Group.Id);
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
            Name <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtName" maxlength="128" />
        </div>
        <div>
            Rank Group <span style="color: Red">*</span>
        </div>
        <div>
            <select id="cmbRankGroups">
            </select>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
