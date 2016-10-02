<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs"
    Inherits="ArmyTraining.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Control panel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Button ID="btnBackup" Text="Backup Database" OnClick="BackupDatabase_Click" runat="server" />
    <asp:Label ID="lblBackupMsg" runat="server" />
</asp:Content>
