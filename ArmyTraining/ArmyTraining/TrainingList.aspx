<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TrainingList.aspx.cs" Inherits="ArmyTraining.TrainingList" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    Trainings
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="PageContent">
    <style type="text/css">
        input[type=text]
        {
            width: 200px;
            margin-bottom: 3px;
        }

        select
        {
            width: 204px;
            margin-bottom: 3px;
        }
    </style>
    <script src="js/general.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#<%=txtStartDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
            $('#<%=txtEndDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        });
        function validateData() {
            var dateFrom = document.getElementById("<%=txtStartDate.ClientID %>").value;
            var dateTo = document.getElementById("<%=txtEndDate.ClientID %>").value;
            var duration = document.getElementById("<%=txtDuration.ClientID %>").value;
            var errorMsg = "";
            if (dateFrom != "" && !isDate(dateFrom)) {
                errorMsg += "Please enter a valid start date\n";
            }
            if (dateTo != "" && !isDate(dateTo)) {
                errorMsg += "Please enter a valid end date\n";
            }
            if (duration != "" && !isNumeric(duration)) {
                errorMsg += "Please enter a valid duration\n";
            }
            if (errorMsg != "") {
                alert(errorMsg);
                return false;
            }
            return true;
        }
    </script>
    <div>
        <div style="border: solid 1px #777777; font-size: small; padding: 5px 10px;">
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <colgroup>
                    <col width="130px" />
                    <col width="200px" />
                    <col width="20px" />
                    <col width="150px" />
                    <col width="200px" />
                    <col />
                </colgroup>
                <tr>
                    <td>Date from
                    </td>
                    <td>
                        <input type="text" id="txtStartDate" runat="server" />
                    </td>
                    <td></td>
                    <td>Date to
                    </td>
                    <td>
                        <input type="text" id="txtEndDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Duration
                    </td>
                    <td>
                        <asp:TextBox ID="txtDuration" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:RadioButton ID="rdEquelTo" Text="Equal to" runat="server" GroupName="Duration" />
                        <asp:RadioButton ID="rdUpto" Checked="true" Text="Up to" runat="server" GroupName="Duration" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDurationType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" AutoPostBack="true" runat="server" />
                    </td>
                    <td></td>
                    <td>Sponsor country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSponsorCountry" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Personal No
                    </td>
                    <td>
                        <input type="text" id="txtTrainee" runat="server" />
                    </td>
                    <td></td>
                    <td>Rank
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRank" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Course type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourseType" OnSelectedIndexChanged="ddlCourseType_SelectedIndexChanged"
                            AutoPostBack="true" runat="server" />
                    </td>
                    <td></td>
                    <td>Course
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Training background
                    </td>
                    <td>
                        <asp:DropDownList ID="drpTrainingBkg" AutoPostBack="true" runat="server" />
                    </td>
                    <td></td>
                    <td>Training level
                    </td>
                    <td>
                        <asp:DropDownList ID="drpTrainingLevel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Course level
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourseLevel" AutoPostBack="true" runat="server" />
                    </td>
                    <td></td>
                    <td>Completion type
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCompletionType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Started in Year
                    </td>
                    <td>
                        <input type="text" id="txtYear" runat="server" />
                    </td>
                    <td></td>
                    <td>Training ID
                    </td>
                    <td>
                        <input type="text" id="txtTrainingId" runat="server" />
                    </td>
                    <td style="text-align: right">
                        <asp:Button runat="server" ID="btnSearch" OnClientClick="return validateData();"
                            OnClick="Search_Clicked" Text="Search" Width="80px" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 375px; overflow: auto; border: solid 1px #777777; margin-top: 3px;">
            <div style="background-color: #AAAAAA; border-bottom: solid 1px #777777; padding-left: 10px"
                runat="server" id="pageHeader" visible="false" class="ItemStyle ItemPaddingStyle">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>Trainings
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
                    <div>
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td style="width: 5%; border-bottom: solid 1px #777777; padding-left: 10px" class="Header">ID
                                </td>
                                <td style="width: 25%; border-bottom: solid 1px #777777;" class="Header ItemPaddingStyle">Course
                                </td>
                                <td style="width: 15%; border-bottom: solid 1px #777777;" class="Header ItemPaddingStyle">Country
                                </td>
                                <td style="width: 20%; border-bottom: solid 1px #777777;" class="Header ItemPaddingStyle">Trainees
                                </td>
                                <td style="width: 10%; border-bottom: solid 1px #777777; text-align: center;" class="Header ItemPaddingStyle">StartDate
                                </td>
                                <td style="width: 10%; border-bottom: solid 1px #777777; text-align: center;" class="Header ItemPaddingStyle">EndDate
                                </td>
                                <td style="width: 5%; border-bottom: solid 1px #777777; text-align: center" class="Header ItemPaddingStyle">Delete
                                </td>
                            </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table> </div>
                </FooterTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #DDDDDD">
                        <td class="Input ItemPaddingStyle" style="border-bottom: solid 1px #777777; padding-left: 10px">
                            <asp:LinkButton ID="lnkEdit" runat="server" OnClick="ItemEditClicked"><%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).Id%></asp:LinkButton>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CourseName%>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CountryName%>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).TraineeInfos%>
                        </td>
                        <td style="border-bottom: solid 1px #777777; text-align: center;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).StartDate.ToString("dd/MM/yyyy")%>
                        </td>
                        <td style="border-bottom: solid 1px #777777; text-align: center;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).EndDate.ToString("dd/MM/yyyy")%>
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
                            <asp:LinkButton ID="lnkEdit" runat="server" OnClick="ItemEditClicked"><%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).Id%></asp:LinkButton>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CourseName%>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).CountryName%>
                        </td>
                        <td style="border-bottom: solid 1px #777777;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).TraineeInfos%>
                        </td>
                        <td style="border-bottom: solid 1px #777777; text-align: center;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).StartDate.ToString("dd/MM/yyyy")%>
                        </td>
                        <td style="border-bottom: solid 1px #777777; text-align: center;" class="Input ItemPaddingStyle">
                            <%#((ArmyTraining.Model.Trainings.TrainingInfo)Container.DataItem).EndDate.ToString("dd/MM/yyyy")%>
                        </td>
                        <td class="ItemPaddingStyle" style="border-bottom: solid 1px #777777; text-align: center;">
                            <asp:ImageButton ImageAlign="AbsMiddle" ToolTip="Delete" CommandName="Delete" ImageUrl="~/images/DeleteIcon.jpg"
                                OnClientClick="return confirm('Do you want to delete?');" runat="server" ID="imgBtnDelete"
                                Width="20px" Height="20px" OnCommand="DeleteCommand" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <div id="spnEmptyRow" runat="server" class="ItemStyle" style="padding-left: 10px; padding-top: 5px; padding-right: 10px;"
                visible="false">
                There are no traing found.
            </div>
            <div id="spnNoSearch" runat="server" class="ItemStyle" style="padding-left: 10px; padding-top: 5px; padding-right: 10px;">
                No search done yet.
            </div>
        </div>
    </div>
</asp:Content>
