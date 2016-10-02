using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class ArmServiceList : System.Web.UI.Page, IServiceListView
    {
        ServiceListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new ServiceListPresenter(this);
            _Presenter.OnViewLoaded();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Service)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((Service)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindServices();
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.Delete(int.Parse(e.CommandArgument.ToString()));
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void ViewDataInGUI(ServiceCollection ranks)
        {
            rptCommissions.Visible = true;
            spnEmptyRow.Visible = false;
            rptCommissions.Controls.Clear();
            rptCommissions.DataSource = ranks;
            rptCommissions.DataBind();
        }

        public void ShowEmptyMessage()
        {
            rptCommissions.Visible = false;
            spnEmptyRow.Visible = true;
        }
    }
}
