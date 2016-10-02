<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DefenseTraining.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    Dashboard
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            doSearch();
        });

        setInterval("doSearch()", 60 * 1000);

        function doSearch() {
            loadReminders();
        }

        function loadReminders() {
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetReminders",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var reminders = data.d.Data;
                        populateReminders(reminders);
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

        function populateReminders(reminders) {
            $("#reminderContainer > tbody").empty();
            $("#tmplReminder").tmpl(reminders).appendTo("#reminderContainer > tbody");
        }

        function openWindow(id) {
            var wTitle = "Edit Event [" + id + "]";
            $.window({
                showModal: true,
                title: wTitle,
                url: "EventEdit.aspx?Id=" + id,
                height: 420,
                width: 550,
                resizable: false,
                maximizable: false,
                bookmarkable: false,
                showRoundCorner: true
            });
        }

        function dismissData(eventId, remindFor) {
            if (confirm("Are you sure you want to dismiss this reminder?") == true) {
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/DismissReminder",
                    data: JSON.stringify({ eventId: eventId, remindFor: remindFor }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            loadReminders();
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
    <script id="tmplReminder" type="text/html">
        <tr>
            <td>
                ${CourseName}
            </td>
            <td>
                ${StartDate} - ${EndDate}
            </td>
            <td>
                ${RemindFor}
            </td>
            <td>
                ${ActionsNeeded}
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/DeleteIcon.jpg" alt="Delete" style="cursor: pointer" tr-id="${TrainingId}" rem-for="${RemindFor}" title="Delete" onclick="dismissData(this);"/>
            </td>
        </tr>
    </script>
    <div style="min-height: 400px;">
        <label for="reminderContainer">
            You have the following actions pending
        </label>
        <table class="itemTable" id="reminderContainer">
            <thead>
                <tr>
                    <th style="width: 20%;">
                        Training
                    </th>
                    <th style="width: 15%;">
                        When
                    </th>
                    <th style="width: 25%;">
                        Remind For
                    </th>
                    <th style="width: 35%;">
                        Actions Needed
                    </th>
                    <th style="text-align: center; width: 5%;">
                        Dismiss
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
</asp:Content>
