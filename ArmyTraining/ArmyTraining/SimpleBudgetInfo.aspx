<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleBudgetInfo.aspx.cs"
    Inherits="ArmyTraining.SimpleBudgetInfo" %>

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
            <colgroup>
                <col />
                <col />
            </colgroup>
            <tr>
                <td style="padding-left: 10px" class="Header">
                    BudgetYear
                </td>
                <td style="padding-right: 10px">
                    <asp:TextBox runat="server" CssClass="Input" ID="txtBudgetYear"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px" class="Header">
                    Expecnce
                </td>
                <td style="padding-right: 10px">
                    <asp:TextBox runat="server" ID="txtExpence" CssClass="Input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; border-top: SOLID 1px #777777; padding-top: 5px;"
                    colspan="2" align="center">
                    <asp:Button runat="server" ID="btnOk" Text="Ok" OnClick="Ok_Cliced" Width="80px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
