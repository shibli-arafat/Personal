<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainingBudgetControl.ascx.cs"
    Inherits="ArmyTraining.Controls.TrainingBudgetControl" %>

<div style="height: 350px; overflow: auto; border: SOLID 1px #777777;">    <asp:Repeater runat="server" ID="rptAdditionalBudgets" OnItemDataBound="OnAdditionalBudgetsBound">
        <HeaderTemplate>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <colgroup>
                    <col width="40%;" />
                    <col width="40%;" />
                    <col width="10%;" />
                    <col width="10%" />
                </colgroup>
                <tr>
                    <td class="Header ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                        Name
                    </td>
                    <td class="Header ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                        Sponsor Country
                    </td>
                    <td class="Header ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                        Remarks
                    </td>
                    <td class="Header ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-right: 10px;">
                        Delete
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                    <asp:TextBox CssClass="Input" runat="server" ID="txtName"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                    <asp:RadioButtonList ID="rdbList" runat="server" RepeatDirection="Horizontal" CssClass="ItemStyle">
                        <asp:ListItem Text="Bangladesh" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Sponsor" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Trainer" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                    <asp:TextBox CssClass="Input" runat="server" ID="txtRemarks"></asp:TextBox>
                </td>
                <td style="border-bottom: SOLID 1px BLACK; padding-right: 10px;text-align:right" class="ItemPaddingStyle ItemStyle">
                    <asp:ImageButton runat="server" ID="imgBtnDelete" OnClick="DeleteAdditionalBudgetInfo" Height="20"
                        Width="20" ImageUrl="~/images/DeleteIcon.jpg" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK; padding-left: 10px;">
                    <asp:TextBox CssClass="Input" runat="server" ID="txtName"></asp:TextBox>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                    <asp:RadioButtonList ID="rdbList" runat="server" RepeatDirection="Horizontal" CssClass="ItemStyle">
                        <asp:ListItem Text="Bangladesh" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Sponsor" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Trainer" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="ItemPaddingStyle" style="border-bottom: SOLID 1px BLACK;">
                    <asp:TextBox CssClass="Input" runat="server" ID="txtRemarks"></asp:TextBox>
                </td>
                <td style="border-bottom: SOLID 1px BLACK; padding-right: 10px;text-align:right" class="ItemPaddingStyle ItemStyle">
                    <asp:ImageButton runat="server" ID="imgBtnDelete" OnClick="DeleteAdditionalBudgetInfo" Height="20"
                        Width="20" ImageUrl="~/images/DeleteIcon.jpg" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div style="padding-top: 5px;">
    <asp:Button runat="server" ID="btnAddAdditionalExpence" Text="Add new additional expences" OnClick="AddAdditionalBudgetInfo" />
</div>
