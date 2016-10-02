using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class RankManager : System.Web.UI.Page, IRankListView
    {
        RankListPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new RankListPresenter(this);
            _Presenter.OnViewLoaded();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Rank)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((Rank)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.Delete(int.Parse(e.CommandArgument.ToString()));
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindRanks();
        }

        public void ViewDataInGUI(RankCollection ranks)
        {
            rptRanks.Visible = true;
            spnEmptyRow.Visible = false;
            rptRanks.Controls.Clear();
            rptRanks.DataSource = ranks;
            rptRanks.DataBind();
        }

        public void ShowEmptyMessage()
        {
            rptRanks.Visible = false;
            spnEmptyRow.Visible = true;
        }
    }

}
