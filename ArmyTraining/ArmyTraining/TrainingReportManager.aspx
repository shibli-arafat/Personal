<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TrainingReportManager.aspx.cs"
    Inherits="ArmyTraining.TrainingReportManager" Title="Training report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Training report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
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
        <div style="border: solid 1px #777777; padding: 5px 8px;" class="ItemStyle">
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
                    <td>
                        Date from
                    </td>
                    <td>
                        <input type="text" id="txtStartDate" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Date to
                    </td>
                    <td>
                        <input type="text" id="txtEndDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Duration
                    </td>
                    <td>
                        <asp:TextBox ID="txtDuration" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdEquelTo" Text="Equal to" runat="server" GroupName="Duration" />
                        <asp:RadioButton ID="rdUpto" Checked="true" Text="Up to" runat="server" GroupName="Duration" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDurationType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" AutoPostBack="true" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Sponsor country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSponsorCountry" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Personal No
                    </td>
                    <td>
                        <input type="text" id="txtTrainee" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Rank
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRank" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Course type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourseType" OnSelectedIndexChanged="ddlCourseType_SelectedIndexChanged"
                            runat="server" AutoPostBack="true" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Course
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Training background
                    </td>
                    <td>
                        <asp:DropDownList ID="drpTrainingBkg" AutoPostBack="true" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Training level
                    </td>
                    <td>
                        <asp:DropDownList ID="drpTrainingLevel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Course level
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourseLevel" AutoPostBack="true" runat="server" />
                    </td>
                    <td>
                    </td>
                    <td>
                        Completion type
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
                     <td style="text-align: right;">
                        <asp:Button Text="Show Report" ID="btnShowReport" runat="server" OnClientClick="return validateData();"
                            OnClick="ShowReport" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
