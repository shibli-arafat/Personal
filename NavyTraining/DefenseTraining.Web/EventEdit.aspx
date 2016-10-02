<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventEdit.aspx.cs" Inherits="DefenseTraining.Web.EventEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=text]
        {
            border: 1px solid #aaaaaa;
        }
        .text-box
        {
            width: 90%;
            margin-bottom: 5px;
        }
        .date-picker
        {
            width: 100px;
            margin-bottom: 5px;
        }
        .table
        {
            border-collapse: collapse;
            width: 100%;
        }
        .table th
        {
            background-image: url("Styles/images/ui-bg_highlight-soft_75_cccccc_1x100.png");
            background-repeat: repeat-x;
            border-width: 1px;
            padding: 3px 7px 4px 7px;
            border-style: solid;
            border-color: Silver;
            font-weight: normal;
            text-align: left;
            height: 20px;
        }
        .table td
        {
            border-width: 1px;
            padding: 3px 7px 4px 7px;
            border-style: solid;
            border-color: Silver;
        }
    </style>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _event = new Object();

        $(document).ready(function () {
            $("#tabs").tabs();
            loadEventTypes();
            loadCountries();
            loadExpenseHeads();
            loadRequiredDocs();
            allowOnlyNumeric();
            $(".date-picker").datepicker({ dateFormat: "dd M yy" });
            var queryString = decodeURI(window.location.search.substring(1));
            var parms = queryString.split('&');
            var id = parseInt(parms[0].substring(parms[0].indexOf("=") + 1));
            if (id != 0) {
                loadEventData(id);
            }
        });

        function loadRequiredDocs() {
            $.ajax({
                type: "POST",
                url: "RequiredDocList.aspx/GetRequiredDocs",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divRequiredDocs > div").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#divRequiredDocs > div");
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

        function loadEventTypes() {
            $.ajax({
                type: "POST",
                url: "EventTypeList.aspx/GetEventTypes",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbEventTypes");
                        options.append($("<option />").val(0).text("Please Select"));
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
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbCountries");
                        options.append($("<option />").val(0).text("Please Select"));
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

        function loadExpenseHeads() {
            $.ajax({
                type: "POST",
                url: "ExpenseHeadList.aspx/GetExpenseHeads",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divHostResponsibilities > div").empty();
                        $("#tmplData").tmpl(data.d.Data).appendTo("#divHostResponsibilities > div");
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

        function loadEventData(id) {
            $.ajax({
                type: "POST",
                url: "EventEdit.aspx/GetEvent",
                data: '{ "id":' + JSON.stringify(id) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _event = data.d.Data;
                        _nominees = _event.Nominees;
                        _reminders = _event.Reminders;
                        populateEventData();
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

        function populateEventData() {
            $("#txtEventName").val(_event.Name);
            $("#cmbEventTypes").val(_event.Type.Id);
            $("#divEventTypes > span > input").val(_event.Type.Name);
            $("#cmbGenres").val(_event.Genre.Id);
            $("#divGenres > span > input").val(_event.Genre.Name);
            $("#cmbSpecialities").val(_event.Speciality.Id);
            $("#divSpecialities > span > input").val(_event.Speciality.Name);
            $("#cmbCountries").val(_event.Country.Id);
            $("#divCountries > span > input").val(_event.Country.Name);
            $("#txtCity").val(_event.City);
            $("#txtInstitute").val(_event.Institute);
            $("#txtStartsOn").val(_event.StartsOn);
            $("#txtEndsOn").val(_event.EndsOn);
            $("#txtRanks").val(_event.Ranks);
            $("#txtVacancies").val(_event.Vacancies);
            displayResponsibilities();
            $("#txtAcceptanceOn").val(_event.AcceptanceOn);
            $("#txtNominationOn").val(_event.NominationOn);
            $("#txtDocForwardOn").val(_event.DocForwardOn);
            displayRequiredDocs();
            displayTrainees();
            bindReminders();
        }

        function displayTrainees() {
        }

        function loadPersons() {
        }

        function displayResponsibilities() {
            $("#divHostResponsibilities :checkbox").each(function () {
                for (var i = 0; i < _event.HostResponsibilities.length; i++) {
                    var existing = _event.HostResponsibilities[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }

        function displayRequiredDocs() {
            $("#divRequiredDocs :checkbox").each(function () {
                for (var i = 0; i < _event.RequiredDocs.length; i++) {
                    var existing = _event.RequiredDocs[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }

        function displayInitAlotment() {
            $("#divInitAlotment > div > div").each(function () {
                for (var i = 0; i < _event.InitAlotment.length; i++) {
                    var alotment = _event.InitAlotment[i];
                    if (alotment.Type == $(this).find("input:checkbox").attr("typeVal")) {
                        $(this).find("input:checkbox").attr("checked", "checked");
                        $(this).find("input:text").val(alotment.Quota);
                    }
                }
            });
        }

        function displayReAlotment() {
            $("#divReAlotment > div > div").each(function () {
                for (var i = 0; i < _event.ReAlotment.length; i++) {
                    var alotment = _event.ReAlotment[i];
                    if (alotment.Type == $(this).find("input:checkbox").attr("typeVal")) {
                        $(this).find("input:checkbox").attr("checked", "checked");
                        $(this).find("input:text").val(alotment.Quota);
                    }
                }
            });
        }

        function getFormData() {
            _event.Name = $.trim($("#txtEventName").val());
            _event.Type = new Object();
            _event.Type.Id = parseInt($("#cmbEventTypes").val(), 10);
            _event.Genre = new Object();
            _event.Genre.Id = parseInt($("#cmbGenres").val(), 10);
            _event.Speciality = new Object();
            _event.Speciality.Id = parseInt($("#cmbSpecialities").val(), 10);
            _event.Country = new Object();
            _event.Country.Id = parseInt($("#cmbCountries").val(), 10);
            _event.City = $.trim($("#txtCity").val());
            _event.Institute = $.trim($("#txtInstitute").val());
            _event.StartsOn = $.trim($("#txtStartsOn").val());
            _event.EndsOn = $.trim($("#txtEndsOn").val());
            _event.Ranks = $.trim($("#txtRanks").val());
            _event.Vacancies = parseInt($.trim($("#txtVacancies").val()), 10);
            _event.HostResponsibilities = getResponsibilities();
            _event.RequiredDocs = getRequiredDocs();
            _event.AcceptanceOn = $.trim($("#txtAcceptanceOn").val());
            _event.NominationOn = $.trim($("#txtNominationOn").val());
            _event.DocForwardOn = $.trim($("#txtDocForwardOn").val());
            _event.InitAlotment = getInitAlotment();
            _event.ReAlotment = getReAlotment();
            _event.Nominees = _nominees;
            _event.Reminders = _reminders;
        }

        function isValidData(data) {
            var msg = "";
            if (data.Type.Id == 0) {
                msg += "Please select an event type\n";
            }
            if (data.Genre.Id == 0) {
                msg += "Please select a event genre\n";
            }
            if (data.Speciality.Id == 0) {
                msg += "Please select a speciality\n";
            }
            if (data.Name == "") {
                msg += "Please enter event name\n";
            }
            if (data.Country.Id == 0) {
                msg += "Please select a country\n";
            }
            if (data.City == "") {
                msg += "Please enter city\n";
            }
            if (data.StartsOn == "") {
                msg += "Please enter when starts\n";
            }
            if (data.EndsOn == "") {
                msg += "Please enter when ends\n";
            }
            if (isNaN(data.Vacancies) || data.Vacancies == 0) {
                msg += "Please enter No. of vacancies\n";
            }
            if (data.HostResponsibilities.length == 0) {
                msg += "Please select host country responsibilities\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function getAllowanceDetails() {
            var details = new Array();
            $("#divHostResponsibilities :checkbox:checked").each(function () {
                var detail = new Object();
                detail.Id = $(this).attr("dataId");
                detail.push(detail);
            });
            $("#divHostResponsibilities :checkbox:checked").each(function () {
                var detail = new Object();
                detail.Id = $(this).attr("dataId");
                detail.push(detail);
            });
            return details;
        }

        function getRequiredDocs() {
            var requiredDocs = new Array();
            $("#divRequiredDocs :checkbox:checked").each(function () {
                var requiredDoc = new Object();
                requiredDoc.Id = $(this).attr("dataId");
                requiredDocs.push(requiredDoc);
            });
            return requiredDocs;
        }

        function saveData() {
            getFormData();
            if (isValidData(_event)) {
                $.ajax({
                    type: "POST",
                    url: "EventEdit.aspx/SaveEvent",
                    data: '{ "evnt":' + JSON.stringify(_event) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            window.parent.doSearch();
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

        function removeReminder(element) {
            var remindFor = $(element).attr("remindFor");
            for (var i = 0; i < _reminders.length; i++) {
                if (_reminders[i].RemindFor == remindFor) {
                    _reminders.splice(i, 1);
                    break;
                }
            }
            bindReminders();
        }

        function addReminder() {
            if (isValidReminder()) {
                var reminder = new Object();
                reminder.RemindFor = $.trim($("#txtRemindFor").val());
                reminder.RemindOn = $.trim($("#txtRemindOn").val());
                reminder.Dismissed = false;
                _reminders.push(reminder);
                bindReminders();
            }
        }

        function isValidReminder() {
            var msg = "";
            if ($.trim($("#txtRemindFor").val()) == "") {
                msg += "Please enter remind for\n";
            }
            else {
                if (isDuplicateReminder($.trim($("#txtRemindFor").val()))) {
                    msg += "This reminder already exist\n";
                }
            }
            if ($.trim($("#txtRemindOn").val()) == "") {
                msg += "Please select a date\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function isDuplicateTrainee(personalNo) {

        }

        function isDuplicateReminder(remindFor) {
            for (var i = 0; i < _reminders.length; i++) {
                if (_reminders[i].RemindFor == remindFor) {
                    return true;
                }
            }
        }
    </script>
    <script id="tmplData" type="text/html">
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}">${Name}</input>
        </div>
    </script>
    <script id="tmplReminder" type="text/html">
        <tr>
            <td>
                ${RemindFor}
            </td>
            <td >
                ${RemindOn}
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/DeleteIcon.jpg" alt="Remove" style="cursor: pointer" remindFor="${RemindFor}" title="Remove" onclick="removeReminder(this);"/>
            </td>
        </tr>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="button" value="Save" onclick="saveData();" style="margin-left: 2px;
        margin-top: 2px;" />
    <div id="tabs" style="border-width: 0;">
        <ul>
            <li><a href="#tabs-1">General</a></li>
            <li><a href="#tabs-2">Trainees</a></li>
            <li><a href="#tabs-3">Setup Reminder</a></li>
        </ul>
        <div id="tabs-1">
            <div style="float: left; width: 48%;">
                <div>
                    What <span style="color: Red;">*</span></div>
                <div>
                    <input type="text" id="txtEventName" class="text-box" />
                </div>
                <div>
                    Training Type <span style="color: Red;">*</span></div>
                <div id="divEventTypes">
                    <select id="cmbEventTypes" class="combobox">
                    </select>
                </div>
                <div>
                    Country <span style="color: Red;">*</span>
                </div>
                <div id="divCountries">
                    <select id="cmbCountries" class="combobox">
                    </select>
                </div>
                <div>
                    City <span style="color: Red;">*</span></div>
                <div>
                    <input type="text" id="txtCity" class="text-box" />
                </div>
                <div>
                    Institute <span style="color: Red;">*</span></div>
                <div>
                    <input type="text" id="txtInstitute" class="text-box" />
                </div>
            </div>
            <div style="float: right; width: 48%;">
                <div style="border-bottom: 1px solid silver">
                    When</div>
                <div>
                    From <span style="color: Red;">*</span>
                </div>
                <div>
                    <input type="text" id="txtStartsOn" class="date-picker" />
                </div>
                <div>
                    To <span style="color: Red;">*</span>
                </div>
                <div>
                    <input type="text" id="txtEndsOn" class="date-picker" />
                </div>
                <div>
                    Host Country Responsibilities <span style="color: Red;">*</span>
                </div>
                <div id="divHostResponsibilities" style="height: 90px; overflow: auto; border: 1px solid silver;">
                    <div>
                    </div>
                </div>
            </div>
        </div>
        <div id="tabs-2">
            <div id="divTrainees" style="width: 100%;">
                <fieldset>
                    <table style="margin-bottom: 7px;" class="table">
                        <thead>
                            <tr>
                                <th style="width: 13%;">
                                    Personal No
                                </th>
                                <th style="width: 19%;">
                                    Rank
                                </th>
                                <th style="width: 19%;">
                                    Unit
                                </th>
                                <th style="width: 30%;">
                                    Name
                                </th>
                                <th style="width: 19%;">
                                    Branch
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <input type="text" id="txtPersonalNo" style="width: 100%; margin: 0 0 0 0;" />
                                </td>
                                <td id="tdRanks">
                                    <select id="cmbRanks" style="width: 100%; margin: 0 0 0 0;" class="combobox">
                                    </select>
                                    <img alt="Add new" title="Add new rank" src="Styles/images/add-new.png" style="width: 18px;
                                        height: 23px; float: right; cursor: pointer;" onclick="openDialog('rank', 'RankEdit.aspx/SaveRank', 'New Rank');" />
                                </td>
                                <td id="tdUnits">
                                    <select id="cmbUnits" style="width: 100%; margin: 0 0 0 0;" class="combobox">
                                    </select>
                                    <img alt="Add new" title="Add new unit" src="Styles/images/add-new.png" style="width: 18px;
                                        height: 23px; float: right; cursor: pointer;" onclick="openDialog('unit', 'UnitEdit.aspx/SaveUnit', 'New Unit');" />
                                </td>
                                <td>
                                    <input type="text" id="txtNomineeName" style="width: 100%; margin: 0 0 0 0;" />
                                </td>
                                <td id="tdBranches">
                                    <select id="cmbBranches" style="width: 100%; margin: 0 0 0 0;" class="combobox">
                                    </select>
                                    <img alt="Add new" title="Add new branch" src="Styles/images/add-new.png" style="width: 18px;
                                        height: 23px; float: right; cursor: pointer;" onclick="openDialog('branch', 'BranchEdit.aspx/SaveBranch', 'New Branch');" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="float: right; margin-left: 10px;">
                        <input type="button" value="Cancel" onclick="hideNomineeDiv();" />
                    </div>
                    <div style="float: right;">
                        <input type="button" value="OK" onclick="addNominee();" />
                    </div>
                </fieldset>
            </div>
            <div id="divShowNominee" style="width: 100%;">
                <fieldset>
                    <div style="float: right;">
                        <input type="button" value="Add Nominee" onclick="showNomineeDiv();" />
                    </div>
                </fieldset>
            </div>
            <fieldset>
                <table id="tblNominees" class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th width="10%">
                                Personal No
                            </th>
                            <th width="18%">
                                Rank
                            </th>
                            <th width="18%">
                                Unit
                            </th>
                            <th width="31%">
                                Name
                            </th>
                            <th width="18%">
                                Branch
                            </th>
                            <th width="5%">
                                Remove
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </fieldset>
        </div>
        <div id="tabs-3">
            <fieldset>
                <legend>Add Reminder</legend>Remind For
                <input type="text" id="txtRemindFor" style="width: 400px;" />
                Remind On
                <input type="text" id="txtRemindOn" class="date-picker" />
                <input type="button" value="Add" onclick="addReminder();" />
            </fieldset>
            <fieldset>
                <table id="tblReminders" class="table">
                    <thead>
                        <tr>
                            <th width="70%">
                                Remind For
                            </th>
                            <th width="20%">
                                Remind On
                            </th>
                            <th width="10%">
                                Remove
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
