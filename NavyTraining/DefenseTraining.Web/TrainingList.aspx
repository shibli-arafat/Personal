<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TrainingList.aspx.cs" Inherits="DefenseTraining.Web.TrainingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Trainings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" media="screen" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.paginate.js" type="text/javascript"></script>
    <style type="text/css">
        .demo
        {
            text-align: center;
            background-image: url("Styles/images/ui-bg_highlight-soft_75_cccccc_1x100.png");
            background-repeat: repeat-x;
            padding: 3px 5px 3px 5px;
            border: 1px solid silver;
            margin-bottom: 1px;
        }
    </style>
    <script type="text/javascript">
        var _totPages = 1;
        var _startIndex = 1;
        var _dataPerPage = 25;

        $(document).ready(function () {
            $("#divTable").hide();
            $("#divNoSearch").text("You didn't make any search yet.");
            $("#divNoSearch").show();
            $(".date-picker").datepicker({ dateFormat: "dd M yy" });
            allowOnlyNumeric();
            loadEventTypes();
            loadCountries();
            loadCourses();
            loadRanks();
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

        function loadCountries() {
            $.ajax({
                type: "POST",
                url: "CountryList.aspx/GetCountries",
                data: JSON.stringify({ group: 0 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbCountries");
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

        function loadCourses() {
            $.ajax({
                type: "POST",
                url: "CourseList.aspx/GetCourses",
                data: JSON.stringify({ eventTypeId: $("#cmbEventTypes").val(), keyword: "" }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbCourses");
                        options.empty();
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

        function loadRanks() {
            $.ajax({
                type: "POST",
                url: "RankList.aspx/GetRanks",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbRanks");
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

        function openWindow(id) {
            var wTitle = "Edit Training [" + id + "]";
            if (id === 0) {
                wTitle = "New Training";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "TrainingEdit.aspx?Id=" + id,
                height: 480,
                width: 750,
                resizable: false,
                maximizable: false,
                bookmarkable: false,
                showRoundCorner: true
            });
        }

        function doSearch() {
            var filter = createFilter();
            $.ajax({
                type: "POST",
                url: "TrainingList.aspx/GetTrainings",
                data: JSON.stringify({ filter: filter }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        if (data.d.Data.length > 0) {
                            _totPages = Math.ceil(data.d.TotalCount / _dataPerPage);
                            $("#divTable").show();
                            $("#divNoSearch").hide();
                            $("#demo2").paginate({
                                count: _totPages,
                                start: _startIndex,
                                display: _dataPerPage,
                                border: false,
                                text_color: '#888',
                                background_color: '#EEE',
                                text_hover_color: 'black',
                                background_hover_color: '#CFCFCF',
                                onChange: function (page) {
                                    _startIndex = page;
                                    doSearch();
                                }
                            });
                        }
                        else {
                            $("#divTable").hide();
                            $("#divNoSearch").text("No data found on the search criteria.");
                            $("#divNoSearch").show();
                        }
                        $("#dataContainer > tbody").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#dataContainer > tbody");
                    }
                    else {
                        alert(data.d.ErrorMessage);
                    }
                },
                error: function (msg) {
                    alert(msg.Error);
                }
            });
        }

        function createFilter() {
            var filter = new Object();
            if ($.trim($("#txtTrainingId").val()) == "") {
                filter.Id = 0;
            }
            else {
                filter.Id = parseInt($.trim($("#txtTrainingId").val()), 10);
            }
            filter.PersonNo = $.trim($("#txtPersonNo").val());
            filter.RankId = parseInt($("#cmbRanks").val(), 10);

            filter.EventTypeId = parseInt($("#cmbEventTypes").val(), 10);
            filter.CourseId = parseInt($("#cmbCourses").val(), 10);
            filter.CountryId = parseInt($("#cmbCountries").val(), 10);

            filter.DateFrom = $.trim($("#txtDateFrom").val());
            filter.DateTo = $.trim($("#txtDateTo").val());

            filter.StartIndex = _startIndex;
            filter.DataPerPage = _dataPerPage;
            return filter;
        }

        function deleteData(id) {
            if (confirm("Are you sure you want to delete this record?") == true) {
                $.ajax({
                    type: "POST",
                    url: "TrainingList.aspx/DeleteTraining",
                    data: JSON.stringify({ id: id }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            doSearch();
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

        function clearFilter() {
            $("#txtTrainingId").val("");
            $("#cmbEventTypes").val(0);
            $("#cmbCountries").val(0);
            $("#cmbRanks").val(0);
            $("#txtDateFrom").val("");
            $("#txtDateTo").val("");
            $("#txtPersonNo").val("");
        }

        function openPaymentScheduleWindow(id, trainingId) {
            var wHeight, wWidth;
            wHeight = 400;
            wWidth = 340;
            var url = "PaymentScheduleEdit.aspx?id=" + id + "&trainingId=" + trainingId;
            $.window({
                showModal: true,
                title: "New Payment",
                url: url,
                height: wHeight,
                width: wWidth,
                resizable: false,
                maximizable: false,
                bookmarkable: false,
                showRoundCorner: true
            });
        }

        function openTrainingReportWindow() {
            var wHeight, wWidth;
            var filter = createFilter();
            var qString = "cid=" + filter.CountryId;
            qString += "&df=" + filter.DateFrom;
            qString += "&dt=" + filter.DateTo;
            qString += "&etid=" + filter.EventTypeId;
            qString += "&crsId=" + filter.CourseId;
            qString += "&tid=" + filter.Id;
            qString += "&pn=" + filter.PersonNo;
            qString += "&rid=" + filter.RankId;
            wHeight = 530;
            wWidth = 1120;
            url = "TrainingReportViewer.aspx?" + qString;
            $.window({
                showModal: true,
                title: "New Payment",
                url: url,
                height: wHeight,
                width: wWidth,
                resizable: true,
                maximizable: true,
                bookmarkable: false,
                showRoundCorner: true
            });
        }
    </script>
    <script id="tmplData" type="text/html">
        <tr>
            <td>
                ${Id}
            </td>
            <td>
                ${Course.Name}
            </td>
            <td>
                ${Country.Name}
            </td>
            <td>
                ${CommaSeparatedTrainees}
            </td>
            <td>
                ${StartDate} - ${EndDate}
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/report-icon.png" width="18px" height="16px" alt="Pay" style="cursor: pointer;" title="Pay" onclick="openPaymentScheduleWindow(0, ${Id});"/>
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
        <div style="min-width: 410px;">
            <input type="button" value="Add New" onclick="openWindow(0)" style="float: left;" />
            <input type="button" value="Show Report" onclick="openTrainingReportWindow()" style="margin-left: 10px;" />
            <input type="button" value="Search" onclick="doSearch();" style="float: right;" />
            <input type="button" value="Clear Filter" onclick="clearFilter();" style="float: right;
                margin-right: 10px;" />
            <div class="searchPanel" style="margin-top: 4px;">
                <table border="0" cellspacing="0" cellpadding="0">
                    <colgroup>
                        <col width="8%" />
                        <col width="17%" />
                        <col width="8%" />
                        <col width="17%" />
                        <col width="8%" />
                        <col width="17%" />
                        <col width="8%" />
                        <col width="17%" />
                    </colgroup>
                    <tr>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Training ID
                        </td>
                        <td class="ItemPaddingStyle">
                            <input type="text" id="txtTrainingId" class="numeric-only" />
                        </td>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Personal No
                        </td>
                        <td class="ItemPaddingStyle">
                            <input type="text" id="txtPersonNo" />
                        </td>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Rank
                        </td>
                        <td class="ItemPaddingStyle">
                            <select id="cmbRanks">
                            </select>
                        </td>
                        <td class="InputSpecial ItemPaddingStyle" style="padding-left: 10px;">
                            Training Type
                        </td>
                        <td class="ItemPaddingStyle">
                            <select id="cmbEventTypes" onchange="loadCourses();">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Course
                        </td>
                        <td class="ItemPaddingStyle">
                            <select id="cmbCourses">
                            </select>
                        </td>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Country
                        </td>
                        <td class="ItemPaddingStyle">
                            <select id="cmbCountries">
                            </select>
                        </td>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Date From
                        </td>
                        <td class="ItemPaddingStyle">
                            <input type="text" class="date-picker" id="txtDateFrom" />
                        </td>
                        <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                            Date To
                        </td>
                        <td class="ItemPaddingStyle">
                            <input type="text" class="date-picker" id="txtDateTo" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divNoSearch" style="color: Red;">
            </div>
            <div id="divTable">
                <div class="demo">
                    <div id="demo2">
                    </div>
                </div>
                <table class="itemTable" id="dataContainer">
                    <thead>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                Course
                            </th>
                            <th>
                                Country
                            </th>
                            <th>
                                Trainees
                            </th>
                            <th>
                                When
                            </th>
                            <th style="text-align: center;">
                                Add Payment
                            </th>
                            <th style="text-align: center;">
                                Edit
                            </th>
                            <th style="text-align: center;">
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
