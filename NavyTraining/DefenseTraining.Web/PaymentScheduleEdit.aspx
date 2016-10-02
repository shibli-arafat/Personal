<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentScheduleEdit.aspx.cs"
    Inherits="DefenseTraining.Web.PaymentScheduleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .date-picker
        {
            width: 100px;
        }
        .table
        {
            border-collapse: collapse;
            width: 100%;
        }
        .table th
        {
            background-image: url("Styles/images/ui-bg_highlight-soft_75_cccccc_1x100.png");
            background-repeat: repeat-x;
            border-width: 1px;
            padding: 3px 7px 4px 7px;
            border-style: solid;
            border-color: Silver;
            font-weight: normal;
            text-align: left;
            height: 20px;
        }
        input[type=text]
        {
            margin-bottom: 0;
        }
        .table td
        {
            border-width: 1px;
            padding: 3px 7px 4px 7px;
            border-style: solid;
            border-color: Silver;
        }
        td > input[type=text]
        {
            width: 92%;
            text-align: right;
        }
    </style>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _paymentSchedule;

        $(document).ready(function () {
            var queryString = decodeURI(window.location.search.substring(1));
            $(".date-picker").datepicker({ dateFormat: "dd M yy" });
            loadPaymentSchedule(queryString);
        });

        function loadPaymentSchedule(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            var trainingId = parms[1].substring(parms[1].indexOf("=") + 1);
            $.ajax({
                type: "POST",
                url: "PaymentScheduleEdit.aspx/GetPaymentSchedule",
                data: JSON.stringify({ id: id, trainingId: trainingId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _paymentSchedule = data.d.Data;
                        $("#txtCourse").val(_paymentSchedule.CourseName);
                        $("#txtStartDate").val(_paymentSchedule.StartDate);
                        $("#txtEndDate").val(_paymentSchedule.EndDate);
                        $("#txtPaymentDate").val(_paymentSchedule.PaymentDate);
                        $("#tblPayments > tbody").empty();
                        $("#tmplData").tmpl(_paymentSchedule.Payments).appendTo("#tblPayments > tbody");
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
            _paymentSchedule.PaymentDate = $.trim($("#txtPaymentDate").val());
            var payments = new Array();
            $("#tblPayments > tbody > tr").find(".payment").each(function () {
                var payment = new Object();
                payment.BudgetCode = new Object();
                payment.BudgetCode.Id = $(this).attr("budget-id");
                payment.Amount = $(this).val();
                payments.push(payment);
            });
            _paymentSchedule.Payments = payments;
        }

        function isValidFormData() {
            var msg = "";
            if (_paymentSchedule.PaymentDate == "") {
                msg += "Please enter payment date\n";
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
                url: "PaymentScheduleEdit.aspx/SavePaymentSchedule",
                data: JSON.stringify({ paymentSchedule: _paymentSchedule }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _paymentSchedule = data.d.Data;
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
        <tr>
            <td>
                ${BudgetCode.Code}
            </td>
            <td>
                <input type="text" budget-id="${BudgetCode.Id}" class="payment" value="${Amount}"/>
            </td>
        </tr>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div id="divCourse">
            Course:
            <input type="text" id="txtCourse" style="border-style: none;" disabled="disabled" />
        </div>
        <div id="divStartDate">
            Start Date:
            <input type="text" id="txtStartDate" style="border-style: none;" disabled="disabled" />
        </div>
        <div id="divEndDate">
            End Date:
            <input type="text" id="txtEndDate" style="border-style: none;" disabled="disabled" />
        </div>
        <hr />
        <div style="margin-bottom: 5px;">
            Payment Date
        </div>
        <div>
            <input type="text" id="txtPaymentDate" class="date-picker" />
        </div>
        <div style="margin-bottom: 5px; margin-top: 5px;">
            Payments <span style="color: Red">*</span>
        </div>
        <table id="tblPayments" class="table">
            <thead>
                <tr>
                    <th width="50%">
                        Budget Code
                    </th>
                    <th width="50%">
                        Amount
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
