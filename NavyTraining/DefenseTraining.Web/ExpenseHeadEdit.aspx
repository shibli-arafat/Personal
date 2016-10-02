<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseHeadEdit.aspx.cs"
    Inherits="DefenseTraining.Web.ExpenseHeadEdit" %>

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
    <script src="Scripts/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _expenseHead;

        $(document).ready(function () {
            var queryString = decodeURI(window.location.search.substring(1));
            $("#divAutoCalc").hide();
            loadBudgetCodes();
            loadCalculationBasis();
            loadExpenseHead(queryString);
            populateFormData();
            allowOnlyNumeric();
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
            _expenseHead.IsDaily = $("#chkIsDaily").attr("checked");
            _expenseHead.ApplicableForSpouse = $("#chkApplicableForSpouse").attr("checked");
            _expenseHead.ApplicableForKids = $("#ApplicableForKids").attr("checked");
            _expenseHead.IsInBdt = $("#chkIsInBdt").attr("checked");
            _expenseHead.IsAutoCalc = $("#chkIsAutoCalc").attr("checked");
            _expenseHead.BudgetCode.Id = $("#cmbBudgetCodes").val();
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
            $("#cmbBudgetCodes").val(_expenseHead.BudgetCode.Code);
            $("#chkIsDaily").attr("checked", _expenseHead.IsDaily == true ? "checked" : "");
            $("#chkApplicableForSpouse").attr("checked", _expenseHead.ApplicableForSpouse == true ? "checked" : "");
            $("#chkApplicableForKids").attr("checked", _expenseHead.ApplicableForKids == true ? "checked" : "");
            $("#chkIsInBdt").attr("checked", _expenseHead.IsInBdt == true ? "checked" : "");
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
            if (_expenseHead.BudgetCode.Id == 0) {
                msg += "Please select a budget code\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function loadBudgetCodes() {
            $.ajax({
                type: "POST",
                url: "BudgetEdit.aspx/GetBudgetCodes",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbBudgetCodes");
                        options.append($("<option />").val(0).text("Please Select"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.Code));
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <label for="txtName">
            Name <span style="color: Red">*</span>
        </label>
        <input type="text" id="txtName" />
        <label for="cmbBudgetCodes">
            BudgetCode <span style="color: Red">*</span>
        </label>
        <select id="cmbBudgetCodes"></select>
        <label for="chkIsDaily">
            <input type="checkbox" id="chkIsDaily" />Is Daily?
        </label>
        <label for="chkApplicableForSpouse">
            <input type="checkbox" id="chkApplicableForSpouse" />Applicable for Spouse?
        </label>
        <label for="chkApplicableForKids">
            <input type="checkbox" id="chkApplicableForKids" />Applicable for Kids?
        </label>
        <label for="chkIsInBdt" style="margin-bottom: 7px;">
            <input type="checkbox" id="chkIsInBdt" />Is in BDT?
        </label>
        <label for="chkIsAutoCalc" style="margin-bottom: 7px;">
            <input type="checkbox" id="chkIsAutoCalc" onchange="toggleAutoCalc();" />Is Auto
            Calculation?
        </label>
        <div id="divAutoCalc">
            <label for="cmbCalculateOn">
                Calculate On <span style="color: Red">*</span>
            </label>
            <select id="cmbCalculateOn">
            </select>
            <label for="txtValue">
                Value <span style="color: Red">*</span>
            </label>
            <input type="text" id="txtValue" maxlength="14" class="numeric-only" />
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
