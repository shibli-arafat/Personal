<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PersonList.aspx.cs" Inherits="DefenseTraining.Web.PersonList" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Persons
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            loadRanks();
        });

        function doSearch() {
            populateData();
        }

        function loadRanks() {
            $.ajax({
                type: "POST",
                url: "RankList.aspx/GetRanks",
                data: '{}',
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

        function populateData() {
            $.ajax({
                type: "POST",
                url: "PersonList.aspx/GetPersons",
                data: JSON.stringify({ personNo: $("#txtPersonNo").val(), name: $("#txtName").val(), rankId: parseInt($("#cmbRanks").val(), 10) }),
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
            var wTitle = "Edit Person [" + id + "]";
            if (id === 0) {
                wTitle = "New Person";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "PersonEdit.aspx?Id=" + id,
                height: 320,
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
                    url: "PersonList.aspx/DeletePerson",
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
                ${PersonNo}
            </td>
            <td>
                ${Name}
            </td>
            <td>
                ${Rank.Name}
            </td>
            <td>
                ${Email}
            </td>
            <td>
                ${MobileNo}
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
            <input type="button" value="Add New" onclick="openWindow(0)" />
            <div class="searchPanel" style="margin-top: 4px;">
                <table border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td style="padding-left: 10px;">
                            Person No
                        </td>
                        <td>
                            <input type="text" id="txtPersonNo" maxlength="16" />
                        </td>
                        <td style="padding-left: 10px;">
                            Name
                        </td>
                        <td>
                            <input type="text" id="txtName" maxlength="128" />
                        </td>
                        <td style="padding-left: 10px;">
                            Rank
                        </td>
                        <td>
                            <select id="cmbRanks">
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
                            <th width="10%">
                                PersonNo
                            </th>
                            <th width="30%">
                                Name
                            </th>
                            <th width="15%">
                                Rank
                            </th>
                            <th width="20%">
                                Email
                            </th>
                            <th width="15%">
                                Mobile No
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
