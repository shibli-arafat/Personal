using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CourseDetail : System.Web.UI.Page, ICourseDetailView
    {
        private CourseDetailPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CourseDetailPresenter(this);
            _Presenter.OnViewLoaded();
            if (!IsPostBack)
            {
                if (CourseId > 0)
                {
                    header.Text = "Edit course (" + CourseId + ").";
                }
                else
                {
                    header.Text = "Add course.";
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

        public int CourseId
        {
            get { return int.Parse(Request[Constants.CourseDetail_Request_Id]); }
        }

        public Course PopulateCourseFromGui()
        {
            Course course = new Course();
            course.Name = txtName.Text;
            course.Description = txtDescription.Text;
            course.Level = new CourseType();
            course.Level.Id = int.Parse(drpCourseTypes.SelectedValue);
            course.TrainingBkg.Id = int.Parse(drpTrainingBkg.SelectedValue);
            return course;
        }

        public void PopulateGuiFromCourse(Course course)
        {
            txtName.Text = course.Name;
            txtDescription.Text = course.Description;
            drpCourseTypes.SetSelectedItem(course.Level.Id);
            drpCourseTypes.SetTooltip();
            drpTrainingBkg.SetSelectedItem(course.TrainingBkg.Id);
            drpTrainingBkg.SetTooltip();
        }

        public void BindCourseTypes(CourseTypeCollection types)
        {
            drpCourseTypes.Items.Clear();
            drpCourseTypes.DataSource = types;
            drpCourseTypes.DataValueField = "Id";
            drpCourseTypes.DataTextField = "Name";
            drpCourseTypes.DataBind();
            drpCourseTypes.Items.Insert(0, new ListItem("Please select", "0"));
            drpCourseTypes.SetTooltip();
        }

        public void BindTrainingBackgrounds(TrainingBackgroundCollection trBackgrounds)
        {
            TrainingBackground emptyTrBkg = new TrainingBackground();
            emptyTrBkg.Name = "Please select";
            trBackgrounds.Insert(0, emptyTrBkg);
            drpTrainingBkg.DataSource = trBackgrounds;
            drpTrainingBkg.DataValueField = "Id";
            drpTrainingBkg.DataTextField = "Name";
            drpTrainingBkg.DataBind();
            drpTrainingBkg.SetTooltip();
        }
    }
}
