<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleAdditionalExpenceInfo.aspx.cs"
    Inherits="ArmyTraining.SimpleAdditionalExpenceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <base target="_self" />
    <style type="text/css">
        .Header
        {
            font-family: Verdana;
            font-size: small;
            font-weight: bold;
            margin-top: 5px;
        }
        .Input
        {
            font-family: Verdana;
            font-size: small;
            width: 200px;
            margin-top: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px">
            <tr>
                <td class="Header">
                    Name
                </td>
                <td>
                    <asp:TextBox CssClass="Input" runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" class="Header">
                    Provided by
                </td>
                <td>
                    <div>
                        <asp:RadioButton CssClass="Input" GroupName="Choise" Text="Bangladesh" runat="server" ID="rdBangladesh"
                            Checked="true" /></div>
                    <div>
                        <asp:RadioButton CssClass="Input" GroupName="Choise" Text="Trainer Country" runat="server" ID="rdTraining" /></div>
                    <div>
                        <asp:RadioButton CssClass="Input" GroupName="Choise" Text="Sponsor Cuntry" runat="server" ID="rdSponsor" /></div>
                    <div>
                </td>
            </tr>
            <tr>
                <td class="Header">
                    Remarks
                </td>
                <td>
                    <asp:TextBox CssClass="Input" runat="server" ID="txtRemarks"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; border-top: SOLID 1px #777777; padding-top: 5px;"
                    colspan="2" align="center">
                    <asp:Button runat="server" ID="btnOk" Text="OK" Width="80px" OnClick="Ok_Cliced" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
