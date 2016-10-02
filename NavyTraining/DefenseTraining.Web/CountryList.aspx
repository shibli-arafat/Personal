<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="DefenseTraining.Web.CountryList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Countries
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/API/CountryEdit.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var _countries = new Array();
        var _selectedId = 0;
        var _country = new CountryEdit();

        $(document).ready(function () {
            _country.populateGroups();
        });

        function doSearch() {
            populateData();
        }

        function populateData() {
            $.ajax({
                type: "POST",
                url: "CountryList.aspx/GetCountries",
                data: JSON.stringify({ group: $("#cmbGroups").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _countries = data.d.Data;
                        $("#dataContainer > tbody").empty();
                        $("#tmplData").tmpl(_countries).appendTo("#dataContainer > tbody");
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
            _selectedId = id
            var wTitle = "Edit Country [" + _selectedId + "]";
            if (id === 0) {
                wTitle = "New Country";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "CountryEdit.aspx?Id=" + id,
                height: 200,
                width: 330,
                resizable: false,
                maximizable: false,
                bookmarkable: false,
                showRoundCorner: true
            });
        }

        function deleteData(id) {
            _selectedId = id;
            if (confirm("Are you sure you want to delete this record?") == true) {
                $.ajax({
                    type: "POST",
                    url: "CountryList.aspx/DeleteCountry",
                    data: '{"id":' + _selectedId + '}',
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

        function getDataById() {
            var country = new Object();
            for (var i = 0; i < _countries.length; i++) {
                if (_countries[i].Id == _selectedId) {
                    country = _countries[i];
                    break;
                }
            }
            return country;
        }
    </script>
    <script id="tmplData" type="text/html">
        <tr>
            <td>
                ${Name}
            </td>
            <td>
                ${GroupName}
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
                            Country Group
                        </td>
                        <td>
                            <select id="cmbGroups">
                            </select>
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
                            <th width="70%">
                                Name
                            </th>
                            <th width="20%">
                                Group
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
