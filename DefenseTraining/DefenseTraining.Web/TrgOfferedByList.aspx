<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrgOfferedByList.aspx.cs"
    Inherits="DefenseTraining.Web.TrgOfferedByList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Countries
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var _trgOfferedBys = new Array();

        $(document).ready(function () {
            populateData();
        });

        function populateData() {
            $.ajax({
                type: "POST",
                url: "TrgOfferedByList.aspx/GetTrgOfferedBys",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _trgOfferedBys = data.d.Data;
                        $("#dataContainer > tbody").empty();
                        $("#tmplData").tmpl(_trgOfferedBys).appendTo("#dataContainer > tbody");
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
            var decoration = getDataById(id);
            var wTitle = "Edit TrgOfferedBy [" + id + "]";
            if (id === 0) {
                wTitle = "New TrgOfferedBy";
                decoration.Name = "";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "TrgOfferedByEdit.aspx?Id=" + id + "&Name=" + decoration.Name,
                height: 170,
                width: 350,
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
                    url: "TrgOfferedByList.aspx/DeleteTrgOfferedBy",
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

        function getDataById(id) {
            var trgOfferedBy = new Object();
            for (var i = 0; i < _trgOfferedBys.length; i++) {
                if (_trgOfferedBys[i].Id == id) {
                    trgOfferedBy = _trgOfferedBys[i];
                    break;
                }
            }
            return trgOfferedBy;
        }
    </script>
    <script id="tmplData" type="text/html">
        <tr>
            <td>
                ${Name}
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
            <div style="margin-top: 4px;">
                <table class="itemTable" id="dataContainer">
                    <thead>
                        <tr>
                            <th width="90%">
                                Name
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
