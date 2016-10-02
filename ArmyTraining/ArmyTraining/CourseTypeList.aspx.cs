using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CourseTypeList : System.Web.UI.Page, ICourseTypeListView
    {
        CourseTypeListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CourseTypeListPresenter(this);
            _Presenter.OnViewLoaded();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                ImageButton editBtn = e.Item.FindControl("imgBtnEdit") as ImageButton;
                deleteButton.CommandArgument = ((CourseType)e.Item.DataItem).Id.ToString();
                editBtn.Attributes.Add("onclick", "return OpenDetail(" + ((CourseType)e.Item.DataItem).Id + ")");

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

        public void ViewDataInGUI(CourseTypeCollection ranks)
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

        public void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindCourseTypes();
        }
    }
}
