using System;
using System.Web.UI;
using ArmyTraining.Model;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class CourseTypeDetail : System.Web.UI.Page, ICourseTypeDetail
    {
        private CourseTypeDetailPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new CourseTypeDetailPresenter(this);
            _Presenter.OnPageLoad();
            if (!IsPostBack)
            {
                if (CourseTypeId > 0)
                {
                    header.Text = "Edit course type (" + CourseTypeId + ").";
                }
                else
                {
                    header.Text = "Add course type.";
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

        public CourseType PopulateCourseTypeFromGUI()
        {
            CourseType result = new CourseType();
            result.Name = txtName.Value;
            return result;
        }

        public int CourseTypeId
        {
            get { return int.Parse(Request[Constants.CourseTypeDetail_Request_Id]); }
        }

        public void PopulateGUIFromCourseType(CourseType courseType)
        {
            txtName.Value = courseType.Name;
        }
    }
}
