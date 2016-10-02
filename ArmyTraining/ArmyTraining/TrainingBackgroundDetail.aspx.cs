using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class TrainingBackgroundDetail : System.Web.UI.Page, ITrainingBackgroundDetail
    {
        private TrainingBackgroundDetailPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new TrainingBackgroundDetailPresenter(this);
            _Presenter.OnPageLoad();
            if (!IsPostBack)
            {
                if (TrainingBackgroundId > 0)
                {
                    header.Text = "Edit training background (" + TrainingBackgroundId + ").";
                }
                else
                {
                    header.Text = "Add training background.";
                }
            }
        }

        protected void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                _Presenter.HandleSave();
                string js = "window.returnValue = 1;window.close();";
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "SaveSuccess", js, true);
            }
            catch (Exception ex)
            {
                hdnMessage.Value = ex.Message;
            }
        }

        public TrainingBackground PopulateTrainingBackgroundFromGui()
        {
            TrainingBackground result = new TrainingBackground();
            result.Name = txtName.Value;
            return result;
        }

        public int TrainingBackgroundId
        {
            get { return int.Parse(Request[Constants.TrainingBackgroundDetail_Request_Id]); }
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void PopulateGuiFromTrainingBackground(TrainingBackground trainingBkg)
        {
            txtName.Value = trainingBkg.Name;
        }
    }
}
