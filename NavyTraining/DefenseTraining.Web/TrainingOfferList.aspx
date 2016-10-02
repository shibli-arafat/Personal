<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingOfferList.aspx.cs"
    Inherits="DefenseTraining.Web.TrainingOfferList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" runat="server">
    Training Offers
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="content">
    <link href="Styles/list-page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {            
            populateData();
        });        

        function populateData() {
            $.ajax({
                type: "POST",
                url: "TrainingOfferList.aspx/GetTrainingOffers",
                data: JSON.stringify({}),
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
            var wTitle = "Edit TrainingOffer [" + id + "]";
            if (id === 0) {
                wTitle = "New TrainingOffer";
            }
            $.window({
                showModal: true,
                title: wTitle,
                url: "TrainingOfferEdit.aspx?Id=" + id,
                height: 500,
                width: 335,
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
                    url: "TrainingOfferList.aspx/DeleteTrainingOffer",
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
            <td>
                ${Country.Name}
            </td>
            <td>
                ${RankGroup.Name}
            </td>
            <td>
                ${StartDate}
            </td>
            <td>
                ${EndDate}
            </td>
            <td>
                ${NoOfVacancies}
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
            <div style="margin-top: 4px;">
                <table class="itemTable" id="dataContainer">
                    <thead>
                        <tr>
                            <th width="20%">
                                Name
                            </th>
                            <th width="13%">
                                Training Type
                            </th>
                            <th width="13%">
                                Country
                            </th>
                            <th width="13%">
                                Ranks
                            </th>
                            <th width="10%">
                                Start Date
                            </th>
                            <th width="10%">
                                End Date
                            </th>
                            <th width="11%">
                                No. Of Vacancies
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
