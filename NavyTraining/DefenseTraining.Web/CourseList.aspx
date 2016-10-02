<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="DefenseTraining.Web.CourseList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Courses
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            loadEventTypes();
        });

        function loadEventTypes() {
            $.ajax({
                type: "POST",
                url: "EventTypeList.aspx/GetEventTypes",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbEventTypes");
                        options.append($("<option />").val(0).text("All"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.Name));
                        });
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

        function doSearch() {
            $.ajax({
                type: "POST",
                url: "CourseList.aspx/GetCourses",
                data: JSON.stringify({ eventTypeId: $("#cmbEventTypes").val(), keyword: $("#txtKeyword").val() }),
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
            var wTitle = "Edit Course [" + id + "]";
            if (id === 0) {
                wTitle = "New Course";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "CourseEdit.aspx?Id=" + id,
                height: 300,
                width: 330,
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
                    url: "CourseList.aspx/DeleteCourse",
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
                ${Name}
            </td>
            <td>
                ${EventType.Name}
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
        <div style="min-height: 410px;">
            <input type="button" value="Add New" onclick="openWindow(0)" />
            <div class="searchPanel" style="margin-top: 4px;">
                <table border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td style="padding-left: 10px;">
                            Course Type
                        </td>
                        <td>
                            <select id="cmbEventTypes">
                            </select>
                        </td>
                        <td style="padding-left: 10px;">
                            Keyword
                        </td>
                        <td>
                            <input type="text" id="txtKeyword" />
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
                            <th width="45%">
                                Course
                            </th>
                            <th width="45%">
                                Course Type
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
