using System;
using ArmyTraining.Model.Trainings;
using ArmyTraining.Model.Util;

namespace ArmyTraining.Controls
{
    public partial class TrainingActivitiesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void Initialize(TrainingFlow trainingFlow)
        {
            ViewState["FlowId"] = trainingFlow.Id;

            txtAccepetanceDate.Text = trainingFlow.AcceptanceDate.ToDateString();
            txtAttachment.Text = trainingFlow.AttachmentDate.ToDateString();
            txtDocumentDate.Text = trainingFlow.DocumentDate.ToDateString();
            txtDraftGoDate.Text = trainingFlow.DraftGoDate.ToDateString();
            txtGoDate.Text = trainingFlow.GoDate.ToDateString();
            txtEntitlementDate.Text = trainingFlow.EntitlementDate.ToDateString();
            txtFltItineraryDate.Text = trainingFlow.FltItineraryDate.ToDateString();
            txtLetterToAllCOncern.Text = trainingFlow.LetterToAllConcernDate.ToDateString();
            txtMedicalDate.Text = trainingFlow.MedicalDate.ToDateString();
            txtNominationDate.Text = trainingFlow.NominationDate.ToDateString();
            txtOfferLetterDate.Text = trainingFlow.OfferLetterDate.ToDateString();
            txtSelectionLetterDate.Text = trainingFlow.SelectionLetterDate.ToDateString();
        }

        public TrainingFlow GetInfo()
        {
            TrainingFlow result = new TrainingFlow();
            result.Id = Convert.ToInt32(ViewState["FlowId"]);

            result.AcceptanceDate = txtAccepetanceDate.Text.ToDateValue();
            result.AttachmentDate = txtAttachment.Text.ToDateValue();
            result.DocumentDate = txtDocumentDate.Text.ToDateValue();
            result.DraftGoDate = txtDraftGoDate.Text.ToDateValue();
            result.GoDate = txtGoDate.Text.ToDateValue();
            result.EntitlementDate = txtEntitlementDate.Text.ToDateValue();
            result.FltItineraryDate = txtFltItineraryDate.Text.ToDateValue();
            result.LetterToAllConcernDate = txtLetterToAllCOncern.Text.ToDateValue();
            result.MedicalDate = txtMedicalDate.Text.ToDateValue();
            result.NominationDate = txtNominationDate.Text.ToDateValue();
            result.OfferLetterDate = txtOfferLetterDate.Text.ToDateValue();
            result.SelectionLetterDate = txtSelectionLetterDate.Text.ToDateValue();

            return result;
        }
    }
}