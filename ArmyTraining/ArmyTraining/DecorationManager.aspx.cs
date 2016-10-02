using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;

namespace ArmyTraining
{
    public partial class DecorationManager : System.Web.UI.Page
    {
        private CommissionListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CommissionListPresenter();
            if (!IsPostBack)
            {
                PopulateCommissions();
            }
        }

        private void PopulateCommissions()
        {
            DecorationCollection commissions = _Presenter.GetCommissions();
            if (commissions.Count == 0)
            {
                rptCommissions.Visible = false;
                spnEmptyRow.Visible = true;
            }
            else
            {
                rptCommissions.Visible = true;
                spnEmptyRow.Visible = false;
                rptCommissions.Controls.Clear();
                rptCommissions.DataSource = commissions;
                rptCommissions.DataBind();
            }
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            PopulateCommissions();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Decoration)e.Item.DataItem).Id.ToString();

                ImageButton editButton = e.Item.FindControl("imgBtnEdit") as ImageButton;
                editButton.Attributes.Add("onclick", "return OpenDetail(" + ((Decoration)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.DeleteCommission(int.Parse(e.CommandArgument.ToString()));
            PopulateCommissions();
        }

    }
}
