<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainingActivitiesControl.ascx.cs"
    Inherits="ArmyTraining.Controls.TrainingActivitiesControl" %>

<script type="text/javascript">
    $(function() {
        $('#<%=txtOfferLetterDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtAccepetanceDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtNominationDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtDraftGoDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtSelectionLetterDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtLetterToAllCOncern.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtAttachment.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtMedicalDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtDocumentDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtFltItineraryDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtEntitlementDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=txtGoDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
    });
</script>

<div style="overflow: auto; height: 385px; border: SOLID 1px #777777; border-bottom-width: 0px;
    padding-left: 10px; padding-right: 10px">
    <table border="0" cellspacing="0" cellpadding="0">
        <colgroup>
            <col width="200px" />
            <col width="200px" />
            <col width="200px" />
            <col width="200px" />
        </colgroup>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Offer Letter Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtOfferLetterDate" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header  ItemPaddingStyle" style="padding-left: 10px;">
                Acceptance Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAccepetanceDate" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Nomination Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNominationDate" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Draft Go Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDraftGoDate" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Selection Letter Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSelectionLetterDate" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Letter To All Concern
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLetterToAllCOncern" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Attachment Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAttachment" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Medical Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMedicalDate" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Document Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDocumentDate" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Flt Itinerary Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFltItineraryDate" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Entitlement Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEntitlementDate" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Header ItemPaddingStyle" style="padding-left: 10px;">
                Go Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtGoDate" CssClass="Input"></asp:TextBox>
            </td>
            <td colspan="2">
            </td>
        </tr>
    </table>
</div>
