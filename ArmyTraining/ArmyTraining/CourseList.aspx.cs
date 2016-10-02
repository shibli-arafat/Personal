using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CourseList : System.Web.UI.Page, ICourseListView
    {
        CourseListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CourseListPresenter(this);
            _Presenter.OnViewLoaded();
            drpCourseTypes.SetTooltip();
        }

        CourseFilter CreateFilter()
        {
            CourseFilter result = new CourseFilter();
            result.PageNumber = 1;
            result.Count = 20;
            result.CourseTypeId = int.Parse(drpCourseTypes.SelectedValue);
            result.TrainingBkgId = int.Parse(drpTrainingBkg.SelectedValue);
            result.Keyword = txtKeyword.Text;
            return result;
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindItems(CreateFilter());
        }

        public void BindCourseTypes(CourseTypeCollection types)
        {
            CourseType all = new CourseType();
            all.Name = "All";
            all.Id = 0;
            types.Insert(0, all);
            drpCourseTypes.DataSource = types;
            drpCourseTypes.DataBind();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Course)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((Course)e.Item.DataItem).Id.ToString() + ")");

                HtmlGenericControl dvTypeName = e.Item.FindControl("dvCourseType") as HtmlGenericControl;
                dvTypeName.InnerText = ((Course)e.Item.DataItem).Level.Name;

                //HtmlGenericControl dvCountries = e.Item.FindControl("dvCountries") as HtmlGenericControl;
                //dvCountries.InnerText = ((Course)e.Item.DataItem).Countries.GetCommaSeperatedNames();
            }
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.Delete(int.Parse(e.CommandArgument.ToString()), CreateFilter());
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void DisplayListInGUI(CourseSearchResult courses, CourseFilter filter)
        {
            spnNoSearch.Visible = false;
            PopulatePager(courses, filter);
            pageHeader.Visible = true;
            rptCourses.Visible = true;
            spnEmptyRow.Visible = false;

            rptCourses.Controls.Clear();
            rptCourses.DataSource = courses.Courses;
            rptCourses.DataBind();
        }

        private void PopulatePager(CourseSearchResult data, CourseFilter filter)
        {
            int totalPages = (int)Math.Ceiling((float)data.TotalCount / filter.Count);
            drpPages.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                li.Selected = filter.PageNumber == i;
                drpPages.Items.Add(li);
            }
            lnkPrev.Enabled = true;
            lnkNext.Enabled = true;
            drpPages.Enabled = true;

            if (filter.PageNumber == 1)
            {
                lnkPrev.Enabled = false;
            }
            if (filter.PageNumber == totalPages)
            {
                lnkNext.Enabled = false;
            }
            if (totalPages == 1)
            {
                drpPages.Enabled = false;
            }
            int start = (filter.PageNumber - 1) * filter.Count + 1;
            int end = start + data.Courses.Count - 1;
            ltStart.Text = start.ToString();
            ltEnd.Text = end.ToString();
            ltTotal.Text = data.TotalCount.ToString();
        }

        public void ShowEmptyRow()
        {
            spnNoSearch.Visible = false;
            spnEmptyRow.Visible = true;
            rptCourses.Visible = false;
            pageHeader.Visible = false;
        }

        protected void Search(object sender, EventArgs e)
        {
            _Presenter.BindItems(CreateFilter());
        }

        protected void PrevClicked(object sender, EventArgs e)
        {
            CourseFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) - 1;
            _Presenter.BindItems(filter);
        }

        protected void NextClicked(object sender, EventArgs e)
        {
            CourseFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) + 1;
            _Presenter.BindItems(filter);
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
            CourseFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue);
            _Presenter.BindItems(filter);
        }


        public void BindTriningBkgs(TrainingBackgroundCollection backgrounds)
        {
            TrainingBackground all = new TrainingBackground();
            all.Name = "All";
            all.Id = 0;
            backgrounds.Insert(0, all);
            drpTrainingBkg.DataSource = backgrounds;
            drpTrainingBkg.DataBind();
        }
    }
}
