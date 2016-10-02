<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearlyBudgetManager.aspx.cs"
    Inherits="ArmyTraining.YearlyBudgetManager" MasterPageFile="~/Main.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    Yearly budgets</asp:Content>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="PageContent">
    <script language="javascript" type="text/javascript">
        detailUrl = "YearlyBudgetDetail.aspx";
        detailHeight = 160;
        detailWidth = 450;
    </script>
    <div>
        <div style="height: 530px; overflow: auto; border: solid 1px #777777;">
            <asp:Repeater runat="server" ID="rptYearlyBudgets" Visible="false" OnItemDataBound="ItemData_Bound">
                <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr style="background-color: Silver;">
                            <td style="width: 45%; border-bottom: solid 1px #777777; padding-left: 10px" class="Header">
                                Year
                            </td>
                            <td style="width: 45%; border-bottom: solid 1px #777777; text-align: center;" class="Header">
                                Budget
                            </td>
                            <td style="width: 5%; border-bottom: solid 1px #777777; padding-right: 2px; text-align: center;"
                                class="Header ItemPaddingStyle">
                                Edit
                            </td>
                            <td style="width: 5%; border-bottom: solid 1px #777777; padding-right: 2px; text-align: center;"
                                class="Header ItemPaddingStyle">
                                Delete
                            </td>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #DDDDDD">
                        <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                            <%#((ArmyTraining.Model.YearlyBudget)Container.DataItem).Year%> - <%#((ArmyTraining.Model.YearlyBudget)Container.DataItem).Year + 1%>
                        </td>
                        <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px;
                            text-align: right; padding-right: 220px;">
                            <%#string.Format("{0:0.00}", ((ArmyTraining.Model.YearlyBudget)Container.DataItem).Budget)%>
                        </td>
                        <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                                runat="server" ID="imgEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                        </td>
                        <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                                runat="server" ID="imgBtnDelete" Width="20px" Height="20px" OnClientClick="return confirm('Do you want to delete?');"
                                OnCommand="DeleteCommand" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                            <%#((ArmyTraining.Model.YearlyBudget)Container.DataItem).Year%> - <%#((ArmyTraining.Model.YearlyBudget)Container.DataItem).Year + 1%>
                        </td>
                        <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px;
                            text-align: right; padding-right: 220px;">
                            <%#string.Format("{0:0.00}", ((ArmyTraining.Model.YearlyBudget)Container.DataItem).Budget)%>
                        </td>
                        <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                                runat="server" ID="imgEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                        </td>
                        <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                                runat="server" ID="imgBtnDelete" Width="20px" Height="20px" OnClientClick="return confirm('Do you want to delete?');"
                                OnCommand="DeleteCommand" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <div id="spnEmptyRow" runat="server" class="ItemStyle" style="padding-left: 10px;
                padding-top: 5px; padding-right: 10px;">
                There are no budgets in the system.</div>
        </div>
        <div style="padding-top: 5px;">
            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70" OnClick="ItemEdited"
                OnClientClick="return OpenDetail(0)" />
            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" Width="90px" OnClick="btnShowReport_Click" />
        </div>
    </div>
</asp:Content>
