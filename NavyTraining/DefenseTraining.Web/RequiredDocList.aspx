﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequiredDocList.aspx.cs"
    Inherits="DefenseTraining.Web.RequiredDocList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Required Document Setup
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var _requiredDocs;
        var _selectedId;

        $(document).ready(function () {
            populateData();
        });

        function populateData() {
            $.ajax({
                type: "POST",
                url: "RequiredDocList.aspx/GetRequiredDocs",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.IsSuccessful) {
                        _requiredDocs = data.d.Data;
                        $("#dataContainer > tbody").empty();
                        $("#tmplData").tmpl(_requiredDocs).appendTo("#dataContainer > tbody");
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
            _selectedId = id;
            var requiredDoc = getDataById();
            var wTitle = "Edit Required Document [" + _selectedId + "]";
            if (id === 0) {
                wTitle = "New Required Document";
                requiredDoc.Name = "";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "RequiredDocEdit.aspx?Id=" + id + "&Name=" + requiredDoc.Name,
                height: 150,
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
                    url: "RequiredDocList.aspx/DeleteRequiredDoc",
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
            var requiredDoc = new Object();
            for (var i = 0; i < _requiredDocs.length; i++) {
                if (_requiredDocs[i].Id == _selectedId) {
                    requiredDoc = _requiredDocs[i];
                    break;
                }
            }
            return requiredDoc;
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
