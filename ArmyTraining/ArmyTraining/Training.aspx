<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="ArmyTraining.Training"
    MasterPageFile="~/Main.Master" %>

<asp:Content ID="content" ContentPlaceHolderID="PageContent" runat="server">
    <style type="text/css">
        .header
        {
            font-family: Verdana;
            font-weight: bold;
        }
        .button
        {
            width: 80px;
            height: 20px;
            font-size: 8;
            font-family: Verdana;
            background-color: #CCCCCC;
            border-style: outset;
            border-width: 1px;
            border-color: #AAAAAA;
        }
        .buttonSelected
        {
            width: 80px;
            height: 20px;
            font-size: 8;
            font-family: Verdana;
            background-color: #555555;
            border-style: outset;
            border-width: 1px;
            border-color: #222222;
        }
        .textInput
        {
            width: 150px;
            font-family: Verdana;
            border-color: #777777;
        }
    </style>
    <div>
        <div>
            <asp:Button runat="server" ID="btnGeneral" CssClass="buttonSelected" CommandArgument="0"
                OnClick="ViewChange" Text="General" />
            <asp:Button runat="server" ID="btnTrainee" CssClass="button" CommandArgument="1"
                OnClick="ViewChange" Text="Trainee" />
            <asp:Button runat="server" ID="btnBudget" CssClass="button" CommandArgument="2" OnClick="ViewChange"
                Text="Budget" />
            <asp:Button runat="server" ID="btnFlow" CssClass="button" CommandArgument="3" OnClick="ViewChange"
                Text="Flow" />
        </div>
        <div>
            <asp:MultiView runat="server" ID="mvTraining" ActiveViewIndex="0">
                <asp:View ID="viewGeneral" runat="server">
                    <div style="overflow: auto; height: 400px;">
                        <table>
                            <colgroup>
                                <col width="120px" />
                                <col width="120px" />
                                <col width="120px" />
                            </colgroup>
                            <tr>
                                <td valign="top">
                                    <div>
                                        Course Type</div>
                                    <div>
                                        <asp:DropDownList runat="server" ID="drpCourseType" Width="100px" AutoPostBack="true"
                                            DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="CourseTypeIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div>
                                        Course</div>
                                    <div>
                                        <asp:DropDownList runat="server" ID="drpCourse" Width="100px" AutoPostBack="true"
                                            DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="CourseIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td valign="top">
                                    <div>
                                        Country</div>
                                    <div>
                                        <asp:DropDownList runat="server" ID="drpCountry" DataTextField="Name" DataValueField="Id"
                                            Width="100px">
                                        </asp:DropDownList>
                                    </div>
                                    <div>
                                        Sponsor</div>
                                    <div>
                                        <asp:DropDownList runat="server" ID="droSponsorCountry" Width="100px" DataTextField="Name"
                                            DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        Start date</div>
                                    <div>
                                        <asp:Calendar Height="100" ID="srartDate" runat="server"></asp:Calendar>
                                    </div>
                                    <div>
                                        End date</div>
                                    <div>
                                        <asp:Calendar ID="endDate" runat="server"></asp:Calendar>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div>
                                        Prerequisites</div>
                                    <div>
                                        <asp:TextBox runat="server" ID="txtPreRequisites" TextMode="MultiLine"></asp:TextBox></div>
                                </td>
                                <td valign="top">
                                    <div>
                                        Remarks</div>
                                    <div>
                                        <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine"></asp:TextBox></div>
                                </td>
                                <td valign="top">
                                    <div>
                                        Status</div>
                                    <div>
                                        <asp:DropDownList ID="drpStatus" runat="server" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <asp:View ID="viewTranee" runat="server">
                    <div>
                        Trainee</div>
                </asp:View>
                <asp:View ID="viewBudget" runat="server">
                    <div>
                        Expences
                    </div>
                    <div>
                        <span>Budget 1</span><asp:TextBox ID="txtBudgetYear1" runat="server"></asp:TextBox><asp:TextBox
                            runat="server" ID="txtExpense1"></asp:TextBox>
                    </div>
                    <div>
                        <span>Budget 2</span><asp:TextBox ID="txtBudgetYear2" runat="server"></asp:TextBox><asp:TextBox
                            runat="server" ID="txtExpense2"></asp:TextBox>
                    </div>
                    <div>
                        <span>Budget 2</span><asp:TextBox ID="txtBudgetYear3" runat="server"></asp:TextBox><asp:TextBox
                            runat="server" ID="txtExpense3"></asp:TextBox>
                    </div>
                    <div>
                        Additional Expences</div>
                    <div>
                        <span id="spnPlaneFair" runat="server">Plane fare</span><input type="radio" runat="server" name="expenceChoice1"
                            id="choice1Bangladesh" />Bangladesh<input id="choice1Training" type="radio" runat="server"
                                name="expenceChoice1" />Training<input id="choise1Sponsor" type="radio"
                                    runat="server" name="expenceChoice1" />Sponsor
                    </div>
                    <div>
                        <span id="spnAllownce" runat="server">Allownce</span><input type="radio" runat="server" name="expenceChoice2" value="Bangladesh"
                            id="choice2Bangladesh" />Bangladesh<input id="choice2Training" type="radio" runat="server"
                                name="expenceChoice2"  />Training<input id="choise2Sponsor" type="radio"
                                    runat="server" name="expenceChoice2" />Sponsor
                    </div>
                </asp:View>
                <asp:View ID="viewFlow" runat="server">
                    <div>
                    <div>Activities on current status</div>
                    <div>
                    <asp:Repeater runat="server" ID="rptActivities">
                    <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                    <td>Name</td>
                    <td></td>
                    <td>Remarks</td>
                    </tr>
                    </HeaderTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    </asp:Repeater>
                    </div>
                    <div>
                    Activities
                    </div>
                    <div>
                    <asp:Repeater runat="server" ID="rptActions">
                    <ItemTemplate>
                    <span runat="server" id="spnAction"></span>
                    </ItemTemplate>
                    </asp:Repeater>
                    </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
        <div>
            <asp:Button runat="server" ID="btnOk" Text="OK" OnClick="Ok_Clicked" /></div>
    </div>
</asp:Content>
