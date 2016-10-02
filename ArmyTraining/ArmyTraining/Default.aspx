<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArmyTraining._Default"
    MasterPageFile="~/Main.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="header">
    Welcome to Overseas Training Information</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageContent" ID="content">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <div style="border: solid 1px #777777">
                    <div style="padding: 5px 10px; border-bottom: solid 1px #777777; background-color: Silver;
                        font-weight: bold;">
                        Ongoing trainings
                    </div>
                    <div style="overflow: auto; height: 100px;">
                        <asp:Repeater ID="rptOngoingTrainings" runat="server">
                            <HeaderTemplate>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <col width="38%" />
                                    <col width="15%" />
                                    <col width="25px" />
                                    <col width="10%" />
                                    <col width="10%" />
                                    <tr>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                            Course
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Country
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Trainees
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Start date
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            End date
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CourseName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CountryName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).TraineeInfos%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).StartDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).EndDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <span runat="server" id="emptyOngoingCell" class="ItemStyle" style="padding-left: 10px;
                            padding-right: 10px; padding-top: 3px;">There are no any Ongoing training right
                            now.</span>
                    </div>
                    <div style="text-align: right; border-top: solid 1px #777777; padding-top: 3px; padding-bottom: 3px;">
                        <a class="ItemStyle" href="TrainingList.aspx?completion=ongoing" style="padding-right: 10px;">
                            Show more </a><a class="ItemStyle" style="padding-right: 10px;" href="TrainingReportManager.aspx?completion=ongoing">
                                View report </a>
                    </div>
                </div>
                <div style="border: solid 1px #777777; margin-top: 10px">
                    <div style="padding: 5px 10px; border-bottom: solid 1px #777777; background-color: Silver;
                        font-weight: bold;">
                        Upcoming trainings
                    </div>
                    <div style="overflow: auto; height: 100px">
                        <asp:Repeater ID="rptUpcommings" runat="server">
                            <HeaderTemplate>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <col width="38%" />
                                    <col width="15%" />
                                    <col width="25px" />
                                    <col width="10%" />
                                    <col width="10%" />
                                    <tr>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                            Course
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Country
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Trainees
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Start date
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            End date
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CourseName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CountryName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).TraineeInfos%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).StartDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).EndDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <span runat="server" id="emptyCellUpcomming" class="ItemStyle" style="padding-left: 10px;
                            padding-right: 10px; padding-top: 3px;">There are no any Upcomming training offer
                            right now.</span>
                    </div>
                    <div style="text-align: right; border-top: solid 1px #777777; padding-top: 3px; padding-bottom: 3px;">
                        <a class="ItemStyle" href="TrainingList.aspx?completion=upcomming" style="padding-right: 10px;">
                            Show more</a><a class="ItemStyle" style="padding-right: 10px;" href="TrainingReportManager.aspx?completion=upcomming">View
                                report</a>
                    </div>
                </div>
                <div style="border: solid 1px #777777; margin-top: 10px">
                    <div style="padding: 5px 10px; border-bottom: solid 1px #777777; background-color: Silver;
                        font-weight: bold;">
                        Completed trainings
                    </div>
                    <div style="overflow: auto; height: 100px">
                        <asp:Repeater ID="rptCompleted" runat="server">
                            <HeaderTemplate>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <col width="38%" />
                                    <col width="15%" />
                                    <col width="25px" />
                                    <col width="10%" />
                                    <col width="10%" />
                                    <tr>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                            Course
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Country
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Trainees
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            Start date
                                        </td>
                                        <td class="Header ItemPaddingStyle" style="border-bottom: solid 1px #777777;">
                                            End date
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CourseName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CountryName%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).TraineeInfos%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).StartDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                    <td class="ItemPaddingStyle ItemStyle" style="border-bottom: solid 1px #777777;">
                                        <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).EndDate.ToString("dd/MM/yyyy")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <span runat="server" id="emptyCompleted" class="ItemStyle" style="padding-left: 10px;
                            padding-right: 10px; padding-top: 3px;">There are no any completed training right
                            now.</span>
                    </div>
                    <div style="text-align: right; border-top: solid 1px #777777; padding-top: 3px; padding-bottom: 3px;">
                        <a class="ItemStyle" href="TrainingList.aspx?completion=completed" style="padding-right: 10px;">
                            Show more</a><a class="ItemStyle" style="padding-right: 10px;" href="TrainingReportManager.aspx?completion=completed">View
                                report</a>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
