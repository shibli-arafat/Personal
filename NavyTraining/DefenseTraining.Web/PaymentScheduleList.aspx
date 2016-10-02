<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PaymentScheduleList.aspx.cs" Inherits="DefenseTraining.Web.PaymentScheduleList" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Persons
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function doSearch() {
            populateData();
            $(".date-picker").datepicker({ dateFormat: "dd M yy" })
        }

        function populateData() {
            $.ajax({
                type: "POST",
                url: "PaymentScheduleList.aspx/GetPaymentSchedules",
                data: JSON.stringify({ dateFrom: $("#txtDateFrom").val(), dateTo: $("#txtDateTo").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#dataContainer > tbody").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#dataContainer > tbody");
                    }
                    else {
                        alert(data.d.ErrorMessage);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }

        function openWindow(id) {
            var wTitle = "Edit Payment [" + id + "]";
            if (id === 0) {
                wTitle = "New Payment";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "PaymentScheduleEdit.aspx?id=" + id + "&trainingId=0",
                height: 400,
                width: 340,
                resizable: false,
                maximizable: false,
                bookmarkable: false,
                showRoundCorner: true
            });
        }

        function deleteData(id) {
            if (confirm("Are you sure you want to delete this record?") == true) {
                $.ajax({
                    type: "POST",
                    url: "PaymentScheduleList.aspx/DeletePaymentSchedule",
                    data: JSON.stringify({ id: id }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            populateData();
                        }
                        else {
                            alert(data.d.ErrorMessage);
                        }
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });
            }
        }
    </script>
    <script id="tmplData" type="text/html">
        <tr>
            <td>
                ${CourseName}
            </td>
            <td>
                ${StartDate}
            </td>
            <td>
                ${EndDate}
            </td>
            <td>
                ${PaymentDate}
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/EditIcon.jpg" alt="Edit" style="cursor: pointer" title="Edit" onclick="openWindow(${Id});"/>
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/DeleteIcon.jpg" alt="Delete" style="cursor: pointer" title="Delete" onclick="deleteData(${Id});"/>
            </td>
        </tr>
    </script>
    <div>
        <div style="min-height: 400px;">
            <div class="searchPanel" style="margin-top: 4px;">
                <table border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td style="padding-left: 10px;">
                            Date From
                        </td>
                        <td>
                            <input type="text" id="txtDateFrom" class="date-picker" maxlength="16" />
                        </td>
                        <td style="padding-left: 10px;">
                            Date To
                        </td>
                        <td>
                            <input type="text" id="txtDateTo" class="date-picker" maxlength="128" />
                        </td>
                        <td style="padding-left: 10px;">
                            <input type="button" value="Search" onclick="doSearch();" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 4px;">
                <table class="itemTable" id="dataContainer">
                    <thead>
                        <tr>
                            <th width="10%">
                                Course
                            </th>
                            <th width="30%">
                                Start Date
                            </th>
                            <th width="15%">
                                End Date
                            </th>
                            <th width="20%">
                                Payment Date
                            </th>
                            <th width="5%" style="text-align: center;">
                                Edit
                            </th>
                            <th width="5%" style="text-align: center;">
                                Delete
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
