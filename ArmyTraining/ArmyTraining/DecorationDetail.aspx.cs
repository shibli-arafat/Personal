using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class DecorationDetail : System.Web.UI.Page, IDecorationDetail
    {
        private CommissionDetailPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CommissionDetailPresenter(this);
            _Presenter.OnPageLoad();
            if (!IsPostBack)
            {
                if (CommsionId > 0)
                {
                    header.Text = "Edit commission (" + CommsionId + ").";
                }
                else
                {
                    header.Text = "Add commission.";
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

        public Decoration PopulateCommissionFromGUI()
        {
            Decoration result = new Decoration();
            result.Name = txtName.Value;
            return result;
        }

        public int CommsionId
        {
            get { return int.Parse(Request[Constants.CommissionDetail_Request_Id]); }
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void PopulateGUIFromCommission(Decoration commission)
        {
            txtName.Value = commission.Name;
        }
    }
}
