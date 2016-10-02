using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CountryList : System.Web.UI.Page, ICountryListView
    {
        CountryListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CountryListPresenter(this);
            _Presenter.OnViewLoaded();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Country)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((Country)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindCountrys();
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.Delete(int.Parse(e.CommandArgument.ToString()));
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void ViewDataInGUI(CountryCollection ranks)
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
