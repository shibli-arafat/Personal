using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Model.Filters;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class PersonList : System.Web.UI.Page, IPersonListView
    {
        PersonListPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new PersonListPresenter(this);
            _Presenter.OnViewLoaded();
        }
        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((Person)e.Item.DataItem).Id.ToString();

                ImageButton imgEdit = e.Item.FindControl("imgEdit") as ImageButton;
                imgEdit.Attributes.Add("onclick", "return OpenDetail(" + ((Person)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        PersonFilter CreateFilter()
        {
            PersonFilter filter = new PersonFilter();
            filter.PersonNumber = txtPersonNo.Text;
            filter.RankName = txtKeyword.Text;
            filter.PageNumber = 1;
            filter.Count = 20;
            return filter;
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            _Presenter.BindData(CreateFilter());
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.DeletePerson(int.Parse(e.CommandArgument.ToString()), CreateFilter());
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public void PopulateListInGUI(PersonSearchResult persons, PersonFilter filter)
        {
            spnNoSearch.Visible = false;
            PopulatePager(persons, filter);
            pageHeader.Visible = true;
            rptCourses.Visible = true;
            spnEmptyRow.Visible = false;

            rptCourses.Controls.Clear();
            rptCourses.DataSource = persons.Persons;
            rptCourses.DataBind();
        }

        private void PopulatePager(PersonSearchResult data, PersonFilter filter)
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
            int end = start + data.Persons.Count - 1;
            ltStart.Text = start.ToString();
            ltEnd.Text = end.ToString();
            ltTotal.Text = data.TotalCount.ToString();
        }


        public void ShowEmptyMessage()
        {
            spnNoSearch.Visible = false;
            spnEmptyRow.Visible = true;
            rptCourses.Visible = false;
            pageHeader.Visible = false;
        }

        protected void Search(object sender, EventArgs e)
        {
            _Presenter.BindData(CreateFilter());
        }

        protected void PrevClicked(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) - 1;
            _Presenter.BindData(filter);
        }

        protected void NextClicked(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) + 1;
            _Presenter.BindData(filter);
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
            PersonFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue);
            _Presenter.BindData(filter);
        }
    }
}
