<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainingTraineeControl.ascx.cs"
    Inherits="ArmyTraining.Controls.TrainingTraineeControl" %>
<script language="javascript" type="text/javascript">

    function AssignPersons() {
        var url = "PersonSelector.aspx";
        url += "?rnd=" + Math.random().toString();
        var persons = window.showModalDialog(url, window, "dialogWidth:400px;dialogHeight:565px;status:no;resizable:no;scroll:no;");
        if (persons == null || persons == '') return false;
        document.getElementById('<%= hdnAddedPersons.ClientID %>').value = persons;
        return true;
    }

    function UpdatePersonDoc(personId, file) {
        document.getElementById('<%= hdnSelectedPerson.ClientID %>').value = personId;
        document.getElementById('<%= hdnSelectedDoc.ClientID %>').value = file;
        return true;
    }

    function ValidateTraineeData() {
    }
</script>
<style type="text/css">
    .ItemPaddingStyle
    {
        padding-top: 3px;
        padding-bottom: 3px;
    }
    .Header
    {
        font-size: small;
        font-weight: bold;
        margin-top: 5px;
    }
    .ItemStyle
    {
        font-size: small;
    }
    .TraineeInput
    {
        width: 100%;
    }
</style>
<div style="height: 350px; overflow: auto; border: SOLID 1px #777777;">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:Repeater runat="server" ID="rptTranees" OnItemDataBound="TraneeDataBinding">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <colgroup>
                    <col width="40%" />
                    <col width="10%" />
                    <col width="10%" />
                    <col width="15%" />
                    <col width="15%" />
                    <col width="10%" />
                    <col />
                </colgroup>
                <tr style="border-top: SOLID 1px Black">
                    <td class="ItemPaddingStyle Header" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                        Person
                    </td>
                    <td class="ItemPaddingStyle Header" style="border-bottom: SOLID 1px BLACK; padding-right: 10px"
                        align="right">
                        Expenditure Army
                    </td>
                    <td class="ItemPaddingStyle Header" style="border-bottom: SOLID 1px BLACK; padding-right: 10px"
                        align="right">
                        Expenditure Other
                    </td>
                    <td class="ItemPaddingStyle Header" style="border-bottom: SOLID 1px BLACK; padding-right: 10px">
                        Sponsor
                    </td>
                    <td class="ItemPaddingStyle Header" align="left" style="border-bottom: SOLID 1px BLACK;
                        padding-right: 10px">
                        Attached File
                    </td>
                    <td class="ItemPaddingStyle Header" align="center" style="border-bottom: SOLID 1px BLACK;
                        padding-right: 10px">
                        Change/Attach File
                    </td>
                    <td class="ItemPaddingStyle Header" align="center" style="border-bottom: SOLID 1px BLACK;
                        padding-right: 10px">
                        Delete
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #dddddd;">
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                    <span runat="server" class="ItemStyle" id="spnTrainees"></span>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox runat="server" ID="txtExpenditure" CssClass="TraineeInput"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox runat="server" ID="txtOtherExpenditure" CssClass="TraineeInput"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox runat="server" ID="txtSponsor" CssClass="TraineeInput"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" align="left" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <a id="lnkFile" runat="server"></a>
                </td>
                <td class="ItemPaddingStyle" align="center" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <asp:Button runat="server" Text="Select" ID="btnAttachFile" OnClientClick="return OpenFileSelector(this);"
                        OnClick="UpdateAttachedFile" />
                </td>
                <td class="ItemPaddingStyle" align="center" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <asp:ImageButton runat="server" ID="imgBtnDelete" OnClick="RemovePerson" ImageUrl="~/images/DeleteIcon.jpg"
                        Width="20" Height="20" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                    <span runat="server" class="ItemStyle" id="spnTrainees"></span>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox CssClass="TraineeInput" runat="server" ID="txtExpenditure"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox runat="server" ID="txtOtherExpenditure" CssClass="TraineeInput"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;"
                    align="right">
                    <asp:TextBox runat="server" ID="txtSponsor" CssClass="TraineeInput"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" align="left" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <a id="lnkFile" runat="server"></a>
                </td>
                <td class="ItemPaddingStyle" align="center" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <asp:Button runat="server" Text="Select" ID="btnAttachFile" OnClientClick="return OpenFileSelector(this);"
                        OnClick="UpdateAttachedFile" />
                </td>
                <td class="ItemPaddingStyle" align="center" style="border-bottom: SOLID 1px BLACK;
                    padding-right: 10px">
                    <asp:ImageButton runat="server" ID="imgBtnDelete" OnClick="RemovePerson" ImageUrl="~/images/DeleteIcon.jpg"
                        Width="20" Height="20" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div style="padding-top: 5px;">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <input type="hidden" runat="server" id="hdnAddedPersons" />
                <asp:Button runat="server" ID="btnAdd" Text="Add new trainees" OnClientClick="return AssignPersons()"
                    OnClick="AddTrainees" />
            </td>
            <td align="right" class="ItemStyle">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        Balance:&nbsp;<span style="font-weight: bold"><asp:Literal ID="ltBalance" runat="server"></asp:Literal></span>&nbsp;<asp:Button
                            runat="server" ID="checkBalance" Text="Check" OnClick="CheckBalance" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
<input type="hidden" runat="server" id="hdnSelectedPerson" value="0" />
<input type="hidden" runat="server" id="hdnSelectedDoc" value="" />
