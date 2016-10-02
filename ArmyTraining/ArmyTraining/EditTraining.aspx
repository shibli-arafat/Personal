<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTraining.aspx.cs" Inherits="ArmyTraining.EditTraining"
    MasterPageFile="~/Main.Master" %>

<%@ Register Src="~/Controls/TrainingGeneralControl.ascx" TagName="TrainingGeneral"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/TrainingBudgetControl.ascx" TagName="TrainingBudget"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/TrainingTraineeControl.ascx" TagName="TrainingTrainee"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/TrainingActivitiesControl.ascx" TagName="TrainingActivities"
    TagPrefix="uc1" %>
<asp:Content ID="contentHeader" ContentPlaceHolderID="head" runat="server">
    <asp:Literal runat="server" ID="ltrHeader"></asp:Literal><asp:Literal runat="server"
        ID="viewHeader">
    </asp:Literal>
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="PageContent">
    <script type="text/javascript">
        function validateData() {
            if ("<%=TrainingId %>" == "0")
                return true;
            return true;
        }
        
        function OpenFileSelector(personElement) {
            var trainingId = <%=TrainingId %>;
            var personId = personElement.getAttribute("personId");
            var file = window.showModalDialog("FileSelector.aspx?TrainingId=" + trainingId + "&PersonId=" + personId, null, "dialogWidth:600px;dialogHeight:200px;status:no;resizable:no;scroll:no;");
            if(file == null || file == "") return false;
            return UpdatePersonDoc(personId, file);            
        }  
    </script>
    <style type="text/css">
        .tabButton
        {
            border-style: solid;
            border-width: 1px;
            border-color: silver;
            font-weight: bold;
            background-color: silver;
            text-align: center;
            padding: 6px 5px 0px 5px;
            min-width: 75px;
            border-radius: 5px 5px 0px 0px;
            color: #111111;
            cursor: pointer;
            text-decoration: none;
        }

        .errorMessage
        {
            background-color: red;
            color: #fff;
            padding: 3px 3px;
            border-radius: 2px 2px;
        }

        .saveButton
        {
            width: 75px;
            margin-top: 6px;
        }
    </style>
    <div id="tabs">
        <div style="height: 32px;">
            <asp:LinkButton runat="server" Height="25" ID="btnGeneral" Text="General" CommandArgument="0"
                OnClick="ChangeView" CssClass="tabButton" />
            <asp:LinkButton runat="server" Height="25" ID="btnTrainee" Text="Trainee" CommandArgument="1"
                OnClick="ChangeView" CssClass="tabButton" />
            <asp:LinkButton runat="server" Height="25" ID="btnBudget" Text="Additional Expenses"
                CommandArgument="2" OnClick="ChangeView" CssClass="tabButton" />
            <asp:LinkButton runat="server" Height="25" ID="btnActivities" Text="Activities" CommandArgument="3"
                OnClick="ChangeView" CssClass="tabButton" />
        </div>
        <div style="height: 385px; border-bottom: solid 1px #777777; margin-bottom: 5px;">
            <asp:MultiView runat="server" ID="mvTraining" ActiveViewIndex="0">
                <asp:View runat="server" ID="viewGeneral">
                    <uc1:TrainingGeneral runat="server" ID="generalControl" />
                </asp:View>
                <asp:View runat="server" ID="Trainee">
                    <uc1:TrainingTrainee runat="server" ID="traineeControl" />
                </asp:View>
                <asp:View runat="server" ID="Budget">
                    <uc1:TrainingBudget runat="server" ID="budgetControl" />
                </asp:View>
                <asp:View runat="server" ID="Activities">
                    <uc1:TrainingActivities runat="server" ID="activitiesControl" />
                </asp:View>
            </asp:MultiView>
        </div>
        <asp:Label ID="lblError" CssClass="errorMessage" runat="server" Visible="false" />
    </div>
    <div>
        <asp:Button CssClass="saveButton" OnClick="SaveClicked" OnClientClick="return validateData();" runat="server"
            ID="btnOk" Text="Save" />
    </div>
</asp:Content>
