﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrgOfferedByEdit.aspx.cs"
    Inherits="DefenseTraining.Web.TrgOfferedByEdit" %>

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
        var _trgOfferedBy;

        $(document).ready(function () {
            var queryString = decodeURI(window.location.search.substring(1));
            _trgOfferedBy = getTrgOfferedBy(queryString);
            $("#txtName").val(_trgOfferedBy.Name);
        });

        function saveData() {
            _trgOfferedBy.Name = $.trim($("#txtName").val());
            if (_trgOfferedBy.Name == "") {
                alert("Please enter name\n");
                $("#txtName").focus();
                return;
            }
            $.ajax({
                type: "POST",
                url: "TrgOfferedByEdit.aspx/SaveTrgOfferedBy",
                data: JSON.stringify({ trgOfferedBy: _trgOfferedBy }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _trgOfferedBy = data.d.Data;
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

        function getTrgOfferedBy(queryString) {
            var trgOfferedBy = new Object();
            var parms = queryString.split('&');
            trgOfferedBy.Id = parms[0].substring(parms[0].indexOf("=") + 1);
            trgOfferedBy.Name = parms[1].substring(parms[1].indexOf("=") + 1);
            return trgOfferedBy;
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
            <input type="text" id="txtName" />
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    <asp:HiddenField ID="hdnMessage" runat="server" />
    </form>
</body>
</html>
