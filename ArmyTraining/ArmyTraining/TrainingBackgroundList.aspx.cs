using System;
using System.Web.UI.WebControls;
using ArmyTraining.Model;
using ArmyTraining.Presenter;

namespace ArmyTraining
{
    public partial class TrainingBackgroundList : System.Web.UI.Page
    {
        private TrainingBackgroundListPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new TrainingBackgroundListPresenter();
            if (!IsPostBack)
            {
                PopulateTrainingBackgrounds();
            }
        }

        private void PopulateTrainingBackgrounds()
        {
            TrainingBackgroundCollection trainingBackgs = _Presenter.GetTrainingBackgrounds();
            if (trainingBackgs.Count == 0)
            {
                rptCommissions.Visible = false;
                spnEmptyRow.Visible = true;
            }
            else
            {
                rptCommissions.Visible = true;
                spnEmptyRow.Visible = false;
                rptCommissions.Controls.Clear();
                rptCommissions.DataSource = trainingBackgs;
                rptCommissions.DataBind();
            }
        }

        protected void ItemEdited(object sender, EventArgs e)
        {
            PopulateTrainingBackgrounds();
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton deleteButton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                deleteButton.CommandArgument = ((TrainingBackground)e.Item.DataItem).Id.ToString();

                ImageButton editButton = e.Item.FindControl("imgBtnEdit") as ImageButton;
                editButton.Attributes.Add("onclick", "return OpenDetail(" + ((TrainingBackground)e.Item.DataItem).Id.ToString() + ")");
            }
        }

        protected void DeleteCommand(object sender, CommandEventArgs e)
        {
            _Presenter.DeleteTrainingBackground(int.Parse(e.CommandArgument.ToString()));
            PopulateTrainingBackgrounds();
        }
    }
}
