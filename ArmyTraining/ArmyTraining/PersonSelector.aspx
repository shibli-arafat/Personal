<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonSelector.aspx.cs"
    Inherits="ArmyTraining.PersonSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select trainees</title>
    <base target="_self" />

    <script language="javascript" type="text/javascript">
        function SelectPersons() {
            window.returnValue = document.getElementById("hdnSelectedPersonIds").value;
            window.close();
        }

        function openPersonDetail() {
            var url = "PersonDetail.aspx";
            url += "?rnd=" + Math.random().toString() + "&ID=0";
            var person = window.showModalDialog(url, window, "dialogWidth:500px;dialogHeight:650px;status:no;resizable:no;scroll:no;");
            if (person == null || person == '') return false;
            return true;
        }
    </script>

    <link rel="Stylesheet" href="css/common.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="border: SOLID 1px #777777">
        <table border="0" cellspacing="0" cellpadding="0" width="400px">
            <tr>
                <td class="Header" style="padding-left: 10px; padding-top: 3px; padding-bottom: 3px;">
                    Person Number
                </td>
                <td class="Input" style="padding-right: 10px; padding-top: 3px; padding-bottom: 3px;">
                    <asp:TextBox runat="server" ID="txtPersonNo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Header" style="padding-left: 10px; padding-top: 3px; padding-bottom: 3px;">
                    Keywords (rank/name)
                </td>
                <td class="Input" style="padding-right: 10px; padding-top: 3px; padding-bottom: 3px;">
                    <asp:TextBox runat="server" ID="txtKeyword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px;">
                    <asp:Button ID="btnAddNew" Text="Add new" Width="80" runat="server" OnClientClick="return openPersonDetail();" />
                </td>
                <td colspan="2" align="right" style="padding-left: 10px; padding-right: 10px; padding-top: 3px;
                    padding-bottom: 3px;">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" Width="80px" OnClick="Search" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 300px; overflow: auto; border: SOLID 1px #777777; margin-top: 10px">
        <div class="Header" style="padding-left: 10px; padding-bottom: 3px">
            Select persons</div>
        <div style="border-top: solid 1px #777777; padding-bottom: 3px;">
            <asp:Panel runat="server" ID="pnlEmpty" Style="padding-left: 10px;">
                <span runat="server" id="spnEmpty" class="Input">No search done yet.</span></asp:Panel>
            <div style="background-color: #AAAAAA; border-bottom: solid 1px #777777; padding-left: 10px"
                runat="server" id="pageHeader" visible="false" class="ItemStyle ItemPaddingStyle">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>
                            Persons
                            <asp:Literal runat="server" ID="ltStart"></asp:Literal>
                            -
                            <asp:Literal runat="server" ID="ltEnd"></asp:Literal>
                            of
                            <asp:Literal runat="server" ID="ltTotal"></asp:Literal>
                        </td>
                        <td align="right" style="padding-right: 10px;">
                            <asp:LinkButton runat="server" ID="lnkPrev" Text="Prev" Enabled="false" OnClick="PrevClicked"></asp:LinkButton>&nbsp;Pages:<asp:DropDownList
                                runat="server" ID="drpPages" AutoPostBack="true" Width="50px" OnSelectedIndexChanged="PageIndexChanged">
                            </asp:DropDownList>
                            &nbsp;<asp:LinkButton runat="server" ID="lnkNext" Text="Next" OnClick="NextClicked" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Repeater ID="rptPersons" runat="server" OnItemDataBound="PersonBound" Visible="false">
                <ItemTemplate>
                    <div style="padding-left: 10px;">
                        <asp:CheckBox CssClass="Input" runat="server" ID="chkSelect" AutoPostBack="true"
                            OnCheckedChanged="SelectUnSelectPerson" /></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div style="background-color: #DDDDDD; padding-left: 10px;">
                        <asp:CheckBox CssClass="Input" runat="server" ID="chkSelect" AutoPostBack="true"
                            OnCheckedChanged="SelectUnSelectPerson" /></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div style="height: 100px; overflow: auto; border: SOLID 1px #777777; margin-top: 10px">
        <div class="Header" style="padding-left: 10px; padding-bottom: 3px">
            Selected persons</div>
        <div style="border-top: solid 1px #777777; padding-left: 10px; padding-bottom: 3px;
            padding-top: 3px">
            <span runat="server" class="Input" id="spnSelectedPersons"></span>
        </div>
        <input type="hidden" runat="server" id="hdnSelectedPersonIds" value="" />
    </div>
    <div style="border-top: SOLID 1px #777777; margin-top: 10px; padding-left: 10px;
        padding-top: 5px; padding-bottom: 5px">
        <input type="button" value="OK" style="width: 60px;" onclick="SelectPersons()" /></div>
    </form>
</body>
</html>
