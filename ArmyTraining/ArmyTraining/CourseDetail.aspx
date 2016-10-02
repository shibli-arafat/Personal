<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="ArmyTraining.CourseDetail" %>

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
            width: 265px;
        }
        
        textarea
        {
            width: 265px;
        }
        
        select
        {
            width: 271px;
        }
    </style>
    <script type="text/javascript">
        function validateData() {
            var errorMsg = "";
            var name = document.getElementById("<%=txtName.ClientID %>").value;
            var type = document.getElementById("<%=drpCourseTypes.ClientID %>").selectedIndex;
            var bkg = document.getElementById("<%=drpTrainingBkg.ClientID %>").selectedIndex;
            if (name == "") {
                errorMsg += "Please enter course name\n";
            }
            if (type == 0) {
                errorMsg += "Please select a course type\n";
            }
            if (bkg == 0) {
                errorMsg += "Please select a training background";
            }
            if (errorMsg.length > 0) {
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
        <table border="0" cellspacing="5" cellpadding="0">
            <tr>
                <td class="Header">
                    Name
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Course Type
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="drpCourseTypes" />
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Training Background
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="drpTrainingBkg" />
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Description
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="border-top: 1px solid gray">
                    <div style="margin-top: 5px;">
                        <asp:Button runat="server" Text="Save" ID="btnSave" Width="70" OnClientClick="return validateData();"
                            OnClick="Save_Clicked" />
                        <input type="button" onclick="window.close();" value="Cancel" style="width: 80px" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnMessage" Value="" runat="server" />
    </form>
</body>
</html>
