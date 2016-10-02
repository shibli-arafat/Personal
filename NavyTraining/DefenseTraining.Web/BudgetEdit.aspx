<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetEdit.aspx.cs" Inherits="DefenseTraining.Web.BudgetEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <style type="text/css">
        input[type=text]
        {
            width: 28px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
    </style>
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _budget;

        $(document).ready(function () {
            loadBudgetCodes();
            $("#txtBudgetYear").keyup(function () {
                $("#txtBudgetYearTo").val(parseInt($("#txtBudgetYear").val(), 10) + 1);
            });
            var queryString = decodeURI(window.location.search.substring(1));
            loadBudget(queryString);
            populateFormData();
            allowOnlyNumeric();
        });

        function saveData() {
            getFormData();
            if (!isValidData()) return;
            $.ajax({
                type: "POST",
                url: "BudgetEdit.aspx/SaveBudget",
                data: JSON.stringify({ budget: _budget }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _budget = data.d.Data;
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
            _budget.BudgetYear = parseInt($.trim($("#txtBudgetYear").val()), 10);
            _budget.BudgetCode.Id = $("#cmbBudgetCodes").val();
            _budget.Amount = parseFloat($.trim($("#txtAmount").val()));
        }

        function loadBudget(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (parseInt(id, 10) == 0) {
                _budget = new Object();
                _budget.BudgetCode = new Object();
                _budget.BudgetYear = 2000;
                return;
            }
            $.ajax({
                type: "POST",
                url: "BudgetEdit.aspx/GetBudget",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _budget = data.d.Data;
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
            $("#txtBudgetYear").val(_budget.BudgetYear);
            $("#txtBudgetYearTo").val(_budget.BudgetYear + 1);
            $("#cmbBudgetCodes").val(_budget.BudgetCode.Id);
            $("#txtAmount").val(_budget.Amount);
        }

        function isValidData() {
            var msg = "";
            if (_budget.BudgetYear == "" || _budget.BudgetYear == 0) {
                msg += "Please enter budget year\n";
            }
            if (_budget.BudgetCode.Id == 0) {
                msg += "Please select budget code\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function allowOnlyNumeric() {
            $(".numeric-only").keydown(function (event) {
                if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode == 65 && event.ctrlKey === true) ||
                (event.keyCode > 35 && event.keyCode <= 39)) {
                    return;
                }
                else {
                    if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                        event.preventDefault();
                    }
                }
            });
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
        <label for="txtBudgetYear">
            Year <span style="color: Red">*</span>
        </label>
        <input type="text" id="txtBudgetYear" class="numeric-only" maxlength="4" />
        -
        <input type="text" id="txtBudgetYearTo" readonly="readonly" />
        <label for="cmbBudgetCodes">
            Budget Code
        </label>
        <select id="cmbBudgetCodes" style="width: 120px">
        </select>
        <label for="txtAmount">
            Amount <span style="color: Red">*</span>
        </label>
        <input type="text" id="txtAmount" style="width: 100px;" class="numeric-only" maxlength="14" />
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
