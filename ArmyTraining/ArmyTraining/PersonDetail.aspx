<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonDetail.aspx.cs" Inherits="ArmyTraining.PersonDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal runat="server" ID="header"></asp:Literal></title>
    <base target="_self" />
    <link rel="Stylesheet" href="css/common.css" type="text/css" />
    <style type="text/css">
        input[type=text]
        {
            width: 250px;
        }
        textarea
        {
            width: 250px;
        }
        select
        {
            width: 256px;
        }
    </style>
    <script type="text/javascript">
        function validateData() {
            var errorMsg = "";
            var personalNo = document.getElementById("<%=txtPersonNo.ClientID %>").value;
            var rank = document.getElementById("<%=drpRank.ClientID %>").selectedIndex;
            var name = document.getElementById("<%=txtName.ClientID %>").value;
            var service = document.getElementById("<%=ddlArmsService.ClientID %>").selectedIndex;
            if (personalNo == "") {
                errorMsg += "Please enter personal number\n";
            }
            if (rank == 0) {
                errorMsg += "Please select a rank\n";
            }
            if (name == "") {
                errorMsg += "Please enter personal number\n";
            }
            if (service == 0) {
                errorMsg += "Please select an arm/service\n";
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
    </script>
</head>
<body onload="onLoad();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrptManPerson" runat="server" />
    <div style="margin: 10px;">
        <table border="0" cellspacing="5" cellpadding="0" width="100%">
            <tr>
                <td class="Header">
                    Personal No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPersonNo" />
                    <asp:Button ID="btnCheckDuplicate" Text="Check Duplicacy" runat="server" OnClick="btnCheckDuplicate_Click" />
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Rank
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="drpRank" />
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Name
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="InputSpecial"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Arms Service
                </td>
                <td>
                    <asp:DropDownList AutoPostBack="true" CssClass="DropdownSpecial" runat="server" ID="ddlArmsService" />
                </td>
            </tr>
            <tr>
                <td class="Header" valign="top">
                    Decoration
                </td>
                <td>
                    <div style="height: 150px; overflow: auto; border-style: inset; border-width: 1px;
                        width: 254px; border-color: Silver;">
                        <asp:CheckBoxList runat="server" ID="chkDecorations" RepeatLayout="Flow" CssClass="ItemStyle" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="Header" valign="top">
                    Email
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="InputSpecial"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Header" valign="top">
                    Mobile
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="InputSpecial"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Header" valign="top">
                    Remarks
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" CssClass="InputSpecial"
                        Height="125px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top: 5px; text-align: center">
                    <asp:Button runat="server" ID="btnSave" Text="Save" Width="70" OnClientClick="return validateData();"
                        OnClick="SaveClicked" />
                    <input type="button" style="width: 80px;" onclick="window.close();" value="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnMessage" runat="server" Value="" />
    </form>
</body>
</html>
