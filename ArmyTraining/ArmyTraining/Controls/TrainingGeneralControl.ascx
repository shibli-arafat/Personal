<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainingGeneralControl.ascx.cs"
    Inherits="ArmyTraining.Controls.TrainingGeneralControl" %>
<style type="text/css">
    .DropDown
    {
        width: 200px;
        font-size: small;
        margin-top: 5px;
    }
    .Header
    {
        font-size: small;
        font-weight: bold;
        margin-top: 5px;
    }
    .Input
    {
        font-size: small;
        width: 200px;
        margin-top: 5px;
    }
    .MultiLine
    {
        height: 100px;
    }
</style>
<script type="text/javascript">
    $(function () {
        $('#<%=txtStartDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtEndDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
    });

    function openCourseDetail() {
        var url = "CourseDetail.aspx";
        url += "?rnd=" + Math.random().toString() + "&ID=0";
        var course = window.showModalDialog(url, window, "dialogWidth:400px;dialogHeight:650px;status:no;resizable:no;scroll:no;");
        if (course == null || course == '') return false;
        return true;
    }
</script>
<div style="overflow: auto; height: 385px; border: SOLID 1px #777777; border-bottom-width: 0px;
    padding-left: 10px; padding-right: 10px">
    <table>
        <colgroup>
            <col width="260px" />
            <col width="200px" />
            <col width="200px" />
        </colgroup>
        <tr>
            <td valign="top">
                <div class="Header">
                    Course Type
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="drpCourseType" AutoPostBack="true" CssClass="DropDown"
                        DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="CourseTypeChanged" />
                </div>
                <div class="Header">
                    Course
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="drpCourse" AutoPostBack="true" CssClass="DropDown"
                        DataTextField="Name" DataValueField="Id" />
                    <asp:Button ID="btnAddCourse" Text="New" runat="server" OnClientClick="return openCourseDetail();"
                        OnClick="CourseTypeChanged" />
                </div>
            </td>
            <td valign="top">
                <div class="Header">
                    Country
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="drpCountry" DataTextField="Name" DataValueField="Id"
                        CssClass="DropDown" />
                </div>
                <div class="Header">
                    Sponsor
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="droSponsorCountry" DataTextField="Name" CssClass="DropDown"
                        DataValueField="Id" />
                </div>
            </td>
            <td valign="top">
                <div class="Header">
                    Start date
                </div>
                <div>
                    <asp:TextBox CssClass="Input" runat="server" ID="txtStartDate" />
                </div>
                <div class="Header">
                    End date
                </div>
                <div>
                    <asp:TextBox CssClass="Input" runat="server" ID="txtEndDate" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div class="Header">
                    Training level
                </div>
                <div>
                    <asp:DropDownList ID="ddlTrainingLevel" runat="server" CssClass="DropDown" />
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div class="Header">
                    Prerequisites
                </div>
                <div>
                    <asp:TextBox runat="server" CssClass="Input MultiLine" ID="txtPreRequisites" TextMode="MultiLine"></asp:TextBox></div>
            </td>
            <td valign="top">
                <div class="Header">
                    Remarks
                </div>
                <div>
                    <asp:TextBox runat="server" ID="txtRemarks" CssClass="Input MultiLine" TextMode="MultiLine"></asp:TextBox></div>
            </td>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
