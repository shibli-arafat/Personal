<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialExpenseHeadEdit.aspx.cs"
    Inherits="DefenseTraining.Web.SpecialExpenseHeadEdit" %>

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
    <script type="text/javascript">
        var _expenseHead;

        $(document).ready(function () {
            var queryString = decodeURI(window.location.search.substring(1));
            $("#divAutoCalc").hide();
            loadCalculationBasis();
            loadExpenseHead(queryString);
            populateFormData();
        });

        function loadCalculationBasis() {
            var basises = new Array();
            basises.push({ Id: 1, Name: "Percentage of Comprehensive DA" });
            var options = $("#cmbCalculateOn");
            $.each(basises, function () {
                options.append($("<option />").val(this.Id).text(this.Name));
            });
        }

        function saveData() {
            getFormData();
            if (!isValidData()) return;
            $.ajax({
                type: "POST",
                url: "ExpenseHeadEdit.aspx/SaveExpenseHead",
                data: JSON.stringify({ expenseHead: _expenseHead }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _expenseHead = data.d.Data;
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

        function getFormData() {
            _expenseHead.Name = $.trim($("#txtName").val());
            _expenseHead.IsAutoCalc = $("#chkIsAutoCalc").attr("checked");
            _expenseHead.BasedOn = 0;
            _expenseHead.Value = 0;
            if (_expenseHead.IsAutoCalc) {
                _expenseHead.BasedOn = $("#cmbCalculateOn").val();
                _expenseHead.Value = parseFloat($.trim($("#txtValue").val()));
            }
        }

        function loadExpenseHead(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (parseInt(id, 10) == 0) {
                _expenseHead = new Object();
                return;
            }
            $.ajax({
                type: "POST",
                url: "ExpenseHeadEdit.aspx/GetExpenseHead",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _expenseHead = data.d.Data;
                    }
                    else {
                        alert(data.d.ErrorMessage);
                        return;
                    }
                },
                error: function (msg) {
                    alert(msg);
                    return;
                }
            });
        }

        function populateFormData() {
            $("#txtName").val(_expenseHead.Name);
            $("#chkIsAutoCalc").attr("checked", _expenseHead.IsAutoCalc == true ? "checked" : "");
            toggleAutoCalc();
            if (_expenseHead.IsAutoCalc) {
                $("#cmbCalculateOn").val(_expenseHead.BasedOn);
                $("#txtValue").val(_expenseHead.Value);
            }
        }

        function toggleAutoCalc() {
            if ($("#chkIsAutoCalc").attr("checked")) {
                $("#divAutoCalc").show();
            }
            else {
                $("#divAutoCalc").hide();
            }
        }

        function isValidData() {
            var msg = "";
            if (_expenseHead.Name == "") {
                msg += "Please enter expense head name\n";
            }
            if (_expenseHead.IsAutoCalc) {
                if (_expenseHead.BasedOn == 0) {
                    msg += "Please select the basis of auto calculation\n";
                }
                if (_expenseHead.Value == 0) {
                    msg += "Please enter value\n";
                }
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
        <div style="margin-bottom: 5px;">
            <input type="checkbox" id="chkIsAutoCalc" onchange="toggleAutoCalc();">Is Auto Calculation?</input>
        </div>
        <div id="divAutoCalc">
            <div>
                Calculate On <span style="color: Red">*</span>
            </div>
            <div>
                <select id="cmbCalculateOn">
                </select>
            </div>
            <div>
                Value <span style="color: Red">*</span>
            </div>
            <div>
                <input type="text" id="txtValue" maxlength="14" class="numeric-only" />
            </div>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
