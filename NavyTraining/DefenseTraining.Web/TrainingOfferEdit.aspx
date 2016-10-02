<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingOfferEdit.aspx.cs"
    Inherits="DefenseTraining.Web.TrainingOfferEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input[type=text], select, textarea
        {
            width: 275px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
        select
        {
            width: 279px;
        }
    </style>
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _trainingOffer;

        $(document).ready(function () {
            loadEventTypes();
            loadCountries();
            loadRankGroups();
            loadExpenseHeads();
            loadRequiredDocs();
            allowOnlyNumeric();
            var queryString = decodeURI(window.location.search.substring(1));
            loadTrainingOffer(queryString);
            if (_trainingOffer.Id != 0) {
                populateFormData();
            }
            $(".date-time").datepicker({ dateFormat: "dd M yy" });
        });

        function loadCountries() {
            $.ajax({
                type: "POST",
                url: "CountryList.aspx/GetCountries",
                data: JSON.stringify({ group: 0 }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
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

        function loadRankGroups() {
            $.ajax({
                type: "POST",
                url: "RankGroupList.aspx/GetRankGroups",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        var options = $("#cmbRankGroups");
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

        function loadEventTypes() {
            $.ajax({
                type: "POST",
                url: "EventTypeList.aspx/GetEventTypes",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
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
                        $("#divResponsibilities").empty();
                        $("#tmplResponsibilities").tmpl(data.d.Data).appendTo("#divResponsibilities");
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

        function saveData() {
            getFormData();
            if (!isValidData()) return;
            $.ajax({
                type: "POST",
                url: "TrainingOfferEdit.aspx/SaveTrainingOffer",
                data: JSON.stringify({ budget: _trainingOffer }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _trainingOffer = data.d.Data;
                        window.parent.populateData();
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

        function getFormData() {
            _trainingOffer.Name = $.trim($("#txtName").val());
            _trainingOffer.EventType = new Object();
            _trainingOffer.EventType.Id = parseInt($("#cmbEventTypes").val(), 10);
            _trainingOffer.Country = new Object();
            _trainingOffer.Country.Id = parseInt($("#cmbCountries").val(), 10);
            _trainingOffer.RankGroup = new Object();
            _trainingOffer.RankGroup.Id = parseInt($("#cmbRankGroups").val(), 10);
            _trainingOffer.NoOfVacancies = parseInt($.trim($("#txtNoOfVacancies").val()), 10);
            _trainingOffer.StartDate = $.trim($("#txtStartDate").val());
            _trainingOffer.EndDate = $.trim($("#txtEndDate").val());
            _trainingOffer.HostResponsibilities = new Array();
            $("#divResponsibilities :checkbox:checked").each(function () {
                var responsibility = new Object();
                responsibility.Id = parseInt($(this).attr("dataId"));
                _trainingOffer.HostResponsibilities.push(responsibility);
            });
            _trainingOffer.RequiredDocs = new Array();
            $("#divRequiredDocs :checkbox:checked").each(function () {
                var requiredDoc = new Object();
                requiredDoc.Id = parseInt($(this).attr("dataId"));
                _trainingOffer.RequiredDocs.push(requiredDoc);
            });
        }

        function loadTrainingOffer(queryString) {
            var parms = queryString.split('&');
            var id = parms[0].substring(parms[0].indexOf("=") + 1);
            if (parseInt(id, 10) == 0) {
                _trainingOffer = new Object();
                _trainingOffer.Id = 0;
                return;
            }
            $.ajax({
                type: "POST",
                url: "TrainingOfferEdit.aspx/GetTrainingOffer",
                data: JSON.stringify({ id: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _trainingOffer = data.d.Data;
                    }
                    else {
                        alert(data.d.ErrorMessage);
                        return;
                    }
                },
                error: function (msg) {
                    alert(msg);
                    return;
                }
            });
        }

        function populateFormData() {
            $("#txtName").val(_trainingOffer.Name);
            $("#cmbEventTypes").val(_trainingOffer.EventType.Id);
            $("#cmbCountries").val(_trainingOffer.Country.Id);
            $("#cmbRankGroups").val(_trainingOffer.RankGroup.Id);
            $("#txtNoOfVacancies").val(_trainingOffer.NoOfVacancies);
            $("#txtStartDate").val(_trainingOffer.StartDate);
            $("#txtEndDate").val(_trainingOffer.EndDate);
            $("#divResponsibilities :checkbox").each(function () {
                for (var i = 0; i < _trainingOffer.HostResponsibilities.length; i++) {
                    var existing = _trainingOffer.HostResponsibilities[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
            $("#divRequiredDocs :checkbox").each(function () {
                for (var i = 0; i < _trainingOffer.RequiredDocs.length; i++) {
                    var existing = _trainingOffer.RequiredDocs[i].Id;
                    if (existing == parseInt($(this).attr("dataId"), 10)) {
                        $(this).attr("checked", "checked");
                    }
                }
            });
        }

        function isValidData() {
            var msg = "";
            if (_trainingOffer.Name == "") {
                msg += "Please enter training name\n";
            }
            if (_trainingOffer.EventType.Id == 0) {
                msg += "Please select training type\n";
            }
            if (_trainingOffer.Country.Id == 0) {
                msg += "Please select country\n";
            }
            if (_trainingOffer.RankGroup.Id == 0) {
                msg += "Please select rank\n";
            }
            if (_trainingOffer.NoOfVacancies == 0) {
                msg += "Please enter No. of vacancies\n";
            }
            if (_trainingOffer.StartDate == "") {
                msg += "Please enter start date\n";
            }
            if (_trainingOffer.EndDate == "") {
                msg += "Please enter end date\n";
            }
            if (_trainingOffer.HostResponsibilities.length == 0) {
                msg += "Please select at least one host responsibility\n";
            }
            if (_trainingOffer.RequiredDocs.length == 0) {
                msg += "Please select at least one required documents\n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }
    </script>
    <script id="tmplResponsibilities" type="text/html">
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}">${Name}</input>
        </div>
    </script>
    <script id="tmplRequiredDocs" type="text/html">
        <div>
            <input type="checkbox" dataId="${Id}" value="${Name}">${Name}</input>
        </div>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            Training Name <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtName" />
        </div>
        <div>
            Training Type <span style="color: Red">*</span>
        </div>
        <div>
            <select id="cmbEventTypes">
            </select>
        </div>
        <div>
            Country <span style="color: Red">*</span>
        </div>
        <div>
            <select id="cmbCountries">
            </select>
        </div>
        <div>
            Rank <span style="color: Red">*</span>
        </div>
        <div>
            <select id="cmbRankGroups">
            </select>
        </div>
        <div>
            No Of Vacancies <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtNoOfVacancies" class="numeric-only" style="width: 100px;" />
        </div>
        <div>
            Host Country Responsibilities <span style="color: Red">*</span>
        </div>
        <div id="divResponsibilities" style="height: 150px; width: 275px; border: 1px solid #dadada;
            overflow: auto; margin-bottom: 5px; margin-top: 5px;">
        </div>
        <div>
            Required Documents <span style="color: Red">*</span>
        </div>
        <div id="divRequiredDocs" style="height: 150px; width: 275px; border: 1px solid #dadada;
            overflow: auto; margin-bottom: 5px; margin-top: 3px;">
        </div>
        <div>
            Start Date <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtStartDate" class="date-time" style="width: 100px;" />
        </div>
        <div>
            End Date <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtEndDate" class="date-time" style="width: 100px;" />
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="saveData()" />
        </div>
    </div>
    </form>
</body>
</html>
