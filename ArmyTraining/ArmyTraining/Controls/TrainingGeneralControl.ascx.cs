using System;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining.Controls
{
    public partial class TrainingGeneralControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        internal void Initialize(ArmyTraining.Model.Trainings.TrainingGeneral trainingGeneral)
        {
            BindCourseTypes();
            BindCoursesOnType(0);
            BindCountries(new CountryInternal().GetCountrys());
            BindTrainingLevels();

            txtEndDate.Text = trainingGeneral.EndDate.ToString("dd/MM/yyyy");
            txtPreRequisites.Text = trainingGeneral.Prerequisites;
            txtRemarks.Text = trainingGeneral.Remarks;
            txtStartDate.Text = trainingGeneral.StartDate.ToString("dd/MM/yyyy");

            droSponsorCountry.SelectedValue = trainingGeneral.SponsorCountryId.ToString();
            if (trainingGeneral.CourseId > 0)
            {
                int typeid = new CourseInternal().GetCourseById(trainingGeneral.CourseId).Level.Id;
                drpCourseType.SelectedValue = typeid.ToString();
                BindCoursesOnType(typeid);
                drpCourse.SelectedValue = trainingGeneral.CourseId.ToString();
                drpCountry.SelectedValue = trainingGeneral.CountryId.ToString();
                ddlTrainingLevel.SelectedValue = trainingGeneral.TrainingLevel.ToString();
            }
        }

        private void BindTrainingLevels()
        {
            ddlTrainingLevel.DataSource = Enum.GetValues(typeof(TrainingLevel));
            ddlTrainingLevel.DataBind();
            ddlTrainingLevel.SetTooltip();
        }

        internal ArmyTraining.Model.Trainings.TrainingGeneral GetInfo()
        {
            ArmyTraining.Model.Trainings.TrainingGeneral result = new ArmyTraining.Model.Trainings.TrainingGeneral();
            result.CountryId = int.Parse(drpCountry.SelectedValue);
            result.CourseId = int.Parse(drpCourse.SelectedValue);
            result.EndDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
            result.Prerequisites = txtPreRequisites.Text;
            result.Remarks = txtRemarks.Text;
            result.SponsorCountryId = int.Parse(droSponsorCountry.SelectedValue);
            result.StartDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
            result.TrainingLevel = (TrainingLevel)Enum.Parse(typeof(TrainingLevel), ddlTrainingLevel.SelectedValue);
            return result;
        }

        protected void CourseTypeChanged(object sender, EventArgs e)
        {
            BindCoursesOnType(int.Parse(drpCourseType.SelectedValue));
        }

        private void BindCoursesOnType(int typeId)
        {
            CourseFilter filter = new CourseFilter();
            filter.CourseTypeId = typeId;

            CourseCollection cources = new CourseCollection();
            if (typeId > 0) cources = new CourseInternal().GetCourses(filter).Courses;
            drpCourse.Items.Clear();
            drpCourse.Items.Add(new ListItem("Please select", "0"));
            cources.ForEach(x => drpCourse.Items.Add(new ListItem(x.Name, x.Id.ToString())));
        }

        private void BindCourseTypes()
        {
            CourseTypeCollection types = new CourseTypeInternal().GetCourseTypes();
            drpCourseType.Items.Clear();
            drpCourseType.Items.Add(new ListItem("Please select", "0"));
            types.ForEach(x => drpCourseType.Items.Add(new ListItem(x.Name, x.Id.ToString())));
        }

        private void BindCountries(CountryCollection countries)
        {
            droSponsorCountry.DataSource = countries;
            droSponsorCountry.DataValueField = "Id";
            droSponsorCountry.DataTextField = "Name";
            droSponsorCountry.DataBind();
            droSponsorCountry.Items.Insert(0, new ListItem("Please selct", "0"));

            drpCountry.DataSource = countries;
            drpCountry.DataValueField = "Id";
            drpCountry.DataTextField = "Name";
            drpCountry.DataBind();
            drpCountry.Items.Insert(0, new ListItem("Please select", "0"));
        }
    }
}