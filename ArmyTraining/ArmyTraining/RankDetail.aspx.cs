using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class RankDetail : System.Web.UI.Page, IRankDetailView
    {
        private RankDetailPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new RankDetailPresenter(this);
            _Presenter.OnViewLoaded();
            if (!IsPostBack)
            {
                if (RankId > 0)
                {
                    header.Text = "Edit rank (" + RankId + ").";
                }
                else
                {
                    header.Text = "Add rank.";
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

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public int RankId
        {
            get { return int.Parse(Request[Constants.RankDetail_Request_Id]); }
        }

        public void PopulateGUIFromRank(Rank rank)
        {
            txtName.Value = rank.Name;
        }

        public Rank PopulateRankFromGUI()
        {
            Rank rank = new Rank();
            rank.Name = txtName.Value;
            return rank;
        }
    }
}
