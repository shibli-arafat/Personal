<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="ArmyTraining.PersonList"
    MasterPageFile="~/Main.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    Persons</asp:Content>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="PageContent">
    <script language="javascript" type="text/javascript">
        detailUrl = "PersonDetail.aspx";
        detailHeight = 510;
        detailWidth = 500;
    </script>
    <div style="border: SOLID 1px #777777; padding: 5px 10px">
        <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td style="width: 20%">
                    Person Number
                </td>
                <td style="width: 30%">
                    <asp:TextBox runat="server" ID="txtPersonNo" />
                </td>
                <td style="width: 20%">
                    Keywords (rank/name)
                </td>
                <td style="width: 30%">
                    <asp:TextBox runat="server" ID="txtKeyword" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" Text="Search" Width="80px" OnClick="Search" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 490px; overflow: auto; border: solid 1px #777777; margin-top: 3px;">
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
        <asp:Repeater runat="server" ID="rptCourses" Visible="false" OnItemDataBound="ItemData_Bound">
            <HeaderTemplate>
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td style="width: 15%; border-bottom: solid 1px #777777; padding-left: 10px" class="Header">
                            Personal No
                        </td>
                        <td style="width: 20%; border-bottom: solid 1px #777777;" class="Header ItemPaddingStyle">
                            Rank
                        </td>
                        <td style="width: 40%; border-bottom: solid 1px #777777; padding-left: 10px" class="Header">
                            Name
                        </td>
                        <td style="width: 15%; border-bottom: solid 1px #777777;" class="Header ItemPaddingStyle">
                            Service type
                        </td>
                        <td style="width: 5%; border-bottom: solid 1px #777777; text-align: center;" class="Header ItemPaddingStyle">
                            Edit
                        </td>
                        <td style="width: 5%; border-bottom: solid 1px #777777; text-align: center;" class="Header ItemPaddingStyle">
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
                        <%#((ArmyTraining.Model.Person)Container.DataItem).PersonNumber%>
                    </td>
                    <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Rank.Name%>
                    </td>
                    <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Name%>
                    </td>
                    <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Service.Name%>
                    </td>
                    <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                        <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                            runat="server" ID="imgEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                    </td>
                    <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                        <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                            OnClientClick="return confirm('Do you want to delete?');" runat="server" ID="imgBtnDelete"
                            Width="20px" Height="20px" OnCommand="DeleteCommand" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr>
                    <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).PersonNumber%>
                    </td>
                    <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Rank.Name%>
                    </td>
                    <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Name%>
                    </td>
                    <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                        <%#((ArmyTraining.Model.Person)Container.DataItem).Service.Name%>
                    </td>
                    <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                        <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Edit" ImageUrl="~/images/EditIcon.jpg"
                            runat="server" ID="imgEdit" Width="20px" Height="20px" OnClick="ItemEdited" />
                    </td>
                    <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                        <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                            OnClientClick="return confirm('Do you want to delete?');" runat="server" ID="imgBtnDelete"
                            Width="20px" Height="20px" OnCommand="DeleteCommand" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <div id="spnEmptyRow" runat="server" class="ItemStyle" style="padding-left: 10px;
            padding-top: 5px; padding-right: 10px;" visible="false">
            There are no person in the system.</div>
        <div id="spnNoSearch" runat="server" class="ItemStyle" style="padding-left: 10px;
            padding-top: 5px; padding-right: 10px;">
            No search done yet.</div>
    </div>
    <div style="padding-top: 5px;">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70" OnClick="ItemEdited"
            OnClientClick="return OpenDetail(0)" />
    </div>
</asp:Content>
