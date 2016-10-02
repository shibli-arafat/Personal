<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DecorationManager.aspx.cs"
    Inherits="ArmyTraining.DecorationManager" MasterPageFile="~/Main.Master" EnableEventValidation="false" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    Decorations</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageContent" ID="content">
    <script language="javascript" type="text/javascript">
        detailUrl = "DecorationDetail.aspx";
        detailHeight = 120;
        detailWidth = 380;
    </script>
    <div>
        <div style="height: 530px; overflow: auto; border: solid 1px #777777">
            <asp:Repeater runat="server" ID="rptCommissions" Visible="false" OnItemDataBound="ItemData_Bound">
                <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <colgroup>
                            <col width="90%" />
                            <col width="5%" />
                            <col width="5%" />
                        </colgroup>
                        <tr style="background-color: Silver;">
                            <td class="Header ItemPaddingStyle" style="padding-left: 10px; border-bottom: solid 1px #777777">
                                Name
                            </td>
                            <td class="Header ItemPaddingStyle" align="center" style="border-bottom: solid 1px #777777">
                                Edit
                            </td>
                            <td class="Header ItemPaddingStyle" align="center" style="border-bottom: solid 1px #777777;">
                                Delete
                            </td>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #DDDDDD">
                        <td class="Input ItemPaddingStyle" style="padding-left: 10px; border-bottom: solid 1px #777777">
                            <%#((ArmyTraining.Model.Decoration)Container.DataItem).Name%>
                        </td>
                        <td align="center" class="ItemPaddingStyle" style="border-bottom: solid 1px #777777">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                                runat="server" ID="imgBtnEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                        </td>
                        <td align="center" class="ItemPaddingStyle" style="border-bottom: solid 1px #777777">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                                OnClientClick="return confirm('Do you want to delete?');" runat="server" ID="imgBtnDelete"
                                Width="20px" Height="20px" OnCommand="DeleteCommand" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="Input ItemPaddingStyle" style="padding-left: 10px; border-bottom: solid 1px #777777">
                            <%#((ArmyTraining.Model.Decoration)Container.DataItem).Name%>
                        </td>
                        <td align="center" class="ItemPaddingStyle" style="border-bottom: solid 1px #777777">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                                runat="server" ID="imgBtnEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                        </td>
                        <td align="center" class="ItemPaddingStyle" style="border-bottom: solid 1px #777777">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                                OnClientClick="return confirm('Do you want to delete?');" runat="server" ID="imgBtnDelete"
                                Width="20px" Height="20px" OnCommand="DeleteCommand" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <div id="spnEmptyRow" runat="server" class="ItemStyle" style="padding-left: 10px;
                padding-top: 5px; padding-right: 10px;">
                There are no commision in the system.</div>
        </div>
        <div style="padding-top: 5px;">
            <asp:Button runat="server" ID="btnAdd" OnClick="ItemEdited" OnClientClick="return OpenDetail(0)"
                Text="Add" Width="70" />
        </div>
    </div>
</asp:Content>
