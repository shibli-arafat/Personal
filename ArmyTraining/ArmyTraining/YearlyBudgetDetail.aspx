<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearlyBudgetDetail.aspx.cs"
    Inherits="ArmyTraining.YearlyBudgetDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <asp:Literal runat="server" ID="header"></asp:Literal>
    </title>
    <base target="_self" />
    <link rel="Stylesheet" href="css/common.css" type="text/css" />
    <style type="text/css">
        input[type=text]
        {
            font-size: small;
            width: 250px;
            margin-top: 5px;
        }
    </style>
    <script src="js/general.js" type="text/javascript"></script>
    <script type="text/javascript">
        function validateData() {
            var errorMsg = "";
            var year = document.getElementById("<%=txtYear.ClientID %>").value;
            var budget = document.getElementById("<%=txtBudget.ClientID %>").value;
            if (year == "" || !isNumeric(year)) {
                errorMsg += "Please enter a valid year.\n"
            }
            if (budget == "" || !isNumeric(budget)) {
                errorMsg += "Please enter a valid budget amount.\n"
            }
            if (errorMsg != "") {
                alert(errorMsg);
                return false;
            }
            return true;
        }

        function onLoad() {
            var message = document.getElementById("<%=hdnMessage.ClientID %>").value;
            if (message != "") {
                alert(message);
            }
        }

        function setYearTo() {
            var year = document.getElementById("<%=txtYear.ClientID %>").value;
            document.getElementById("<%=txtYearTo.ClientID %>").value = parseInt(year) + 1;
        }
    </script>
</head>
<body onload="onLoad();">
    <form id="form1" runat="server">
    <div>
        <table width="350" border="0" cellspacing="5" cellpadding="0">
            <tr>
                <td class="Header">
                    Year
                </td>
                <td>
                    <input type="text" id="txtYear" style="width: 35px" runat="server" onkeyup="setYearTo();" />-<input type="text" id="txtYearTo" style="width: 35px" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Budget
                </td>
                <td>
                    <input type="text" id="txtBudget" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-top: solid 1px #777777; text-align: center;">
                    <div style="margin-top: 5px;">
                        <asp:Button runat="server" Text="Save" Width="70" ID="btnSave" OnClick="Save_Clicked"
                            OnClientClick="return validateData();" />
                        <input type="button" style="width: 80px;" value="Cancel" onclick="window.close()" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnMessage" Value="" runat="server" />
    </form>
</body>
</html>
