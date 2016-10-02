<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AllowanceSettingEdit.aspx.cs" Inherits="DefenseTraining.Web.AllowanceSettingEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Allowance Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/common.js" type="text/javascript"></script>
    <style type="text/css">
        input[type=text]
        {
            margin-bottom: 0;
        }
    </style>
    <script type="text/javascript">
        var _allowanceSetting = new Object();
        $(document).ready(function () {
            loadAllowanceSetting();
            allowOnlyNumeric();
        });

        function loadAllowanceSetting() {
            $.ajax({
                type: "POST",
                url: "AllowanceSettingEdit.aspx/GetAllowanceSetting",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _allowanceSetting = data.d.Data;
                        $("#txtEligibilityForSpuse").val(_allowanceSetting.EligibilityForSpouse);
                        $("#txtEligibilityForKids").val(_allowanceSetting.EligibilityForKids);
                        $("#compAllowanceContainer > tbody").empty();
                        $("#tmplCompAlloance").tmpl(_allowanceSetting.CompAllowanceSettingDetails).appendTo("#compAllowanceContainer > tbody");

                        $("#hotelInclCashContainer > tbody").empty();
                        $("#tmplHotelInclCash").tmpl(_allowanceSetting.HotelInCashAllowanceSettingDetails).appendTo("#hotelInclCashContainer > tbody");
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
            if (!isValidData()) {
                return;
            }
            $.ajax({
                type: "POST",
                url: "AllowanceSettingEdit.aspx/SaveAllowanceSetting",
                data: JSON.stringify({ allowanceSetting: _allowanceSetting }),
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _allowanceSetting = data.d.Data;
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
            _allowanceSetting.EligibilityForSpouse = $("#txtEligibilityForSpuse").val();
            _allowanceSetting.EligibilityForKids = $("#txtEligibilityForKids").val();
            var settingDetails = new Array();
            $("#compAllowanceContainer > tbody > tr").each(function () {
                var row = this;
                var settingDetail = new Object();
                settingDetail.DetailType = 1;
                settingDetail.RankGroup = new Object();
                settingDetail.RankGroup.Id = parseInt($(row).find(".tdRnkGroup").attr("rnkgrpid"), 10);
                settingDetail.RankGroup.Name = $.trim($(row).find(".tdRnkGroup").text());
                settingDetail.PaymentType = 0;
                settingDetail.ForCountryGroup1 = parseFloat($(row).find(".txtGroup1").val());
                settingDetail.ForCountryGroup2 = parseFloat($(row).find(".txtGroup2").val());
                settingDetail.ForCountryGroup3 = parseFloat($(row).find(".txtGroup3").val());
                settingDetails.push(settingDetail);
            });
            $("#hotelInclCashContainer > tbody > tr").each(function () {
                var row = this;
                var settingDetail = new Object();
                settingDetail.DetailType = 2;
                settingDetail.RankGroup = new Object();
                settingDetail.RankGroup.Id = parseInt($(row).find(".tdRnkGroup").attr("rnkgrpid"), 10);
                settingDetail.RankGroup.Name = $.trim($(row).find(".tdRnkGroup").text());
                settingDetail.PaymentType = parseInt($(row).find(".tdPaymentType").attr("paytype"), 10);
                settingDetail.ForCountryGroup1 = parseFloat($(row).find(".txtGroup1").val());
                settingDetail.ForCountryGroup2 = parseFloat($(row).find(".txtGroup2").val());
                settingDetail.ForCountryGroup3 = parseFloat($(row).find(".txtGroup3").val());
                settingDetails.push(settingDetail);
            });
            _allowanceSetting.AllowanceSettingDetails = settingDetails;
        }

        function isValidData() {
            var msg = "";
            if (_allowanceSetting.EligibilityForSpouse == 0) {
                msg += "Please enter value for eligibility for spouse.\n";
            }
            if (_allowanceSetting.EligibilityForKids == 0) {
                msg += "Please enter value for eligibility for kids.\n";
            }
            for (var i = 0; i < _allowanceSetting.AllowanceSettingDetails.length; i++) {
                if (_allowanceSetting.AllowanceSettingDetails[i].ForCountryGroup1 == 0) {
                    msg += "Please enter value for country group1 for " + _allowanceSetting.AllowanceSettingDetails[i].RankGroup.Name + ".\n";
                }
                if (_allowanceSetting.AllowanceSettingDetails[i].ForCountryGroup2 == 0) {
                    msg += "Please enter value for country group2 for " + _allowanceSetting.AllowanceSettingDetails[i].RankGroup.Name + ".\n";
                }
                if (_allowanceSetting.AllowanceSettingDetails[i].ForCountryGroup3 == 0) {
                    msg += "Please enter value for country group3 for " + _allowanceSetting.AllowanceSettingDetails[i].RankGroup.Name + ".\n";
                }
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            return true;
        }
    </script>
    <script id="tmplCompAlloance" type="text/html">
        <tr>
            <td rnkGrpId="${RankGroup.Id}" class="tdRnkGroup">
                ${RankGroup.Name}
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup1}" style="text-align: right;" class="numeric-only txtGroup1"/>
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup2}" style="text-align: right;" class="numeric-only txtGroup2"/>
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup3}" style="text-align: right;" class="numeric-only txtGroup3"/>
            </td>
        </tr>
    </script>
    <script id="tmplHotelInclCash" type="text/html">
        <tr>
            <td rnkGrpId="${RankGroup.Id}" class="tdRnkGroup">
                ${RankGroup.Name}
            </td>
            <td payType="${PaymentType}" class="tdPaymentType">
                ${Description}
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup1}" style="text-align: right;" class="numeric-only txtGroup1"/>
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup2}" style="text-align: right;" class="numeric-only txtGroup2"/>
            </td>
            <td style="text-align: center;">
                <input type="text" value="${ForCountryGroup3}" style="text-align: right;" class="numeric-only txtGroup3"/>
            </td>
        </tr>
    </script>
    <div style="margin-bottom: 10px;">
        <div style="margin-bottom: 5px;">
            Eligibility for Spuse:
            <input type="text" id="txtEligibilityForSpuse" class="numeric-only" />
            In Month
        </div>
        <div style="margin-bottom: 5px;">
            Eligibility for Kids:
            <input type="text" id="txtEligibilityForKids" class="numeric-only" />
            In Month
        </div>
        <hr style="color: #dadada" />
        <label for="compAllowanceContainer">
            Daily Allowance
        </label>
        <table class="itemTable" id="compAllowanceContainer">
            <thead>
                <tr>
                    <th width="40%">
                        Ranks
                    </th>
                    <th width="20%" style="text-align: center;">
                        Group-1
                    </th>
                    <th width="20%" style="text-align: center;">
                        Group-2
                    </th>
                    <th width="20%" style="text-align: center;">
                        Group-3
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <div style="margin-bottom: 10px;">
        <label for="hotelInclCashContainer">
            Hotel Including Cash
        </label>
        <table class="itemTable" id="hotelInclCashContainer">
            <thead>
                <tr>
                    <th width="40%">
                        Ranks
                    </th>
                    <th width="15%">
                        Description
                    </th>
                    <th width="15%" style="text-align: center;">
                        Group-1
                    </th>
                    <th width="15%" style="text-align: center;">
                        Group-2
                    </th>
                    <th width="15%" style="text-align: center;">
                        Group-3
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <input type="button" value="Save" id="btnSave" onclick="saveData();" />
</asp:Content>
