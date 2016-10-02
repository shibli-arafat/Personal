<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankDetail.aspx.cs" Inherits="ArmyTraining.RankDetail" %>

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
    <script type="text/javascript">
        function validateData() {
            var errorMsg = "";
            var name = document.getElementById("<%=txtName.ClientID %>").value;
            if (name == "") {
                errorMsg += "Please enter rank name\n";
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
    <div style="margin: 10px">
        <table width="350" border="0" cellspacing="5" cellpadding="0">
            <tr>
                <td class="Header">
                    Name
                </td>
                <td>
                    <input type="text" id="txtName" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-top: solid 1px #777777; text-align: center;">
                    <div style="margin-top: 5px;">
                        <asp:Button runat="server" Text="Save" Width="70" ID="btnSave" OnClientClick="return validateData();"
                            OnClick="Save_Clicked" />
                        <input type="button" value="Cancel" onclick="window.close()" style="width: 80px" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnMessage" Value="" runat="server" />
    </form>
</body>
</html>
