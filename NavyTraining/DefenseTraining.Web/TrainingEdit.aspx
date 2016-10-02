<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingEdit.aspx.cs" Inherits="DefenseTraining.Web.TrainingEdit" %>

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
            margin-top: 2px;
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
        td > input[type=text]
        {
            width: 75px;
            text-align: right;
        }
    </style>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _training = new Object();

        $(document).ready(function () {
            $("#divDialog").dialog({
                autoOpen: false,
                modal: true,
                width: 400
            });
            $("#tabs").tabs();
            $(".date-picker").datepicker({ dateFormat: "dd M yy" });
            loadCourses();
            loadCountries();
            loadExpenseHeads();
            loadRequiredDocs();
            loadPersons();
            var queryString = decodeURI(window.location.search.substring(1));
            loadTraining(queryString);
        });

        function loadCourses() {
            $.ajax({
                type: "POST",
                url: "CourseList.aspx/GetCourses",
                data: JSON.stringify({ eventTypeId: 0, keyword: "" }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbCourses");
                        options.append($("<option />").val(0).text("Please Select"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.Name));
                        });
                        $("#cmbCourses").val(0);
                        $("#divCourses > span > input").val("Please Select");
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
                        options.append($("<option />").val(0).text("Please Select"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.Name));
                        });
                        $("#cmbCountries").val(0);
                        $("#divCountries > span > input").val("Please Select");
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
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divHostResponsibilities").empty();
                        $("#tmplResponsibilities").tmpl(data.d.Data).appendTo("#divHostResponsibilities");
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

        function loadRequiredDocs() {
            $.ajax({
                type: "POST",
                url: "RequiredDocList.aspx/GetRequiredDocs",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        $("#divRequiredDocs").empty();
                        $("#tmplRequiredDocs").tmpl(data.d.Data).appendTo("#divRequiredDocs");
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

        function loadPersons() {
            $.ajax({
                type: "POST",
                url: "PersonList.aspx/GetPersons",
                data: JSON.stringify({ personNo: "", name: "", rankId: 0 }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbPersons");
                        options.append($("<option />").val(0).text("Please Select"));
                        $.each(data.d.Data, function () {
                            options.append($("<option />").val(this.Id).text(this.PersonNo + " - " + this.Name + ", " + this.Rank.Name));
                        });
                        $("#cmbPersons").val(0);
                        $("#divPersons > span > input").val("Please Select");
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

        function addTrainee() {
            var msg = "";
            var traineeParam = new Object();
            traineeParam.PersonId = $("#cmbPersons").val();
            traineeParam.CountryId = $("#cmbCountries").val();
            traineeParam.StartDate = $("#txtStartDate").val();
            traineeParam.EndDate = $("#txtEndDate").val();
            traineeParam.ExpenseFrom = $("#txtPaymentFrom").val();
            traineeParam.ExpenseTo = $("#txtPaymentTo").val();
            if (traineeParam.CountryId == 0) {
                msg += "Please select a country\n";
            }
            if (traineeParam.PersonId == 0) {
                msg += "Please select a person\n";
            }
            if (traineeParam.StartDate == "") {
                msg += "Please enter start date\n";
            }
            if (traineeParam.EndDate == "") {
                msg += "Please enter end date\n";
            }
            if (traineeParam.ExpenseFrom == "") {
                msg += "Please enter expense from\n";
            }
            if (traineeParam.ExpenseTo == "") {
                msg += "Please enter expense to\n";
            }
            if (msg != "") {
                alert(msg);
                return;
            }
            loadTrainee(traineeParam);
            populateTrainees();
        }

        function loadTrainee(traineeParam) {
            $.ajax({
                type: "POST",
                url: "TrainingEdit.aspx/GetTrainee",
                data: JSON.stringify({ traineeParam: traineeParam }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        if (_training.Trainees == null) {
                            _training.Trainees = new Array();
                            _training.Trainees.push(data.d.Data);
                        }
                        else {
                            if (!traineeExists(data.d.Data.Person.Id)) {
                                _training.Trainees.push(data.d.Data);
                            }
                        }
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

        function traineeExists(personId) {
            for (var i = 0; i < _training.Trainees.length; i++) {
                if (_training.Trainees[i].Person.Id == personId) {
                    return true;
                }
            }
            return false;
        }

        function populateTrainees() {
            var div = $("#divTrainees");
            div.html($("#tmplTrainees").tmpl(_training.Trainees));
        }

        function loadTraining(queryString) {
            var parms = queryString.split("&");
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (id == 0) {
                _training = new Object();
                _training.Course = new Object();
                _training.Country = new Object();
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "TrainingEdit.aspx/GetTraining",
                    data: JSON.stringify({ id: id }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            _training = data.d.Data;
                            populateTraining();
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

        function populateTraining() {
            $("#cmbCourses").val(_training.Course.Id);
            $("#divCourses > span > input").val(_training.Course.Name);
            $("#cmbCountries").val(_training.Country.Id);
            $("#divCountries > span > input").val(_training.Country.Name);
            $("#txtStartDate").val(_training.StartDate);
            $("#txtEndDate").val(_training.EndDate);
            $("#txtMedicalDate").val(_training.MedicalDate);
            $("#txtDocumentDate").val(_training.DocumentDate);
            $("#txtBriefingDate").val(_training.BriefingDate);
            $("#txtNominationDate").val(_training.NominationDate);
            $("#txtAcceptanceDate").val(_training.AcceptanceDate);
            $("#txtDocForwardDate").val(_training.DocForwardDate);
            $("#txtPaymentFrom").val(_training.PaymentFrom);
            $("#txtPaymentTo").val(_training.PaymentTo);
            $("#txtUsdRate").val(_training.UsdRate);

            $("#divHostResponsibilities :checkbox").each(function () {
                for (var i = 0; i < _training.HostResponsibilities.length; i++) {
                    var existing = _training.HostResponsibilities[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });

            $("#divRequiredDocs :checkbox").each(function () {
                for (var i = 0; i < _training.RequiredDocs.length; i++) {
                    var existing = _training.RequiredDocs[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });

            populateTrainees();

            bindReminders();

            $("#lblGrandTotal").text("Grand Total: " + _training.Total);
        }

        function removeTrainee(personId) {
            for (var i = 0; i < _training.Trainees.length; i++) {
                if (_training.Trainees[i].Person.Id == personId) {
                    _training.Trainees.splice(i, 1);
                    break;
                }
            }
            populateTrainees();
        }

        function getFormData() {
            _training.Course.Id = $("#cmbCourses").val();
            _training.Country.Id = $("#cmbCountries").val();
            _training.StartDate = $("#txtStartDate").val();
            _training.EndDate = $("#txtEndDate").val();
            _training.MedicalDate = $("#txtMedicalDate").val();
            _training.DocumentDate = $("#txtDocumentDate").val();
            _training.BriefingDate = $("#txtBriefingDate").val();
            _training.NominationDate = $("#txtNominationDate").val();
            _training.AcceptanceDate = $("#txtAcceptanceDate").val();
            _training.DocForwardDate = $("#txtDocForwardDate").val();
            _training.PaymentFrom = $("#txtPaymentFrom").val();
            _training.PaymentTo = $("#txtPaymentTo").val();
            _training.UsdRate = $("#txtUsdRate").val();
            if (_training.UsdRate == "") {
                _training.UsdRate = 0;
            }
            var responsibilities = new Array();
            $("#divHostResponsibilities :checkbox:checked").each(function () {
                var responsibility = new Object();
                responsibility.Id = $(this).attr("dataId");
                responsibility.Name = $(this).val();
                responsibilities.push(responsibility);
            });
            _training.HostResponsibilities = responsibilities;

            var requiredDocs = new Array();
            $("#divRequiredDocs :checkbox:checked").each(function () {
                var requiredDoc = new Object();
                requiredDoc.Id = $(this).attr("dataId");
                requiredDocs.push(requiredDoc);
            });
            _training.RequiredDocs = requiredDocs;

            var trainees = new Array();
            $("#divTrainees > div").each(function () {
                var trainee = new Object();
                trainee.Person = new Object();
                trainee.Person.Id = $(this).attr("traineeId");
                trainee.Rank = new Object();
                trainee.Rank.Id = $(this).attr("rankId");
                var expenses = new Array();
                $(this).find(".self").each(function () {
                    var expense = new Object();
                    expense.IsSelected = $(this).find(".selected").is(":checked");
                    expense.Head = new Object();
                    expense.Head.Id = $(this).find(".selected").attr("expense-head-id");
                    expense.Amount = $(this).find(".amount").val();
                    expense.Quantity = $(this).find(".quantity").val();
                    expenses.push(expense);
                });
                trainee.Expenses = expenses;
                expenses = new Array();
                $(this).find(".spouse").each(function () {
                    var expense = new Object();
                    expense.IsSelected = $(this).find(".selected").is(":checked");
                    expense.Head = new Object();
                    expense.Head.Id = $(this).find(".selected").attr("expense-head-id");
                    expense.Amount = $(this).find(".amount").val();
                    expense.Quantity = $(this).find(".quantity").val();
                    expenses.push(expense);
                });
                trainee.SpouseExpenses = expenses;
                expenses = new Array();
                $(this).find(".kids").each(function () {
                    var expense = new Object();
                    expense.IsSelected = $(this).find(".selected").is(":checked");
                    expense.Head = new Object();
                    expense.Head.Id = $(this).find(".selected").attr("expense-head-id");
                    expense.Amount = $(this).find(".amount").val();
                    expense.Quantity = $(this).find(".quantity").val();
                    expenses.push(expense);
                });
                trainee.KidsExpenses = expenses;
                trainees.push(trainee);
            });
            _training.Trainees = trainees;
        }

        function saveData() {
            getFormData();
            if(isValidData()) {
                $.ajax({
                    type: "POST",
                    url: "TrainingEdit.aspx/SaveTraining",
                    data: JSON.stringify({ training: _training }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.d.IsSuccessful) {
                            _training = data.d.Data;
                            window.parent.doSearch();
                        }
                        else                     {
                            alert(data.d.ErrorMessage);
                        }
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });
            }
        }

        function isValidData() {
            var msg = "";
            if (_training.Course.Id == 0) {
                msg += "Please select a course\n";
            }
            if (_training.Country.Id == 0) {
                msg += "Please select a country\n";
            }
            if (_training.StartDate == "") {
                msg += "Please enter start date\n";
            }
            if (_training.EndDate == "") {
                msg += "Please enter end date\n";
            }
            if (_training.HostResponsibilities.length == 0) {
                msg += "Please select host country's responsibilities\n";
            }
            if (_training.RequiredDocs.length == 0) {
                msg += "Please select required documents\n";
            }
            if (_training.Trainees.length > 0) {
                if (_training.PaymentFrom == "") {
                    msg += "Please enter payment from\n";
                }
                if (_training.PaymentTo == "") {
                    msg += "Please enter payment to\n";
                }
                if (_training.UsdRate == 0) {
                    msg += "Please enter USD rate\n";
                }
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function openDialog() {
            $("#txtRemindFor").val("");
            $("#txtActionsNeeded").val("");
            $("#txtRemindOn").val("");
            $("#divDialog").dialog("open");
        }

        function addReminder() {
            var reminder = new Object();
            reminder.RemindFor = $.trim($("#txtRemindFor").val());
            reminder.ActionsNeeded = $.trim($("#txtActionsNeeded").val());
            reminder.RemindOn = $.trim($("#txtRemindOn").val());
            if (_training.Reminders == null || _training.Reminders.length == 0) {
                _training.Reminders = new Array();
            }
            if (isValidReminder(reminder)) {                
                _training.Reminders.push(reminder);
                bindReminders();
            }
            $("#divDialog").dialog("close"); 
        }

        function isValidReminder(reminder) {
            var msg = "";
            if (reminder.RemindFor == "") {
                msg += "Please enter remind for\n";
            }
            else {
                if (isDuplicateReminder(reminder.RemindFor)) {
                    msg += "This reminder already exist\n";
                }
            }
            if (reminder.RemindOn == "") {
                msg += "Please select a date\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }

        function bindReminders() {
            $("#tblReminders > tbody").empty();
            $("#tmplReminders").tmpl(_training.Reminders).appendTo("#tblReminders > tbody");
        }

        function isDuplicateReminder(remindFor) {
            for (var i = 0; i < _training.Reminders.length; i++) {
                if (_training.Reminders[i].RemindFor == remindFor) {
                    return true;
                }
            }
        }

        function removeReminder(element) {
            var remindFor = $(element).attr("remindFor");
            for (var i = 0; i < _training.Reminders.length; i++) {
                if (_training.Reminders[i].RemindFor == remindFor) {
                    _training.Reminders.splice(i, 1);
                    break;
                }
            }
            bindReminders();
        }
    </script>
    <script id="tmplResponsibilities" type="text/html">
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}" />${Name}
        </div>
    </script>
    <script id="tmplReminders" type="text/html">
        <tr>
            <td>
                ${RemindFor}
            </td>
            <td>
                ${ActionsNeeded}
            </td>
            <td>
                ${RemindOn}
            </td>
            <td style="text-align: center;">
                <img src="Styles/Images/DeleteIcon.jpg" alt="Delete" style="cursor: pointer" remindFor="${RemindFor}" title="Remove" onclick="removeReminder(this);"/>
            </td>
        </tr>
    </script>
    <script id="tmplRequiredDocs" type="text/html">
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}" />${Name}
        </div>
    </script>
    <script id="tmplTrainees" type="text/html">
        <div traineeId="${Person.Id}" rankId="${Rank.Id}">
            <label style="padding: 5px 2px; border: 1px solid #dadada;">
                ${Person.PersonNo} ${Rank.Name} ${Person.Name}
                <input type="button" value="Remove" onclick="removeTrainee(${Person.Id})"/>
            </label>
            <table style="margin-left: 15px;">
                <div style="margin-left: 15px;">
                    <label style="margin-top: 5px;">
                        Self
                    <label>
                    {{each(i, expense) Expenses}}
                        <tr class="self">
                            <td>
                                {{if IsSelected}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" checked="checked" />${Head.Name}
                                {{else}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" />${Head.Name}
                                {{/if}}                                
                            </td>
                            <td>
                                <input type="text" class="amount" value="${Amount}" />
                            </td>
                            <td>
                                X <input type="text" class="quantity" value="${Quantity}" /> = 
                            </td>
                            <td style="text-align: right; border: 1px solid #datada;">
                                <label style="width: 100px;">${Total}</label>
                            </td>
                        </tr>
                    {{/each}}
                </div>
            </table>
            <table style="margin-left: 15px;">
                <div style="margin-left: 15px;">
                    <label style="margin-top: 5px;">
                        Spouse
                    <label>
                    {{each(i, expense) SpouseExpenses}}
                        <tr class="spouse">
                            <td>
                                {{if IsSelected}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" checked="checked" />${Head.Name}
                                {{else}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" />${Head.Name}
                                {{/if}}                                 
                            </td>
                            <td>
                                <input type="text" class="amount" value="${Amount}" />
                            </td>
                            <td>
                                X <input type="text" class="quantity" value="${Quantity}" /> = 
                            </td>
                            <td style="text-align: right; border: 1px solid #datada;">
                                <label style="width: 100px;">${Total}</label>
                            </td>
                        </tr>
                    {{/each}}
                </div>
            </table>
            <table style="margin-left: 15px;">
                <div style="margin-left: 15px;">
                    <label style="margin-top: 5px;">
                        Kids
                    <label>
                    {{each(i, expense) KidExpenses}}
                        <tr class="kids">
                            <td>
                                {{if IsSelected}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" checked="checked" />${Head.Name}
                                {{else}}
                                     <input type="checkbox" class="selected" expense-head-id="${Head.Id}" />${Head.Name}
                                {{/if}}                                 
                            </td>
                            <td>
                                <input type="text" class="amount" value="${Amount}" />
                            </td>
                            <td>
                                X <input type="text" class="quantity" value="${Quantity}" /> = 
                            </td>
                            <td style="text-align: right; border: 1px solid #datada;">
                                <label style="width: 100px;">${Total}</label>
                            </td>
                        </tr>
                    {{/each}}
                </div>
            </table>
            <label style="margin-left: 15px; margin-bottom: 10px; margin-top: 7px; border-top: 1px solid #dadada;">
                Total: ${Total}
            </label>            
        </div>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="button" value="Save" onclick="saveData();" style="margin-left: 2px;
        margin-top: 2px;" />
    <div id="tabs" style="border-width: 0;">
        <ul>
            <li><a href="#tabGeneral">General</a></li>
            <li><a href="#tabTrainee">Trainees</a></li>
            <li><a href="#tabReminder">Setup Reminder</a></li>
        </ul>
        <div id="tabGeneral">
            <div style="float: left; width: 48%;">
                <label for="cmbCourses" style="margin-top: 5px;">
                    Training On <span style="color: Red">*</span>
                </label>
                <div id="divCourses">
                    <select class="combobox" id="cmbCourses">
                    </select>
                </div>
                <label for="cmbCountries" style="margin-top: 5px;">
                    Country <span style="color: Red">*</span>
                </label>
                <div id="divCountries">
                    <select class="combobox" id="cmbCountries">
                    </select>
                </div>
                <label for="txtStartDate" style="margin-top: 5px;">
                    Start Date <span style="color: Red">*</span>
                </label>
                <input type="text" id="txtStartDate" class="date-picker" maxlength="10" />
                <label for="txtEndDate">
                    End Date <span style="color: Red">*</span>
                </label>
                <input type="text" id="txtEndDate" class="date-picker" maxlength="10" />
                <label for="txtMedicalDate">
                    Medical Date
                </label>
                <input type="text" id="txtMedicalDate" class="date-picker" maxlength="10" />
                <label for="txtDocumentDate">
                    Document Date
                </label>
                <input type="text" id="txtDocumentDate" class="date-picker" maxlength="10" />
                <label for="txtBriefingDate">
                    Briefing Date
                </label>
                <input type="text" id="txtBriefingDate" class="date-picker" maxlength="10" />
                <label for="txtNominationDate">
                    Nomination Date
                </label>
                <input type="text" id="txtNominationDate" class="date-picker" maxlength="10" />
                <label for="txtAcceptanceDate">
                    Acceptance Date
                </label>
                <input type="text" id="txtAcceptanceDate" class="date-picker" maxlength="10" />
                <label for="txtDocForwardDate">
                    Doc. Forward Date
                </label>
                <input type="text" id="txtDocForwardDate" class="date-picker" maxlength="10" />
            </div>
            <div style="float: right; width: 50%;">
                <label for="divHostResponsibilities">
                    Host Country's Responsibilities <span style="color: Red">*</span>
                </label>
                <div id="divHostResponsibilities" style="height: 150px; width: 100%; border: 1px solid #dadada;
                    overflow: auto; margin-bottom: 10px;">
                </div>
                <label for="divRequiredDocs">
                    Required Documents <span style="color: Red">*</span>
                </label>
                <div id="divRequiredDocs" style="height: 150px; width: 100%; border: 1px solid #dadada;
                    overflow: auto; margin-bottom: 5px;">
                </div>
            </div>
        </div>
        <div id="tabTrainee">
            <table>
                <tr>
                    <td>
                        <div id="divPersons">
                            <select class="combobox" id="cmbPersons">
                            </select>
                        </div>
                    </td>
                    <td style="padding-left: 30px;">
                        Expense From
                    </td>
                    <td>
                        <input type="text" id="txtPaymentFrom" class="date-picker" maxlength="10" />
                    </td>
                    <td>
                        To
                    </td>
                    <td>
                        <input type="text" id="txtPaymentTo" class="date-picker" maxlength="10" />
                    </td>
                    <td>
                        <input type="button" id="btnAddTrainee" value="Add Trainee" style="margin-left: 5px;"
                            onclick="addTrainee();" />
                    </td>
                </tr>
                <tr>
                    <td>
                        USD to BDT Rate:
                        <input type="text" id="txtUsdRate" />
                    </td>
                </tr>
            </table>
            <div id="divTrainees">
            </div>
            <label id="lblGrandTotal" style="margin-top: 5px; border: 1px solid #dadada; padding: 5px;">
                Grand Total:
            </label>
        </div>
        <div id="tabReminder">
            <input type="button" id="btnAddReminder" value="Add Reminder" onclick="openDialog();" />
            <hr style="color: #dadada" />
            <table id="tblReminders" class="table">
                <thead>
                    <tr>
                        <th width="30%">
                            Remind For
                        </th>
                        <th width="40%">
                            Actions Needed
                        </th>
                        <th width="20%">
                            Remind From
                        </th>
                        <th width="10%">
                            Remove
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <div id="divDialog" title="Add Reminder">
            <fieldset>
                <label for="txtRemindFor">
                    Remind For
                </label>
                <input type="text" id="txtRemindFor" style="width: 345px;" />
                <label for="txtActionsNeeded">
                    Actions Needed
                </label>
                <textarea id="txtActionsNeeded" rows="4" cols="0" style="width: 345px; margin-bottom: 5px;"></textarea>
                <label for="txtRemindOn" class="date-picker">
                    Remind From
                </label>
                <input type="text" id="txtRemindOn" class="date-picker" />
                <div style="margin-top: 15px; text-align: center;">
                    <input type="button" value="Add" onclick="addReminder();" />
                </div>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
